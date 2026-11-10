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
