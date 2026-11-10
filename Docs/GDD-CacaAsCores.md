---
faixa: CIATec
doc: GDD
doc_extenso: Game Design Document
titulo: Caça às Cores
subtitulo: Busca visual e resposta a instruções, para crianças em idade escolar
versao: v1.0
mudanca: 
data: 14/10/2026
projeto_vinculado: Caça às Cores
organizacao: CIATec
triple_diamond: 
ppi: 
pesquisador: [a definir]
tipo: requisitos
status: rascunho
data_criacao: 14/10/2026
data_atualizacao: 14/10/2026
---

# 1 CONCEITO DO JOGO

## 1.1 Premissa

*A criança escolhe uma fase numa grade de cards. Em cada rodada, ela ouve e lê uma instrução curta, como "Encontre o vermelho", e toca, entre as formas da tela, a que corresponde a ela. Errou, tenta de novo, sem perder nada; acertou, a próxima rodada abre. Acertando de primeira 4 das 5 rodadas, a fase está concluída e a próxima se libera; cada fase é um pouco mais difícil que a anterior.*

**A sensação:** *ENTENDER O QUE FOI PEDIDO E ACHAR.*

## 1.2 Gênero e Plataforma

**Gênero:** jogo casual de busca visual, como jogo sério.

**Modo de jogo:** um jogador, em sessão supervisionada ou educacional. Professores, terapeutas, pesquisadores e cuidadores podem mediar; é o mediador quem prepara a sessão (seção 7.3).

**Plataforma:** Unity 2D, para o navegador (WebGL). A janela pode ser mais alta que larga (retrato) ou mais larga que alta (paisagem), e o jogo se reorganiza com ela.

**Interação:** clique de mouse sobre o objeto; numa tela sensível ao toque, o toque vale o mesmo. Não há câmera nem outro sensor.

**Idiomas:** só português do Brasil.

## 1.3 Público-Alvo

Crianças em idade escolar, incluindo crianças com transtorno do espectro autista (TEA), com diferentes perfis de linguagem, atenção, percepção visual e motricidade. A faixa é de 6 a 10 anos. Como parte delas ainda não lê, a instrução também é falada.

**O diagnóstico de TEA, por si só, não determina a dificuldade inicial**: o nível sai do desempenho na tarefa.

# 2 MECÂNICAS

## 2.1 Conceito Geral

**Localizar e selecionar.** A cada rodada o jogo apresenta uma instrução e um conjunto de objetos; um deles é o alvo, e todos os outros são distratores. A criança seleciona o objeto que corresponde à instrução, e o jogo responde se a seleção corresponde ou não.

**Uma rodada é uma instrução, até o alvo ser achado**. Ela não tem duração fixa: dura o tempo que a criança leva.

A tarefa permite observar a resposta a estímulos e instruções em condições controladas. **O desempenho não é interpretado como medida de uma capacidade clínica**: acertos e tempos dependem também da compreensão da instrução, da familiaridade com a tarefa, da visão, da motricidade, da fadiga e da motivação.

**Não há vidas nem pontuação**. O erro não gasta nada e não encerra nada; a sessão só acaba quando o mediador volta da grade de fases ao início.

![](figuras/tela-rodada.png)

## 2.2 Os objetos e os dois modos

**Os objetos da tarefa são quatro formas geométricas planas**, que se distinguem pela silhueta, mesmo pequenas, e que uma criança de 6 anos sabe nomear. Os objetos do cotidiano ficam no cenário, e nunca são alvo.

**As cores são seis**, com nomes diferentes entre si e que a criança conhece. Nenhuma delas aparece no cenário, e todas têm o contraste da seção 7.4 com ele. Os valores ficam num lugar só, que se ajusta sem mexer no código.

**O time escolhe as quatro formas e as seis cores**, dentro destas regras, e o orientador aprova a escolha antes de o jogo usá-las. Os exemplos deste documento usam a recomendação abaixo.

> **Recomendação.** As formas: círculo, quadrado, triângulo e estrela. As cores: vermelho, azul, verde, amarelo, laranja e roxo, com os valores que passarem no contraste.

**Há dois modos, e só dois**:

- **Só cor.** A instrução nomeia só a cor ("Encontre o vermelho"), e o alvo é o único objeto daquela cor. As formas se sorteiam entre as quatro, e não são todas iguais; elas não importam: a criança acerta pela cor.
- **Cor e forma.** A instrução nomeia a forma e a cor ("Encontre o quadrado azul"), e o alvo é o único objeto que tem as duas. Para a forma pesar, há distratores com a mesma cor e outra forma, e com a mesma forma e outra cor (`G-05`).

