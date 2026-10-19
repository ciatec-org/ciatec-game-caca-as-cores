---
doc: GLIDE Doc 1 — SGDD
titulo: Caça às Cores
subtitulo: Busca visual e resposta a instruções, para crianças em idade escolar
versao: v2.11
mudanca: as formas, as cores e a interface da rodada viram regra mais recomendação, e o time escolhe dentro da regra. v2.10: sem cópia da sessão no navegador; o time escolhe as cores; textos de tela, categorias da rodada e layout completados; sem a tela Fim (o cartão da fase 5 diz que terminou); o porquê das decisões saiu do corpo para as DD, e o GDD dos alunos sai das seções 1 a 13. v2.9: só no navegador, com o arquivo da sessão baixado sozinho; quem não passa tenta de novo, sem descida; sem vibração, sem animações reduzidas e sem tabela de tradução; a tabela das cores vizinhas e a concordância da estrela no texto; RT-33 e RT-48 reescritos. v2.8: o jardim menos apagado, e sem nenhuma das seis cores do jogo (DD-41 revista). v2.7: o jardim também por trás dos menus
data: 14/10/2026
projeto_vinculado: Exercício de design científico GLIDE
organizacao: CIATec (contexto ilustrativo)
triple_diamond: 1º Diamante — definição inicial, proposta
ppi: nenhum até o momento (cenário simulado)
pesquisador: "[a definir]"
tipo: requisitos
ids_externos: RT
status: rascunho
data_criacao: 01/10/2026
data_atualizacao: 14/10/2026
---

# 1 CONCEITO DO JOGO

> **Exercício didático.** Este documento reescreve no formato v2 do GLIDE o SGDD v1.0 do Caça às Cores, que é um exercício de design científico com dados simulados. Toda afirmação aqui vem daquele documento, chamado adiante de documento-fonte, de uma decisão do usuário registrada na seção 14, ou de uma regra do formato. Personas, princípios e limiares continuam hipotéticos, e os valores atribuídos na triagem de 14/10/2026 se confirmam em playtest.

## 1.1 Premissa

*A criança escolhe uma fase numa grade de cards. Em cada rodada, ela ouve e lê uma instrução curta, como "Encontre o vermelho", e toca, entre as formas da tela, a que corresponde a ela. Errou, tenta de novo, sem perder nada; acertou, a próxima rodada abre. Acertando de primeira 4 das 5 rodadas, a fase está concluída e a próxima se libera; cada fase é um pouco mais difícil que a anterior.*

**A sensação:** *ENTENDER O QUE FOI PEDIDO E ACHAR.*

O objetivo do protótipo é estudar a interação, a busca visual e a resposta a instruções numa tarefa breve e configurável, e não presumir efeito terapêutico (seção 16.3).

## 1.2 Gênero e Plataforma

**Gênero:** jogo casual de busca visual, como jogo sério.

**Modo de jogo:** um jogador, em sessão supervisionada ou educacional. Professores, terapeutas, pesquisadores e cuidadores podem mediar; é o mediador quem prepara a sessão (seção 7.3).

**Plataforma:** Unity 2D, para o navegador (WebGL). A janela pode ser mais alta que larga (retrato) ou mais larga que alta (paisagem), e o jogo se reorganiza com ela (`DD-15`).

**Interação:** clique de mouse sobre o objeto; numa tela sensível ao toque, o toque vale o mesmo. Não há câmera nem outro sensor (`DD-12`).

**Idiomas:** só português do Brasil (`DD-31`).

## 1.3 Público-Alvo

Crianças em idade escolar, incluindo crianças com transtorno do espectro autista (TEA), com diferentes perfis de linguagem, atenção, percepção visual e motricidade. A faixa é de 6 a 10 anos (seção 15.2). Como parte delas ainda não lê, a instrução também é falada (`DD-27`).

**O diagnóstico de TEA, por si só, não determina a dificuldade inicial** (`DD-07`): o nível sai do desempenho na tarefa.

# 2 MECÂNICAS

## 2.1 Conceito Geral

**Localizar e selecionar.** A cada rodada o jogo apresenta uma instrução e um conjunto de objetos; um deles é o alvo, e todos os outros são distratores (`DD-02`, `DD-18`). A criança seleciona o objeto que corresponde à instrução, e o jogo responde se a seleção corresponde ou não.

**Uma rodada é uma instrução, até o alvo ser achado** (`DD-25`). Ela não tem duração fixa: dura o tempo que a criança leva.

A tarefa permite observar a resposta a estímulos e instruções em condições controladas. **O desempenho não é interpretado como medida de uma capacidade clínica** (`DD-14`): acertos e tempos dependem também da compreensão da instrução, da familiaridade com a tarefa, da visão, da motricidade, da fadiga e da motivação.

**Não há vidas nem pontuação** (`DD-26`). O erro não gasta nada e não encerra nada; a sessão só acaba quando o mediador volta da grade de fases ao início.

![](figuras/tela-rodada.png)

## 2.2 Os objetos e os dois modos

**Os objetos da tarefa são quatro formas geométricas planas** (`DD-24`), que se distinguem pela silhueta, mesmo pequenas, e que uma criança de 6 anos sabe nomear. Os objetos do cotidiano ficam no cenário, e nunca são alvo.

**As cores são seis** (`DD-28`), com nomes diferentes entre si e que a criança conhece. Nenhuma delas aparece no cenário, e todas têm o contraste da seção 7.4 com ele. Os valores ficam num lugar só, que se ajusta sem mexer no código.

**O time escolhe as quatro formas e as seis cores**, dentro destas regras, e o orientador aprova a escolha antes de o jogo usá-las. Os exemplos deste documento usam a recomendação abaixo.

> **Recomendação.** As formas: círculo, quadrado, triângulo e estrela. As cores: vermelho, azul, verde, amarelo, laranja e roxo, com os valores que passarem no contraste.

**Há dois modos, e só dois** (`DD-01`, `DD-24`):

- **Só cor.** A instrução nomeia só a cor ("Encontre o vermelho"), e o alvo é o único objeto daquela cor. As formas se sorteiam entre as quatro, e não são todas iguais; elas não importam: a criança acerta pela cor.
- **Cor e forma.** A instrução nomeia a forma e a cor ("Encontre o quadrado azul"), e o alvo é o único objeto que tem as duas. Para a forma pesar, há distratores com a mesma cor e outra forma, e com a mesma forma e outra cor (`G-05`).

**A semelhança dos distratores tem dois graus** (`DD-28`): vizinhos, das duas cores mais parecidas com a cor do alvo — as que ficam ao lado dela no círculo das cores —, e distintos, das outras três. **O time monta a tabela das vizinhas e das distintas para as cores que escolher**, no formato da tabela abaixo, que é a das cores recomendadas. No modo só cor, todo distrator tem outra cor, com outro nome. No modo cor e forma, um distrator tem a cor do alvo e outra forma (`G-05`), e os de outra cor seguem a semelhança da fase.

| Cor do alvo | Cores vizinhas | Cores distintas |
| --- | --- | --- |
| Vermelho | Laranja e roxo | Amarelo, verde e azul |
| Laranja | Vermelho e amarelo | Verde, azul e roxo |
| Amarelo | Laranja e verde | Vermelho, azul e roxo |
| Verde | Amarelo e azul | Vermelho, laranja e roxo |
| Azul | Verde e roxo | Vermelho, laranja e amarelo |
| Roxo | Azul e vermelho | Laranja, amarelo e verde |

## 2.3 Fechamento da rodada, da fase e da sessão

**A rodada fecha no acerto** (`DD-23`). Com o acerto, um retorno breve e a próxima rodada. Com o erro, um retorno neutro, e a rodada continua aberta: a criança tenta de novo, quantas vezes precisar. Com o limite de tempo ligado, a rodada também fecha quando o tempo acaba: o jogo mostra qual era o alvo e abre a próxima.

**A fase fecha depois de 5 rodadas** (`DD-43`), num cartão sem números: "Fase concluída!" ou "Vamos tentar de novo!" (seção 5.2). O cartão leva à próxima fase, ou a tentar a mesma de novo, ou de volta à grade.

**A sessão vai de fase em fase.** Quando a fase 5 é concluída, o cartão do fim da fase diz "Você terminou todas as fases!" e leva de volta à grade (`DD-29`). O resumo com os indicadores vai só para o arquivo da sessão, gravado sozinho (seção 13). **A criança ou o mediador podem sair de uma fase a qualquer momento** (`DD-10`), com confirmação ("Sair da fase?", com Continuar e Sair), de volta à grade; o voltar da grade encerra a sessão, e é então que o arquivo baixa (seção 13).

# 3 CONTROLES

Neste documento, **tocar** quer dizer clicar com o mouse, ou tocar numa tela sensível ao toque.

- **Selecionar:** um clique ou um toque sobre o objeto o seleciona. A seleção é um gesto só: não há arrastar, segurar nem duplo clique. Durante o retorno de acerto, tocar num objeto não faz nada; com a voz falando, o toque vale (`DD-35`).
- **Repetir a instrução:** tocar no cartão da instrução, inteiro, reapresenta a instrução da rodada, em qualquer rodada, inclusive no tutorial (`DD-08`, `DD-40`); o alto-falante dentro dele é só o sinal. Tocado com a voz falando, ele recomeça a fala.
- **O botão pressionado:** todo objeto e todo botão reagem em até 80 ms do instante em que o botão do mouse aperta, antes de soltar — o objeto afunda, o botão escurece (`DD-40`).
- **Pausar:** um botão suspende a rodada (`DD-10`): o relógio para (`DD-19`), os objetos somem da tela, e a pausa mostra retomar, sair e as chaves de áudio e de voz (`DD-30`).
- **Sair:** um botão sai da fase a qualquer momento, depois de uma confirmação, e volta para a grade de fases; o voltar da grade volta ao início (`DD-10`, `DD-35`, `DD-43`).
- **Áreas de seleção amplas:** os objetos são grandes e separados o bastante para evitar o clique acidental (seção 7.4).

O jogo não usa câmera, microfone nem outro sensor (`DD-12`).

# 4 TUTORIAIS

**O tutorial abre uma vez por sessão, antes da primeira fase, e é uma rodada só** (`DD-32`, `DD-36`): a instrução explica o que fazer, em texto e em voz — "Vamos treinar! Toque no \<cor\>." —, e a mãozinha do jogo vai até o alvo e repete o gesto de tocar até a criança tocar. Ela não tem limite de tempo (`DD-04`) e não conta para a progressão nem para os indicadores. Depois dela, um cartão diz "Agora é com você!" e oferece começar a fase. **A rodada do tutorial é sempre a mesma** (`DD-36`): três formas grandes, de cores distintas, e o alvo sempre da mesma cor (recomendação: vermelho, "Vamos treinar! Toque no vermelho.").

A instrução aparece sempre em texto e, com a voz ligada, é falada (`DD-27`). **A mãozinha só existe no tutorial**: nas rodadas ela mostraria a resposta. A chave dela, nas configurações, liga ou desliga a mãozinha; desligada, a rodada do tutorial é igual a uma rodada comum, sem tempo.

![](figuras/tutorial.gif)

# 5 DINÂMICAS E PROGRESSÃO

## 5.1 Arco de uma Sessão Típica

A duração é ilustrativa, e não validada clinicamente: cada fase leva cerca de um minuto.

| Etapa | O que acontece | Duração ilustrativa |
| --- | --- | --- |
| Entrada | O mediador digita o código da criança e ajusta as configurações (seção 7.3) | 1 minuto |
| Grade de fases | A criança, ou o mediador, escolhe uma fase liberada | segundos |
| Tutorial | Uma rodada, com a mãozinha apontando o alvo, só antes da primeira fase | menos de 1 minuto |
| Fases | 5 rodadas cada, e o cartão do resultado; de fase em fase, até a 5 ou até sair | ~1 minuto por fase |
| Encerramento | O voltar da grade ao início | segundos |


