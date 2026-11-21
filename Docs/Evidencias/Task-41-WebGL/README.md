# Capturas WebGL — Task #41

Evidências visuais da [task #41](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/41), vinculada à [US-09 / #14](https://github.com/ciatec-org/ciatec-game-caca-as-cores/issues/14) e ao ABD US-02.6 / T-02.6.3. São capturas reais da sessão da **task #39**, já documentada no [PR #75](https://github.com/ciatec-org/ciatec-game-caca-as-cores/pull/75).

## Origem e ambiente

| Item | Registro da sessão |
| --- | --- |
| SHA do jogo testado | `e232ccad0eed67cfdb9d2bef944f5b1727f26e87` |
| Referência documental da #39 | Commit `3fb22cbd88e5a348c0f7e43b4ba49da5fe8049b9` do PR #75 |
| Data e intervalo da sessão | 13/11/2026, 14:19:20–14:22:16 UTC |
| Unity e cena | Unity 6000.5.7f1 (017862109af0); `Assets/Game/Scenes/MainScene.unity` |
| Build e ambiente | Development WebGL, Windows, WebGL 2.0, servidor HTTP local |
| Navegador e interação | Chrome 157.0.8103.51 headless, ANGLE/SwiftShader, cliques automatizados via CDP |
| Formato | PNG, 1280 × 720 pixels, DPR 1 |

Os originais foram localizados em `D:\Temp\ciatec-task39-webgl-20261113\evidencias\` e preservados. A cópia para esta pasta manteve os bytes, sem recorte, edição ou recompressão. Os arquivos `rodada-N-aberta.png` (N de 1 a 6) receberam os nomes `rodada-0N.png`; `rodada-3-selecao-incorreta.png` tornou-se `rodada-03-erro.png`.

A associação com a sessão foi conferida com a lista `visualInspection.screenshots`, os eventos em `browser.rounds`, o roteiro de captura preservado e os horários dos arquivos originais, dentro do intervalo registrado. Consulte o [relatório completo da #39](https://github.com/gabrielmilagresdev/ciatec-game-caca-as-cores/blob/3fb22cbd88e5a348c0f7e43b4ba49da5fe8049b9/Docs/Validacao-WebGL-Task39.md) e o [resultados.json daquela execução](https://github.com/gabrielmilagresdev/ciatec-game-caca-as-cores/blob/3fb22cbd88e5a348c0f7e43b4ba49da5fe8049b9/Docs/Evidencias/Task-39-WebGL/resultados.json).

**Nenhuma nova sessão, build ou suíte EditMode/Play Mode foi executada na #41.** As imagens não pertencem à repetição posterior da #40.

## Catálogo

| Arquivo | Rodada | Instrução | Evidência |
| --- | --- | --- | --- |
| [rodada-01.png](rodada-01.png) | 1 | Encontre a estrela vermelha | Primeira abertura, cartão legível e quatro formas disponíveis. |
| [rodada-02.png](rodada-02.png) | 2 | Encontre o azul | Segunda abertura; triângulo azul entre três objetos. |
| [rodada-03.png](rodada-03.png) | 3 | Encontre o quadrado verde | Terceira abertura; quadrado e círculo verdes permitem conferir a exigência de forma e cor. |
| [rodada-03-erro.png](rodada-03-erro.png) | 3, após o erro | Encontre o quadrado verde | Texto “Seleção incorreta” após clicar no círculo verde; a instrução e as formas permanecem. |
| [rodada-04.png](rodada-04.png) | 4 | Encontre o vermelho | Abertura após acertar o quadrado verde na segunda tentativa; feedback anterior limpo. |
| [rodada-05.png](rodada-05.png) | 5 | Encontre a estrela vermelha | Quinta abertura, retornando à instrução inicial da sessão. |
| [rodada-06.png](rodada-06.png) | 6 | Encontre o azul | Estado aberto após o quinto acerto, associado à quinta transição nos registros da #39. |

**Resultado histórico da #39:** cinco rodadas concluídas, erro proposital seguido de acerto na terceira, tentativas `1, 1, 2, 1, 1`, cinco transições automáticas e nenhuma exceção inesperada capturada. Os intervalos de 502,3–515,2 ms e os 65/65 testes EditMode aprovados também pertencem à #39, não a novos testes desta entrega.

## Imagens

**Rodada 1 — abertura inicial**

![Rodada 1: cartão Encontre a estrela vermelha e quatro formas visíveis](rodada-01.png)

**Rodada 2 — instrução por cor**

![Rodada 2: cartão Encontre o azul e triângulo azul entre os objetos](rodada-02.png)

**Rodada 3 — instrução por cor e forma**

![Rodada 3: cartão Encontre o quadrado verde, com círculo e quadrado verdes na fileira](rodada-03.png)

**Rodada 3 — seleção incorreta**

![Rodada 3 após selecionar o círculo verde: mesma instrução e feedback Seleção incorreta](rodada-03-erro.png)

**Rodada 4 — continuidade após a nova tentativa correta**

![Rodada 4: cartão Encontre o vermelho, formas visíveis e feedback anterior limpo](rodada-04.png)

**Rodada 5 — continuidade da sequência cíclica**

![Rodada 5: cartão Encontre a estrela vermelha na quinta rodada](rodada-05.png)

**Rodada 6 — abertura após a conclusão da quinta**

![Rodada 6: cartão Encontre o azul após o quinto acerto registrado na sessão](rodada-06.png)

## Integridade e limites

As sete imagens foram abertas e inspecionadas nesta task: instruções legíveis, formas e cores visíveis, sem cortes dos elementos relevantes, carregamento ou dados pessoais. O feedback incorreto está visível na imagem correspondente. O conjunto original não contém uma captura do feedback “Acerto!”.

Os PNGs totalizam **639.622 bytes** (aproximadamente 625 KiB), entre 87.855 e 98.077 bytes por arquivo. Os hashes em [SHA256SUMS](SHA256SUMS) correspondem aos bytes dos originais e das cópias publicadas. A regra existente `*.png` do Git LFS foi preservada; após o checkout, os hashes devem ser calculados sobre os PNGs materializados pelo LFS, não sobre seus ponteiros.

As capturas 01/05 são idênticas entre si, assim como 02/06: a sequência provisória se repete e a tela assume o mesmo aspecto. Mantiveram-se os sete nomes para identificar os momentos capturados; o LFS armazena cinco conteúdos PNG únicos. As imagens isoladas não comprovam a ordem, os tempos, os cliques ou a ausência de exceções: esses fatos dependem dos registros associados no PR #75.

São evidências técnicas de uma execução automatizada em headless/SwiftShader, sem validação de GPU física, interação manual gráfica, toque ou outros navegadores. Não constituem validação pedagógica, clínica ou de acessibilidade com crianças ou participantes. Nenhum código de produção, cena, configuração, sprite ou documento de planejamento foi alterado nesta entrega.