**A semelhança dos distratores tem dois graus**: vizinhos, das duas cores mais parecidas com a cor do alvo — as que ficam ao lado dela no círculo das cores —, e distintos, das outras três. **O time monta a tabela das vizinhas e das distintas para as cores que escolher**, no formato da tabela abaixo, que é a das cores recomendadas. No modo só cor, todo distrator tem outra cor, com outro nome. No modo cor e forma, um distrator tem a cor do alvo e outra forma (`G-05`), e os de outra cor seguem a semelhança da fase.

| Cor do alvo | Cores vizinhas | Cores distintas |
| --- | --- | --- |
| Vermelho | Laranja e roxo | Amarelo, verde e azul |
| Laranja | Vermelho e amarelo | Verde, azul e roxo |
| Amarelo | Laranja e verde | Vermelho, azul e roxo |
| Verde | Amarelo e azul | Vermelho, laranja e roxo |
| Azul | Verde e roxo | Vermelho, laranja e amarelo |
| Roxo | Azul e vermelho | Laranja, amarelo e verde |

## 2.3 Fechamento da rodada, da fase e da sessão

**A rodada fecha no acerto**. Com o acerto, um retorno breve e a próxima rodada. Com o erro, um retorno neutro, e a rodada continua aberta: a criança tenta de novo, quantas vezes precisar. Com o limite de tempo ligado, a rodada também fecha quando o tempo acaba: o jogo mostra qual era o alvo e abre a próxima.

**A fase fecha depois de 5 rodadas**, num cartão sem números: "Fase concluída!" ou "Vamos tentar de novo!" (seção 5.2). O cartão leva à próxima fase, ou a tentar a mesma de novo, ou de volta à grade.

**A sessão vai de fase em fase.** Quando a fase 5 é concluída, o cartão do fim da fase diz "Você terminou todas as fases!" e leva de volta à grade. O resumo com os indicadores vai só para o arquivo da sessão, gravado sozinho (seção 13). **A criança ou o mediador podem sair de uma fase a qualquer momento**, com confirmação ("Sair da fase?", com Continuar e Sair), de volta à grade; o voltar da grade encerra a sessão, e é então que o arquivo baixa (seção 13).

# 3 CONTROLES

Neste documento, **tocar** quer dizer clicar com o mouse, ou tocar numa tela sensível ao toque.

- **Selecionar:** um clique ou um toque sobre o objeto o seleciona. A seleção é um gesto só: não há arrastar, segurar nem duplo clique. Durante o retorno de acerto, tocar num objeto não faz nada; com a voz falando, o toque vale.
- **Repetir a instrução:** tocar no cartão da instrução, inteiro, reapresenta a instrução da rodada, em qualquer rodada, inclusive no tutorial; o alto-falante dentro dele é só o sinal. Tocado com a voz falando, ele recomeça a fala.
- **O botão pressionado:** todo objeto e todo botão reagem em até 80 ms do instante em que o botão do mouse aperta, antes de soltar — o objeto afunda, o botão escurece.
- **Pausar:** um botão suspende a rodada: o relógio para, os objetos somem da tela, e a pausa mostra retomar, sair e as chaves de áudio e de voz.
- **Sair:** um botão sai da fase a qualquer momento, depois de uma confirmação, e volta para a grade de fases; o voltar da grade volta ao início.
- **Áreas de seleção amplas:** os objetos são grandes e separados o bastante para evitar o clique acidental (seção 7.4).

O jogo não usa câmera, microfone nem outro sensor.

# 4 TUTORIAIS

**O tutorial abre uma vez por sessão, antes da primeira fase, e é uma rodada só**: a instrução explica o que fazer, em texto e em voz — "Vamos treinar! Toque no \<cor\>." —, e a mãozinha do jogo vai até o alvo e repete o gesto de tocar até a criança tocar. Ela não tem limite de tempo e não conta para a progressão nem para os indicadores. Depois dela, um cartão diz "Agora é com você!" e oferece começar a fase. **A rodada do tutorial é sempre a mesma**: três formas grandes, de cores distintas, e o alvo sempre da mesma cor (recomendação: vermelho, "Vamos treinar! Toque no vermelho.").