## 5.2 Progressão por fases

**São cinco fases, em cards, e a dificuldade muda de um card para o outro** (`DD-43`). Dentro da fase ela não muda. A criança vê a grade, sabe em que fase está, e avança por mérito.

| Evento | Regra |
| --- | --- |
| Fase | 5 rodadas, sorteadas na hora pelas regras dela (`DD-44`) |
| Passar | 4 rodadas corretas das 5: "Fase concluída!", a fase ganha um ✓ na grade, a seguinte se libera, e o cartão oferece "Próxima fase" e "Voltar às fases" |
| Não passar | Menos de 4 corretas: "Vamos tentar de novo!", e o cartão oferece "Tentar de novo", com rodadas novas, e "Voltar às fases". A criança não avança, e o jogo não a leva para outra fase |
| Fim | Concluída a fase 5, o cartão diz "Você terminou todas as fases!" e só leva à grade |
| Início | A grade abre com as fases liberadas até a que o mediador escolhe nas configurações; o padrão é a 1. Nada se guarda entre sessões |
| Repetir | Uma fase concluída pode ser jogada de novo pela grade |
| Pausa | Disponível a qualquer momento, e o relógio para (`DD-19`) |
| Interromper | A pedido da criança ou do mediador, ou diante de desconforto observado |

**Rodada correta é a que acertou na primeira tentativa** (`DD-23`); as outras são com erro (errou e depois acertou), não resolvidas ou omissões (seção 13.3). **Só a correta conta para passar de fase**: clicar em tudo até acertar não conta.

**A adaptação aos erros é entre as fases, e não dentro delas.** O portão impede subir antes da hora; quem não passa tenta de novo quantas vezes quiser, ou volta à grade e escolhe uma fase já liberada. Como cada fase tem uma dificuldade só, o desempenho de uma fase se compara com o da mesma fase noutra sessão ou noutra criança (`H-03`). O mínimo de 4 de 5 é um valor de partida, que se confirma em playtest.

## 5.3 Fim da Sessão e Resultados

**A criança não vê números** (`DD-29`): nem no cartão do fim da fase, nem em outra tela. Números de erro na frente dela viram nota.

**O resumo vive só no arquivo da sessão**, que baixa sozinho quando a sessão termina (seção 13). Ele traz, por fase jogada, as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas e as omissões, e se a fase foi concluída. São indicadores descritivos de eventos de jogo, sem interpretação: **seleção incorreta é evento de jogo, e não diagnóstico** (`DD-14`).


# 6 LEVEL DESIGN

**O que faz uma rodada fácil ou difícil** são o número de objetos, o tamanho deles, a semelhança dos distratores, o modo (só cor, ou cor e forma) e o limite de tempo (seção 12). **Recomenda-se mudar uma por vez** (`DD-05`), para que a diferença de desempenho possa ser atribuída à variável que mudou; por isso **cada fase difere da vizinha numa variável só** (`G-03`).

**Uma fase é um conjunto de regras, e não uma lista de rodadas** (`DD-44`). Cada rodada é sorteada na hora, pelas regras da fase: a cor e a forma do alvo, e os distratores, respeitando as garantias da seção 23.10. Assim, a criança que repete uma fase vê rodadas novas, e não decora onde está o alvo. A cor-alvo não se repete em duas rodadas seguidas. O sorteio dá também a ordem dos objetos; a posição na tela vem do layout, que os põe nas casas da grade da orientação atual (`DD-40`). As cinco fases são estas:

| Fase | O que muda da anterior |
| --- | --- |
| 1 · 3 formas | 3 objetos grandes, só cor, distratores de cores distintas |
| 2 · 5 formas | 5 objetos |
| 3 · Cores parecidas | Distratores de cores vizinhas |
| 4 · Cor e forma | Cor e forma |
| 5 · 8 formas | 8 objetos |

![](figuras/niveis.png)

# 7 UI / UX

## 7.1 Princípios de Interface

- **Uma instrução principal por rodada** (`DD-02`).
- **Alvos grandes**, com separação suficiente para evitar cliques acidentais (seção 7.4).
- **Nenhum estado da interface se indica só pela cor** (`DD-16`): acerto, erro, fase bloqueada e fase concluída vêm sempre com contorno, movimento, ícone ou texto. A regra vale para a interface, e não para a tarefa: achar a cor é o próprio jogo, e o pedido vem escrito e falado (seção 15.2).
- **O retorno é consistente, não punitivo e não usa cor** (seção 8).
- **Repetir, pausar e sair** são controles claros, presentes em toda tela de jogo (`DD-10`).

## 7.2 Requisitos de Acessibilidade por Domínio

| Domínio | Requisito |
| --- | --- |
| Visual | Contraste medido (seção 7.4), alvos grandes, cenário calmo e animações breves |
| Auditivo | O áudio é opcional, e a instrução em texto está sempre na tela |
| Motor | Clique simples, com áreas de seleção amplas |
| Linguístico | Frases curtas no modelo da seção 9.2, a instrução falada para quem não lê, e a mãozinha no tutorial |
| Cultural | Objetos do cotidiano no cenário, e representações não estereotipadas |
| Sensorial | Nada alterna claro e escuro mais de uma vez por segundo, e nenhum som é abrupto; a pausa está disponível |


## 7.3 Telas e Fluxo de Navegação

**Início → Configurações → Fases → (Tutorial) → Rodada → Resultado da fase.** O tutorial só aparece antes da primeira fase da sessão; depois dele, ou direto da grade, vêm as rodadas. As 5 rodadas da fase se seguem, e o cartão do resultado leva à próxima fase, à mesma, ou à grade. A pausa e a saída ficam disponíveis em toda tela de jogo.

![](figuras/fluxo-telas.png)

**Os menus emulam o visual dos menus dos pacotes CIATEC, e o laço de jogo tem o tema do jogo** (`DD-17`). O início, as configurações e a grade de fases reproduzem a moldura dos menus da plataforma — a barra com o símbolo e a marca CIATEC, e o painel com borda e preenchimento translúcido, por trás do qual aparece o jardim do jogo (`DD-41`) —, com as cores e as medidas da pasta `visual-menus`. Os menus só têm o tema claro (`DD-31`). **O jogo não usa o M3Kit:** reproduz o visual com os próprios meios, com o símbolo, as fontes, as cores e as medidas da pasta `visual-menus`. O tutorial, as rodadas, o retorno, a pausa e o cartão do fim da fase têm a arte e o tema do jogo. A barra só tem o símbolo e a marca e, na grade de fases, o voltar.

![](figuras/menu-inicio.png)

**A tela de configurações** é do mediador, e vem depois do início. Nela se digitam o código pseudônimo da criança (`DD-34`), sem o qual o Começar não segue e o campo diz "Digite o código da criança (não o nome).", porque todo evento do registro leva o código, e se escolhem as fases liberadas, o tempo limite, o áudio, a voz e a mãozinha do tutorial. Os padrões são fases liberadas até a 1, tempo limite desligado, áudio ligado, voz ligada e mãozinha ligada (`DD-35`, `DD-43`). Quando a janela não comporta todas as opções, a tela rola, e o Começar fica fixo embaixo: em retrato, uma coluna, com o rótulo em cima do seletor; em paisagem, duas colunas, com o rótulo ao lado (`DD-40`). Os rótulos são os mesmos nas duas: Código da criança, Fases liberadas até, Tempo limite, Áudio, Voz na instrução e Mãozinha no tutorial.

![](figuras/janela-menus.png)


**A grade de fases** segue o menu de fases dos pacotes CIATEC: as cinco fases em cards de 140 dp ou mais, que preenchem a largura do painel (`DD-43`). O card mostra o número, uma miniatura do que a fase tem — quantas formas, se só cor ou cor e forma — e uma linha curta para o mediador. A liberada tem a borda acesa, a concluída tem um ✓ e pode ser jogada de novo, a bloqueada tem um cadeado e, tocada, faz aparecer numa linha abaixo da grade "Passe a fase N para liberar a fase N + 1.", que fica até o próximo toque. Em retrato, os cards ficam em duas colunas; em paisagem, os cinco numa linha. O voltar da barra volta ao início.

![](figuras/menu-fases.png)

**A tela da rodada** traz a instrução em texto, os botões de pausa e de saída e os objetos sobre o cenário. **O arranjo dela é do time**, dentro destas regras: a instrução e os dois botões ficam sempre visíveis; os objetos não se sobrepõem e ficam longe dos botões; o arranjo se reorganiza com a orientação (`DD-40`); e redimensionar a janela no meio da rodada reorganiza a tela sem perder nada. O laço de jogo pode ter um visual bem diferente dos menus.

> **Recomendação.** Os botões de pausa e de saída nos dois cantos de cima. Em retrato, a instrução numa linha própria, abaixo dos botões, e os objetos numa grade de uma coluna até 3 objetos e de duas colunas de 4 a 8; em paisagem, a instrução entre os dois botões, e os objetos numa linha até 4 e em duas linhas de 5 a 8, com a metade, arredondada para cima, na de cima, e a linha incompleta centrada. As figuras `janela-rodada.png` e `medidas.png` mostram esse arranjo.

![](figuras/janela-rodada.png)

**A pausa** esconde os objetos, para não virar tempo de busca, e mostra retomar, sair e as chaves de áudio e de voz (`DD-30`).


## 7.4 MEDIDAS E ALVOS

**Tudo se mede em dp, e a tela de referência é uma janela de 390 × 844 dp, em retrato e em paisagem** (`DD-40`): é a menor janela em que o jogo precisa caber. No navegador, 1 dp é 1 pixel da página (o px do CSS). Os botões e o texto têm medida fixa em dp; os objetos se medem pelo espaço que sobra. A tabela traz os mínimos, que são regra; o arranjo que os respeita é do time (seção 7.3). Os valores se confirmam em playtest (`DD-35`).

| Grandeza | Valor | O que garante |
| --- | --- | --- |
| Tela de referência | Janela de 390 × 844 dp em retrato, e de 844 × 390 dp em paisagem; janelas maiores usam o mesmo layout | A base de todas as medidas |
| Objeto grande | O maior diâmetro que cabe com 8 objetos no arranjo da orientação atual, até 200 dp: no arranjo recomendado, ~146 dp em retrato e ~115 dp em paisagem | O tamanho não muda de uma fase para outra, só de uma orientação para outra |
| Objeto médio e pequeno | 80 % e 60 % do grande | Os três tamanhos da seção 12; o pequeno fica acima de 60 dp |
| Separação entre objetos | 16 dp, no mínimo | Evitar o clique acidental |
| Botões de pausar e sair | 56 dp, no mínimo, e a 16 dp das bordas, no mínimo | Acima dos 44 px do alvo da WCAG 2.5.5 |
| Cartão da instrução | 56 dp de altura, no mínimo; o cartão inteiro é o alvo de repetir | Alvo largo para a ação mais frequente |
| Seletores e campos das configurações | 44 dp e 48 dp de altura | Alvo do mediador |
| Texto da instrução | 26 dp, no mínimo, e até duas linhas | Legível a ~30 cm |
| Resposta ao botão pressionado | Até 80 ms, antes de soltar | Ver que o clique pegou |
| Contraste dos objetos contra o cenário | 3:1, no mínimo (WCAG 1.4.11) | Ver o objeto sem depender do tom |
| Contraste do texto contra o fundo | 4,5:1, no mínimo (WCAG 1.4.3) | Ler a instrução |

> **Recomendação.** A figura cota o arranjo recomendado na janela de referência: nele, a área dos objetos começa 32 dp abaixo do cartão da instrução e acaba a 16 dp da borda de baixo e das laterais.

