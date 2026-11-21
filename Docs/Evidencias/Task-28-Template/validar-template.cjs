/* Tests the production HTML/CSS with only Unity initialization mocked.
 * Usage: node validar-template.cjs <repo> <temporary-directory> <evidence-directory>
 * Requires existing Playwright, resolvable normally or through TASK28_PLAYWRIGHT.
 * TASK28_CHROME may override the installed Google Chrome executable path.
 */
'use strict';
const fs = require('node:fs/promises');
const path = require('node:path');
const os = require('node:os');
const http = require('node:http');
const crypto = require('node:crypto');
const assert = require('node:assert/strict');
const { chromium } = require(process.env.TASK28_PLAYWRIGHT || 'playwright');
const playwrightVersion = require(path.join(
  path.dirname(require.resolve(process.env.TASK28_PLAYWRIGHT || 'playwright')),
  'package.json')).version;
const [repo, temporaryDirectory, evidenceDirectory] = process.argv.slice(2).map(p => path.resolve(p));
if (!repo || !temporaryDirectory || !evidenceDirectory) throw new Error('Three directory arguments required.');
const chrome = process.env.TASK28_CHROME || 'C:/Program Files/Google/Chrome/Application/chrome.exe';
const sourcePath = path.join(repo, 'Assets/WebGLTemplates/CacaAsCores/index.html');
const hash = data => crypto.createHash('sha256').update(data).digest('hex');
const checks = [];
function check(name, condition) { checks.push({ name, result: condition ? 'PASS' : 'FAIL' }); }
const values = {
  PRODUCT_NAME: 'Caça às Cores', BACKGROUND_COLOR: '#231f20', WIDTH: '960', HEIGHT: '600',
  DATA_FILENAME: 'Test.data', FRAMEWORK_FILENAME: 'Test.framework.js',
  CODE_FILENAME: 'Test.wasm', LOADER_FILENAME: 'Test.loader.js', SYMBOLS_FILENAME: 'Test.symbols.json',
  'JSON.stringify(COMPANY_NAME)': JSON.stringify('CIATec'),
  'JSON.stringify(PRODUCT_NAME)': JSON.stringify('Caça às Cores'),
  'JSON.stringify(PRODUCT_VERSION)': JSON.stringify('0.1.0')
};
// No canvas operations, resize handlers, rendering, or Unity implementation.
const mock = `window.createUnityInstance = function(canvas, config) {
  window.__unityMockCalls = (window.__unityMockCalls || 0) + 1;
  window.__unityMock = { calls: window.__unityMockCalls, canvasId: canvas.id,
    canvasAttributes: [canvas.getAttribute('width'), canvas.getAttribute('height')],
    config: Object.assign({}, config), state: 'pending' };
  return new Promise(function(resolve, reject) {
    window.__unityMock.succeed = function() { window.__unityMock.state = 'resolved'; resolve({}); };
    window.__unityMock.fail = function() { window.__unityMock.state = 'rejected';
      reject(new Error('Falha simulada task28: inicializacao indisponivel')); };
  });
};\n`;
function processTemplate(source, symbols) {
  return source.replace(/^#if SYMBOLS_FILENAME\r?\n([\s\S]*?)^#endif\r?\n/gm,
    (_, block) => symbols ? block : '').replace(/\{\{\{\s*(.*?)\s*\}\}\}/g, (_, key) => {
      if (!Object.hasOwn(values, key)) throw new Error('Unexpected macro: ' + key);
      return values[key];
    });
}
async function measure(page, label, viewport, screenshot) {
  const result = await page.evaluate(async () => {
    const snapshot = () => {
      const c = document.getElementById('unity-canvas');
      const r = c.getBoundingClientRect();
      const root = document.documentElement;
      const body = document.body;
      const dimensions = e => ({ clientWidth: e.clientWidth, clientHeight: e.clientHeight,
        scrollWidth: e.scrollWidth, scrollHeight: e.scrollHeight,
        offsetWidth: e.offsetWidth, offsetHeight: e.offsetHeight,
        rect: e.getBoundingClientRect().toJSON() });
      const css = getComputedStyle(c);
      return { innerWidth, innerHeight, canvas: { x: r.x, y: r.y, width: r.width,
        height: r.height, right: r.right, bottom: r.bottom },
        canvasCSS: { width: css.width, height: css.height, display: css.display },
        canvasBuffer: [c.width, c.height], root: dimensions(root), body: dimensions(body),
        browserDPR: devicePixelRatio,
        rootOverflow: getComputedStyle(root).overflow,
        bodyOverflow: getComputedStyle(body).overflow };
    };
    let last = JSON.stringify(snapshot());
    let stableFrames = 0;
    let frames = 0;
    while (stableFrames < 3 && frames < 120) {
      await new Promise(requestAnimationFrame);
      const current = JSON.stringify(snapshot());
      stableFrames = current === last ? stableFrames + 1 : 0;
      last = current;
      frames++;
    }
    return { ...snapshot(), stable: stableFrames >= 3, frames,
      documentToken: window.__templateTestDocument,
      jsProbe: window.__templateTestJSProbe = (window.__templateTestJSProbe || 0) + 1,
      timeOrigin: performance.timeOrigin,
      navigationEntries: performance.getEntriesByType('navigation').length,
      mockCalls: window.__unityMock?.calls,
      loading: { hidden: document.getElementById('unity-status').hidden,
        text: document.getElementById('unity-status').textContent,
        role: document.getElementById('unity-status').getAttribute('role') } };
  });
  const near = (a, b) => Math.abs(a - b) <= 1;
  const c = result.canvas;
  const fits = result.stable && result.innerWidth === viewport.width && result.innerHeight === viewport.height &&
    near(c.x, 0) && near(c.y, 0) && near(c.width, viewport.width) && near(c.height, viewport.height) &&
    near(c.right, viewport.width) && near(c.bottom, viewport.height);
  const noExcess = [result.root, result.body].every(e =>
    e.scrollWidth <= viewport.width + 1 && e.scrollHeight <= viewport.height + 1 &&
    near(e.rect.x, 0) && near(e.rect.y, 0) && near(e.rect.width, viewport.width) && near(e.rect.height, viewport.height));
  const noScrollbarSpace = near(result.root.clientWidth, result.innerWidth) && near(result.root.clientHeight, result.innerHeight);
  check(label + ': canvas covers viewport (tolerance 1 CSS px)', fits);
  check(label + ': no measured excess or scrollbar space', noExcess && noScrollbarSpace);
  if (screenshot) await page.screenshot({ path: path.join(evidenceDirectory, screenshot), fullPage: true });
  return { label, requestedViewport: viewport, ...result, noExcess, noScrollbarSpace,
    result: fits && noExcess && noScrollbarSpace ? 'PASS' : 'FAIL', screenshot };
}
async function main() {
  await fs.mkdir(temporaryDirectory, { recursive: true });
  await fs.mkdir(evidenceDirectory, { recursive: true });
  const source = await fs.readFile(sourcePath);
  const text = source.toString('utf8');
  const processed = processTemplate(text, false);
  const symbolsProcessed = processTemplate(text, true);
  assert(!processed.includes('{{{') && !/^#(?:if|endif)/m.test(processed));
  const originalStyle = text.match(/<style>([\s\S]*?)<\/style>/)[1];
  assert.equal(processed.match(/<style>([\s\S]*?)<\/style>/)[1],
    originalStyle.replace('{{{ BACKGROUND_COLOR }}}', values.BACKGROUND_COLOR));
  assert.equal(symbolsProcessed.match(/<style>([\s\S]*?)<\/style>/)[1],
    processed.match(/<style>([\s\S]*?)<\/style>/)[1]);
  check('Fixture: original CSS preserved except background macro', true);
  await fs.writeFile(path.join(temporaryDirectory, 'index.html'), processed);
  await fs.writeFile(path.join(temporaryDirectory, 'symbols.html'), symbolsProcessed);
  await fs.writeFile(path.join(temporaryDirectory, 'mock.loader.js'), mock);
  const requests = [];
  const server = http.createServer((request, response) => {
    const url = new URL(request.url, 'http://localhost');
    let code = 200, content = '', type = 'text/html; charset=utf-8';
    if (url.pathname.endsWith('/index.html')) content = url.pathname.startsWith('/symbols/') ? symbolsProcessed : processed;
    else if (url.pathname.endsWith('/Build/Test.loader.js') && !url.pathname.startsWith('/loader-missing/')) {
      content = mock; type = 'application/javascript; charset=utf-8';
    } else if (url.pathname === '/favicon.ico') code = 204;
    else { code = 404; content = 'Not found (intentional for loader-missing scenario)'; }
    requests.push({ path: url.pathname, status: code });
    response.writeHead(code, { 'Content-Type': type, 'Cache-Control': 'no-store' });
    response.end(content);
  });
  await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
  const origin = 'http://127.0.0.1:' + server.address().port;
  const records = [], pages = [];
  let browser;
  const results = { startedAtUTC: new Date().toISOString(), platform: os.platform(), osRelease: os.release(),
    nodeVersion: process.version, playwrightVersion, chromeExecutable: chrome, headless: true,
    sourceSHA256: hash(source), fixtureSHA256: hash(processed), symbolsFixtureSHA256: hash(symbolsProcessed),
    mockSHA256: hash(mock), macroValues: values, temporaryDirectory, origin,
    toleranceCSSPixels: 1, checks, measurements: records, pages, requests };
  try {
    browser = await chromium.launch({ executablePath: chrome, headless: true });
    results.browserVersion = browser.version();
    async function open(scenario, viewport, dpr = 1) {
      const context = await browser.newContext({ viewport, deviceScaleFactor: dpr, isMobile: false, hasTouch: false });
      await context.addInitScript(() => { window.__templateTestDocument = crypto.randomUUID(); });
      const page = await context.newPage();
      const log = { scenario, dpr, pageErrors: [], console: [], requestFailures: [], documentNavigations: [] };
      pages.push(log);
      page.on('pageerror', e => log.pageErrors.push(String(e)));
      page.on('console', m => log.console.push({ type: m.type(), text: m.text() }));
      page.on('requestfailed', r => log.requestFailures.push({ url: r.url(), error: r.failure() }));
      page.on('framenavigated', f => { if (f === page.mainFrame()) log.documentNavigations.push(f.url()); });
      await page.goto(origin + '/' + scenario + '/index.html', { waitUntil: 'load' });
      if (scenario !== 'loader-missing') await page.waitForFunction(() => !!window.__unityMock);
      return { context, page, log };
    }
    const session = await open('success', { width: 1280, height: 720 });
    const { page } = session;
    const pending = await measure(page, 'loader-pending', { width: 1280, height: 720 }, 'loader-carregando.png');
    records.push(pending);
    check('Loader: loading status visible and role=status before resolution',
      pending.loading.hidden === false && pending.loading.text === 'Carregando…' && pending.loading.role === 'status');
    const captured = await page.evaluate(() => ({ config: window.__unityMock.config,
      canvasId: window.__unityMock.canvasId, canvasAttributes: window.__unityMock.canvasAttributes }));
    results.loaderCaptured = captured;
    const expectedConfig = { dataUrl: 'Build/Test.data', frameworkUrl: 'Build/Test.framework.js',
      codeUrl: 'Build/Test.wasm', streamingAssetsUrl: 'StreamingAssets', companyName: 'CIATec',
      productName: 'Caça às Cores', productVersion: '0.1.0', matchWebGLToCanvasSize: true, devicePixelRatio: 1 };
    check('Loader: entire config passed correctly', JSON.stringify(captured.config) === JSON.stringify(expectedConfig));
    check('Loader: actual canvas passed with initial HTML dimensions 960x600',
      captured.canvasId === 'unity-canvas' && JSON.stringify(captured.canvasAttributes) === '["960","600"]');
    await page.evaluate(() => window.__unityMock.succeed());
    await page.waitForFunction(() => document.getElementById('unity-status').hidden);
    for (const [width, height] of [[390, 844], [844, 390], [1280, 720], [1920, 1080]]) {
      await page.setViewportSize({ width, height });
      records.push(await measure(page, 'fixed-' + width + 'x' + height, { width, height }, 'viewport-' + width + 'x' + height + '.png'));
    }
    const dynamic = [];
    for (const [width, height] of [[1280, 720], [390, 844], [844, 390], [1920, 1080], [390, 844]]) {
      await page.setViewportSize({ width, height });
      const entry = await measure(page, 'dynamic-' + (dynamic.length + 1), { width, height });
      dynamic.push(entry); records.push(entry);
    }
    check('Dynamic: same document and timeOrigin, one navigation, no reload',
      dynamic.every(m => m.documentToken === pending.documentToken && m.timeOrigin === pending.timeOrigin && m.navigationEntries === 1) &&
      session.log.documentNavigations.length === 1);
    check('Dynamic: JavaScript probe advances; one mock initialization; loading stays hidden',
      dynamic.every((m, i) => m.mockCalls === 1 && m.loading.hidden && (i === 0 || m.jsProbe > dynamic[i - 1].jsProbe)));
    check('Mock does not resize internal buffer: remains 960x600 throughout all CSS resizes',
      records.every(m => JSON.stringify(m.canvasBuffer) === '[960,600]'));
    const failure = await open('failure', { width: 390, height: 844 });
    await failure.page.evaluate(() => window.__unityMock.fail());
    await failure.page.waitForFunction(() => document.getElementById('unity-status').getAttribute('role') === 'alert');
    const rejected = await measure(failure.page, 'loader-rejected', { width: 390, height: 844 }, 'loader-falha-inicializacao.png');
    records.push(rejected);
    check('Loader rejection: visible Portuguese error and role=alert', !rejected.loading.hidden &&
      rejected.loading.role === 'alert' && rejected.loading.text === 'Não foi possível iniciar o jogo. Recarregue a página.');
    check('Loader rejection: expected error logged', failure.log.console.some(m => m.type === 'error' && m.text.includes('Falha simulada task28')));
    const missing = await open('loader-missing', { width: 390, height: 844 });
    await missing.page.waitForFunction(() => document.getElementById('unity-status').getAttribute('role') === 'alert');
    records.push(await measure(missing.page, 'loader-network-failure', { width: 390, height: 844 }, 'loader-falha-rede.png'));
    check('Loader script HTTP 404: original onerror displays alert',
      await missing.page.evaluate(() => !document.getElementById('unity-status').hidden && !window.__unityMock));
    check('Loader script HTTP 404: expected diagnostic logged', missing.log.console.some(m =>
      m.type === 'error' && m.text.includes('Falha ao carregar o loader da build WebGL.')));
    const symbols = await open('symbols', { width: 844, height: 390 });
    results.symbolsConfig = await symbols.page.evaluate(() => window.__unityMock.config);
    check('Optional symbols branch: symbolsUrl passed correctly', results.symbolsConfig.symbolsUrl === 'Build/Test.symbols.json');
    await symbols.page.evaluate(() => window.__unityMock.succeed());
    await symbols.page.waitForFunction(() => document.getElementById('unity-status').hidden);
    const highDPR = await open('high-dpr', { width: 390, height: 844 }, 2);
    results.highDPRConfig = await highDPR.page.evaluate(() => window.__unityMock.config);
    await highDPR.page.evaluate(() => window.__unityMock.succeed());
    await highDPR.page.waitForFunction(() => document.getElementById('unity-status').hidden);
    const dprMeasurement = await measure(highDPR.page, 'browser-dpr-2', { width: 390, height: 844 });
    records.push(dprMeasurement);
    check('Browser DPR 2: config remains DPR 1 and CSS covers viewport',
      dprMeasurement.browserDPR === 2 && results.highDPRConfig.devicePixelRatio === 1 && dprMeasurement.result === 'PASS');
    check('All scenarios: zero unhandled JavaScript exceptions', pages.every(p => p.pageErrors.length === 0));
    check('Success, symbols and DPR scenarios: zero console errors/warnings or failed requests',
      [session, symbols, highDPR].every(s => s.log.requestFailures.length === 0 &&
        !s.log.console.some(m => ['error', 'warning'].includes(m.type))));
    check('No Unity artifacts requested: mock only replaces initialization',
      !requests.some(r => /\.(wasm|data|framework\.js|symbols\.json)$/.test(r.path)));
    check('Production template byte-for-byte unchanged', hash(await fs.readFile(sourcePath)) === results.sourceSHA256);
  } finally {
    if (browser) await browser.close();
    await new Promise(resolve => server.close(resolve));
    results.finishedAtUTC = new Date().toISOString();
    results.summary = { pass: checks.filter(c => c.result === 'PASS').length,
      fail: checks.filter(c => c.result === 'FAIL').length, measurements: records.length };
    await fs.writeFile(path.join(evidenceDirectory, 'resultados.json'), JSON.stringify(results, null, 2) + '\n');
    console.log(JSON.stringify({ browserVersion: results.browserVersion, summary: results.summary,
      failedChecks: checks.filter(c => c.result === 'FAIL'), evidenceDirectory }, null, 2));
    if (results.summary.fail) process.exitCode = 1;
  }
}
main().catch(error => { console.error(error); process.exitCode = 1; });