A instrução aparece sempre em texto e, com a voz ligada, é falada. **A mãozinha só existe no tutorial**: nas rodadas ela mostraria a resposta. A chave dela, nas configurações, liga ou desliga a mãozinha; desligada, a rodada do tutorial é igual a uma rodada comum, sem tempo.

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

**São cinco fases, em cards, e a dificuldade muda de um card para o outro**. Dentro da fase ela não muda. A criança vê a grade, sabe em que fase está, e avança por mérito.

| Evento | Regra |
| --- | --- |
| Fase | 5 rodadas, sorteadas na hora pelas regras dela |
| Passar | 4 rodadas corretas das 5: "Fase concluída!", a fase ganha um ✓ na grade, a seguinte se libera, e o cartão oferece "Próxima fase" e "Voltar às fases" |
| Não passar | Menos de 4 corretas: "Vamos tentar de novo!", e o cartão oferece "Tentar de novo", com rodadas novas, e "Voltar às fases". A criança não avança, e o jogo não a leva para outra fase |
| Fim | Concluída a fase 5, o cartão diz "Você terminou todas as fases!" e só leva à grade |
| Início | A grade abre com as fases liberadas até a que o mediador escolhe nas configurações; o padrão é a 1. Nada se guarda entre sessões |
| Repetir | Uma fase concluída pode ser jogada de novo pela grade |
| Pausa | Disponível a qualquer momento, e o relógio para |
| Interromper | A pedido da criança ou do mediador, ou diante de desconforto observado |

**Rodada correta é a que acertou na primeira tentativa**; as outras são com erro (errou e depois acertou), não resolvidas ou omissões (seção 13.3). **Só a correta conta para passar de fase**: clicar em tudo até acertar não conta.

**A adaptação aos erros é entre as fases, e não dentro delas.** O portão impede subir antes da hora; quem não passa tenta de novo quantas vezes quiser, ou volta à grade e escolhe uma fase já liberada. Como cada fase tem uma dificuldade só, o desempenho de uma fase se compara com o da mesma fase noutra sessão ou noutra criança. O mínimo de 4 de 5 é um valor de partida, que se confirma em playtest.

## 5.3 Fim da Sessão e Resultados

**A criança não vê números**: nem no cartão do fim da fase, nem em outra tela. Números de erro na frente dela viram nota.

**O resumo vive só no arquivo da sessão**, que baixa sozinho quando a sessão termina (seção 13). Ele traz, por fase jogada, as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas e as omissões, e se a fase foi concluída. São indicadores descritivos de eventos de jogo, sem interpretação: **seleção incorreta é evento de jogo, e não diagnóstico**.


# 6 LEVEL DESIGN

**O que faz uma rodada fácil ou difícil** são o número de objetos, o tamanho deles, a semelhança dos distratores, o modo (só cor, ou cor e forma) e o limite de tempo (seção 12). **Recomenda-se mudar uma por vez**, para que a diferença de desempenho possa ser atribuída à variável que mudou; por isso **cada fase difere da vizinha numa variável só** (`G-03`).

**Uma fase é um conjunto de regras, e não uma lista de rodadas**. Cada rodada é sorteada na hora, pelas regras da fase: a cor e a forma do alvo, e os distratores, respeitando as garantias da seção 15.10. Assim, a criança que repete uma fase vê rodadas novas, e não decora onde está o alvo. A cor-alvo não se repete em duas rodadas seguidas. O sorteio dá também a ordem dos objetos; a posição na tela vem do layout, que os põe nas casas da grade da orientação atual. As cinco fases são estas:

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

- **Uma instrução principal por rodada**.
- **Alvos grandes**, com separação suficiente para evitar cliques acidentais (seção 7.4).
- **Nenhum estado da interface se indica só pela cor**: acerto, erro, fase bloqueada e fase concluída vêm sempre com contorno, movimento, ícone ou texto. A regra vale para a interface, e não para a tarefa: achar a cor é o próprio jogo, e o pedido vem escrito e falado.
- **O retorno é consistente, não punitivo e não usa cor** (seção 8).
- **Repetir, pausar e sair** são controles claros, presentes em toda tela de jogo.

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