![](figuras/medidas.png)

# 8 FEEDBACK E MOVIMENTO

Quatro regras governam o retorno.

**O retorno informa, e não pune** (`DD-03`). O erro diz que a seleção não corresponde ao alvo, sem som punitivo, e não tira nada: não há vidas nem pontuação (`DD-26`).

**O retorno é previsível**: o mesmo evento produz sempre o mesmo retorno.

**O retorno não usa cor** (`DD-35`). Contorno e movimento dizem acerto e erro; a cor é só do alvo, que é o que a criança procura.

**O jogador controla os estímulos** (`DD-09`): o som do retorno se desliga com o áudio, e a voz, com a chave dela. As animações são breves e simples, e **nenhum efeito alterna claro e escuro mais de uma vez por segundo, nem tem som abrupto**.

## 8.1 Os efeitos

**A forma de cada efeito é do time**, dentro das regras acima e destas: o acerto destaca o alvo sem usar cor, toca um som curto e suave com o áudio ligado, e, durante ele, tocar num objeto não faz nada; a troca de rodada começa sozinha depois do acerto e é uma transição, e não um corte; o erro aparece no objeto escolhido, sem cor, sem som e sem voz, e a rodada continua aberta; com o limite de tempo ligado, um indicador sem número e sem cor de alerta mostra o tempo que resta e para na pausa e no acerto; quando o tempo acaba sem acerto, o jogo mostra qual era o alvo e abre a próxima rodada; e a pausa esconde os objetos. Cada efeito dura até 1 s, e os tempos se confirmam em playtest (`DD-35`).

> **Recomendação.** A tabela abaixo, e os GIFs dela.

| Efeito | O que faz | Animação |
| --- | --- | --- |
| **INSTRUIR** | QUANDO: a rodada abre, ou o botão de repetir é tocado. A instrução aparece em texto junto com os objetos, e é falada quando a voz está ligada. Repetir reapresenta o texto e recomeça a fala. | o texto entra com os objetos ![](figuras/fb-instrucao.gif) |
| **ACERTO** | QUANDO: a criança seleciona o alvo. Um contorno grosso no alvo, que cresce um pouco, oito brilhos claros que saem dele, e um som curto e suave com o áudio ligado (`DD-37`). Durante o retorno, tocar num objeto não faz nada. | cresce de 1 para 1,1 vez em 300 ms; os brilhos duram 600 ms; a troca começa 500 ms depois ![](figuras/fb-acerto.gif) |
| **TROCA** | QUANDO: uma rodada fecha e outra abre. As formas encolhem e somem, a instrução some junto, e as formas novas crescem do zero com a instrução nova (`DD-37`). | saída em 250 ms; entrada em 250 ms; o GIF do ACERTO mostra a troca |
| **ERRO** | QUANDO: a criança seleciona um distrator. O objeto escolhido balança de leve, como um "não", e esmaece no meio do balanço, sem cor e sem som; a rodada continua aberta para outra tentativa (`DD-39`). | vai e volta três vezes em 400 ms, até 10 px para cada lado ![](figuras/fb-erro.gif) |
| **TEMPO** | QUANDO: o limite de tempo está ligado. Uma barra fina, logo abaixo da instrução, esvazia da direita para a esquerda até o fim do tempo, sem número e sem cor de alerta; ela para na pausa e no acerto (`DD-38`). | esvazia em 15 s, em ritmo constante ![](figuras/fb-alvo.gif) |
| **ALVO** | QUANDO: o limite de tempo está ligado e acaba sem acerto. O alvo ganha um contorno que pulsa, e a próxima rodada abre. | pulsa por 1 s ![](figuras/fb-alvo.gif) |
| **PAUSA** | QUANDO: o botão de pausa é tocado. Os objetos somem, o relógio para, e a tela mostra retomar, sair e as chaves. | aparece na hora ![](figuras/fb-pausa.gif) |

## 8.2 Cores de estado

**Nenhuma cor carrega estado neste jogo** (`DD-35`). O acerto, o erro e o alvo mostrado se veem pela forma e pelo movimento, e nunca pela cor. As cores que aparecem são conteúdo: as seis da seção 2.2.

# 9 ARTE E DIREÇÃO VISUAL

## 9.1 Estilo, paleta e contraste

**Os menus emulam o visual dos pacotes CIATEC, e o laço de jogo tem o tema do jogo** (`DD-17`, seção 7.3). No laço de jogo: **formas grandes e planas, um cenário calmo, animações breves.** Evitam-se flashes, estímulos abruptos e elementos decorativos. Os valores das seis cores são da arte, com o contraste da seção 7.4; as cores das figuras deste documento são esquema.

## 9.2 Os objetos e a instrução

**As formas são planas e de contorno nítido**, nas seis cores (`DD-24`, `DD-28`).

**A instrução segue um modelo só** (`DD-27`): no modo só cor, "Encontre o \<cor\>"; no modo cor e forma, "Encontre o \<forma\> \<cor\>", com o artigo e a cor concordando com o gênero da forma — com as recomendadas, "Encontre a estrela vermelha", e azul, verde e laranja não mudam. O texto fica na tela a rodada inteira (`DD-27`): nada some sozinho.

## 9.3 Temas

**Um cenário só, calmo, o mesmo em todas as rodadas** (`DD-33`): tons suaves, pouco detalhe, nada que se mova, com as formas sobre ele. **O céu e o chão cobrem a tela inteira em qualquer proporção, e as peças do cenário ficam presas nos cantos de baixo** (`DD-41`): elas crescem pelo lado curto da tela, não se esticam quando ela gira, e, se a tela for estreita demais, a menos importante some primeiro — as flores, depois a cerca; a árvore fica. **O cenário não usa nenhuma das seis cores do jogo** (`DD-41`): céu azul-claro, chão e copa em verdes acinzentados, tronco marrom, contornos em verde mais escuro; uma flor vermelha ou um balão azul no fundo competiria com a instrução. É nele que entram os objetos do cotidiano — a criança ajuda a organizar as coisas do jardim —, que nunca são alvo e não competem com a instrução (`DD-11`). A arte final do jardim não existe (seção 15.3).

# 10 ÁUDIO

## 10.1 Princípio e categorias

**O jogo é jogável no mudo** (`DD-09`): o áudio é opcional, e a instrução em texto está sempre na tela. As categorias são a voz da instrução e os sons do retorno.

**Há duas chaves de som** (`DD-35`): o áudio inteiro, que leva junto os sons do retorno, e a voz da instrução.

## 10.2 Efeitos e voz

**Nenhum som é punitivo nem abrupto.** Com a voz ligada, a instrução é falada quando a rodada abre e a cada repetir (`DD-27`). O acerto tem um som curto e suave, de duas notas subindo (`DD-37`); o erro não tem som. Os sons e a voz ainda não existem (seção 15.3).

## 10.3 Música e temas

Não há música.

# 11 TECNOLOGIA E PLATAFORMA

**Unity 2D, para o navegador (WebGL), com Canvas e UI, objetos clicáveis e um gerador que sorteia as rodadas pelas regras de cada fase** (`DD-15`, `DD-44`). O registro é local, num arquivo gravado sozinho, sem câmera nem sensores (`DD-12`, `DD-13`, `DD-29`).

**O jogo não usa a plataforma CIATEC.** Todas as telas da seção 7.3 são do jogo, e as fases e as regras delas ficam nele.

**O visual dos menus é emulado, sem o M3Kit e sem o pacote da plataforma** (`DD-17`): o jogo reproduz com os próprios meios a moldura e as cores do tema claro, com o material da pasta `visual-menus`.

# 12 PARÂMETROS DE FASE E PROGRESSÃO

**Cada fase declara a condição das suas rodadas.** As faixas abaixo orientam quem ajusta as fases, e o jogo não as impõe: uma fase fora delas também é aceita. **A rodada que não cabe degrada, e não quebra** (`DD-21`): com mais objetos do que a tela comporta no tamanho pedido, o jogo monta a rodada com o que cabe e avisa que reduziu.

| Variável | Faixa de partida | Efeito na tarefa |
| --- | --- | --- |
| Número de objetos | 3 a 8 | Aumenta o conjunto de alternativas |
| Tamanho dos objetos | Grande, médio ou pequeno, o mesmo para todos os objetos da rodada (`DD-18`) | Altera a exigência visual-motora da seleção |
| Semelhança dos distratores | Distintos ou vizinhos (`DD-28`); o número deles é sempre o de objetos menos um (`DD-18`) | Torna o alvo mais difícil de distinguir |
| Modo | Só cor, ou cor e forma (`DD-24`) | Aumenta a complexidade da regra |
| Tempo limite | Desligado no padrão; ligado, 15 s (`DD-35`) | Acrescenta pressão temporal |
| Voz na instrução | Ligada ou desligada | Permite comparar configurações, se o estudo previr |

**O limite de tempo vem desligado** (`DD-04`): a velocidade não é requisito central da tarefa sem justificativa científica. Ligado, ele aparece num indicador que esvazia, sem número (`DD-38`, recomendação: uma barra fina): sem nada na tela, a criança não sabe que o tempo existe; com números, ele vira contagem regressiva.


# 13 TELEMETRIA E REGISTRO

**Registra-se o que acontece em cada rodada, para análise exploratória.** O registro é local (`DD-13`, `DD-29`). **O arquivo baixa sozinho, uma vez, quando a sessão termina** — no voltar da grade ao início —, para a pasta de downloads do computador. Não há outra cópia: se a aba fechar antes, a sessão se perde. Os nomes dos campos e o formato do arquivo se combinam com o orientador (seção 15.3). O tempo de cada evento é relativo ao início da sessão, que é o toque no Começar das configurações, e nunca data e hora do relógio.

**Nada identificável é registrado** (`DD-13`): todo evento leva o código pseudônimo que o mediador digita (`DD-34`), e nenhum registro traz nome, imagem, voz ou outro dado que identifique a criança.

## 13.1 O que é registrado

| Domínio | Evento | O que acompanha |
| --- | --- | --- |
| Rodada | A rodada começa | A fase, a cor-alvo, a forma-alvo no modo cor e forma, o número e o tamanho dos objetos, a semelhança dos distratores, o tempo limite e a voz (`DD-20`); a cor e a forma de cada objeto, na ordem, porque a rodada é sorteada e não se refaz depois (`DD-44`); e o instante em que os objetos aparecem e em que a voz termina |
| Rodada | Um objeto é selecionado | O objeto, se foi acerto ou erro, e o instante |
| Rodada | A rodada fecha | Correta, com erro, não resolvida ou omissão (seção 13.3) |
| Fase | A fase começa, e fecha | A fase; ao fechar, as corretas e se ela foi concluída (`DD-20`, `DD-43`) |
| Controles | Repetir, pausar, retomar, sair, e ligar ou desligar o áudio e a voz | Qual controle, e o novo estado (`DD-20`) |

**A condição e o conteúdo da rodada, o fim de cada fase e o uso dos controles entram no registro** (`DD-20`, `DD-44`): sem eles não se compara o desempenho por condição nem se sabe se os controles foram usados; e, como as rodadas são sorteadas, o conteúdo de cada uma só existe no registro.

## 13.2 O resumo e as grandezas derivadas

O arquivo traz também o resumo da sessão (`DD-29`), por fase jogada: as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas, as omissões, e se a fase foi concluída. São grandezas derivadas do registro, e identificadas como derivadas, como a proporção de acertos por fase. **Nenhuma delas é, por si só, medida diagnóstica ou clínica validada** (`DD-14`).

## 13.3 Definição das grandezas contáveis

