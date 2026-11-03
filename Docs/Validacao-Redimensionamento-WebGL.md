# Validação de redimensionamento WebGL — task #28

## Resultados técnicos

### Identificação e situação da validação

| Campo | Registro |
| --- | --- |
| Task | #28 — validação de redimensionamento WebGL; story relacionada: #7 |
| Data da análise e dos testes registrados | 02/11/2026, fuso America/Sao_Paulo |
| Execução automatizada no Chrome | 18:55:28–18:55:47; horários UTC preservados no JSON |
| Base analisada | `60067b2e69fde1f01423b862f728c2fa3bb27b7f` |
| Branch de trabalho | `codex/task-28-webgl-resize` |
| Resultado do template isolado | **43 verificações PASS, 0 FAIL; 13 medições; 7 capturas** |
| Situação da build Unity | **NÃO EXECUTADA** neste ambiente |
| Situação da task #28 | Pendente de validação com a build real da Unity |

### Objetivo e referências

Abrir a build WebGL atual e observar o preenchimento da área de conteúdo do
navegador em retrato, paisagem, desktop e durante mudanças sucessivas de tamanho,
sem recarregar a página. Registrar medidas, aparência e mensagens efetivamente
observadas, conforme a [task #28](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/28)
e a [story #7](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/7).

Foram consultados integralmente o `AGENTS.md` local e o guia
[Build-WebGL.md](Build-WebGL.md), além das seções relevantes:

- SGDD v2: 1.2, 7.1–7.4, 11 e 23.5, incluindo RT-118, RT-119 e RT-120.
- ABD v1: 4.2.3 (US-01.3 / T-01.3.3), 4.7.1 (US-06.1) e 4.7.2 (US-06.2).
- [PR #61](https://github.com/ciatec-org/ciatec-game-caca-as-cores/pull/61),
  cuja integração à `develop` foi confirmada no Git local e no GitHub.

Os requisitos planejados não são tratados como funcionalidades já disponíveis.
Este registro não valida o jogo como instrumento clínico.

### Preparação do repositório

- Estado inicial: `develop`, árvore de trabalho limpa, sem alterações locais
  rastreadas ou arquivos não rastreados apresentados pelo `git status`.
- `AGENTS.md` local já ignorado por `.git/info/exclude`; preservado fora da entrega.
- Executados `git fetch origin` e `git pull --ff-only origin develop`.
  O pull informou `Already up to date.`; divergência `develop...origin/develop`: `0 0`.
- Base analisada: `60067b2e69fde1f01423b862f728c2fa3bb27b7f`,
  `Merge pull request #61 from ciatec-org/codex/task-27-webgl-build`.
- Branch criada: `codex/task-28-webgl-resize`, a partir dessa base.
- Até a revisão de estrutura do relatório, não haviam sido realizados commits,
  pushes, merges ou abertura de PR nesta task.
- Na continuação, o único trabalho local existente era este documento não
  rastreado. A branch foi mantida e a análise anterior foi preservada e ampliada.

### Ambiente e ferramentas

| Item | Constatação |
| --- | --- |
| Sistema | Computador Windows; comandos locais via PowerShell |
| Editor exigido pelo projeto | `6000.5.7f1 (017862109af0)`, em `ProjectSettings/ProjectVersion.txt` |
| Unity instalada | Não localizada nos caminhos e registros consultados abaixo; não executada |
| WebGL Build Support | Não localizado; sem Editor disponível para confirmar o módulo e gerar a build |
| Google Chrome | Executável presente em `C:\Program Files\Google\Chrome\Application\chrome.exe`; versão de arquivo `156.0.8078.74` |
| Microsoft Edge | Executável presente em `C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe`; versão de arquivo `156.0.4314.58` |
| Inspeção / automação | Playwright 1.62.1 existente no runtime; Chrome headless executado com sucesso na etapa de template isolado |
| Build local | Nenhuma build WebGL executável localizada na busca descrita abaixo |
| Execução WebGL / GPU | Runtime Unity não executado; os testes de página descritos abaixo não criam um contexto WebGL |

Foram consultados `C:\Program Files\Unity`, `C:\Program Files\Unity Hub`,
`C:\Program Files (x86)\Unity`, `C:\Program Files (x86)\Unity Hub`,
`C:\Unity`, `C:\UnityHub`, as pastas de Unity Hub em
`%LOCALAPPDATA%` e `%APPDATA%`,
o PATH e registros de instalação/desinstalação usuais de Unity no Windows.
Nenhuma instalação foi identificada nessas consultas. A busca não certifica
ausência de uma instalação portátil em qualquer outro diretório do computador.

Na raiz do projeto, `Builds`, `Build`, `Library` e `Logs` não foram localizados.
A busca de arquivos incluiu arquivos ignorados e ocultos: no repositório não
apareceram `.loader.js`, `.wasm` ou `.data`; o único `index.html` encontrado foi
o template-fonte. A busca complementar por `.loader.js`, `.wasm` e `Unity.exe`
no diretório pai do repositório, em Downloads e em Documents também não retornou candidatos.

Não existe, portanto, uma build identificada cuja correspondência com o código
atual possa ser conferida. O template-fonte contém macros e diretivas de
pré-processamento da Unity; abri-lo isoladamente não executa o jogo. Os relatos
históricos e o log mencionados no PR #61 e em `Build-WebGL.md` não constituem
execução da task #28 neste computador; esse log não está disponível localmente.

Nenhum programa foi instalado e nenhuma configuração global foi alterada.

### Testes reais no Chrome com loader simulado

#### Metodologia

O [resultado bruto](Evidencias/Task-28-Template/resultados.json) identifica
Windows `10.0.26200`, Node.js `v24.22.1`, Playwright **1.62.1** e Google Chrome
**156.0.8078.74**. Foi utilizado o Chrome instalado, em modo headless, sem
download de Chromium ou instalação de dependências.

O [script reproduzível](Evidencias/Task-28-Template/validar-template.cjs) leu o
template de produção e gerou cópias temporárias fora dos assets e do repositório,
em um diretório temporário local, identificado no JSON pelo marcador
`<diretorio-temporario-local>` após anonimização para publicação.
O servidor HTTP foi limitado a `127.0.0.1`, com porta atribuída pelo sistema:
`http://127.0.0.1:50404`. Servidor e navegador foram encerrados ao término.

As alterações da cópia foram exclusivamente substituições das macros e avaliação
do bloco `#if SYMBOLS_FILENAME`. Usaram-se dimensões iniciais `960 × 600`, empresa
`CIATec`, produto `Caça às Cores`, versão `0.1.0` e nomes fictícios `Test.*` para
os arquivos de build. O fundo `#231f20` é um valor de fixture para a macro
`BACKGROUND_COLOR`, sem pretensão de certificar a cor de uma build real.
Todos os valores e hashes estão no JSON. O CSS foi comparado ao original,
permitindo apenas essa substituição da cor; o JavaScript de produção permaneceu
com sua lógica original, processado somente pelas macros/diretivas.

O servidor entregou um loader mínimo que define `createUnityInstance` e captura
canvas, atributos e configuração recebidos. Sua Promise fica pendente até o teste
resolvê-la ou rejeitá-la. O mock **não** altera dimensões, desenha conteúdo, cria
contexto WebGL, adiciona listeners de resize ou implementa comportamento da Unity.
Não houve solicitações de `.data`, `.wasm`, framework ou símbolos reais.

O Playwright controlou a **viewport de conteúdo**, sem emular aparelho móvel,
e mediu `innerWidth/innerHeight`, retângulo e posição do canvas, dimensões
client/scroll/offset e retângulos de `html` e `body`, buffer, DPR e estado da
mensagem. Antes de cada leitura, exigiu três frames consecutivos com medidas
estáveis. A tolerância foi de **1 pixel CSS**; o desvio observado do canvas foi
**zero** em todas as medições. Exceções não tratadas, mensagens de console,
requisições malsucedidas e navegações do documento foram coletadas por eventos
do navegador. `overflow: hidden` não foi usado como critério suficiente:
compararam-se limites do canvas e da página, scroll/client e capturas.

#### Resoluções medidas após o sucesso simulado

Dimensões em pixels CSS. `Página client/scroll` contém os valores medidos em
**ambos** `html` e `body`, iguais em cada linha. DPR do navegador: 1.

| Viewport solicitada | innerWidth × innerHeight | Canvas medido | X, Y | Página client/scroll | Excesso / espaço de scrollbar | Resultado / captura |
| --- | --- | --- | --- | --- | --- | --- |
| 390 × 844 | 390 × 844 | 390 × 844 | 0, 0 | 390 × 844 | Nenhum | [PASS](Evidencias/Task-28-Template/viewport-390x844.png) |
| 844 × 390 | 844 × 390 | 844 × 390 | 0, 0 | 844 × 390 | Nenhum | [PASS](Evidencias/Task-28-Template/viewport-844x390.png) |
| 1280 × 720 | 1280 × 720 | 1280 × 720 | 0, 0 | 1280 × 720 | Nenhum | [PASS](Evidencias/Task-28-Template/viewport-1280x720.png) |
| 1920 × 1080 | 1920 × 1080 | 1920 × 1080 | 0, 0 | 1920 × 1080 | Nenhum | [PASS](Evidencias/Task-28-Template/viewport-1920x1080.png) |

Nenhuma exceção JavaScript, mensagem de erro/aviso ou requisição malsucedida foi
observada nesse cenário. As capturas mostram somente o fundo do canvas com o
status oculto após a resolução da Promise; **não são imagens do jogo Unity**.

#### Redimensionamento dinâmico sem recarga

Foi mantida a mesma página do cenário de sucesso, já inicializada uma vez pelo
mock. Executou-se exatamente a sequência solicitada:

| Etapa | Viewport e canvas medidos | X, Y | Scroll de html/body | Sonda JS acumulada | Resultado |
| --- | --- | --- | --- | --- | --- |
| 1 | 1280 × 720 | 0, 0 | 1280 × 720 | 6 | PASS |
| 2 | 390 × 844 | 0, 0 | 390 × 844 | 7 | PASS |
| 3 | 844 × 390 | 0, 0 | 844 × 390 | 8 | PASS |
| 4 | 1920 × 1080 | 0, 0 | 1920 × 1080 | 9 | PASS |
| 5 | 390 × 844 | 0, 0 | 390 × 844 | 10 | PASS |

O identificador criado pelo teste para o documento e `performance.timeOrigin`
permaneceram iguais. Houve **uma única navegação**, uma chamada de inicialização
ao mock e nenhum reload. O contador da sonda JavaScript avançou em cada medição;
o status continuou oculto. Não surgiram margens, excesso medido, erros ou avisos.
Essa sonda demonstra execução de JavaScript na página, não atividade da engine.

#### Carregamento simulado e medições complementares

| Verificação executada | Observação real no navegador | Resultado |
| --- | --- | --- |
| Configuração entregue a `createUnityInstance` | Objeto completo correspondeu ao esperado: URLs `Build/Test.data`, `Build/Test.framework.js`, `Build/Test.wasm`, `StreamingAssets`, empresa/produto/versão, `matchWebGLToCanvasSize: true` e `devicePixelRatio: 1` | PASS |
| Canvas recebido | `unity-canvas`, atributos iniciais `width="960"`, `height="600"`; dimensões não são campos adicionais de `config` | PASS |
| Promise pendente | Texto `Carregando…` visível, `hidden: false`, `role="status"` | PASS |
| Promise resolvida | O JavaScript original ocultou o status; canvas continuou cobrindo a viewport | PASS |
| Promise rejeitada | Mensagem `Não foi possível iniciar o jogo. Recarregue a página.` visível, `role="alert"`; erro simulado registrado em `console.error`, sem exceção não tratada | PASS |
| Loader indisponível por HTTP 404 | O `loader.onerror` original exibiu o alerta e registrou `Falha ao carregar o loader da build WebGL.` | PASS |
| Símbolos opcionais | Segunda cópia processada com o bloco condicional habilitado entregou `symbolsUrl: "Build/Test.symbols.json"`; sucesso ocultou o status | PASS |
| DPR do navegador igual a 2 | Na viewport 390 × 844, canvas CSS 390 × 844, configuração recebida ainda com DPR 1 | PASS |

As quatro medições abaixo complementam as quatro resoluções e as cinco etapas
dinâmicas, totalizando **13 medições**. Em todas, canvas em `(0, 0)` e dimensões
client/scroll de `html` e `body` iguais à viewport, sem excesso medido.

| Registro no JSON | Viewport e canvas CSS | DPR do navegador | Resultado |
| --- | --- | --- | --- |
| `loader-pending` | 1280 × 720 | 1 | PASS |
| `loader-rejected` | 390 × 844 | 1 | PASS |
| `loader-network-failure` | 390 × 844 | 1 | PASS |
| `browser-dpr-2` | 390 × 844 | 2 | PASS |

O buffer ficou em **960 × 600 em todas as 13 medições**, enquanto o canvas CSS
mudou. Isso é coerente com um mock que não implementa sincronização, e **não é
uma falha demonstrada do template de produção**. O teste certifica a passagem
dos parâmetros à dependência substituída, não que o loader real os aplicou.

#### Resultado das 43 verificações

A tabela agrupa as verificações individuais do JSON, sem contagem adicional.
Elas não representam 43 execuções independentes da aplicação Unity.

| Grupo de verificações | PASS | FAIL |
| --- | --- | --- |
| Cobertura da viewport pelo canvas nas 13 medições | 13 | 0 |
| Ausência de excesso medido e espaço de scrollbar nas 13 medições | 13 | 0 |
| Estado de carregamento, configuração e canvas recebidos pelo mock | 3 | 0 |
| Documento sem recarga e continuidade da sonda JavaScript | 2 | 0 |
| Buffer mantido em 960 × 600 pelo mock sem sincronização | 1 | 0 |
| Rejeição da inicialização: alerta e erro esperado | 2 | 0 |
| Falha HTTP do loader: alerta e diagnóstico esperado | 2 | 0 |
| Configuração de símbolos opcionais | 1 | 0 |
| DPR 2 no navegador com DPR 1 na configuração recebida | 1 | 0 |
| Ausência de exceções JavaScript não tratadas em todos os cenários | 1 | 0 |
| Ausência de erros/avisos e falhas de requisição nos cenários de sucesso, símbolos e DPR 2 | 1 | 0 |
| Ausência de solicitações de artefatos reais da Unity | 1 | 0 |
| Preservação do CSS processado e integridade do template de produção | 2 | 0 |
| **Total** | **43** | **0** |

#### Erros, avisos e evidências

- Nos cenários de sucesso, símbolos e DPR 2: nenhum erro/aviso de console,
  nenhuma exceção não tratada e nenhuma requisição malsucedida.
- Na rejeição: um erro intencional, `Falha simulada task28: inicializacao
  indisponivel`, capturado pelo `.catch(showError)` original. Não houve
  `pageerror` ou rejeição não tratada.
- Na falha de rede: HTTP **404** intencional do script, mensagem automática do
  Chrome `Failed to load resource...404 (Not Found)`, requisição com
  `net::ERR_ABORTED` e o diagnóstico do `loader.onerror`. São os erros esperados
  da injeção de falha, não falhas inesperadas do teste.
- Nenhum aviso FSR/EASU apareceu: o runtime/URP não foi carregado, portanto esse
  resultado não confirma nem refuta o diagnóstico da task #27.

Evidências preservadas:

- [JSON completo: medidas, 43 verificações, configuração, console, rede e hashes](Evidencias/Task-28-Template/resultados.json).
- [Script de reprodução e mock mínimo](Evidencias/Task-28-Template/validar-template.cjs).
- Quatro capturas de viewport, ligadas na tabela de resoluções.
- [Carregamento pendente](Evidencias/Task-28-Template/loader-carregando.png),
  [falha de inicialização](Evidencias/Task-28-Template/loader-falha-inicializacao.png)
  e [falha de rede](Evidencias/Task-28-Template/loader-falha-rede.png).

As capturas de retrato/paisagem, carregamento e rejeição foram também abertas
para inspeção visual. As medidas completas incluem estados de carregamento e
erro, ambos sem excesso geométrico da página. São sete PNGs reais do Chrome,
não montagens ou capturas da build Unity.

Para reproduzir, executar a partir da raiz do repositório, com Node.js e
Playwright já disponíveis. Se o Node não resolver o módulo `playwright`, definir
`TASK28_PLAYWRIGHT` com o caminho da instalação existente. `TASK28_CHROME` permite
informar outro caminho do executável do Google Chrome, se necessário:

```powershell
# Configurações opcionais, conforme a instalação de cada integrante:
# $env:TASK28_PLAYWRIGHT = 'CAMINHO_DA_INSTALACAO_EXISTENTE_DO_PLAYWRIGHT'
# $env:TASK28_CHROME = 'CAMINHO_DO_EXECUTAVEL_DO_CHROME'
node Docs/Evidencias/Task-28-Template/validar-template.cjs `
  (Get-Location).Path `
  (Join-Path $env:TEMP 'task-28-template') `
  (Join-Path (Get-Location).Path 'Docs/Evidencias/Task-28-Template')
```

O script regenera as evidências no diretório de saída fornecido. Para preservar
esta execução, escolher outro diretório de evidências ao repetir. Porta e
identificadores de documento variam entre execuções. Os HTMLs processados, o
loader temporário e os dados temporários do navegador não integram a entrega.

#### Limitações metodológicas

O navegador foi o Chrome instalado, em modo headless com viewport controlada;
isso não testa uma janela interativa redimensionada manualmente, outros
navegadores, zoom arbitrário, aparelhos físicos ou a interface móvel do browser.
O ramo condicional foi processado pelo script, não pelo compilador da Unity.
Nenhum asset de build foi carregado. Não foram testados renderização, shaders,
resolução efetiva do WebGL, sincronização do render target, desempenho, entrada,
rodada, navegação interna ou preservação de estado da Unity.

### Análise estática do código

As conclusões desta seção são **inferências estáticas**, não resultados de teste.

#### Tamanho visual do canvas HTML

Em `Assets/WebGLTemplates/CacaAsCores/index.html`, `html` e `body` têm largura e
altura de `100%`, margem zero e `overflow: hidden`. `#unity-canvas` é um elemento
de bloco com largura e altura CSS de `100%`. Não há contêiner com dimensões fixas,
padding ou borda no canvas. Espera-se que sua área visual acompanhe a viewport
de conteúdo, inclusive quando sua proporção muda.

As dimensões Web iniciais de Player Settings são `960 × 600`. Elas alimentam os
atributos HTML `width` e `height` pelas macros `WIDTH` e `HEIGHT`; não impõem uma
largura ou altura CSS fixa à página. O template não solicita tela cheia do sistema
nem bloqueia uma orientação. `resizableWindow: 0` não deve ser interpretado como
um bloqueio do redimensionamento da janela do navegador.

`overflow: hidden` pode ocultar conteúdo excedente. A ausência visual de barras,
isoladamente, não prova que todo conteúdo cabe: é necessário medir limites e
dimensões de rolagem, além de observar a página.

#### Resolução do canvas e renderização interna

O loader é inserido por um elemento `script`. Seu `onload` chama
`createUnityInstance(canvas, config)` com URLs dos artefatos gerados na pasta
`Build`; a resolução da Promise oculta o status de carregamento. Falhas do loader
ou da instanciação mostram o alerta e são enviadas a `console.error`.

`matchWebGLToCanvasSize: true` solicita a sincronização do buffer do canvas com
seu tamanho visual. `devicePixelRatio: 1` fixa o fator usado pela Unity, mesmo
quando `window.devicePixelRatio` tem outro valor. Após inicialização e
estabilização, espera-se um buffer de `390 × 844` para a viewport CSS de
`390 × 844`, e `844 × 390` na orientação inversa. Isso ainda precisa ser medido.
Essa interpretação segue a documentação da Unity 6000.5 sobre
[tamanho do canvas](https://docs.unity.com/en-us/engine/6000.5/manual/platform-specific/webgl/develop/canvas-size)
e [configuração do template](https://docs.unity.com/en-us/engine/6000.5/manual/platform-specific/webgl/building-distribution/templates/web-templates-build-configuration).

O buffer apresentado pelo canvas não equivale necessariamente a todas as
resoluções intermediárias da URP: `QualitySettings.asset` seleciona Mobile como
padrão para WebGL, e `Mobile_RPAsset.asset` tem Render Scale `0.8` e Upscaling Filter
Auto (`0`). Não se deve deduzir a resolução de cada passe apenas de `canvas.width`
e `canvas.height`. Nenhum asset gráfico foi alterado.

#### Layout interno da Unity e cena da build

`ProjectSettings/EditorBuildSettings.asset` contém somente
`Assets/Scenes/SampleScene.unity` habilitada no índice 0. Seu GUID
`99c9720ab356a0642a771bea13969a05` corresponde ao `.meta` existente.
Não foi localizado um asset de Build Profile que substitua essa lista;
as substituições devem ser conferidas no Editor quando ele estiver disponível.

A SampleScene contém Main Camera, Directional Light e Global Volume; a câmera
usa viewport normalizada `(0, 0, 1, 1)`. Não há Canvas de UI, menus ou rodada nessa
cena. Existem outras cenas e scripts no repositório, mas eles não substituem
automaticamente a lista de build e não foram usados para ampliar esta validação.

Preencher a página e ajustar a resolução não reorganiza botões, instruções ou
objetos por si só. O Canvas Scaler e o arranjo interno dependem das tasks de UI
e layout, incluindo US-06.1 e US-06.2; não foram implementados nesta task.

#### Conferências estáticas efetivamente realizadas

| Verificação estática | Resultado |
| --- | --- |
| Versão do projeto | Conferida: Unity 6000.5.7f1 |
| Template selecionado e compressão | Conferidos: `PROJECT:CacaAsCores`, compressão desativada (`2`) |
| Canvas / loader | Código inspecionado; sincronização habilitada, DPR configurado em 1 e loader nativo |
| Cena habilitada e GUID | Correspondência confirmada entre lista compartilhada e `.meta` da SampleScene |
| Metadados do template | Presentes: `WebGLTemplates.meta`, `CacaAsCores.meta` e `index.html.meta`; sem alterações |
| Exclusão de artefatos | `git check-ignore` confirmou as regras para `Builds/WebGL/index.html`, `Builds/WebGL/Build/WebGL.wasm` e `Data/Plugins/lib_burst_generated.wasm` |
| Assets, Player Settings e pacotes | Nenhuma alteração desta task; não houve importação ou abertura do Editor |
| Revisão da entrega | Documento, script e evidências revisados; `git diff --check` e verificação dos arquivos novos sem erros de whitespace |

Essas verificações não comprovam compilação, carregamento, disponibilidade de
WebGL 2.0, ausência de exceções ou continuidade da renderização.

### Testes da build Unity não executados

As dimensões abaixo são **planejadas para a build Unity**; nenhuma viewport da
build foi medida. Os resultados anteriores correspondem ao template isolado.
Em todas as células de verificação, **NE = NÃO EXECUTADO** por falta de Editor e
build local verificável.

| Cenário | Viewport planejada (px CSS) | Canvas CSS / buffer | Margens / overflow / barras | Renderização | Console navegador / Unity | Resultado |
| --- | --- | --- | --- | --- | --- | --- |
| A — Retrato | 390 × 844 | NE | NE | NE | NE | NÃO EXECUTADO |
| B — Paisagem | 844 × 390 | NE | NE | NE | NE | NÃO EXECUTADO |
| C — Desktop | 1280 × 720 | NE | NE | NE | NE | NÃO EXECUTADO |
| D — Desktop maior | 1920 × 1080 | NE | NE | NE | NE | NÃO EXECUTADO |
| E — Dinâmico, sem reload | 1280 × 720 → 390 × 844 → 844 × 390 → 1920 × 1080 → 390 × 844 | NE | NE | NE | NE | NÃO EXECUTADO |

Não há capturas, exportações de console, medidas de runtime ou logs de uma nova
build Unity. As evidências do template isolado não substituem essas evidências.
Não foi observada nem descartada a ocorrência do aviso FSR/EASU no jogo atual.
O diagnóstico histórico da task #27 permanece em `Build-WebGL.md`.

#### Procedimento para os testes pendentes da build

1. Em um ambiente com Unity **6000.5.7f1** e WebGL Build Support, registrar SO,
   navegador/versão, GPU, data, commit testado e alterações locais. Para usar uma
   build fornecida, exigir a identificação do commit, configurações e log de
   geração; a data dos arquivos, sozinha, não demonstra correspondência.
2. Seguir [Build-WebGL.md](Build-WebGL.md): conferir template, compressão, lista
   compartilhada com SampleScene e possíveis substituições de perfil. Gerar
   Development Build por **Build And Run** em `Builds/WebGL`. Registrar o sucesso
   ou falha e o Console da Unity. Não abrir por `file://`.
3. Registrar a URL HTTP efetivamente aberta. No navegador, abrir DevTools,
   habilitar Preserve log e usar viewport responsiva de dimensões personalizadas,
   com zoom da página em 100%, sem perfil de aparelho que altere a identidade
   do navegador. O tamanho externo da janela não serve como medida da viewport.
4. Após o carregamento, testar A, B, C e D. Em cada tamanho, aguardar estabilização,
   medir a viewport e o canvas, observar bordas/margens/barras e capturar a cena e
   os valores. O buffer deve acompanhar o canvas CSS com fator 1; investigar
   diferenças persistentes em vez de aprovar apenas pela aparência.
5. Para E, executar a sequência da tabela sem reload. Complementar com **três
   ciclos paisagem → retrato → paisagem na mesma página**. Registrar as medidas,
   conferir erros, perda de contexto WebGL, reinicialização e travamentos.
   `performance.timeOrigin` ajuda a identificar recarga da página; não comprova
   sozinho que o runtime Unity não reiniciou.
6. Verificar a continuidade da renderização durante e depois das mudanças. A
   SampleScene é estática: capturas iguais não demonstram quadros sendo gerados.
   Quando possível, acompanhar quadros no Unity Profiler conectado à Development
   Build. Se não houver evidência suficiente, registrar continuidade como
   **inconclusiva**, sem criar uma interface ou gameplay artificial para o teste.
7. Salvar mensagens dos consoles do navegador e da Unity. Registrar o aviso
   FSR/EASU, se reaparecer, separadamente das exceções. Não alterar a URP para
   ocultá-lo. Atualizar a tabela com medidas reais, evidências e eventuais falhas.
8. Revisar o Git após gerar a build, separar serializações automáticas de mudanças
   intencionais e executar `git diff --check`. Não incluir builds ou caches no PR.

Para a leitura em cada etapa, usar os mesmos campos de medição descritos na
metodologia e implementados no script de evidência: `innerWidth/innerHeight`,
`getBoundingClientRect()`, dimensões client/scroll, `canvas.width/height`, DPR,
estado do status e `performance.timeOrigin`. Conferir o canvas em `(0, 0)`,
cobrindo a viewport, e comparar o buffer após estabilizar. Não solicitar outro
contexto de renderização nem alterar dimensões do canvas durante a medição.
Os indicadores de overflow da página não detectam sobreposições ou cortes dentro
da Unity. Essa medição ainda não foi executada contra a build real.

#### Cobertura dos requisitos e limitações da build

| Requisito | Parte avaliável com a SampleScene | Situação atual / dependências |
| --- | --- | --- |
| RT-118 | Abrir o runtime no navegador nas duas orientações e medir preenchimento | NÃO VALIDADO experimentalmente; falta executar a build |
| RT-119 | A SampleScene não contém instrução, botões e objetos de rodada para avaliar visibilidade e sobreposição | NÃO VALIDADO; depende das funcionalidades de UI e layout |
| RT-120 | É possível verificar o redimensionamento do canvas e a continuidade do runtime, quando houver build | NÃO VALIDADO; preservar rodada, tentativas e tempo exige uma rodada implementada e testável |

Não foram validados posicionamento de botões futuros, menus ausentes na cena,
organização das formas, preservação do estado da rodada, troca de telas por
clique, dispositivos reais, outros navegadores em execução ou desempenho.
A task #28 não encerra automaticamente os requisitos completos nem a story #7.

### Parecer técnico, integridade e pendências

O impedimento para testar o jogo continua ambiental: Editor/módulo não localizados
e ausência de uma build executável com origem verificável. Os testes reais do
template isolado não reproduziram defeito no preenchimento da viewport. Não foi
necessária uma correção no template de produção.
Nenhuma alteração de código de produção, cena, prefab, `.meta`, pacote,
Player Settings, URP, SGDD ou ABD foi realizada.

As entregas registradas são este documento e a pasta
`Docs/Evidencias/Task-28-Template`, com script, JSON e sete capturas. Nesta revisão
de estrutura, somente o relatório foi editado; os testes não foram reexecutados.
Para concluir a task, falta disponibilizar a versão/módulo exigidos ou uma build
atual com procedência verificável, executar a matriz e anexar evidências reais.

Estado do Git na revisão anterior à publicação: branch `codex/task-28-webgl-resize`, HEAD na base
`60067b2`, com `?? Docs/Validacao-Redimensionamento-WebGL.md` e
`?? Docs/Evidencias/`, sem staging.
Nenhuma alteração automática da Unity ou artefato de build foi incluído.
O SHA-256 do `AGENTS.md` permaneceu
`AF42D1EB039D13ECF6897507F189A13334B7EF8A2A3E609111CD2A604F7C0EC0`.

**Parecer de integração:** o conjunto documental e de testes isolados é adequado
para revisão e integração como evidência parcial, pois não altera a aplicação.
Isso não autoriza encerrar a task #28 ou afirmar conformidade completa de
RT-118/119/120. A execução da build e seus consoles continuam sem evidência;
layout interno, continuidade da renderização e preservação de rodada também.

Para o PR, incluir este documento e as evidências revisadas, mantendo as
limitações explícitas. Os caminhos pessoais foram anonimizados no relatório e
somente no campo `temporaryDirectory` do JSON; os resultados, demais metadados,
script e PNGs foram preservados. Commit, push e abertura de PR foram autorizados
pelo usuário. Merge e encerramento da issue #28 não fazem parte desta entrega.
Acrescentar resultados da build quando executados, e correções apenas se um
problema de escopo for efetivamente reproduzido.

## Comentarios sobre os testes

A ideia era conferir se a area reservada ao jogo acompanhava os tamanhos do
navegador. Como nao havia Unity nem uma build disponivel nesse computador,
o Codex executou testes automaticos no Chrome usando uma copia do template HTML.
O codigo que cuida do tamanho da pagina foi mantido.

Para a pagina conseguir iniciar, usamos um loader simulado. Ele recebia as
informacoes que seriam enviadas para a Unity e permitia testar sucesso ou erro
no carregamento. Esse loader nao desenhava o jogo nem ajustava o tamanho do
canvas, que e a area onde o jogo apareceria.

Nas quatro resolucoes verificadas, o canvas ocupou toda a area disponivel.
Isso aconteceu tanto em pe quanto deitado, incluindo os tamanhos maiores de
desktop. As medidas nao mostraram margens ou areas sobrando fora da pagina.

O Codex tambem mudou o tamanho da mesma pagina cinco vezes, de forma automatica.
O canvas acompanhou cada mudanca sem precisar recarregar. Nessa sequencia nao
apareceram erros no JavaScript. Os erros de carregamento registrados vieram dos
casos em que a falha foi provocada de proposito, e a pagina mostrou a mensagem
esperada.

Com esses resultados, nao encontramos um problema de tamanho no template HTML
nos casos testados. A parte que ocupa o espaco do navegador funcionou como
esperado. Isso ainda nao garante o comportamento do jogo completo.

Falta abrir uma build real da Unity e conferir se a imagem do jogo continua
sendo desenhada e se sua resolucao acompanha as mudancas. O buffer ficou em
960 por 600 nesses testes, porque o loader simulado nao fazia esse ajuste.
Tambem nao deu para avaliar botoes, formas ou a continuidade de uma rodada.
Por isso, a task #28 continua com essa parte pendente.