**Os menus emulam o visual dos menus dos pacotes CIATEC, e o laço de jogo tem o tema do jogo**. O início, as configurações e a grade de fases reproduzem a moldura dos menus da plataforma — a barra com o símbolo e a marca CIATEC, e o painel com borda e preenchimento translúcido, por trás do qual aparece o jardim do jogo —, com as cores e as medidas da pasta `visual-menus`. Os menus só têm o tema claro. **O jogo não usa o M3Kit:** reproduz o visual com os próprios meios, com o símbolo, as fontes, as cores e as medidas da pasta `visual-menus`. O tutorial, as rodadas, o retorno, a pausa e o cartão do fim da fase têm a arte e o tema do jogo. A barra só tem o símbolo e a marca e, na grade de fases, o voltar.

![](visual-menus/menu-inicio.png)

**A tela de configurações** é do mediador, e vem depois do início. Nela se digitam o código pseudônimo da criança, sem o qual o Começar não segue e o campo diz "Digite o código da criança (não o nome).", porque todo evento do registro leva o código, e se escolhem as fases liberadas, o tempo limite, o áudio, a voz e a mãozinha do tutorial. Os padrões são fases liberadas até a 1, tempo limite desligado, áudio ligado, voz ligada e mãozinha ligada. Quando a janela não comporta todas as opções, a tela rola, e o Começar fica fixo embaixo: em retrato, uma coluna, com o rótulo em cima do seletor; em paisagem, duas colunas, com o rótulo ao lado. Os rótulos são os mesmos nas duas: Código da criança, Fases liberadas até, Tempo limite, Áudio, Voz na instrução e Mãozinha no tutorial.

![](visual-menus/janela-menus.png)


**A grade de fases** segue o menu de fases dos pacotes CIATEC: as cinco fases em cards de 140 dp ou mais, que preenchem a largura do painel. O card mostra o número, uma miniatura do que a fase tem — quantas formas, se só cor ou cor e forma — e uma linha curta para o mediador. A liberada tem a borda acesa, a concluída tem um ✓ e pode ser jogada de novo, a bloqueada tem um cadeado e, tocada, faz aparecer numa linha abaixo da grade "Passe a fase N para liberar a fase N + 1.", que fica até o próximo toque. Em retrato, os cards ficam em duas colunas; em paisagem, os cinco numa linha. O voltar da barra volta ao início.

![](visual-menus/menu-fases.png)

**A tela da rodada** traz a instrução em texto, os botões de pausa e de saída e os objetos sobre o cenário. **O arranjo dela é do time**, dentro destas regras: a instrução e os dois botões ficam sempre visíveis; os objetos não se sobrepõem e ficam longe dos botões; o arranjo se reorganiza com a orientação; e redimensionar a janela no meio da rodada reorganiza a tela sem perder nada. O laço de jogo pode ter um visual bem diferente dos menus.

> **Recomendação.** Os botões de pausa e de saída nos dois cantos de cima. Em retrato, a instrução numa linha própria, abaixo dos botões, e os objetos numa grade de uma coluna até 3 objetos e de duas colunas de 4 a 8; em paisagem, a instrução entre os dois botões, e os objetos numa linha até 4 e em duas linhas de 5 a 8, com a metade, arredondada para cima, na de cima, e a linha incompleta centrada. As figuras `janela-rodada.png` e `medidas.png` mostram esse arranjo.

![](figuras/janela-rodada.png)

**A pausa** esconde os objetos, para não virar tempo de busca, e mostra retomar, sair e as chaves de áudio e de voz.


## 7.4 MEDIDAS E ALVOS

**Tudo se mede em dp, e a tela de referência é uma janela de 390 × 844 dp, em retrato e em paisagem**: é a menor janela em que o jogo precisa caber. No navegador, 1 dp é 1 pixel da página (o px do CSS). Os botões e o texto têm medida fixa em dp; os objetos se medem pelo espaço que sobra. A tabela traz os mínimos, que são regra; o arranjo que os respeita é do time (seção 7.3). Os valores se confirmam em playtest.

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

**O retorno informa, e não pune**. O erro diz que a seleção não corresponde ao alvo, sem som punitivo, e não tira nada: não há vidas nem pontuação.

**O retorno é previsível**: o mesmo evento produz sempre o mesmo retorno.

**O retorno não usa cor**. Contorno e movimento dizem acerto e erro; a cor é só do alvo, que é o que a criança procura.

**O jogador controla os estímulos**: o som do retorno se desliga com o áudio, e a voz, com a chave dela. As animações são breves e simples, e **nenhum efeito alterna claro e escuro mais de uma vez por segundo, nem tem som abrupto**.

## 8.1 Os efeitos