| Grandeza | O que conta | O que não conta |
| --- | --- | --- |
| Rodada iniciada | Toda rodada de tarefa que começou, inclusive a interrompida pela saída | A rodada do tutorial |
| Rodada correta | A que acertou na primeira tentativa | A que acertou depois de um erro |
| Rodada com erro | A que teve erro antes do acerto | A que acabou sem acerto: essa é não resolvida ou omissão. As quatro categorias do fechamento — correta, com erro, não resolvida e omissão — se excluem |
| Acerto | A seleção do alvo | — |
| Seleção incorreta | A seleção de qualquer outro objeto | — |
| Omissão | A rodada que acabou sem nenhuma seleção, pelo tempo limite ou pela saída | — |
| Não resolvida | A rodada que acabou com erros e sem acerto, pelo tempo limite ou pela saída | — |
| Tempo de resposta | Do instante em que os objetos aparecem, ou do fim da voz, até o acerto: o registro guarda os dois instantes, e os pesquisadores escolhem a base (seção 15.2) | O tempo pausado (`DD-19`) |
| Fase | A fase da rodada, de 1 a 5 | — |

# 14 DECISÕES DE DESIGN

> **Os identificadores são estáveis para sempre**: decisão revista mantém o número, e decisão morta não tem o número reaproveitado. O mesmo vale para a seção 23. As decisões DD-01 a DD-16 vêm do documento-fonte, cuja seção vai indicada; da DD-17 em diante, de decisões do usuário e da triagem das lacunas de 14/10/2026.

**DD-01 — O alvo varia pela cor; cor e forma é extensão, introduzida em separado.** O modo inicial pede só a cor. A combinação de cor e forma entra deliberadamente, como mudança própria, para que a dimensão nova não se confunda com outra. A hipótese da fonte: instruções consistentes e dificuldade configurável podem tornar a tarefa mais compreensível. Documento-fonte, seção 4.1. Aplica-se às seções 2.2 e 9.2.

**DD-02 — Um alvo e uma instrução principal por rodada.** Os outros objetos são distratores, alternativas que não são alvo. Uma instrução só reduz a ambiguidade da tarefa. Documento-fonte, seções 4.1, 10.1 e 11.1. Aplica-se às seções 2.1 e 7.1.

**DD-03 — O erro informa, e não pune.** O retorno do erro é neutro, sem som punitivo, e a criança tenta de novo (`DD-23`). O erro deve gerar informação útil. Documento-fonte, seção 4.2 e `GP-02`. Aplica-se às seções 2.3 e 8.

**DD-04 — Sem pressão temporal por padrão.** O limite de tempo vem desligado, e a velocidade não é requisito central sem justificativa científica. Documento-fonte, seções 4.3 e 5.3. Aplica-se às seções 4 e 12.

**DD-05 — Recomenda-se mudar uma variável de dificuldade por vez.** É recomendação, e não regra, nas palavras do documento-fonte; entre fases vizinhas ela vale sempre (`G-03`). Mudanças graduais permitem identificar as condições de tarefa mais adequadas, e atribuir a diferença de desempenho à variável que mudou. Documento-fonte, seção 4.3. Aplica-se à seção 6.

**~~DD-06~~ — A progressão é oferecida, e não imposta; a adaptação automática é experimental.** Substituída pelo `DD-22` em 14/10/2026: a progressão passou a ser automática, por bancos, e a criança não a vê.

**DD-07 — O nível sai do desempenho, e não só do diagnóstico.** O diagnóstico de TEA, por si só, não determina a dificuldade; o mediador escolhe até que fase liberar, e o portão das fases ajusta pelo desempenho (`DD-43`). Documento-fonte, seções 2.3 e 11.3. Aplica-se às seções 1.3 e 5.2.

**DD-08 — O tutorial demonstra, e a instrução é repetível.** A demonstração pode reduzir dúvidas sobre o procedimento. A fonte previa três etapas, exemplo, prática e início; o exemplo e a prática se juntaram numa rodada só pelo `DD-36`. Documento-fonte, seção 4.4. Aplica-se às seções 3 e 4.

**DD-09 — O jogador controla os estímulos.** O áudio e a voz são desligáveis, nenhum efeito alterna claro e escuro mais de uma vez por segundo nem tem som abrupto, e a instrução em texto está sempre na tela. Revista em 14/10/2026: as animações reduzíveis da fonte saíram, porque os efeitos já são breves e simples; o `GP-04` fica com o áudio, a voz, a pausa e a ausência de flash. Documento-fonte, seções 4.2, 5.3, 7.3 e 10.2; a retirada, decisão do usuário de 14/10/2026. Aplica-se às seções 8 e 10.

**DD-10 — Pausa e saída estão sempre disponíveis.** A criança ou o mediador podem pausar ou interromper a qualquer momento, inclusive diante de desconforto observado. Documento-fonte, seções 5.3 e 11.2. Aplica-se às seções 2.3, 3 e 7.

**DD-11 — A narrativa é opcional e não compete com a instrução.** Documento-fonte, seção 7.2. Aplica-se à seção 9.3.

**DD-12 — Mouse ou toque, sem câmera nem sensores.** Documento-fonte, seções 2.2 e 7.4. Aplica-se às seções 1.2, 3 e 11.

**DD-13 — O registro é local e pseudônimo.** Nada identificável da criança é registrado, e o tempo de cada evento conta do início da sessão, como o exemplo do documento-fonte já fazia; os campos que a fonte sugere estão no registro de decisões (`decisoes-sgdd-v2.md`). Documento-fonte, seções 7.4, 12 e 12A. Aplica-se às seções 11 e 13.

**DD-14 — Os indicadores são descritivos, e não diagnósticos.** O resumo e as grandezas derivadas descrevem eventos de jogo; o jogo não diagnostica TEA nem mede isoladamente atenção, linguagem ou processamento visual. Documento-fonte, seções 3.3, 12A e 14. Aplica-se às seções 2.1, 5.3 e 13.

**DD-15 — Unity 2D, para o navegador, em janelas em retrato ou em paisagem.** O jogo roda no navegador (WebGL) e se reorganiza quando a janela é mais alta que larga ou mais larga que alta (`DD-40`). Revista duas vezes em 14/10/2026: a fonte e a triagem davam o desktop primeiro, em paisagem; o usuário passou o jogo para o celular, nas duas orientações; e depois para o navegador só, mais fácil de testar e validar, mantendo o layout das duas orientações. Documento-fonte, seção 2.2; as revisões, decisões do usuário de 14/10/2026. Aplica-se às seções 1.2, 7 e 11.

**DD-16 — Nenhum estado da interface se indica só pela cor.** Acerto, erro, fase bloqueada e fase concluída vêm sempre com contorno, movimento, ícone ou texto. A regra é da interface, e não da tarefa: achar a cor é o próprio jogo, e o pedido vem escrito e falado. Revista em 14/10/2026: o texto anterior, "a interface não transmite instrução só pela cor", parecia proibir o modo só cor. Documento-fonte, seção 10.1. Aplica-se à seção 7.1.

**DD-17 — Os menus emulam o visual dos pacotes CIATEC, e o laço de jogo tem o tema do jogo; sem o M3Kit e sem a integração.** O início, as configurações e a grade de fases reproduzem a moldura dos menus da plataforma e as cores do tema claro do M3Kit, mas o jogo não usa o M3Kit nem o pacote da plataforma; o tutorial, as rodadas, o retorno, a pausa e o cartão do fim da fase têm a arte do jogo. É a divisão dos jogos da plataforma, em que os menus são M3 e a partida é do jogo (`manifesto-ui.md` §4.1 e §12), e deixa o jogo pronto para entrar nela sem trocar de cara. Decisões do usuário de 14/10/2026. Aplica-se às seções 7.3, 9.1 e 11.

**DD-18 — Os distratores são todos os objetos menos o alvo, e todos os objetos têm o mesmo tamanho.** O número de distratores sai do número de objetos, e o que se configura neles é a semelhança com o alvo. O tamanho vale para a rodada inteira: se só o alvo mudasse de tamanho, o tamanho viraria pista. A fonte dava 0 a 7 distratores com um mínimo de 3 objetos, e falava em "tamanho do alvo" numa seção e em "tamanho dos objetos" noutra. Triagem das lacunas de 14/10/2026. Aplica-se às seções 2.1 e 12.

**DD-19 — A pausa para o relógio da rodada.** O tempo pausado não entra no tempo de resposta nem no tempo limite: a pausa existe para o conforto (`GP-04`), e contá-la puniria quem a usa. Triagem das lacunas de 14/10/2026. Aplica-se às seções 3, 5.2 e 13.

**DD-20 — O registro traz a condição de cada rodada, o fim de cada fase e o uso dos controles.** A hipótese `H-03` compara o desempenho por condição, e a `H-04` pergunta se os controles são encontrados e usados; sem esses eventos, nenhuma das duas se verifica. Triagem das lacunas de 14/10/2026; o fim da fase no lugar das trocas de banco desde o `DD-43`. Aplica-se à seção 13.

**DD-21 — A rodada que não cabe degrada, e não quebra.** O jogo monta a rodada com o que cabe e avisa que reduziu, em vez de recusá-la ou travar. É a regra do formato para conteúdo incompleto; pela mesma regra, as faixas da seção 12 orientam quem ajusta as fases e não são portão no jogo, porque um limite chutado trava justamente os testes que iriam medi-lo. Triagem das lacunas de 14/10/2026. Aplica-se à seção 12.

**~~DD-22~~ — A progressão é automática, por cinco bancos de rodadas, e a criança não a vê.** Substituída pelo `DD-43` e pelo `DD-44` em 14/10/2026: o usuário quis um sistema de fases no molde CIATEC, em que a criança vê a fase e avança por mérito, e rodadas sorteadas, para quem repete uma fase não decorar o alvo.

**DD-23 — Depois de um erro, a criança tenta de novo até acertar; com o limite de tempo ligado, até ele acabar.** A rodada só fecha no acerto, ou no fim do tempo, quando o jogo mostra qual era o alvo e segue. Rodada correta, para a progressão, é a que acertou na primeira tentativa, para que clicar em tudo até acertar não conte como acerto. Realiza a "opção de nova tentativa" do `GP-02`. Decisão do usuário de 14/10/2026. Aplica-se às seções 2.3, 5.2, 8.1 e 13.3.

**DD-24 — A tarefa usa formas geométricas planas: círculo, quadrado, triângulo e estrela; os objetos do cotidiano ficam no cenário.** Há dois modos, só cor e cor e forma, e nenhum só de forma. No modo só cor, as formas variam e não importam, e a instrução nomeia só a cor. A forma geométrica é um atributo limpo para a segunda dimensão, e quatro silhuetas bem distintas são nomeadas por crianças de 6 anos. Fecha a contradição da fonte entre o exemplo do círculo e os "objetos cotidianos" do domínio cultural. Decisões do usuário de 14/10/2026. Revista no mesmo dia: o conjunto das quatro formas virou recomendação, e o time escolhe dentro da regra (silhueta distinta, nome que a criança conhece), para deixar a criatividade dele livre. Aplica-se às seções 2.2, 9.2 e 9.3.

**DD-25 — Uma rodada é uma instrução, até o alvo ser achado.** É o que a progressão, o resumo e o exemplo de registro da fonte já supunham. O "20 a 60 segundos por rodada" da fonte saiu. Decisão do usuário de 14/10/2026. Aplica-se às seções 2.1 e 5.1.

**DD-26 — Não há vidas nem pontuação.** Vidas e pontos são mecânica de punição e de placar, contra o `GP-02` e a regra de só interromper a pedido. A "perda exagerada de pontos" da fonte saiu. Decisões do usuário de 14/10/2026. Aplica-se às seções 2.1 e 8.

