# Build WebGL — Caça às Cores

Preparação da task [#27](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/27),
parte da story [#7](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/7).
Referências: ABD US-01.3 / T-01.3.1 e T-01.3.2; SGDD seções 1.2 e 11.

## Configuração versionada

| Item | Configuração |
| --- | --- |
| Unity | **6000.5.7f1** |
| Company Name | CIATec |
| Product Name | Caça às Cores |
| Version | 0.1.0, preservada |
| Web Template | CacaAsCores (`PROJECT:CacaAsCores`) |
| Compression Format | Disabled (`webGLCompressionFormat: 2`) |
| Cena compartilhada de build | `Assets/Scenes/SampleScene.unity`, habilitada no índice 0 |
| Diretório de saída recomendado | `Builds/WebGL`, ignorado pelo `.gitignore` existente |

A compressão fica desativada nesta etapa para facilitar a execução local sem
exigir cabeçalhos HTTP de Brotli/Gzip. Isso aumenta o tamanho dos arquivos;
a configuração de hospedagem e a otimização da entrega podem ser avaliadas depois.
WebAssembly, threads desativadas, Input System, memória e dependências permanecem
conforme a configuração existente. As alterações gráficas automáticas observadas
após a build estão separadas do escopo do PR, conforme a revisão abaixo.

O template padrão não oferece uma configuração do projeto que garanta canvas
ocupando toda a janela em desktop e em retrato. O template mínimo em
`Assets/WebGLTemplates/CacaAsCores/index.html` usa o loader nativo do Unity e
preenche a área disponível da página, sem margens ou dimensões CSS fixas.
`matchWebGLToCanvasSize` mantém o render target sincronizado ao canvas;
`devicePixelRatio: 1` estabelece a base de pixels CSS prevista para as medidas
em dp. O Canvas Scaler e o layout dos elementos do jogo pertencem às suas tasks.

Ocupar a janela significa preencher a área de conteúdo do navegador. Não há
solicitação automática de tela cheia do sistema nem bloqueio do zoom da página.
O template apenas carrega a aplicação e informa uma falha de inicialização;
não implementa menus, gameplay ou persistência de sessão.

**Ícone pendente:** não existe asset de identidade do jogo adequado. O PNG de
`TutorialInfo` pertence ao template URP e não deve ser usado como marca do jogo.
Nenhum ícone, favicon ou identidade visual nova foi criado.

## Preparar o Editor e o módulo Web

1. No Unity Hub, instale ou localize a versão **6000.5.7f1**.
2. Em **Installs > 6000.5.7f1 > Add modules**, confirme ou instale
   **WebGL Build Support**. Não abra este projeto nas versões mais antigas.
3. Abra a raiz do projeto nessa versão e aguarde a importação e compilação.
   Confira o Console antes de prosseguir. Não atualize os pacotes para gerar a build.
4. Abra **File > Build Profiles**. Em **Platforms**, selecione **Web** e use
   **Switch Platform**, caso Web ainda não seja a plataforma ativa.
   Se o módulo não estiver disponível, volte ao Hub para instalá-lo.
5. Use a lista compartilhada de cenas, sem substituição por uma lista específica
   de perfil. Confirme somente `Assets/Scenes/SampleScene.unity`, habilitada,
   no índice 0. Se já houver um perfil personalizado, confira suas substituições.
6. Em **Player Settings**, confira **Company Name**, **Product Name** e, na aba Web,
   **Resolution and Presentation > Web Template: CacaAsCores** e
   **Publishing Settings > Compression Format: Disabled**.

Não é necessário criar um Build Profile personalizado. As configurações de Player
e a lista compartilhada de cenas já estão versionadas; a seleção da plataforma
ativa é feita no Editor. Não foi criado manualmente um asset de perfil com
referências internas do Unity.

## Gerar e executar

1. Em **Build Profiles > Web**, deixe **Client Browser Type: System Default**.
2. Para a validação local, habilite **Development Build**. Não é necessário
   habilitar Deep Profiling ou publicar em Unity Play.
3. Clique em **Build And Run** e selecione `Builds/WebGL` dentro da raiz do projeto.
   Use essa pasta apenas para a saída gerada; não salve assets do projeto nela.
4. Aguarde o término da build. O Unity deve iniciar o servidor local e abrir
   uma URL HTTP no navegador. Não abra `index.html` por duplo clique / `file://`.
5. Confira o **Console do Unity** e o **console do navegador** (F12): não deve
   haver exceções de importação, carregamento ou execução.
6. Confirme que a cena ocupa a área disponível da página, sem moldura de tamanho
   fixo ou barras de rolagem. O estado atual esperado é a cena de exemplo com
   câmera, luz e volume; ainda não há menus ou formas jogáveis.
7. Após a execução, confira `git status --short`: os arquivos gerados da build
   não devem aparecer. Revise separadamente qualquer alteração automática
   em assets ou configurações; esta task não exige mudanças globais da URP.

## Validação e limites

Na preparação de 26/10/2026, foram encontradas instalações Unity 6000.0.56f1 e
6000.3.25f1, ambas sem WebGL Build Support. A versão 6000.5.7f1 não foi localizada
nos caminhos de instalação consultados nem no cadastro de editores do Hub.
Essas versões não foram usadas para abrir ou migrar o projeto.
**Na preparação inicial pelo agente, não foi gerada nem executada uma build Unity.**

Verificações estáticas: cena e GUID da lista de build, seleção do template,
macros do loader, metadados dos novos arquivos, exclusão da saída e preservação
das configurações não relacionadas. Isso não comprova compilação ou execução.

Esse registro descreve a preparação inicial pelo agente, antes da instalação e
dos testes manuais posteriores; não representa o estado final da validação.

### Revisão dos testes manuais — 27/10/2026

Resultados informados pela equipe, sem uma nova execução do Unity pelo agente:

| Verificação | Resultado e evidência |
| --- | --- |
| Geração da build WebGL | Sucesso informado pela equipe e corroborado por `Logs/Editor.log`: `Build completed with a result of 'Succeeded'`, registro de 26/10/2026, aproximadamente 999 s |
| Versão do Editor/runtime | Unity 6000.5.7f1, informada pela equipe; o log local registra a mesma versão e revisão 017862109af0 |
| Módulo WebGL | O log registra o carregamento de WebGL Build Support na versão 6000.5.7f1 |
| Abertura da aplicação | Cena de exemplo abriu no Google Chrome, conforme relato da equipe |
| API gráfica | WebGL 2.0 funcionando, conforme relato da equipe |
| Console do Unity | Nenhum erro aparente observado pela equipe; isso não significa ausência de todo aviso nos logs |
| Console do navegador | A equipe não identificou outros erros de execução além do aviso de shader transcrito abaixo |
| Ocupação da janela | Aparentemente completa, conforme observação da equipe; sem medição ou confirmação de todas as proporções |
| Template aplicado à build | O HTML gerado contém o nome do produto, canvas com largura e altura CSS de 100%, `matchWebGLToCanvasSize: true` e `devicePixelRatio: 1` |
| Artefatos no Git | Nenhum arquivo de `Builds`, `Data`, `Library` ou `Logs` está rastreado ou staged na revisão |

Não foram certificados desempenho, aparência de todos os efeitos de
pós-processamento, outros navegadores, dispositivos móveis ou o redimensionamento
completo previsto na task #28. O relato não identifica explicitamente a URL
utilizada nem o acionamento de Build And Run; a abertura no Chrome está confirmada,
mas não se registra separadamente esse procedimento como executado.

### Aviso de shader da URP

Texto informado pela equipe, originado em `WebGL.framework.js:2130`:

```text
Shader 'Hidden/Universal Render Pipeline/Edge Adaptive Spatial Upsampling' is not supported (in 'Blit FSR Upscaling'). PostProcessing render passes will not execute.
```

Foi conferido o código do pacote local URP 17.5.0:

- `PostProcessUtils.LoadShader` emite esse aviso e retorna material nulo para o
  shader não suportado. Não desabilita globalmente todos os efeitos.
- `PostProcess` constrói o passe FSR/EASU na inicialização, mesmo quando esse
  algoritmo não será selecionado para renderizar a câmera.
- `Fsr1UpscalePostProcessPass` marca esse passe como inválido e não o executa sem
  material. O shader EASU exige shader target 4.5 / instruções texture gather.
- Mobile, padrão de qualidade para WebGL, usa Render Scale 0.8 e Upscaling Filter
  Auto. A seleção automática resolve esse caso para Linear, não FSR. O perfil PC
  também permanece em Auto. Nenhum desses valores foi alterado nesta task.

**Parecer:** o aviso é explicável pela inicialização de um passe opcional não
suportado e não selecionado na configuração atual. Não foi identificada correção
necessária na URP para a task #27. Ele não comprova falha da build nem que todo o
pós-processamento deixou de funcionar. A aparência de Bloom, Vignette e Tonemapping
não foi validada por este diagnóstico; se houver defeito visual ou adoção de FSR,
a configuração deverá ser investigada novamente. Não remover efeitos, editar o
pacote ou atualizar a URP apenas para ocultar o aviso.

### Escopo do futuro Pull Request

Arquivos da task a incluir:

```text
.gitignore
ProjectSettings/ProjectSettings.asset
Assets/WebGLTemplates.meta
Assets/WebGLTemplates/CacaAsCores.meta
Assets/WebGLTemplates/CacaAsCores/index.html
Assets/WebGLTemplates/CacaAsCores/index.html.meta
Docs/Build-WebGL.md
```

Em `ProjectSettings.asset`, incluir os ajustes de nome, empresa, template e
compressão. A representação YAML `"Ca\xE7a \xE0s Cores"` equivale a
`Caça às Cores`. Após a build apareceram também um preload do InputSystem_Actions
e um bloco de batching WebGL desativado: são alterações adicionais à preparação
original e não precisam integrar o PR desta task. Usar seleção de hunks ao
preparar o commit; esses dados locais foram preservados na revisão.

Os quatro arquivos abaixo também foram modificados após a importação/build e
devem ficar fora deste PR:

```text
Assets/Settings/DefaultVolumeProfile.asset
Assets/Settings/Mobile_RPAsset.asset
Assets/Settings/PC_RPAsset.asset
Assets/Settings/UniversalRenderPipelineGlobalSettings.asset
```

Eles contêm ajustes de perfil de volume, prefiltragem de shaders e lista de
recursos de runtime. A versão do asset global permanece 10; não se trata da
migração para versão 11 observada no PR #60. Isso não torna essas alterações
necessárias ao escopo da task #27. Foram preservadas para revisão separada, sem
reversão ou descarte automático.

Além da saída ignorada em `Builds/WebGL`, o Burst gerou
`Data/Plugins/lib_burst_generated.cpp` e `Data/Plugins/lib_burst_generated.wasm`
na raiz. Uma regra específica no `.gitignore` impede sua inclusão acidental.
Os arquivos gerados foram preservados no disco. Não usar `git add .` para preparar
esta entrega, pois ainda existem alterações gráficas locais fora do escopo.

**Prontidão:** configuração e geração/abertura no Chrome estão prontas para
revisão da task #27, com o aviso não bloqueante e as limitações acima registradas.
Preparar o PR somente com o conjunto de arquivos e hunks indicado; esta revisão
não constitui autorização para commit, push ou merge.

A task **#28** cobre a execução e o registro de redimensionamento em retrato e
paisagem, incluindo as referências 390 × 844 e 844 × 390 do SGDD. O template
prepara o dimensionamento da página, mas não comprova o layout futuro do jogo.
O critério da story #7 de trocar telas por clique depende das implementações
de cena e navegação da story #6. A story #7 não está concluída por esta preparação.
O PR #60 e seu ScriptableObject não são dependências desta task.

## Referências técnicas

- [Unity 6000.5 — adicionar um template Web](https://docs.unity3d.com/6000.5/Documentation/Manual/web-templates-add.html).
- [Unity 6000.5 — configuração e interação do template](https://docs.unity3d.com/6000.5/Documentation/Manual/web-templates-build-configuration.html).
- [Unity 6000.5 — estrutura e instanciação](https://docs.unity3d.com/6000.5/Documentation/Manual/web-templates-structure.html).
- [URP 17.5 — carregamento de materiais de pós-processamento](https://github.com/Unity-Technologies/Graphics/blob/6000.5/staging/Packages/com.unity.render-pipelines.universal/Runtime/PostProcessUtils.cs).
- [URP 17.5 — passe FSR/EASU](https://github.com/Unity-Technologies/Graphics/blob/6000.5/staging/Packages/com.unity.render-pipelines.universal/Runtime/Passes/PostProcess/Fsr1UpscalePostProcessPass.cs).