**A forma de cada efeito é do time**, dentro das regras acima e destas: o acerto destaca o alvo sem usar cor, toca um som curto e suave com o áudio ligado, e, durante ele, tocar num objeto não faz nada; a troca de rodada começa sozinha depois do acerto e é uma transição, e não um corte; o erro aparece no objeto escolhido, sem cor, sem som e sem voz, e a rodada continua aberta; com o limite de tempo ligado, um indicador sem número e sem cor de alerta mostra o tempo que resta e para na pausa e no acerto; quando o tempo acaba sem acerto, o jogo mostra qual era o alvo e abre a próxima rodada; e a pausa esconde os objetos. Cada efeito dura até 1 s, e os tempos se confirmam em playtest.

> **Recomendação.** A tabela abaixo, e os GIFs dela.

| Efeito | O que faz | Animação |
| --- | --- | --- |
| **INSTRUIR** | QUANDO: a rodada abre, ou o botão de repetir é tocado. A instrução aparece em texto junto com os objetos, e é falada quando a voz está ligada. Repetir reapresenta o texto e recomeça a fala. | o texto entra com os objetos ![](figuras/fb-instrucao.gif) |
| **ACERTO** | QUANDO: a criança seleciona o alvo. Um contorno grosso no alvo, que cresce um pouco, oito brilhos claros que saem dele, e um som curto e suave com o áudio ligado. Durante o retorno, tocar num objeto não faz nada. | cresce de 1 para 1,1 vez em 300 ms; os brilhos duram 600 ms; a troca começa 500 ms depois ![](figuras/fb-acerto.gif) |
| **TROCA** | QUANDO: uma rodada fecha e outra abre. As formas encolhem e somem, a instrução some junto, e as formas novas crescem do zero com a instrução nova. | saída em 250 ms; entrada em 250 ms; o GIF do ACERTO mostra a troca |
| **ERRO** | QUANDO: a criança seleciona um distrator. O objeto escolhido balança de leve, como um "não", e esmaece no meio do balanço, sem cor e sem som; a rodada continua aberta para outra tentativa. | vai e volta três vezes em 400 ms, até 10 px para cada lado ![](figuras/fb-erro.gif) |
| **TEMPO** | QUANDO: o limite de tempo está ligado. Uma barra fina, logo abaixo da instrução, esvazia da direita para a esquerda até o fim do tempo, sem número e sem cor de alerta; ela para na pausa e no acerto. | esvazia em 15 s, em ritmo constante ![](figuras/fb-alvo.gif) |
| **ALVO** | QUANDO: o limite de tempo está ligado e acaba sem acerto. O alvo ganha um contorno que pulsa, e a próxima rodada abre. | pulsa por 1 s ![](figuras/fb-alvo.gif) |
| **PAUSA** | QUANDO: o botão de pausa é tocado. Os objetos somem, o relógio para, e a tela mostra retomar, sair e as chaves. | aparece na hora ![](figuras/fb-pausa.gif) |

## 8.2 Cores de estado

**Nenhuma cor carrega estado neste jogo**. O acerto, o erro e o alvo mostrado se veem pela forma e pelo movimento, e nunca pela cor. As cores que aparecem são conteúdo: as seis da seção 2.2.

# 9 ARTE E DIREÇÃO VISUAL

## 9.1 Estilo, paleta e contraste

**Os menus emulam o visual dos pacotes CIATEC, e o laço de jogo tem o tema do jogo** (seção 7.3). No laço de jogo: **formas grandes e planas, um cenário calmo, animações breves.** Evitam-se flashes, estímulos abruptos e elementos decorativos. Os valores das seis cores são da arte, com o contraste da seção 7.4; as cores das figuras deste documento são esquema.

## 9.2 Os objetos e a instrução

**As formas são planas e de contorno nítido**, nas seis cores.

**A instrução segue um modelo só**: no modo só cor, "Encontre o \<cor\>"; no modo cor e forma, "Encontre o \<forma\> \<cor\>", com o artigo e a cor concordando com o gênero da forma — com as recomendadas, "Encontre a estrela vermelha", e azul, verde e laranja não mudam. O texto fica na tela a rodada inteira: nada some sozinho.

## 9.3 Temas