**DD-27 — A instrução está sempre em texto, e é falada para quem não lê; nada some sozinho.** O texto segue um modelo só (seção 9.2) e fica na tela a rodada inteira. Com a voz ligada, ela fala quando a rodada abre e a cada repetir. A demonstração só existe no tutorial: nas rodadas ela mostraria a resposta. A "duração de exposição" da fonte saiu. A instrução continua verbal, que é o que a tarefa estuda. Decisões do usuário de 14/10/2026. Aplica-se às seções 1.3, 4, 9.2, 10.2 e 12.

**DD-28 — Seis cores-alvo, e a semelhança em dois graus.** Vermelho, azul, verde, amarelo, laranja e roxo: as quatro da fonte e duas que crianças de 6 anos já nomeiam. O distrator semelhante é uma cor vizinha, de outro nome, e não um tom da mesma cor: assim o alvo continua sendo o único objeto daquela cor. Decisões do usuário de 14/10/2026. Revista no mesmo dia: as seis cores e a tabela das vizinhas viraram recomendação, e o time escolhe dentro da regra e monta a tabela das cores que escolher. Aplica-se às seções 2.2 e 12.

**DD-29 — A criança não vê números; o resumo vai só para o arquivo, que baixa sozinho quando a sessão termina.** Números de erro na frente da criança viram nota. Os cartões do fim da fase não têm números; a tela de fim própria saiu em 14/10/2026, e o cartão da fase 5 diz que a criança terminou todas as fases. O arquivo se grava sem ninguém precisar lembrar, inclusive quando a sessão para no meio. Substitui a tela de resumo da fonte. Revista em 14/10/2026, quando o jogo passou ao navegador (`DD-15`): como uma página não grava numa pasta sozinha, o arquivo baixa automaticamente para a pasta de downloads, uma vez, no voltar da grade; um download por saída de fase seria vários por sessão, e o navegador pede permissão para isso. A cópia no armazenamento do navegador, que guardaria a sessão se a aba fechasse, também saiu: se o download não acontecer, a sessão se perde, e isso é aceito. Decisões do usuário de 14/10/2026. Aplica-se às seções 2.3, 5.3, 11 e 13.

**DD-30 — A pausa esconde os objetos e dá acesso às configurações.** Escondidos, os objetos não viram tempo de busca; e a pausa é o lugar de mudar o áudio e a voz no meio da sessão, sem botão a mais na tela da rodada. Decisão do usuário de 14/10/2026, e esconder os objetos, da triagem. Aplica-se às seções 3, 7.3 e 8.1.

**DD-31 — Só português, e só o tema claro.** A voz e as instruções são faladas, e cada idioma seria uma gravação inteira a mais. Revista em 14/10/2026: a tabela de tradução saiu, porque o jogo não terá outro idioma. Decisões do usuário de 14/10/2026. Aplica-se às seções 1.2 e 7.3.

**DD-32 — O tutorial abre em toda sessão, antes da primeira fase.** Sem conta, o jogo não sabe se a criança é nova, e o tutorial faz toda sessão começar igual. Ele não conta para o portão da fase nem para os indicadores. Revista em 14/10/2026: as 2 a 3 rodadas de prática desta decisão viraram uma rodada só (`DD-36`), e ela vem antes da primeira fase escolhida (`DD-43`). Decisões do usuário de 14/10/2026. Aplica-se às seções 4 e 5.1.

**DD-33 — Um cenário só, calmo, o mesmo em todas as rodadas.** Nada no fundo muda entre condições, e há uma arte só a produzir. Decisão do usuário de 14/10/2026. Aplica-se à seção 9.3.

**DD-34 — O mediador digita o código pseudônimo da criança.** As sessões da mesma criança se ligam pelo código, e a tabela que liga o código à criança fica fora do jogo, com a equipe. Decisão do usuário de 14/10/2026. Aplica-se às seções 7.3 e 13.

**DD-35 — Os valores de partida da triagem.** As medidas da seção 7.4, os tempos e as formas dos retornos da seção 8.1, o retorno sem cor, o tempo limite de 15 s (a barra dele, pelo `DD-38`), as 5 rodadas da fase e o portão de 4, os padrões das configurações, as duas chaves de som, o toque ignorado durante o retorno de acerto, e a confirmação ao sair. Foram atribuídos por proposta e aceitos pelo usuário em 14/10/2026, e se confirmam em playtest. Aplica-se às seções 3, 5.1, 7.3, 7.4, 8, 10 e 12.

**DD-36 — O tutorial é uma rodada só: ele explica o que fazer, a mãozinha mostra o toque, e a criança toca.** O exemplo que o jogo resolvia sozinho, e as práticas depois dele, eram três passos para ensinar um toque; no protótipo jogável, o exemplo rodando sem a criança pareceu o jogo se jogando. Juntar exemplo e prática numa rodada mantém a demonstração, que sustenta o `GP-01` e a `H-01`. A mãozinha se desliga nas configurações. Na segunda versão do protótipo, a rodada só falava a instrução comum e a mão não aparecia, e o tutorial "não explicou": a instrução da rodada passou a dizer "Vamos treinar! Toque no \<cor\>.", e a mão repete o gesto de tocar. Revista em 14/10/2026: a rodada do tutorial é sempre a mesma, com o alvo vermelho, para haver uma frase só a gravar e uma rodada só a montar. Decisões do usuário de 14/10/2026, sobre o protótipo. Aplica-se às seções 4, 5.1 e 7.3.

**DD-37 — O acerto se celebra, e a troca de rodada é suave.** No protótipo, o contorno sozinho e a rodada nova surgindo de uma vez não davam a sensação de ter vencido a rodada. O acerto ganha brilhos claros e um som curto e suave; a troca faz as formas saírem e as novas entrarem, em 250 ms cada. Sem flash e sem cor de estado (`DD-35`). Decisão do usuário de 14/10/2026, sobre o protótipo. Aplica-se às seções 8.1 e 10.2.

**DD-38 — O tempo limite aparece numa barra discreta.** Uma barra fina sob a instrução esvazia nos 15 s, sem número e sem cor de alerta, e para na pausa e no acerto. No protótipo, sem nada na tela, o tempo pareceu não funcionar: a criança não tem como saber que ele existe. Substitui o "sem relógio na tela" do `DD-35`. Decisão do usuário de 14/10/2026, sobre o protótipo. Aplica-se às seções 8.1 e 12.

**DD-39 — O erro balança de leve.** O objeto errado balança como um "não" e esmaece no meio do balanço, em 400 ms, sem cor, sem som e sem voz. No protótipo, só esmaecer não dizia que a seleção estava errada. Continua neutro (`DD-03`): nada se perde e a rodada segue aberta. Decisão do usuário de 14/10/2026, sobre o protótipo. Aplica-se à seção 8.1.

**DD-40 — O layout se mede em dp e se reorganiza com a orientação.** O palco fixo de 1280 × 720 reduzido para caber, do protótipo, deixava o jogo numa faixa de 30 % da tela em retrato e os botões com 32 px em paisagem. Agora os botões e o texto têm medida fixa em dp, e os objetos se medem pelo espaço que sobra: o grande é o maior que cabe com 8 objetos na orientação atual, para que o tamanho, que é uma variável da tarefa (`DD-18`), não mude de uma fase para outra. A posição não vem da rodada, que traz só a ordem dos objetos. O cartão inteiro da instrução repete; todo objeto e todo botão reagem ao botão pressionado; e as configurações rolam quando a janela não as comporta, com o Começar fixo embaixo. Revisão de UI/UX de 14/10/2026 (`ui-celular.md`), aprovada pelo usuário; revista no mesmo dia, quando o arranjo da rodada e a forma dos efeitos viraram recomendação, com os mínimos como regra (a interface do laço de jogo pode diferir das outras telas, como nos jogos CIATEC), e quando o jogo passou ao navegador (`DD-15`): saíram o recorte da câmera e a barra de gestos, e o dedo pousado virou o botão pressionado. Aplica-se às seções 3, 6, 7.3 e 7.4.

**DD-41 — O cenário cobre a tela, e as peças dele ficam nos cantos de baixo.** O céu e o chão se estendem em qualquer proporção; a cerca, a árvore e as flores ficam presas nos cantos de baixo, crescem pelo lado curto e não se esticam quando a tela gira; numa tela estreita, somem as flores e depois a cerca. Assim o cenário nunca se deforma e nunca disputa o meio da tela com as formas. **O mesmo jardim fica por trás dos menus**: o painel da moldura é translúcido para a ilustração de fundo do jogo aparecer, como no menu de fases CIATEC (`manifesto-ui.md` §12), e é o jardim que aparece; a barra de cima continua opaca. Revista em 14/10/2026, a pedido do usuário: o jardim passou a aparecer também nos menus, e depois ficou menos apagado, sem usar nenhuma das seis cores do jogo, para não competir com a instrução. Revisão de UI/UX de 14/10/2026, aprovada pelo usuário. Aplica-se às seções 7.3 e 9.3.

**~~DD-42~~ — A vibração no acerto, desligada no padrão.** Retirada em 14/10/2026: o jogo passou ao navegador (`DD-15`), e os efeitos já são simples; o acerto fica com o contorno, os brilhos e o som.

**DD-43 — Cinco fases em cards, de 5 rodadas; passa com 4 de primeira, e quem não passa tenta de novo.** A grade segue o menu de fases dos pacotes CIATEC: um card por fase, com o número e uma miniatura; a dificuldade muda de um card para o outro e fica parada dentro dele. A criança passa de fase acertando de primeira 4 das 5 rodadas; não passando, o cartão oferece tentar de novo ou voltar às fases, e ela não avança. As fases liberadas no começo são escolhidas pelo mediador (padrão: só a 1), e nada se guarda entre sessões. O tutorial vem antes da primeira fase. A adaptação aos erros passa a ser entre fases: o portão não deixa subir antes da hora, na grade a criança pode voltar a uma fase já liberada, e cada fase, com uma dificuldade só, se compara com a mesma fase noutra sessão. Substitui o `DD-22`. Revista em 14/10/2026: a descida para a fase anterior, depois de duas tentativas sem passar, saiu, para simplificar. Decisões do usuário de 14/10/2026. Aplica-se às seções 2.3, 5, 6, 7.3 e 13.

**DD-44 — As rodadas se sorteiam na hora, pelas regras da fase, sem semente.** A fase guarda regras, e não rodadas prontas: a criança que repete uma fase vê rodadas novas. O sorteio respeita as garantias da seção 23.10 e não repete a cor-alvo em rodadas seguidas. Sem semente, a sessão não se refaz depois, e por isso o registro grava o conteúdo de cada rodada. Substitui as rodadas prontas do `DD-22`. Decisão do usuário de 14/10/2026. Aplica-se às seções 6, 11 e 13.

## 14.1 Rastreio

A coluna de princípio aponta os princípios hipotéticos da seção 17, quando a decisão realiza um deles; a de hipótese, as da seção 21.

