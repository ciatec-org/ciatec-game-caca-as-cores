# Validação WebGL — Task #39 (Marco M1)

Validação executada em **13/11/2026** para a [task #39](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/39), ligada à [US-09 / issue #14](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/14). No ABD, corresponde à **US-02.6 / T-02.6.1**. A entrega registra uma nova build e uma nova sessão; os resultados anteriores da auditoria do PR #74 não foram reaproveitados como execução desta task.

## Referências e critérios

Referências consultadas: as issues #39 e #14, os PRs [#73](https://github.com/ciatec-org/ciatec-game-caca-as-cores/pull/73) e [#74](https://github.com/ciatec-org/ciatec-game-caca-as-cores/pull/74), o [SGDD v2.12](SGDD-CacaAsCores-v2.md) (seções 2.2–2.3, 3, 8.1, 9.2, 11 e requisitos RT-38, RT-41, RT-76, RT-77, RT-85), o [ABD v1.3](ABD-CacaAsCores-v1.md) (US-02.2 a US-02.6) e a documentação [Build WebGL](Build-WebGL.md).

Critério central: cinco rodadas consecutivas na build WebGL, com um erro proposital seguido de acerto, todas aceitando seleções e avançando automaticamente, sem exceção inesperada no navegador. Também foram conferidos cartão de instrução, sprites, cores, tentativas e intervalo de transição. Isso valida o recorte M1 existente; não certifica todas as funcionalidades planejadas no SGDD.

## Ambiente e base testada

| Item | Valor |
| --- | --- |
| Base oficial | `ciatec-org/ciatec-game-caca-as-cores:develop` |
| SHA testado | `e232ccad0eed67cfdb9d2bef944f5b1727f26e87` |
| Integrações presentes | PR #73 e merge do PR #74, confirmado no GitHub e na ancestralidade Git |
| Unity | `6000.5.7f1`, revisão `017862109af0` |
| Plataforma e build | WebGL; `BuildOptions.Development`; IL2CPP/WebAssembly |
| Cena | `Assets/Game/Scenes/MainScene.unity` |
| Sistema | Windows; execução local isolada |
| Navegador | Chrome/157.0.8103.51 |
| Execução | Automatizada via Chrome DevTools Protocol; Chrome headless com ANGLE/SwiftShader |
| Janela | 1280 × 720 CSS px, DPR 1; entrada de mouse |
| Hospedagem | HTTP em `127.0.0.1`; MIME `application/wasm`; COOP `same-origin` e COEP `require-corp` |
| Configuração preservada | Template `CacaAsCores`; compressão desativada; espera de 0,5 s |

O checkout original não foi alvo de edições pelo agente; sua branch, HEAD e lista de alterações permaneceram iguais. A comparação de hashes detectou uma regravação de `ProjectSettings/ProjectSettings.asset` às 11:13 durante o trabalho, sem origem confirmada; o arquivo foi mantido como encontrado. Os demais arquivos monitorados, incluindo AGENTS, SGDD e ABD, conservaram seus hashes. Foi criado um clone separado, com a branch `test/task39-webgl-five-rounds` sobre a develop oficial. A Unity foi executada em uma segunda cópia descartável. Nenhum observador, driver ou alteração de runtime foi incluído no jogo testado.

A lista compartilhada ainda aponta para `Assets/Scenes/Testing.unity`. Para esta validação foi fornecida **somente a MainScene** diretamente ao `BuildPipeline`, sem alterar permanentemente `EditorBuildSettings.asset`. A referência a SampleScene no documento histórico da task #27 não foi usada para escolher a cena deste teste.

## Geração e reprodução da build

O módulo **WebGL Build Support** da Unity 6000.5.7f1 estava instalado. Em uma cópia de Assets, Packages e ProjectSettings do SHA acima, um auxiliar temporário de Editor chamou:

```csharp
using System;
using UnityEditor;
using UnityEditor.Build.Reporting;

public static class Task39Build
{
    public static void Gerar()
    {
        var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Game/Scenes/MainScene.unity" },
            locationPathName = Environment.GetEnvironmentVariable("CIATEC_TASK39_WEBGL"),
            target = BuildTarget.WebGL,
            options = BuildOptions.Development
        });
        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception("Falha na build WebGL; consultar o log.");
    }
}
```

Para reproduzir, coloque esse auxiliar em `Assets/Editor/Task39Build.cs` **apenas na cópia de validação**, defina a variável de saída para um diretório externo e execute a mesma versão do Editor:

```powershell
$env:CIATEC_TASK39_WEBGL = 'D:\Temp\task39-repro\WebGL'
& 'D:\UnityEditor2\6000.5.7f1\Editor\Unity.exe' `
  -batchmode -quit `
  -projectPath 'D:\Temp\task39-repro\validacao' `
  -executeMethod Task39Build.Gerar `
  -logFile 'D:\Temp\task39-repro\build-webgl.log'
```

Adapte apenas os caminhos à instalação local. O auxiliar efetivamente usado também exportou o resumo do BuildReport e seus avisos para JSON; o código acima reproduz a seleção de cena e as opções da build. A primeira tentativa de preparação falhou no tipo de dois campos desse auxiliar (contagens `int`, não `uint`); isso foi corrigido fora do repositório antes da geração registrada abaixo, sem modificar o jogo.

A build foi servida por Node.js em HTTP local. O roteiro temporário `roteiros/servir-webgl.cjs`, preservado junto das evidências locais, permite reabrir **esta mesma build**:

```powershell
node 'D:\Temp\ciatec-task39-webgl-20261113\roteiros\servir-webgl.cjs' `
  'D:\Temp\ciatec-task39-webgl-20261113\WebGL'
```

Abra `http://127.0.0.1:8039/` no navegador e acompanhe o Console (F12). Não use `file://`. Para uma reprodução sem esse roteiro local, um servidor HTTP estático que entregue `.wasm` como `application/wasm` é suficiente para a configuração atual, sem threads e sem compressão; mantenha os cabeçalhos descritos na tabela para repetir o ambiente utilizado.

**Resultado da geração:** **Succeeded**, **0 erros e 4 avisos** no BuildReport; 996,8 s (aproximadamente 16 min 37 s). O log encerrou com código 0. Os quatro avisos estão discriminados abaixo.

A Unity reserializou arquivos na cópia descartável: `Assets/Settings/DefaultVolumeProfile.asset`, `Assets/Settings/PC_RPAsset.asset`, `Assets/Settings/UniversalRenderPipelineGlobalSettings.asset`, `ProjectSettings/ProjectSettings.asset`. Os diffs foram conferidos: correspondem a dados de volume/prefiltragem/recursos de runtime e dados automáticos do Player. Não foram copiados para a branch da task. Scripts, cena MainScene, configuração das rodadas, paleta, sprites, pacotes e respectivos `.meta` permaneceram iguais à base; a lista de build também foi preservada.

## Roteiro e cinco rodadas observadas

A sequência provisória no código é vermelho → estrela vermelha → azul → quadrado verde, repetindo. **O Inspector da MainScene seleciona a posição 1**, por isso esta sessão começou pela estrela vermelha. Cinco rodadas consecutivas não exigem cinco instruções distintas.

O roteiro aguardou a inicialização, capturou a tela, enviou cliques de mouse aos objetos visíveis e acompanhou os logs `[Rodada]` já existentes. Na terceira rodada, selecionou primeiro o círculo verde, aguardou 750 ms sem acerto e só então selecionou o quadrado verde. Após o quinto acerto, conferiu a sexta abertura e a ausência de outra transição espontânea durante mais 800 ms.

| Rodada | Instrução exibida | Seleção executada | Resultado esperado e observado | Tentativas | Fechamento | Próxima instrução / intervalo observado |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Encontre a estrela vermelha | Estrela vermelha | Acerto e avanço automático — confirmado | 1 | CORRETA | Encontre o azul; 507,9 ms |
| 2 | Encontre o azul | Triângulo azul | Acerto e avanço automático — confirmado | 1 | CORRETA | Encontre o quadrado verde; 502,3 ms |
| 3 | Encontre o quadrado verde | Círculo verde → quadrado verde | Seleção incorreta, sem encerrar; depois acerto e avanço — confirmado | 2 | COM ERRO | Encontre o vermelho; 510,8 ms |
| 4 | Encontre o vermelho | Quadrado vermelho | Acerto e avanço automático — confirmado | 1 | CORRETA | Encontre a estrela vermelha; 507,3 ms |
| 5 | Encontre a estrela vermelha | Estrela vermelha | Acerto e avanço automático — confirmado | 1 | CORRETA | Encontre o azul; 515,2 ms |

**Erro proposital:** O círculo verde produziu “Seleção incorreta”, visível na captura. Não houve fechamento nem troca durante a espera de pelo menos 750 ms. O quadrado verde foi aceito como tentativa 2; a rodada fechou COM ERRO e avançou. A primeira seleção nas rodadas seguintes voltou a ser tentativa 1.

**Transições e bloqueio:** Foram registradas **5 aberturas automáticas após os 5 acertos**, sem duplicação; a sexta tela mostrou “Encontre o azul”, com o resultado anterior limpo. Os intervalos ficaram entre **502,3 e 515,2 ms**, coerentes com a espera configurada e a execução por frames. Na rodada 2, o pointerup de um clique extra ocorreu **179,2 ms após o agendamento**, ainda **323,1 ms antes da abertura**: não gerou tentativa, fechamento ou transição adicional. Esse evento foi observado no DOM, sem modificar o runtime Unity. Uma sondagem anterior terminou após a troca e foi desconsiderada como prova de bloqueio (campo `blockProbeMiss`); a comprovação é a sondagem da rodada 2.

Os intervalos acima são diferenças entre timestamps do Console do Chrome: log `próxima rodada em 500 ms` → log `nova rodada`. Incluem a retomada da coroutine no frame seguinte; não são medidas de tempo de resposta da criança nem uma certificação de temporização em outros dispositivos.

## Inspeção visual e estabilidade

Foram inspecionadas as sete capturas desta execução: aberturas 1 a 6 e erro da rodada 3. Em cada abertura havia um único cartão legível no topo, com a frase da tabela, formas e cores visíveis e sem texto de instrução duplicado. O feedback “Seleção incorreta” apareceu sem substituir a instrução. As telas seguintes limparam esse feedback. O canvas medido tinha **1280 × 720**, tanto no render target quanto na área CSS. Não houve tela vazia inesperada ou sprite ausente nas rodadas inspecionadas. A inspeção é visual; não constitui avaliação colorimétrica ou de acessibilidade com participantes.

O Console confirmou **Unity 6000.5.7f1 (017862109af0)** e **WebGL 2.0**. A captura dos eventos Runtime/Log do Chrome não registrou erro de Console nem exceção JavaScript inesperada; também não foram encontradas mensagens de exceção C# no registro capturado. Houve 6 seleções aceitas (5 acertos e 1 erro proposital), 5 fechamentos e 5 transições. O fluxo completou a sessão sem travamento ou interrupção.

### Avisos

| Origem | Mensagem / resultado | Avaliação nesta execução |
| --- | --- | --- |
| Build, 1 aviso | CS0618 em `ControladorDaRodada.cs:68`: `FindFirstObjectByType<T>()` obsoleto | Compilou; API existente, sem falha funcional observada. Nenhuma refatoração feita. |
| Build, 3 avisos | IL2CPP separou os métodos grandes `TMP_TextParsingUtilities::.cctor()`, `TextMeshPro::GenerateTextMesh()` e `TextMeshProUGUI::GenerateTextMesh()` em arquivos C++ próprios | Mensagens sobre o custo de compilação do TextMeshPro; build bem-sucedida. |
| Navegador | AudioContext não permitido antes de gesto do usuário | Política de autoplay; áudio não foi validado. Não interrompeu a sessão. |
| Navegador | `Additional Lights Cookie Format (GrayscaleHigh)` não suportado; fallback para `RGBA8 UNorm` | Fallback explícito da URP; não houve falha visual observada na cena. |
| Navegador | Shader `Hidden/Universal Render Pipeline/Edge Adaptive Spatial Upsampling` não suportado em `Blit FSR Upscaling` | Passe opcional não selecionado pela configuração atual; sessão e renderização das formas funcionaram. |

O log de importação também contém mensagens de dependências não encontradas de shaders Terrain da URP. Elas não aparecem como erros no BuildReport final e não impediram esta cena; uso de Terrain não foi avaliado. Os textos completos dos quatro avisos de build e dos três avisos do navegador estão no JSON versionado.

Esses avisos não foram tratados como exceções nem como defeitos apenas por existirem. Nenhuma configuração da URP foi alterada para suprimi-los. O código local da URP 17.5 confirma que `PostProcessUtils.LoadShader` emite o aviso de EASU para o material não suportado e que `Fsr1UpscalePostProcessPass` ignora esse passe quando inválido. O perfil Mobile, padrão para WebGL, está com Render Scale 0,8 e filtro Auto, que resolve para Linear nessa escala. O aviso não demonstra desativação global de todo pós-processamento. Não foi identificado impacto que exija correção de URP nesta task.

## Testes adicionais

Nova execução **EditMode: 65/65 aprovados, 0 falhas, 0 ignorados**, na Unity 6000.5.7f1, com XML próprio desta task. Comando executado na cópia isolada, antes de adicionar o auxiliar de build:

```powershell
& 'D:\UnityEditor2\6000.5.7f1\Editor\Unity.exe' `
  -batchmode -projectPath 'D:\Temp\ciatec-task39-webgl-20261113\validacao' `
  -runTests -testPlatform EditMode `
  -testResults 'D:\Temp\ciatec-task39-webgl-20261113\evidencias\editmode.xml' `
  -logFile 'D:\Temp\ciatec-task39-webgl-20261113\evidencias\editmode.log'
```

Não foi executada uma nova suíte Play Mode nesta task; os testes de navegador acima verificaram o fluxo integrado real.

## Evidências e limites

O resumo versionado [resultados.json](Evidencias/Task-39-WebGL/resultados.json) contém BuildReport, resultado EditMode, sequência observada, tempos, console da rodada, avisos e hashes SHA-256 dos arquivos da build. É evidência de engenharia de uma sessão automatizada de teste, **não implementação da telemetria científica do SGDD**.

Os arquivos completos ficaram organizados em `D:\Temp\ciatec-task39-webgl-20261113\`:

- `WebGL/`: build executada; fora do Git.
- `evidencias/`: logs da Unity, XML EditMode, BuildReport, eventos do navegador e capturas locais das rodadas 1 a 6 e do erro proposital.
- `roteiros/`: auxiliares temporários de geração, servidor, validação e conferência de preservação; fora do PR.
- `projeto/`: clone da branch para entrega; `validacao/`: cópia descartável aberta pela Unity.

A validação foi automatizada, em Chrome headless/SwiftShader. As imagens geradas foram inspecionadas pelo agente; **não houve sessão manual em navegador gráfico nem validação de GPU física**. A tentativa de usar um serviço de Chrome gráfico isolado informou que esse navegador não estava disponível; nenhuma aba pessoal foi usada. Não foram certificados toque, outros navegadores, retrato/redimensionamento, desempenho em hardware real, áudio ou acessibilidade com participantes. Essas limitações delimitam a evidência; não impediram os critérios funcionais desta task.

As capturas locais apoiam esta inspeção, mas sua organização/publicação no quadro permanece na **task #41**. Não foram antecipados o gerador definitivo, novas fases, menus, feedbacks planejados ou correções da **task #40**.

## Conclusão

**Validação funcional aprovada para a task #39:** nova build WebGL real, MainScene executada no Chrome, cinco rodadas consecutivas concluídas, erro proposital recuperado e transições automáticas funcionais, sem exceção inesperada. A nova suíte EditMode passou 65/65. **Não foram encontrados defeitos funcionais no roteiro executado que indiquem correção de produção na task #40.** A evidência está pronta para revisão de outro integrante, dentro das condições e limites registrados acima.

O PR desta task contém somente este relatório e o resumo JSON, para revisão de outro integrante. Não altera SGDD, ABD, AGENTS, código, configurações, sprites ou metadados, nem inclui build ou caches. A publicação não encerra automaticamente a issue #39, a US-09/#14 ou o Marco M1 completo; a revisão e as demais tasks do marco seguem seu fluxo próprio.