**Um cenário só, calmo, o mesmo em todas as rodadas**: tons suaves, pouco detalhe, nada que se mova, com as formas sobre ele. **O céu e o chão cobrem a tela inteira em qualquer proporção, e as peças do cenário ficam presas nos cantos de baixo**: elas crescem pelo lado curto da tela, não se esticam quando ela gira, e, se a tela for estreita demais, a menos importante some primeiro — as flores, depois a cerca; a árvore fica. **O cenário não usa nenhuma das seis cores do jogo**: céu azul-claro, chão e copa em verdes acinzentados, tronco marrom, contornos em verde mais escuro; uma flor vermelha ou um balão azul no fundo competiria com a instrução. É nele que entram os objetos do cotidiano — a criança ajuda a organizar as coisas do jardim —, que nunca são alvo e não competem com a instrução. A arte final do jardim não existe (seção 14).

# 10 ÁUDIO

## 10.1 Princípio e categorias

**O jogo é jogável no mudo**: o áudio é opcional, e a instrução em texto está sempre na tela. As categorias são a voz da instrução e os sons do retorno.

**Há duas chaves de som**: o áudio inteiro, que leva junto os sons do retorno, e a voz da instrução.

## 10.2 Efeitos e voz

**Nenhum som é punitivo nem abrupto.** Com a voz ligada, a instrução é falada quando a rodada abre e a cada repetir. O acerto tem um som curto e suave, de duas notas subindo; o erro não tem som. Os sons e a voz ainda não existem (seção 14).

## 10.3 Música e temas

Não há música.

# 11 TECNOLOGIA E PLATAFORMA

**Unity 2D, para o navegador (WebGL), com Canvas e UI, objetos clicáveis e um gerador que sorteia as rodadas pelas regras de cada fase**. O registro é local, num arquivo gravado sozinho, sem câmera nem sensores.

**O jogo não usa a plataforma CIATEC.** Todas as telas da seção 7.3 são do jogo, e as fases e as regras delas ficam nele.

**O visual dos menus é emulado, sem o M3Kit e sem o pacote da plataforma**: o jogo reproduz com os próprios meios a moldura e as cores do tema claro, com o material da pasta `visual-menus`.

# 12 PARÂMETROS DE FASE E PROGRESSÃO

**Cada fase declara a condição das suas rodadas.** As faixas abaixo orientam quem ajusta as fases, e o jogo não as impõe: uma fase fora delas também é aceita. **A rodada que não cabe degrada, e não quebra**: com mais objetos do que a tela comporta no tamanho pedido, o jogo monta a rodada com o que cabe e avisa que reduziu.

| Variável | Faixa de partida | Efeito na tarefa |
| --- | --- | --- |
| Número de objetos | 3 a 8 | Aumenta o conjunto de alternativas |
| Tamanho dos objetos | Grande, médio ou pequeno, o mesmo para todos os objetos da rodada | Altera a exigência visual-motora da seleção |
| Semelhança dos distratores | Distintos ou vizinhos; o número deles é sempre o de objetos menos um | Torna o alvo mais difícil de distinguir |
| Modo | Só cor, ou cor e forma | Aumenta a complexidade da regra |
| Tempo limite | Desligado no padrão; ligado, 15 s | Acrescenta pressão temporal |
| Voz na instrução | Ligada ou desligada | Permite comparar configurações, se o estudo previr |

**O limite de tempo vem desligado**: a velocidade não é requisito central da tarefa sem justificativa científica. Ligado, ele aparece num indicador que esvazia, sem número (recomendação: uma barra fina): sem nada na tela, a criança não sabe que o tempo existe; com números, ele vira contagem regressiva.


# 13 TELEMETRIA E REGISTRO

**Registra-se o que acontece em cada rodada, para análise exploratória.** O registro é local. **O arquivo baixa sozinho, uma vez, quando a sessão termina** — no voltar da grade ao início —, para a pasta de downloads do computador. Não há outra cópia: se a aba fechar antes, a sessão se perde. Os nomes dos campos e o formato do arquivo se combinam com o orientador (seção 14). O tempo de cada evento é relativo ao início da sessão, que é o toque no Começar das configurações, e nunca data e hora do relógio.

**Nada identificável é registrado**: todo evento leva o código pseudônimo que o mediador digita, e nenhum registro traz nome, imagem, voz ou outro dado que identifique a criança.

## 13.1 O que é registrado