| Decisão | Guiding Principle | Hipótese de validação |
| --- | --- | --- |
| DD-01 · Alvo por cor; cor e forma em separado | GP-01, GP-03 (pendente validação PPI) | — |
| DD-02 · Um alvo e uma instrução por rodada | GP-01 (pendente validação PPI) | — |
| DD-03 · O erro informa, e não pune | GP-02 (pendente validação PPI) | H-02 |
| DD-04 · Sem pressão temporal por padrão | GP-03 (pendente validação PPI) | — |
| DD-05 · Uma variável por vez, recomendada | GP-03 (pendente validação PPI) | H-03 |
| ~~DD-06 · Progressão oferecida~~ (substituída pelo `DD-22`) | — | — |
| DD-07 · Nível pelo desempenho, não só pelo diagnóstico | [sem princípio declarado] | — |
| DD-08 · O tutorial demonstra | GP-01 (pendente validação PPI) | H-01 |
| DD-09 · Controle dos estímulos | GP-04 (pendente validação PPI) | H-04 |
| DD-10 · Pausa e saída sempre | GP-04 (pendente validação PPI) | — |
| DD-11 · Narrativa opcional | [sem princípio declarado] | — |
| DD-12 · Mouse ou toque | [sem princípio declarado] | — |
| DD-13 · Registro local e pseudônimo | [sem princípio declarado] | — |
| DD-14 · Indicadores descritivos | [sem princípio declarado] | — |
| DD-15 · Navegador, em retrato e em paisagem | [sem princípio declarado] | — |
| DD-16 · Nenhum estado só pela cor | [sem princípio declarado] | — |
| DD-17 · Menus emulam o visual dos pacotes; laço no tema do jogo | [sem princípio declarado] | — |
| DD-18 · Distratores são o resto; mesmo tamanho para todos | [sem princípio declarado] | — |
| DD-19 · A pausa para o relógio | GP-04 (pendente validação PPI) | — |
| DD-20 · Registro da condição, do fim da fase e dos controles | [sem princípio declarado] | H-03, H-04 |
| DD-21 · Rodada que não cabe degrada | [sem princípio declarado] | — |
| ~~DD-22 · Progressão automática por cinco bancos~~ (substituída pelo `DD-43` e pelo `DD-44`) | — | — |
| DD-23 · Tentar de novo até acertar | GP-02 (pendente validação PPI) | H-02 |
| DD-24 · Formas geométricas na tarefa, cotidiano no cenário | [sem princípio declarado] | — |
| DD-25 · Rodada de uma instrução | [sem princípio declarado] | — |
| DD-26 · Sem vidas nem pontuação | GP-02 (pendente validação PPI) | — |
| DD-27 · Instrução em texto e voz; nada some | GP-01 (pendente validação PPI) | — |
| DD-28 · Seis cores, semelhança em dois graus | [sem princípio declarado] | — |
| DD-29 · Sem números; resumo no arquivo | [sem princípio declarado] | — |
| DD-30 · Pausa esconde os objetos e tem as configurações | GP-04 (pendente validação PPI) | H-04 |
| DD-31 · Só português, só tema claro | [sem princípio declarado] | — |
| DD-32 · Tutorial em toda sessão | GP-01 (pendente validação PPI) | H-01 |
| DD-33 · Um cenário calmo | GP-04 (pendente validação PPI) | — |
| DD-34 · Código digitado pelo mediador | [sem princípio declarado] | — |
| DD-35 · Valores de partida da triagem | [sem princípio declarado] | — |
| DD-36 · Tutorial de uma rodada, com a mãozinha | GP-01 (pendente validação PPI) | H-01 |
| DD-37 · Acerto celebrado, troca suave | GP-02 (pendente validação PPI) | H-02 |
| DD-38 · Tempo numa barra discreta | GP-01 (pendente validação PPI) | — |
| DD-39 · O erro balança de leve | GP-02 (pendente validação PPI) | H-02 |
| DD-40 · Layout em dp, nas duas orientações | GP-04 (pendente validação PPI) | — |
| DD-41 · Cenário que cobre a tela, peças nos cantos | GP-04 (pendente validação PPI) | — |
| ~~DD-42 · Vibração no acerto~~ (retirada) | — | — |
| DD-43 · Cinco fases em cards, com portão | GP-03 (pendente validação PPI) | H-03 |
| DD-44 · Rodadas sorteadas pelas regras da fase | [sem princípio declarado] | — |

A decisão sem princípio não é defeito do documento: indica escolha da equipe sem evidência de usuário, e é isso que a métrica de cobertura do GLIDE mede.

# 15 LACUNAS E DECISÕES PENDENTES

## 15.1 Por decisão não tomada

Nenhuma. A ordem das rodadas e o banco que acabava antes da sessão deixaram de existir com o sorteio (`DD-44`).

## 15.2 Por ausência de PPI, e dos pesquisadores

| Lacuna | O que ela impede | O que desbloqueia |
| --- | --- | --- |
| Objetivo científico amplo, sem variável primária | Definir a pergunta de pesquisa e o desfecho principal | A equipe de pesquisa |
| **A base do tempo de resposta**: os objetos aparecerem ou o fim da voz | O tempo de resposta e a mediana do resumo; o registro guarda os dois instantes até lá | Os pesquisadores, com o plano de análise |
| **A criança que não distingue cores.** A tarefa é de cor, e a regra da cor que não é a única pista vale só para a interface | Incluir crianças com discromatopsia, ou excluí-las com critério | Os pesquisadores da saúde: critério de inclusão, ou outra pista para a cor |
| Princípios e personas hipotéticos | Ligar as decisões da seção 14 a evidência de usuário | Uma consulta participativa apropriada (PPI) |
| Validade dos indicadores | Usar acertos e tempos como medida: dependem de muitos fatores | A validade de conteúdo e o plano de análise |
| Acessibilidade não testada | Saber se a tarefa é usável e confortável | Testes formativos com a ética aplicável |
| A faixa etária de 6 a 10 anos | Fixar o público | O PPI e o projeto de pesquisa |
| **Os valores de partida** (`DD-35`) | Fixar medidas, tempos e padrões | Playtest |

## 15.3 Dependências fora deste documento

| Pendência | Como se resolve, e de quem depende | Onde trava |
| --- | --- | --- |
| **Governança de dados.** O uso com crianças requer salvaguardas | Consentimento, acesso, retenção e descarte, e o formato do código pseudônimo que impede digitar um nome; do responsável pelo projeto | Seção 13 |
| **A plataforma CIATEC.** Esta versão é autônoma | Decidir se o jogo entra na plataforma; se entrar, a entrada, as fases, o resultado e o registro em fluxo vêm do pacote, e as seções 7.3, 11 e 13 se reescrevem | Seções 7.3, 11 e 13 |
| **O arquivo da sessão e as regras das fases**: o formato e onde as regras de cada fase moram | O orientador, com o time | Seções 6, 12 e 13 |
| **O ajuste das cinco fases** | A curadoria e o playtest, com as garantias da seção 23.10 | Seção 6 |
| **O pesquisador responsável** | A equipe do projeto | A capa |
| **A arte e os sons**: a escolha das formas e das cores (seção 2.2), os valores das seis cores, a arte final do jardim, a fonte, as cores e as medidas do laço de jogo (o cartão da instrução, os botões de pausar e sair, os cartões do fim da fase e do tutorial), os ícones, a voz da instrução e os sons do retorno | O time, pelas regras e recomendações deste documento e com o contraste da seção 7.4, com a aprovação do orientador; a voz, gravada por uma pessoa | Seções 2.2, 7.3, 8, 9 e 10 |

# 16 OBJETIVO TERAPÊUTICO E EDUCACIONAL

> As seções deste bloco pertencem ao ciclo de PPI e são preenchidas pelos pesquisadores. Estão agrupadas aqui para que a camada de design leia contínua. Neste exercício, o documento-fonte já propõe o conteúdo delas; ele entra marcado como proposta, e não como evidência.

## 16.1 Objetivo Terapêutico Principal

> ⚠️ **Proposto pelo documento-fonte do exercício, sem PPI.**

Investigar a viabilidade de uma tarefa lúdica de busca visual e seleção de estímulos, registrando a precisão, o tempo de resposta e os padrões de interação.

## 16.2 Objetivos Secundários

> ⚠️ **Propostos pelo documento-fonte do exercício, sem PPI.**

- Oferecer prática em seguir instruções simples e identificar atributos visuais.
- Permitir configurar em separado o número de objetos e a semelhança entre eles.
- Oferecer retorno claro e previsível, sem punição por erro.
- Registrar eventos temporais para análise exploratória.
- Permitir controlar os estímulos sonoros e a pressão temporal (as animações reduzíveis saíram pelo `DD-09`).

## 16.3 Fora do Escopo

Decisão de escopo, e não de evidência, e por isso preenchida desde já. O Caça às Cores **não** se propõe a:

- diagnosticar TEA;
- medir isoladamente atenção, linguagem ou processamento visual: acertos e tempos de resposta dependem da compreensão da instrução, da familiaridade com a tarefa, da visão, da motricidade, da fadiga, da motivação e de outras variáveis;
- presumir efeito terapêutico: o protótipo estuda a interação.

# 17 GUIDING PRINCIPLES

> ⚠️ **Princípios hipotéticos do exercício, pendentes de validação no PPI.** Não foram derivados de PPI real, e devem ser revistos com crianças, famílias e profissionais.

| GP | Princípio e objetivo de design | Funcionalidades |
| --- | --- | --- |
| GP-01 | A instrução e a ação esperada são claras, para reduzir a ambiguidade da tarefa | Instrução curta; exemplo visual; botão para repetir |
| GP-02 | O erro gera informação útil, e não punição, para facilitar a compreensão do resultado | Retorno neutro; opção de nova tentativa |
| GP-03 | A complexidade é ajustável gradualmente, para evitar mudanças abruptas de dificuldade | Configurar o número de itens e de distratores |
| GP-04 | O jogador controla os estímulos e as pausas, para apoiar o conforto e a participação | Áudio opcional; animações breves, sem flash; pausa e saída |

As decisões que os realizam estão na tabela de rastreio da seção 14.1. As dezenove decisões sem princípio declarado são o achado que a métrica de cobertura procura.

# 18 EXPERIÊNCIA PRETENDIDA

> ⚠️ **Proposta do documento-fonte, a validar com as crianças.** Dizer o que a criança sente exige ter ido até ela.

Uma tarefa clara, previsível e alcançável, com a oportunidade de repetir e aprender a regra, sem sobrecarga visual nem pressão temporal desnecessária.

# 19 MAPEAMENTO LM-GM

| Objetivo investigativo | Mecânica e operacionalização | Origem |
| --- | --- | --- |
| Observar a seleção do alvo | Busca visual: selecionar o objeto que corresponde à instrução | GP-01 (pendente validação PPI) |
| Observar erros e correções | Retorno neutro e nova tentativa: registrar a seleção, o erro e as tentativas seguintes | GP-02 (pendente validação PPI) |
| Manipular a complexidade | Fases em cards: cada uma difere da vizinha numa dimensão | GP-03 (pendente validação PPI) |
| Permitir a interação ajustável | Configurações acessíveis, também na pausa: controlar o áudio e a voz | GP-04 (pendente validação PPI) |

# 20 PERSONAS E REQUISITOS DERIVADOS

> ⚠️ **Proto-personas compostas e hipotéticas**, criadas pelo documento-fonte só para orientar o exercício. Não representam participantes reais nem características universais de crianças com TEA. Base declarada: o raciocínio do exercício, e não o PPI. Status de todas: hipotética, não validada.

| Persona | Requisitos derivados | Princípio |
| --- | --- | --- |
| A — prefere instruções demonstradas | O exemplo visual antes do início; a instrução repetível; a prática sem cronômetro | GP-01, GP-03 |
| B — prefere poucos estímulos | Cenário calmo; áudio desligável; animações breves e sem flashes | GP-04 |
| C — precisa de mais tempo para responder | Sem limite de tempo obrigatório; alvos grandes; a instrução repetível | GP-01, GP-04 |

O que o PPI precisará responder: se estes três perfis existem no público, se há outros que eles não cobrem, e se os requisitos derivados atendem a quem os tem.

# 21 HIPÓTESES PARA VALIDAÇÃO

**Hipótese principal:** o documento-fonte não formula uma; o objetivo principal é de viabilidade (seção 16.1), e a variável primária está em aberto (seção 15.2).

