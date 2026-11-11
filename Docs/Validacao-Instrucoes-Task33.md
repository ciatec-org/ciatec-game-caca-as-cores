# Task #33 — Validação das instruções

A [task #33](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/33) e a [história #10](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/10) foram verificadas no Editor Unity 6000.5.7f1 em Windows. A base foi a `develop` oficial em `511127ee7cab3199752287468ba43862ee248d82`, que inclui os PRs #66, #67 e #68. A cobertura corresponde ao SGDD §9.2, ABD US-02.2/T-02.2.3 e aos requisitos RT-01, RT-30, RT-31, RT-76 e RT-90.

## Matriz conferida

Os textos esperados são literais definidos pelo SGDD. Os 30 casos foram aprovados tanto no EditMode quanto no cartão real da `MainScene` em Play Mode.

| Cor | Só cor | Círculo | Quadrado | Triângulo | Estrela |
| --- | --- | --- | --- | --- | --- |
| Vermelho | Encontre o vermelho | Encontre o círculo vermelho | Encontre o quadrado vermelho | Encontre o triângulo vermelho | Encontre a estrela vermelha |
| Azul | Encontre o azul | Encontre o círculo azul | Encontre o quadrado azul | Encontre o triângulo azul | Encontre a estrela azul |
| Verde | Encontre o verde | Encontre o círculo verde | Encontre o quadrado verde | Encontre o triângulo verde | Encontre a estrela verde |
| Amarelo | Encontre o amarelo | Encontre o círculo amarelo | Encontre o quadrado amarelo | Encontre o triângulo amarelo | Encontre a estrela amarela |
| Laranja | Encontre o laranja | Encontre o círculo laranja | Encontre o quadrado laranja | Encontre o triângulo laranja | Encontre a estrela laranja |
| Roxo | Encontre o roxo | Encontre o círculo roxo | Encontre o quadrado roxo | Encontre o triângulo roxo | Encontre a estrela roxa |

## Procedimento e resultados

| Verificação | Executados | Aprovados | Reprovados | Ignorados |
| --- | ---: | ---: | ---: | ---: |
| EditMode completo | 52 | 52 | 0 | 0 |
| Play Mode na `MainScene` | 4 | 4 | 0 | 0 |

- No Unity Test Runner, execute **EditMode → Run All**. São 30 casos em `InstrucaoDaRodadaTests` e 22 em `RodadaTests`. O modo só cor repete cada expectativa com as quatro formas possíveis do alvo.
- Em uma cópia separada, execute os quatro testes do roteiro temporário `ValidacaoTask33PlayMode` no **PlayMode**. O roteiro carrega a `MainScene`, chama `IniciarRodada` com rodadas determinísticas e compara o `TextMeshProUGUI` com os literais acima. Para cada frase, confere os glifos, a substituição da instrução anterior, o uso do mesmo cartão e a visibilidade durante a rodada. Os cliques automatizados verificam tentativas, acerto, erro, fechamento e `SelecaoAvaliada`. A execução terminou sem exceções inesperadas.
- O Game View foi testado em **390 × 844**, **844 × 390** e **1280 × 720**, com quatro frases representativas em cada tamanho. O cartão ficou no topo, com 88 px de altura e fonte de 26 px. Triângulo vermelho e quadrado vermelho usaram duas linhas em retrato. As demais medições ficaram em uma linha. Os glifos couberam no cartão, com texto preto sobre fundo branco (contraste nominal de 21:1) e sem sobreposição entre o cartão e os botões da rodada.

## Limitações

O marcador vermelho provisório que já pertence à `MainScene` fica junto à borda inferior do triângulo na captura de 844 × 390. Ele não interceptou os cliques avaliados nem afetou o cartão. A cena e o código de produção foram preservados.

Os cliques foram enviados pelo `EventSystem`. Mouse operado por pessoa, toque físico e WebGL ficaram fora desta execução. Os XMLs NUnit, logs, roteiro temporário e três capturas do Game View ficam separados da branch de entrega.

## 11/11/2026 — Compatibilização com o SGDD v2.12

Esta atualização complementa o registro histórico acima, sem substituir seus resultados. Base: develop oficial em `ce752fa309b5a175c63399ef3068912afd2388c6`, com os PRs #67, #69 e #71 integrados. As issues #32 e #33 permanecem concluídas. O SGDD v2.12 (§2.2, §9.2, RT-72 e RT-74) acrescenta retângulo e substitui amarelo por marrom. O modelo de frase, a permanência do cartão e a concordância de gênero (RT-01, RT-30, RT-31, RT-76 e RT-90) foram preservados. O trabalho corresponde ao ABD US-02.2/T-02.2.2 e T-02.2.3.

### Matriz atual: 36 frases

São seis frases só de cor e 30 de cor e forma, com expectativas literais independentes de InstrucaoDaRodada.Montar. Cada caso só de cor é também conferido com as cinco formas possíveis do alvo.

| Cor | Só cor | Círculo | Quadrado | Triângulo | Estrela | Retângulo |
| --- | --- | --- | --- | --- | --- | --- |
| Vermelho | Encontre o vermelho | Encontre o círculo vermelho | Encontre o quadrado vermelho | Encontre o triângulo vermelho | Encontre a estrela vermelha | Encontre o retângulo vermelho |
| Azul | Encontre o azul | Encontre o círculo azul | Encontre o quadrado azul | Encontre o triângulo azul | Encontre a estrela azul | Encontre o retângulo azul |
| Verde | Encontre o verde | Encontre o círculo verde | Encontre o quadrado verde | Encontre o triângulo verde | Encontre a estrela verde | Encontre o retângulo verde |
| Marrom | Encontre o marrom | Encontre o círculo marrom | Encontre o quadrado marrom | Encontre o triângulo marrom | Encontre a estrela marrom | Encontre o retângulo marrom |
| Laranja | Encontre o laranja | Encontre o círculo laranja | Encontre o quadrado laranja | Encontre o triângulo laranja | Encontre a estrela laranja | Encontre o retângulo laranja |
| Roxo | Encontre o roxo | Encontre o círculo roxo | Encontre o quadrado roxo | Encontre o triângulo roxo | Encontre a estrela roxa | Encontre o retângulo roxo |

### Integração e compatibilidade

- CorDoJogo conserva os índices 0–5; o índice 3 agora representa Marrom. FormaDoJogo conserva os índices 0–3 e acrescenta Retangulo = 4. Não há alias Amarelo na paleta ativa. Registros históricos e a matriz antiga acima não foram reescritos.
- ConfiguracaoDoJogo deixa de duplicar valores RGB: seus seis campos de cor passam de Color para referências ColorData já integradas pelo PR #71. O asset existente foi atualizado e mantém o GUID e os tempos. Os cinco sprites importados também ficam referenciados nesse asset. Outras configurações criadas fora do repositório com o formato antigo precisarão receber essas referências no Inspector.
- FabricaDeFormas.Obter recebe a configuração e resolve os cinco sprites; a geração procedural provisória foi substituída para evitar retângulo invisível e reaproveitar a arte existente. Referências ausentes produzem erro explícito. ControladorDaRodada continua criando os mesmos botões e usando o mesmo cartão; ControladorDeJogo lê vermelho por ObterCor. Rodada e sua lógica de tentativas não foram alteradas.
- Form.prefab e Forms permanecem disponíveis para a demonstração. A migração da hierarquia dos botões para esse prefab não é necessária para esta compatibilização: a rodada reutiliza os mesmos sprites e ColorData sem trocar seus eventos ou redesenhar a interface. Cenas, Build Profiles, pacotes e URP não integram a alteração.

### Validação atualizada

| Verificação na Unity 6000.5.7f1 / Windows | Resultado |
| --- | --- |
| EditMode completo | 60/60 aprovados; zero falhas e zero ignorados |
| Play Mode na MainScene, roteiro local | 5/5 aprovados; zero falhas e zero ignorados |
| Game View | Cinco frases representativas em cada uma das três resoluções; cartão e glifos sem corte |
| Development Build WebGL | Gerada com sucesso; zero erros e quatro avisos no relatório de build |
| Chrome 157.0.8103.39 headless / WebGL 2.0 / SwiftShader | 36 frases conferidas; três redimensionamentos; erro, acerto e bloqueio após fechamento conferidos por eventos de mouse do navegador; zero erros ou exceções JavaScript registrados |

A matriz Play Mode conferiu também os sprites e as cores contra os assets do PR #71. O caso adicional só de cor verificou seis frases com as cinco formas, e os três testes de layout verificaram cinco exemplos cada. Retângulo vermelho coube em duas linhas no retrato e em uma linha nas paisagens, mantendo fonte de 26 px e cartão de 88 px. Não houve exceções inesperadas nas execuções aprovadas.

A build de validação selecionou MainScene pelo BuildPipeline, sem mudar a lista global. Incluiu um roteiro temporário que percorre as 36 frases e prepara retângulo marrom para o teste de ponteiro. Os três redimensionamentos preservaram a mesma rodada e zero tentativas; depois, o Chrome enviou erro no quadrado marrom e acerto no retângulo marrom, fechando com duas tentativas. Um terceiro clique foi ignorado. Esse roteiro não pertence ao jogo publicado nem ao PR.

Procedimento: executar EditMode → Run All na Unity 6000.5.7f1. A matriz contém 36 casos de frases, um teste de contrato dos enums e 23 testes de Rodada. Para Play Mode, o roteiro temporário CompatibilidadeV212PlayMode carrega a MainScene, inicia rodadas determinísticas, confere texto, glifos, cartão único, troca, sprites e cores em relação aos assets, além de seleção, eventos e tentativas. Verifica também o modo só cor com as cinco formas e casos representativos em 390 × 844, 844 × 390 e 1280 × 720. O roteiro, XMLs, logs e capturas ficam separados do conteúdo do PR, em D:/Temp/ciatec-sgdd-v212-instructions-20261111.

Os testes foram automatizados. Mouse operado por pessoa, toque físico, GPU física, outros navegadores, áudio e playtest com crianças não foram validados. No Chrome, as três resoluções foram conferidas com retângulo marrom; a matriz completa rodou em 1280 × 720. Não se certificam desempenho, cenário final ou acessibilidade completa dos objetos. O marcador vermelho provisório da MainScene, já registrado na validação anterior, foi preservado.

Permaneceram os avisos conhecidos de FSR/EASU não suportado, fallback do formato de cookies de luz e AudioContext aguardando gesto. A renderização e as verificações descritas passaram; não houve alteração na URP para ocultar avisos. O CS0618 de FindFirstObjectByType no controlador é anterior a esta compatibilização e não impediu a compilação.

### Pendências fora desta compatibilização

A tabela de vizinhança em Docs/cores.csv continua divergindo do SGDD; não é consumida por esta implementação e não foi alterada. A comprovação do contraste dos objetos depende do fundo efetivamente utilizado. A lista global de build continua apontando para Testing conforme a develop recebida; não foi substituída por MainScene nesta entrega. O layout completo dos objetos, o gerador de fases e a voz pertencem às suas próprias implementações.