| Domínio | Evento | O que acompanha |
| --- | --- | --- |
| Rodada | A rodada começa | A fase, a cor-alvo, a forma-alvo no modo cor e forma, o número e o tamanho dos objetos, a semelhança dos distratores, o tempo limite e a voz; a cor e a forma de cada objeto, na ordem, porque a rodada é sorteada e não se refaz depois; e o instante em que os objetos aparecem e em que a voz termina |
| Rodada | Um objeto é selecionado | O objeto, se foi acerto ou erro, e o instante |
| Rodada | A rodada fecha | Correta, com erro, não resolvida ou omissão (seção 13.3) |
| Fase | A fase começa, e fecha | A fase; ao fechar, as corretas e se ela foi concluída |
| Controles | Repetir, pausar, retomar, sair, e ligar ou desligar o áudio e a voz | Qual controle, e o novo estado |

**A condição e o conteúdo da rodada, o fim de cada fase e o uso dos controles entram no registro**: sem eles não se compara o desempenho por condição nem se sabe se os controles foram usados; e, como as rodadas são sorteadas, o conteúdo de cada uma só existe no registro.

## 13.2 O resumo e as grandezas derivadas

O arquivo traz também o resumo da sessão, por fase jogada: as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas, as omissões, e se a fase foi concluída. São grandezas derivadas do registro, e identificadas como derivadas, como a proporção de acertos por fase. **Nenhuma delas é, por si só, medida diagnóstica ou clínica validada**.

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
| Tempo de resposta | Do instante em que os objetos aparecem, ou do fim da voz, até o acerto: o registro guarda os dois instantes, e os pesquisadores escolhem a base (seção 14) | O tempo pausado |
| Fase | A fase da rodada, de 1 a 5 | — |

# 14 EM ABERTO

O que o jogo ainda não tem, ou o que se decide durante o desenvolvimento. O resto deste documento está decidido.

| O que está em aberto | Como se resolve |
| --- | --- |
| **O arquivo da sessão e as regras das fases**: o formato e onde as regras de cada fase moram | O orientador, com o time |
| **O ajuste das cinco fases** | A curadoria e o playtest, com as garantias da seção 15.10 |
| **A arte e os sons**: a escolha das formas e das cores (seção 2.2), os valores das seis cores, a arte final do jardim, a fonte, as cores e as medidas do laço de jogo (o cartão da instrução, os botões de pausar e sair, os cartões do fim da fase e do tutorial), os ícones, a voz da instrução e os sons do retorno | O time, pelas regras e recomendações deste documento e com o contraste da seção 7.4, com a aprovação do orientador; a voz, gravada por uma pessoa |
| **A base do tempo de resposta**: os objetos aparecerem ou o fim da voz | Os pesquisadores, com o plano de análise |
| **Os valores de partida** | Playtest |

# 15 REQUISITOS VERIFICÁVEIS

Cada linha é uma afirmação das seções acima, escrita na forma que se confere jogando. É a lista da validação final: para cada uma, o time anota se viu acontecer.

> `RT` é um requisito do jogo. `G` é uma garantia que o sorteio das rodadas precisa entregar. Os números não são seguidos.

## 15.1 A rodada — seções 2 e 6

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

## 15.2 Controles — seção 3

| ID | Requisito |
| --- | --- |
| RT-11 | Um clique ou um toque sobre um objeto o seleciona |
| RT-12 | A seleção não exige arrastar, segurar nem duplo clique |
| RT-13 | O jogo não usa câmera, microfone nem outro sensor |
| RT-77 | Durante o retorno de acerto, tocar num objeto não faz nada |
| RT-78 | Com a voz falando, tocar num objeto o seleciona |

## 15.3 Tutorial — seção 4

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

## 15.4 Sessão e progressão — seções 5 e 12

| ID | Requisito |
| --- | --- |
| RT-18 | A tela de configurações vem depois do início e antes do tutorial |
| RT-19 | Tocar num card liberado da grade começa aquela fase |
| RT-82 | Há cinco fases, da 1 à 5, e cada uma difere da anterior numa variável só |
| RT-83 | A grade abre com as fases liberadas até a escolhida nas configurações, e o padrão é só a 1; nada se guarda entre sessões |
| RT-20 | O limite de tempo vem desligado |
| RT-58 | O limite de tempo pode ser ligado na configuração, e ligado vale 15 s no padrão |
| RT-85 | Rodada correta é a que acertou na primeira tentativa, e só ela conta para o portão; com erro, não resolvida e omissão não contam |
| RT-129 | Cada fase tem 5 rodadas |
| RT-130 | Com 4 rodadas corretas das 5, a fase é concluída, ganha um ✓ na grade, e a seguinte é liberada |
| RT-131 | Com menos de 4 corretas, a fase não é concluída, e o cartão oferece "Tentar de novo", com rodadas novas, e "Voltar às fases"; o jogo não leva a outra fase |
| RT-133 | Concluída a fase 5, o cartão do fim da fase diz "Você terminou todas as fases!" e só oferece voltar à grade |
| RT-26 | A dificuldade só muda de uma fase para outra; dentro da fase ela não muda |
| RT-27 | Ao fim de cada fase, um cartão sem números diz se ela foi concluída; concluída, leva à fase seguinte ou à grade (a fase 5, só à grade: `RT-133`), e não concluída, a tentar de novo ou à grade |
| RT-28 | O arquivo da sessão traz o resumo por fase jogada: as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas, as omissões, e se a fase foi concluída *(o tempo de resposta depende da seção 14)* |
| RT-29 | Nem os cartões de fase nem o resumo trazem interpretação clínica ou diagnóstico |
| RT-89 | O jogo não tem vidas nem pontuação |