| Hipótese | GP | Verificação futura |
| --- | --- | --- |
| **H-01** A demonstração visual ajuda a compreender o procedimento da rodada | GP-01 | Teste de usabilidade, com critérios definidos antes |
| **H-02** O retorno neutro e consistente é compreendido sem ambiguidade sobre o resultado | GP-02 | Observação e perguntas de compreensão apropriadas |
| **H-03** Aumentar uma variável de dificuldade por vez permite caracterizar melhor o desempenho por condição | GP-03 | Estudo de usabilidade e desempenho com desenho definido antes |
| **H-04** Os controles de áudio e de voz são encontrados e usados quando necessários | GP-04 | Teste de acessibilidade |

O documento-fonte traz também uma hipótese de design por mecânica, que fica como razão das decisões e não como hipótese de estudo: instruções consistentes e dificuldade configurável podem tornar a tarefa mais compreensível (`DD-01`); um retorno previsível pode apoiar a compreensão e a continuidade (`DD-03`); mudanças graduais facilitam identificar as condições de tarefa mais adequadas (`DD-05`); a demonstração pode reduzir dúvidas sobre o procedimento (`DD-08`).

Nenhuma hipótese foi testada. A amostra, os métodos, as variáveis e os critérios de sucesso se definem antes de qualquer estudo com participantes.

# 22 EQUIVALÊNCIA COM O TEMPLATE GLIDE

| Neste documento | Documento-fonte (template v1.0) | Observação |
| --- | --- | --- |
| Capa | §1 Identificação | Os campos da identificação são o que uma capa mostra |
| Seção 1 Conceito | §2 Conceito | — |
| Seção 2 Mecânicas | §4.1 e §7.1 | A mecânica do Tetrad repetia a §4.1, e foi fundida |
| Seção 3 Controles | Dispersos em §2.2, §10 | Promovida a seção própria |
| Seção 4 Tutoriais | §4.4 Onboarding | — |
| Seção 5 Dinâmicas | §5 e §11.2 | Os critérios de progressão foram para a 5.2, e viraram fases com portão |
| Seção 6 Level Design | §11.3 | Não existia como seção; as três faixas viraram cinco fases |
| Seção 7 UI/UX | §10 | A tabela de medidas foi acrescentada |
| Seção 8 Feedback | §4.2 | Promovida, com a tabela de efeitos e as cores de estado |
| Seção 9 Arte | §7.2 e §7.3 do Tetrad | A Story virou o tema da 9.3 |
| Seção 10 Áudio | Disperso | — |
| Seção 11 Tecnologia | §7.4 do Tetrad | — |
| Seção 12 Parâmetros | §11.1 | — |
| Seção 13 Telemetria | §12A | Ficaram o princípio e os eventos; os nomes dos campos e o exemplo de registro foram para o registro de decisões, para o documento técnico |
| Seção 14 Decisões | Dispersas por §4 | Reunidas e numeradas, com o rastreio |
| Seção 15 Lacunas | §13 | Somam-se as lacunas achadas na passagem ao formato; a maioria foi decidida na triagem |
| Seção 16 Objetivo | §3 | — |
| Seção 17 Guiding Principles | §3A | — |
| Seção 18 Experiência | §6 | — |
| Seção 19 LM-GM | §8 | — |
| Seção 20 Personas | §9 | — |
| Seção 21 Hipóteses | §13A | — |
| Seção 23 Requisitos | Não existia | O requisito mora junto do texto que o justifica |
| — | §12 Requisitos técnicos consolidados | **Removida**: é backlog; o conteúdo dela está na seção 23 |
| — | §14 Resumo de sessão simulado | **Removida**: os indicadores estão na 13.2; os valores fictícios, no registro de decisões |
| — | §15 Escopo do MVP | **Removida**: é backlog; cada item está numa seção acima |

# 23 REQUISITOS VERIFICÁVEIS

Nenhum requisito abaixo acrescenta decisão. Cada linha é uma afirmação já feita numa seção acima, reescrita na forma que um teste consegue conferir; se não dá para escrever o teste, não entra. Os identificadores são estáveis para sempre: requisito revisado mantém o número, e requisito aposentado fica riscado, com o motivo, e não tem o número reaproveitado. Os acrescentados depois entraram na subseção a que pertencem, com o número seguinte, e por isso a ordem dentro da tabela não é a numérica.

> **Nota de prefixo.** `RT` identifica requisito transversal, que vale para o jogo inteiro. Os dois modos dividem quase tudo, e o que é de um só está dito no próprio requisito; por isso não há família por modalidade. `G` identifica a garantia que o sorteio das rodadas precisa entregar para os requisitos poderem valer, e que não é requisito do jogo. O documento técnico continua a numeração `RT`: cada identificador é definido uma vez só, no documento a que pertence.

## 23.1 A rodada — decidido nas seções 2 e 6

| ID | Requisito |
| --- | --- |
| RT-01 | Toda rodada apresenta uma instrução e um conjunto de objetos selecionáveis |
| RT-02 | Em toda rodada, exatamente um objeto satisfaz a instrução, e os outros são distratores |
| RT-03 | No modo só cor, a instrução nomeia só uma cor, e o alvo é o único objeto daquela cor |
| RT-73 | No modo só cor, as formas dos objetos de uma rodada se sorteiam entre as quatro, e não são todas iguais |
| RT-04 | No modo cor e forma, a instrução nomeia uma forma e uma cor, e o alvo é o único objeto que tem as duas |
| RT-05 | O modo cor e forma só aparece nas fases que o usam |
| RT-59 | As fases podem usar o modo cor e forma |
| RT-72 | Os objetos são quatro formas planas, que se distinguem pela silhueta e que uma criança de 6 anos sabe nomear |
| RT-74 | As cores dos objetos são seis, com nomes diferentes entre si, e nenhuma delas aparece no cenário |
| RT-75 | A semelhança dos distratores tem dois graus, vizinhos e distintos, pela tabela das vizinhas e das distintas das cores escolhidas (seção 2.2); no modo só cor, todo distrator tem outra cor, com outro nome, e no modo cor e forma a semelhança vale para os distratores de outra cor |
| RT-06 | Selecionar o objeto que satisfaz a instrução conta como acerto, e selecionar qualquer outro conta como seleção incorreta |
| RT-07 | O número de objetos da rodada é o da fase, e os distratores são todos eles menos o alvo |
| RT-08 | O tamanho dos objetos é o da fase — grande, médio ou pequeno — e todos os objetos da rodada têm o mesmo tamanho |
| RT-09 | A semelhança dos distratores é a da fase, e não muda o número de objetos |
| RT-10 | O jogo aceita qualquer regra de fase com a forma certa, sem recusá-la por estar fora da faixa da seção 12 |
| RT-71 | Uma rodada que a tela não comporta é montada com o que cabe, e o jogo avisa que reduziu |
| RT-76 | A instrução e os objetos ficam na tela até a rodada fechar |

## 23.2 Controles — decidido na seção 3

| ID | Requisito |
| --- | --- |
| RT-11 | Um clique ou um toque sobre um objeto o seleciona |
| RT-12 | A seleção não exige arrastar, segurar nem duplo clique |
| RT-13 | O jogo não usa câmera, microfone nem outro sensor |
| RT-77 | Durante o retorno de acerto, tocar num objeto não faz nada |
| RT-78 | Com a voz falando, tocar num objeto o seleciona |

## 23.3 Tutorial — decidido na seção 4

| ID | Requisito |
| --- | --- |
| RT-14 | Com a mãozinha ligada, a mãozinha vai até o alvo da rodada do tutorial e repete o gesto de tocar até a criança tocar, e só o toque da criança seleciona |
| RT-114 | A instrução da rodada do tutorial é "Vamos treinar! Toque no \<cor\>.", em texto e em voz, e a rodada é sempre a mesma: três formas grandes, de cores distintas, com o alvo sempre da mesma cor |
| RT-79 | Com a mãozinha desligada, a rodada do tutorial não tem mãozinha |
| RT-15 | O tutorial tem uma rodada só, que a criança resolve |
| RT-16 | A rodada do tutorial não tem limite de tempo |
| RT-80 | A rodada do tutorial não conta para o portão da fase nem para os indicadores |
| RT-17 | Depois da rodada do tutorial, um cartão oferece começar a fase |
| RT-81 | O tutorial abre uma vez por sessão, antes da primeira fase jogada |

## 23.4 Sessão e progressão — decidido nas seções 5 e 12

| ID | Requisito |
| --- | --- |
| RT-18 | A tela de configurações vem depois do início e antes do tutorial |
| RT-19 | Tocar num card liberado da grade começa aquela fase |
| RT-82 | Há cinco fases, da 1 à 5, e cada uma difere da anterior numa variável só |
| RT-83 | A grade abre com as fases liberadas até a escolhida nas configurações, e o padrão é só a 1; nada se guarda entre sessões |
| ~~RT-84~~ | ~~A sessão tem 10 rodadas de tarefa no padrão, e o número se configura~~ — aposentado: a sessão não tem número fixo de rodadas; a fase tem 5 (`RT-129`) |
| RT-20 | O limite de tempo vem desligado |
| RT-58 | O limite de tempo pode ser ligado na configuração, e ligado vale 15 s no padrão |
| RT-85 | Rodada correta é a que acertou na primeira tentativa, e só ela conta para o portão; com erro, não resolvida e omissão não contam |
| RT-129 | Cada fase tem 5 rodadas |
| RT-130 | Com 4 rodadas corretas das 5, a fase é concluída, ganha um ✓ na grade, e a seguinte é liberada |
| RT-131 | Com menos de 4 corretas, a fase não é concluída, e o cartão oferece "Tentar de novo", com rodadas novas, e "Voltar às fases"; o jogo não leva a outra fase |
| ~~RT-132~~ | ~~Na segunda vez seguida sem passar numa fase acima da 1, o jogo leva à fase anterior, e, concluída ela, oferece a fase difícil de novo~~ — aposentado: quem não passa tenta de novo, sem descida (`DD-43`) |
| RT-133 | Concluída a fase 5, o cartão do fim da fase diz "Você terminou todas as fases!" e só oferece voltar à grade |
| ~~RT-21~~ | ~~Depois de 3 rodadas corretas seguidas, o jogo passa ao banco seguinte, sem perguntar~~ — aposentado: a progressão é por fases (`DD-43`) |
| ~~RT-22~~ | ~~Aceitar a oferta de avanço muda uma variável só~~ — aposentado: não há oferta (`DD-22`) |
| ~~RT-23~~ | ~~Depois de 2 rodadas com erro seguidas, o jogo passa ao banco anterior, sem perguntar~~ — aposentado: a progressão é por fases (`DD-43`) |
| ~~RT-86~~ | ~~No banco muito difícil as rodadas corretas não sobem, e no muito fácil as com erro não descem~~ — aposentado: a progressão é por fases (`DD-43`) |
| ~~RT-87~~ | ~~As contagens de rodadas corretas e com erro zeram a cada troca de banco~~ — aposentado: a progressão é por fases (`DD-43`) |
| ~~RT-60~~ | ~~Aceitar a configuração mais simples deixa a dificuldade mais fácil~~ — aposentado: não há oferta (`DD-22`) |
| ~~RT-24~~ | ~~Aceitar a configuração mais simples não altera nenhum indicador já contado~~ — aposentado: não há oferta (`DD-22`) |
| ~~RT-25~~ | ~~Fora das trocas de banco, a rodada seguinte é do mesmo banco~~ — aposentado: a progressão é por fases (`DD-43`) |
| RT-26 | A dificuldade só muda de uma fase para outra; dentro da fase ela não muda |
| ~~RT-88~~ | ~~Nenhuma tela de jogo mostra o banco, e a troca de banco não tem retorno visível~~ — aposentado: a criança vê a fase na grade (`DD-43`) |
| RT-27 | Ao fim de cada fase, um cartão sem números diz se ela foi concluída; concluída, leva à fase seguinte ou à grade (a fase 5, só à grade: `RT-133`), e não concluída, a tentar de novo ou à grade |
| RT-28 | O arquivo da sessão traz o resumo por fase jogada: as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas, as omissões, e se a fase foi concluída *(o tempo de resposta depende da seção 15.2)* |
| RT-29 | Nem os cartões de fase nem o resumo trazem interpretação clínica ou diagnóstico |
| RT-89 | O jogo não tem vidas nem pontuação |