## 15.5 Interface e acessibilidade — seções 7 e 9

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
| RT-124 | Quando a janela não comporta as configurações, elas rolam, e o Começar fica sempre visível embaixo |
| RT-125 | O céu e o chão do cenário cobrem a tela inteira, sem faixas, em qualquer proporção |
| RT-126 | As peças do cenário ficam nos cantos de baixo, crescem pelo lado curto e não se deformam quando a tela gira; numa tela estreita, somem as flores e depois a cerca |
| RT-141 | Nos menus, o jardim do cenário aparece por trás do painel translúcido, e a barra de cima é opaca |
| RT-142 | Nenhuma peça nem cor do cenário é uma das seis cores do jogo |
| RT-98 | Os objetos têm contraste de pelo menos 3:1 com o cenário, e o texto, de pelo menos 4,5:1 com o fundo |

## 15.6 Feedback — seção 8

| ID | Requisito |
| --- | --- |
| RT-37 | Selecionar o alvo produz um retorno visual de acerto |
| RT-99 | O retorno de acerto destaca o alvo sem usar cor, e acaba em até 1 s |
| RT-38 | Depois do retorno de acerto, a troca para a rodada seguinte começa sem outra ação, enquanto houver rodadas |
| RT-111 | Com o áudio ligado, o acerto toca um som curto e suave; o erro não toca som |
| RT-112 | A troca de rodada é uma transição: as formas e a instrução da rodada que fecha saem, e as da nova entram, em até 1 s, e não de uma vez |
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
| RT-48 | Nenhum efeito alterna claro e escuro mais de uma vez por segundo, nem tem som abrupto |
| RT-115 | Com o limite ligado, um indicador sem número e sem cor de alerta mostra, em ritmo constante, o tempo que resta |
| RT-116 | O indicador do tempo para na pausa e no acerto, e na pausa continua de onde parou ao retomar |
| RT-117 | O retorno de erro não tem cor, som nem voz |

## 15.7 Áudio — seção 10

| ID | Requisito |
| --- | --- |
| RT-49 | Com a voz ligada, a instrução é falada quando a rodada abre |
| RT-50 | O áudio pode ser desligado inteiro, e com ele desligado toda rodada pode ser jogada até o fim |
| RT-51 | Desligar o áudio desliga também os sons do retorno |
| RT-105 | Há duas chaves de som: o áudio inteiro, e a voz na instrução |

## 15.8 Registro — seção 13

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

## 15.9 Integração — seção 11

| ID | Requisito |
| --- | --- |
| RT-127 | O sorteio dá a ordem dos objetos, sem posição; o jogo os põe nas posições do arranjo da orientação atual, na ordem |
| RT-139 | Cada rodada é sorteada na hora, pelas regras da fase, e a cor-alvo não se repete em duas rodadas seguidas |
| RT-140 | Repetir uma fase traz rodadas novas |

## 15.10 Restrições que o sorteio precisa satisfazer — seções 2.2, 6, 7.2 e 9

| ID | Garantia |
| --- | --- |
| G-01 | Toda rodada sorteada tem exatamente um alvo |
| G-02 | Nenhum objeto do cenário traz representação estereotipada |
| G-03 | Cada fase difere da vizinha em uma variável só |
| G-04 | Os distratores vizinhos têm outra cor, com outro nome, e não um tom da cor do alvo |
| G-05 | Toda rodada no modo cor e forma tem ao menos um distrator com a cor do alvo e outra forma, e ao menos um com a forma do alvo e outra cor |