## 23.5 Interface e acessibilidade — decidido nas seções 7 e 9

| ID | Requisito |
| --- | --- |
| RT-30 | A rodada mostra uma instrução só |
| RT-31 | A instrução da rodada está sempre na tela em texto, com o áudio ligado ou desligado |
| RT-90 | No modo só cor a instrução é "Encontre o \<cor\>"; no modo cor e forma, "Encontre o \<forma\> \<cor\>", com o artigo e a cor concordando com o gênero da forma |
| RT-32 | O cartão que repete a instrução e os botões de pausar e sair estão em toda tela de jogo, inclusive no tutorial |
| RT-33 | Nenhum estado da interface — acerto, erro, fase bloqueada ou concluída — se indica só pela cor |
| RT-34 | Os objetos de uma rodada não se sobrepõem |
| RT-35 | A tela de configurações tem o código da criança, as fases liberadas, o tempo limite, o áudio, a voz e a mãozinha do tutorial |
| RT-91 | Os padrões das configurações são fases liberadas até a 1, tempo limite desligado, áudio ligado, voz ligada e mãozinha ligada |
| RT-61 | Os valores das seis cores se configuram num lugar só, sem mexer no código |
| RT-36 | O fluxo segue a ordem da seção 7.3: início, configurações, fases, tutorial (uma vez), fase, cartão do resultado, e de volta às fases ou à fase seguinte |
| RT-63 | O início, as configurações e a grade de fases têm a barra e o painel da moldura dos menus CIATEC, com as cores e as medidas da pasta `visual-menus` |
| RT-134 | A grade mostra as cinco fases em cards de 140 dp ou mais: a liberada com a borda acesa, a concluída com ✓, a bloqueada com cadeado |
| RT-135 | O card mostra o número da fase, uma miniatura do que ela tem e uma linha curta para o mediador |
| RT-136 | Tocar num card bloqueado não abre a fase e diz qual fase passar para liberá-la |
| RT-137 | O voltar da barra da grade volta ao início |
| RT-66 | O jogo não depende do M3Kit nem do pacote da plataforma |
| RT-64 | A barra das telas de menu traz o símbolo e a marca CIATEC |
| RT-65 | O tutorial, as rodadas, o retorno e a pausa têm o tema do jogo, e não o M3 |
| RT-92 | Os menus só têm o tema claro |
| RT-93 | Os textos estão em português |
| RT-94 | Todas as rodadas usam o mesmo cenário, e nada nele se move |
| RT-95 | O objeto grande tem o maior diâmetro que cabe com 8 objetos no arranjo da orientação atual, até 200 dp, e o médio e o pequeno têm 80 % e 60 % dele |
| RT-96 | Dois objetos ficam a pelo menos 16 dp um do outro |
| RT-97 | Os botões de pausar e sair têm pelo menos 56 dp, o cartão da instrução pelo menos 56 dp de altura, e o texto da instrução pelo menos 26 dp |
| RT-118 | O jogo roda no navegador, em janelas em retrato (mais altas que largas) e em paisagem (mais largas que altas) |
| RT-119 | Em retrato e em paisagem, a instrução, os botões de pausar e sair e todos os objetos ficam visíveis, e os objetos não se sobrepõem nem ficam sob os botões |
| RT-120 | Redimensionar a janela no meio da rodada reorganiza a tela sem mudar a rodada, as tentativas nem o tempo |
| RT-121 | Todo objeto e todo botão reagem ao botão pressionado em até 80 ms, antes de soltar: o objeto afunda, o botão escurece |
| RT-122 | Tocar em qualquer ponto do cartão da instrução repete a instrução |
| ~~RT-123~~ | ~~Nenhum botão nem a instrução ficam sob o recorte da câmera ou a barra de gestos~~ — aposentado: o jogo roda só no navegador (`DD-15`) |
| RT-124 | Quando a janela não comporta as configurações, elas rolam, e o Começar fica sempre visível embaixo |
| RT-125 | O céu e o chão do cenário cobrem a tela inteira, sem faixas, em qualquer proporção |
| RT-126 | As peças do cenário ficam nos cantos de baixo, crescem pelo lado curto e não se deformam quando a tela gira; numa tela estreita, somem as flores e depois a cerca |
| RT-141 | Nos menus, o jardim do cenário aparece por trás do painel translúcido, e a barra de cima é opaca |
| RT-142 | Nenhuma peça nem cor do cenário é uma das seis cores do jogo |
| RT-98 | Os objetos têm contraste de pelo menos 3:1 com o cenário, e o texto, de pelo menos 4,5:1 com o fundo |

## 23.6 Feedback — decidido na seção 8

| ID | Requisito |
| --- | --- |
| RT-37 | Selecionar o alvo produz um retorno visual de acerto |
| RT-99 | O retorno de acerto destaca o alvo sem usar cor, e acaba em até 1 s |
| RT-38 | Depois do retorno de acerto, a troca para a rodada seguinte começa sem outra ação, enquanto houver rodadas |
| ~~RT-110~~ | ~~No acerto, oito brilhos claros saem do alvo e somem em 600 ms~~ — aposentado: a forma do retorno de acerto é recomendação (seção 8.1) |
| RT-111 | Com o áudio ligado, o acerto toca um som curto e suave; o erro não toca som |
| RT-112 | A troca de rodada é uma transição: as formas e a instrução da rodada que fecha saem, e as da nova entram, em até 1 s, e não de uma vez |
| ~~RT-113~~ | ~~As formas da rodada nova crescem do zero, e a instrução nova aparece, em 250 ms~~ — aposentado: a forma da troca é recomendação, e o `RT-112` diz a regra |
| RT-39 | Selecionar um distrator produz um retorno visual de que a seleção não corresponde ao alvo |
| RT-100 | O retorno de erro aparece no objeto escolhido, que continua na tela, e acaba em até 1 s |
| RT-40 | O retorno de erro não tem som punitivo |
| RT-41 | Depois de um erro, a rodada continua aberta, e a criança pode selecionar de novo até acertar, ou até o tempo limite acabar |
| RT-101 | Quando o tempo limite acaba sem acerto, o jogo mostra qual era o alvo, e a rodada seguinte abre |
| RT-102 | Nenhum retorno usa cor para dizer acerto ou erro |
| RT-42 | Tocar em repetir reapresenta a instrução: o texto, e a voz quando ligada |
| RT-103 | Tocar em repetir com a voz falando recomeça a fala |
| RT-43 | Tocar em pausar suspende a rodada, esconde os objetos e mostra retomar, sair e as chaves de áudio e de voz |
| RT-44 | Retomar volta à rodada pausada no estado em que ela estava |
| RT-67 | O tempo que a rodada passa pausada não entra no tempo de resposta nem no tempo limite |
| RT-45 | Tocar em sair pede confirmação, e confirmar sai da fase e volta à grade |
| RT-46 | O mesmo evento produz sempre o mesmo retorno |
| ~~RT-47~~ | ~~Com as animações reduzidas, nenhum retorno cresce, pulsa nem brilha: o contorno aparece na hora, e a troca de rodada é direta~~ — aposentado: não há animações reduzidas (`DD-09`) |
| RT-48 | Nenhum efeito alterna claro e escuro mais de uma vez por segundo, nem tem som abrupto |
| ~~RT-104~~ | ~~O tempo limite não aparece na tela~~ — aposentado: o tempo aparece numa barra (`DD-38`) |
| RT-115 | Com o limite ligado, um indicador sem número e sem cor de alerta mostra, em ritmo constante, o tempo que resta |
| RT-116 | O indicador do tempo para na pausa e no acerto, e na pausa continua de onde parou ao retomar |
| RT-117 | O retorno de erro não tem cor, som nem voz |

## 23.7 Áudio — decidido na seção 10

| ID | Requisito |
| --- | --- |
| RT-49 | Com a voz ligada, a instrução é falada quando a rodada abre |
| RT-50 | O áudio pode ser desligado inteiro, e com ele desligado toda rodada pode ser jogada até o fim |
| RT-51 | Desligar o áudio desliga também os sons do retorno |
| RT-105 | Há duas chaves de som: o áudio inteiro, e a voz na instrução |
| ~~RT-128~~ | ~~Com a vibração ligada, o acerto vibra por 20 ms onde o aparelho permitir, e o erro nunca vibra~~ — aposentado: não há vibração (`DD-42`) |

## 23.8 Registro — decidido na seção 13

| ID | Requisito |
| --- | --- |
| RT-52 | Todo evento registrado leva o código pseudônimo da sessão |
| RT-106 | O código pseudônimo é o que o mediador digita nas configurações |
| RT-53 | O começo de cada rodada é registrado, com a fase, a cor-alvo, a forma-alvo no modo cor e forma e o número de objetos |
| RT-54 | Cada seleção é registrada, com o objeto, se foi acerto ou erro, e o instante |
| RT-107 | O começo de cada rodada registra o instante em que os objetos aparecem e, com a voz ligada, o instante em que ela termina |
| RT-108 | O fechamento de cada rodada é registrado numa só das quatro categorias — correta, com erro, não resolvida ou omissão —, pelas definições da seção 13.3 |
| RT-55 | O instante de todo evento é relativo ao começo da sessão, e nenhum registro tem data ou hora do relógio |
| RT-56 | Nenhum registro traz nome, imagem, voz ou outro dado que identifique a criança |
| RT-57 | O arquivo da sessão baixa sozinho uma vez, quando a sessão termina no voltar da grade |
| RT-62 | O registro fica no computador onde a sessão roda, na pasta de downloads, e nada é enviado para fora |
| RT-68 | O começo de cada rodada registra também o tamanho, a semelhança dos distratores, o tempo limite e a voz |
| RT-69 | O fim de cada fase é registrado, com a fase, as corretas, e se ela foi concluída |
| RT-70 | Todo uso de repetir, pausar, retomar, sair e das chaves de áudio e de voz é registrado, inclusive pela pausa |
| RT-138 | O começo de cada rodada registra a cor e a forma de cada objeto, na ordem |

## 23.9 Integração — decidido na seção 11

| ID | Requisito |
| --- | --- |
| ~~RT-109~~ | ~~As rodadas vêm de cinco arquivos de banco, que se trocam sem mexer no jogo~~ — aposentado: as rodadas se sorteiam pelas regras da fase (`DD-44`) |
| RT-127 | O sorteio dá a ordem dos objetos, sem posição; o jogo os põe nas posições do arranjo da orientação atual, na ordem |
| RT-139 | Cada rodada é sorteada na hora, pelas regras da fase, e a cor-alvo não se repete em duas rodadas seguidas |
| RT-140 | Repetir uma fase traz rodadas novas |

## 23.10 Restrições que o sorteio precisa satisfazer — decidido nas seções 2.2, 6, 7.2 e 9

| ID | Garantia |
| --- | --- |
| G-01 | Toda rodada sorteada tem exatamente um alvo |
| G-02 | Nenhum objeto do cenário traz representação estereotipada |
| G-03 | Cada fase difere da vizinha em uma variável só |
| G-04 | Os distratores vizinhos têm outra cor, com outro nome, e não um tom da cor do alvo |
| G-05 | Toda rodada no modo cor e forma tem ao menos um distrator com a cor do alvo e outra forma, e ao menos um com a forma do alvo e outra cor |
| ~~G-06~~ | ~~Os bancos têm rodadas o bastante para a sessão mais longa configurada~~ — aposentada: as rodadas se sorteiam (`DD-44`) |
