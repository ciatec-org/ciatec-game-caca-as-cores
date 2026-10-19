---
faixa: CIATec
doc: Plano de trabalho
doc_extenso: Agile Backlog Document
titulo: Caça às Cores
subtitulo: Plano de trabalho para uma equipe de iniciação científica de três pessoas
versao: v1.2
mudanca: 
data: 14/10/2026
projeto_vinculado: Caça às Cores
organizacao: CIATec
triple_diamond: 
ppi: 
pesquisador: [a definir]
tipo: backlog
status: rascunho
data_criacao: 14/10/2026
data_atualizacao: 14/10/2026
---

# 1 COMO USAR ESTE PLANO

## 1.1 Para quem é

**Este plano é para uma equipe de iniciação científica de três pessoas, começando a graduação, com 2 horas por semana cada uma.** Ele diz o que construir, em que ordem, e em pedaços pequenos o bastante para caber numa sessão de trabalho. O que o jogo é, e por quê, está no GDD (`GDD-CacaAsCores.md`), nas figuras dele, em `documentation/figuras`, e no material dos menus, em `documentation/visual-menus`: este plano não decide nada sobre o jogo, só organiza o trabalho de construí-lo. **Toda dúvida sobre como algo deve acontecer se responde no GDD**; se ele não responde, a dúvida vai ao orientador, e a resposta volta ao GDD.

**A tecnologia é Unity 2D, para o navegador** (seção 1.2 do GDD): Unity 6 LTS (6000.3), a interface em uGUI (Canvas) com TextMeshPro, e a build WebGL. O plano começa depois das 3 semanas de estudo de Unity do time: a semana 1 do plano é a semana 4 do time. Fora o git (EP-00), o estudo é por demanda, quando uma task pedir.

## 1.2 O ritmo

O time trabalha em **sprints de 2 semanas**. Com 3 pessoas a 2 h por semana, cada sprint tem 12 h de time, das quais cerca de 10 h rendem trabalho depois que o time pega o ritmo (e cerca de 8 h nos dois primeiros sprints). O resto é reunião e imprevisto.

| Momento | Quando | Duração |
| --- | --- | --- |
| Planejamento | Começo do sprint | 20 min: o time escolhe as histórias do sprint pela seção 5 e divide as tasks |
| Acompanhamento | Toda semana, por mensagem | 5 min: o que fiz, o que vou fazer, onde travei |
| Demonstração e retrospectiva | Fim do sprint | 30 min: cada um mostra na build WebGL o que fez; o que melhorar |

## 1.3 O quadro e o caminho de uma task

**O quadro tem quatro colunas: A fazer, Fazendo, Em revisão e Feito.** Cada pessoa pega **uma task por vez**, cria uma branch para ela, abre um pull request quando termina, e **outra pessoa revisa** antes de juntar ao main. Uma task de 1 ou 2 h é uma sessão semanal de uma pessoa: **se ela ficou uma semana parada, é hora de pedir ajuda**, e não de esperar a reunião.

## 1.4 Pronta para começar, e pronta de verdade

**Uma história está pronta para entrar no sprint** quando o time leu as seções do GDD que ela cita, as dependências dela estão feitas, e não há dúvida aberta sobre o que ela pede.

**Uma história está feita** quando:

- cada requisito da lista dela foi visto acontecer, jogando no Play do Editor ou na build WebGL;
- o Console não mostra nenhuma exceção durante uma rodada jogada;
- se ela desenha alguma coisa, há uma captura; depois do layout das duas orientações (US-06.1), uma numa janela em retrato e outra em paisagem;
- o pull request foi revisado por outra pessoa e está no main.

**Não há testes automáticos neste plano.** É o primeiro jogo do time, e tudo se confere jogando: nas tasks de validação, nas histórias de marco e na validação final.

## 1.5 As três frentes

Para cada pessoa ganhar profundidade em alguma coisa, o plano sugere três frentes, sem que ninguém fique preso nelas: **regras** (a rodada, o gerador, as fases, o registro), **telas** (os menus, o layout) e **sensação** (os retornos, o áudio, o tutorial, o cenário). Nas histórias de marco, o time inteiro joga junto.

## 1.6 Como ler uma história

Cada história traz o perfil, as horas, a prioridade e o sprint sugerido; a história no formato *Como… quero… para que…*; **a lista dos requisitos do GDD que ela realiza, um por linha** — o texto vem do GDD, sem resumo; os cenários de aceite; e as tasks, de 1 ou 2 h cada, com a camada (regras, telas, conteúdo, arte, validação…).

> **As histórias de marco** (uma por marco) só fecham com a build WebGL jogada do início ao fim no navegador — nunca com uma parte jogada no Editor. São a única prova de que as peças foram juntadas.

# 2 CAPACIDADE E PREVISÃO

**O plano tem 8 épicos, 42 histórias e 115 tasks, somando 163 horas.** No ritmo do time, isso dá **19 sprints, ou cerca de 38 semanas** depois do estudo. É uma previsão, e não um prazo: o projeto não tem data fixa. **O plano conta em horas, e não em pontos**: depois dos dois primeiros sprints, o time soma as horas das tasks que fechou por sprint e refaz a previsão com esse número.

| Épico | Histórias | Horas |
| --- | --- | --- |
| EP-00 · Git e começo do projeto | 2 | 10 h |
| EP-01 · Fundação do projeto Unity | 4 | 15 h |
| EP-02 · A rodada | 6 | 26 h |
| EP-03 · Menus no visual CIATEC | 4 | 13 h |
| EP-04 · Fases e sorteio | 6 | 23 h |
| EP-05 · Feedback e tutorial | 7 | 30 h |
| EP-06 · Layout e cenário | 7 | 26 h |
| EP-07 · Registro da sessão e validação final | 6 | 20 h |

| Marco | O que se vê | Previsão |
| --- | --- | --- |
| M1 · Uma rodada joga | A build WebGL abre no navegador, mostra a instrução e as formas, e o clique acerta ou erra, rodada após rodada | fim do sprint 6, semana 12 do plano |
| M2 · As fases funcionam | Do início à fase 5, passando e tentando de novo, com os menus emulando o visual CIATEC | fim do sprint 11, semana 22 do plano |
| M3 · Jogo completo | Retornos, pausa, voz, tutorial, layout das duas orientações e o jardim | fim do sprint 17, semana 34 do plano |
| M4 · Pronto para o estudo | O registro baixado sozinho no fim da sessão, e a validação final com o GDD | fim do sprint 19, semana 38 do plano |

**Se o trabalho tiver de caber num semestre** (~16 semanas), cabe o M1, na semana 12. **Num ano letivo** (~32 semanas), cabe o M1, na semana 12 e o M2, na semana 22; o resto fica para o ano seguinte.

# 3 ÉPICOS

Cada épico está inteiro na seção 4: a descrição, por que importa, quando está pronto, e as histórias e tasks dele.

| Épico | Domínio e marco | Depende de |
| --- | --- | --- |
| EP-00 · Git e começo do projeto | Setup · M1 | — |
| EP-01 · Fundação do projeto Unity | Setup · M1 | EP-00 |
| EP-02 · A rodada | Gameplay · M1 | EP-01 |
| EP-03 · Menus no visual CIATEC | Interface · M2 | EP-01 |
| EP-04 · Fases e sorteio | Gameplay · M2 | EP-02, EP-03 |
| EP-05 · Feedback e tutorial | Interface · M3 | EP-04 |
| EP-06 · Layout e cenário | Interface · M3 | EP-02, EP-03 |
| EP-07 · Registro da sessão e validação final | Dados · M4 | EP-04, EP-05 |

# 4 ÉPICOS, HISTÓRIAS E TASKS

As histórias estão na ordem em que o time as faz. As tasks de cada uma também: as de cima vêm primeiro.

## 4.1 EP-00 — Git e começo do projeto

O time aprende a trabalhar junto no git, monta o quadro, escreve os combinados e lê o GDD. Nenhuma linha do jogo sai daqui, e é o épico que faz o resto andar.

**Por que importa:** Três pessoas mexendo no mesmo projeto Unity sem branch e pull request apagam o trabalho umas das outras na primeira semana.

**Pronto quando:**

- As três pessoas fizeram um commit numa branch e abriram um pull request revisado por outra;
- O quadro está montado, com os combinados escritos;
- As três leram as seções 1 a 8 do GDD, e as dúvidas foram respondidas.

## 4.1.1 US-00.1 — Git em equipe

**Perfil:** Time (IC) · **Horas:** 5 · **Prioridade:** P1 · **Sprint sugerido:** 1

*Como cada pessoa do time, quero trabalhar numa branch, fazer commits e abrir um pull request, para que o trabalho de três pessoas não se apague um ao outro.*

**Cenários de aceite:**

- Dado o repositório de teste, quando cada pessoa cria uma branch, faz um commit e abre um pull request, então um colega revisa e o junta ao main.
- Dado duas pessoas mudando a mesma linha, quando o segundo pull request entra, então quem o abriu resolve o conflito sem perder a mudança do outro.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-00.1.1 | Instalar o git e o GitHub Desktop (ou usar o git no terminal), e clonar um repositório de teste | 1 h · setup |
| T-00.1.2 | Fazer o curso curto 'Introduction to GitHub' (seção 9) | 2 h · setup |
| T-00.1.3 | Em dupla: criar um conflito de propósito num arquivo de texto e resolvê-lo | 1 h · setup |
| T-00.1.4 | Ler o .gitignore oficial do Unity e entender por que Library/ e Temp/ não vão para o git | 1 h · setup |

## 4.1.2 US-00.2 — O quadro, os combinados e o GDD

**Perfil:** Time (IC) · **Horas:** 5 · **Prioridade:** P1 · **Sprint sugerido:** 2

*Como o time, quero montar o quadro, escrever os combinados e ler o GDD, para que cada um saiba o que pegar, como pedir ajuda e o que vai construir.*

**Cenários de aceite:**

- Dado este plano, quando o time monta o quadro, então as histórias do sprint 1 estão em 'A fazer', com as tasks.
- Dado as seções 1 a 8 do GDD lidas, quando o time se reúne com o orientador, então cada dúvida anotada sai com resposta ou vira pergunta para o GDD.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-00.2.1 | Montar o quadro (GitHub Projects ou Trello) com as colunas A fazer, Fazendo, Em revisão e Feito | 1 h · setup |
| T-00.2.2 | Escrever os combinados: horário das 2 h, revisão de pull request, como pedir ajuda | 1 h · docs |
| T-00.2.3 | Ler as seções 1 a 8 do GDD, olhando as figuras, e anotar as dúvidas no quadro | 2 h · docs |
| T-00.2.4 | Reunião curta com o orientador para responder às dúvidas | 1 h · docs |

## 4.2 EP-01 — Fundação do projeto Unity

O repositório do jogo, o projeto Unity 2D, a cena com as telas, a build para o navegador e o lugar único dos valores do jogo (cores e tempos). É o esqueleto em que todo o resto se encaixa.

**Por que importa:** Sem uma estrutura combinada desde o começo, três pessoas criam três jeitos de fazer a mesma coisa, e o projeto fica difícil de juntar.

**Pronto quando:**

- O repositório tem o projeto Unity 2D, o .gitignore e o README com como abrir;
- A cena troca de tela pelo gerenciador de telas;
- A build WebGL abre no navegador.

## 4.2.1 US-01.1 — Repositório e projeto criados

**Perfil:** Time (IC) · **Horas:** 3 · **Prioridade:** P1 · **Sprint sugerido:** 2

*Como o time, quero ter o repositório com o projeto Unity 2D e a estrutura de pastas, para que cada pessoa saiba onde pôr cada coisa.*

**Requisitos do GDD que ela realiza:**

- `RT-66` — O jogo não depende do M3Kit nem do pacote da plataforma

**Cenários de aceite:**

- Dado o repositório clonado, quando a pessoa abre a pasta no Unity Hub, então o projeto abre sem erro no Console.
- Dado o projeto, quando alguém procura o pacote da plataforma CIATEC ou o M3Kit, então não os acha: o jogo é autônomo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.1.1 | Criar o repositório no GitHub com o .gitignore do Unity e o README | 1 h · setup |
| T-01.1.2 | Criar o projeto Unity 2D (6000.3) e as pastas Scripts, Prefabs, Scenes, Art, Audio e Data dentro de Assets/Game/ | 1 h · setup |
| T-01.1.3 | Escrever no README como abrir o projeto e onde mora cada coisa | 1 h · docs |

## 4.2.2 US-01.2 — As telas numa cena só

**Perfil:** Time (IC) · **Horas:** 5 · **Prioridade:** P1 · **Sprint sugerido:** 3

*Como o time, quero ter uma cena com cada tela num painel e um gerenciador que mostra uma por vez, para que o fluxo da seção 7.3 tenha onde morar.*

**Cenários de aceite:**

- Dado a cena principal, quando o gerenciador recebe 'Fases', então só o painel da grade de fases aparece.
- Dado um painel que ainda não existe, quando o gerenciador recebe o nome dele, então aparece um aviso no Console, e não um erro.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.2.1 | Criar a cena principal com um Canvas e os painéis vazios: início, configurações, fases e jogo | 2 h · presentation |
| T-01.2.2 | Escrever o GerenciadorDeTelas (mostra uma tela, esconde as outras) | 2 h · presentation |
| T-01.2.3 | Botões provisórios que levam de uma tela à outra, na ordem da seção 7.3 | 1 h · presentation |

## 4.2.3 US-01.3 — Build para o navegador

**Perfil:** Time (IC) · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 3

*Como o time, quero gerar a build WebGL e abri-la no navegador, para que possa jogar e conferir o jogo como ele vai ser entregue.*

**Cenários de aceite:**

- Dado a cena principal, quando a pessoa gera a build WebGL e a abre no navegador, então o jogo abre e as telas trocam pelo clique.
- Dado a janela do navegador redimensionada para mais alta que larga, quando o jogo está aberto, então ele continua ocupando a janela inteira.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.3.1 | Configurar o Player Settings da WebGL: nome, ícone e o jogo ocupando a janela inteira | 1 h · setup |
| T-01.3.2 | Gerar a build WebGL e abri-la pelo Build And Run do Unity (a build não abre com duplo clique no arquivo) | 2 h · setup |
| T-01.3.3 | Abrir a build e redimensionar a janela, em pé e deitada, anotando o que se vê | 1 h · validação |

## 4.2.4 US-01.4 — Os valores do jogo num lugar só

**Perfil:** Time (IC) · **Horas:** 3 · **Prioridade:** P2 · **Sprint sugerido:** 4

*Como o time, quero guardar as cores e os tempos num ScriptableObject, para que ajustar um valor sem caçar o número no código.*

**Requisitos do GDD que ela realiza:**

- `RT-61` — Os valores das seis cores se configuram num lugar só, sem mexer no código

**Cenários de aceite:**

- Dado o asset de configuração, quando alguém muda uma cor, então todas as formas daquela cor mudam sem mexer em código.
- Dado um tempo da seção 8.1, quando alguém procura onde ele está, então o acha no asset, e não espalhado pelos scripts.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-01.4.1 | Criar o ScriptableObject ConfiguracaoDoJogo com as 6 cores e os tempos da seção 8.1 | 2 h · content |
| T-01.4.2 | Preencher o asset com os tempos da seção 8.1 e cores provisórias, até a escolha da US-02.1, e deixá-lo referenciado na cena | 1 h · content |

## 4.3 EP-02 — A rodada

O coração do jogo: a instrução, as formas, o clique, o acerto e o erro, e a rodada seguinte. Ainda sem fases, sem animação e sem o layout das duas orientações — só a rodada funcionando.

**Por que importa:** É a tarefa que o estudo observa. Tudo o que vem depois enfeita, mede ou organiza esta rodada.

**Pronto quando:**

- Uma rodada mostra a instrução e as formas, e o clique decide acerto ou erro;
- A história de marco M1 foi jogada na build WebGL, do início ao fim.

## 4.3.1 US-02.1 — Ver as formas

**Perfil:** Criança · **Horas:** 7 · **Prioridade:** P1 · **Sprint sugerido:** 4

*Como criança, quero ver formas grandes e coloridas na tela, para que consiga procurar a que a instrução pede.*

**Requisitos do GDD que ela realiza:**

- `RT-72` — Os objetos são quatro formas planas, que se distinguem pela silhueta e que uma criança de 6 anos sabe nomear
- `RT-74` — As cores dos objetos são seis, com nomes diferentes entre si, e nenhuma delas aparece no cenário

**Cenários de aceite:**

- Dado uma rodada de 3 objetos, quando ela abre, então aparecem três formas planas, de cores diferentes.
- Dado as quatro formas nas seis cores, quando o time as põe lado a lado, então cada forma se distingue pela silhueta e cada cor pelo nome.
- Dado a escolha do time, quando o orientador a vê, então ela cumpre as regras da seção 2.2, tem a tabela das vizinhas e das distintas, e está aprovada.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.1.1 | Escolher as quatro formas e as seis cores pelas regras da seção 2.2 (ou ficar com as recomendadas), montar a tabela das vizinhas e das distintas, pôr as cores no asset e aprovar com o orientador | 2 h · ux |
| T-02.1.2 | Desenhar os sprites brancos das quatro formas escolhidas e os contornos, num editor de imagem | 2 h · assets |
| T-02.1.3 | Criar o prefab Forma: sprite + contorno + cor vinda do asset de configuração | 2 h · presentation |
| T-02.1.4 | Tela de teste com as 4 formas nas 6 cores, para conferir | 1 h · validação |

## 4.3.2 US-02.2 — Ler a instrução

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 5

*Como criança, quero ler a instrução em cima da tela, para que saiba o que procurar.*

**Requisitos do GDD que ela realiza:**

- `RT-01` — Toda rodada apresenta uma instrução e um conjunto de objetos selecionáveis
- `RT-30` — A rodada mostra uma instrução só
- `RT-31` — A instrução da rodada está sempre na tela em texto, com o áudio ligado ou desligado
- `RT-90` — No modo só cor a instrução é "Encontre o <cor>"; no modo cor e forma, "Encontre o <forma> <cor>", com o artigo e a cor concordando com o gênero da forma
- `RT-76` — A instrução e os objetos ficam na tela até a rodada fechar

**Cenários de aceite:**

- Dado uma rodada do modo só cor com alvo vermelho, quando ela abre, então o cartão diz 'Encontre o vermelho'.
- Dado o modo cor e forma com uma forma de nome feminino, quando a rodada abre, então o artigo e a cor concordam com ela (com as recomendadas: 'Encontre a estrela vermelha').

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.2.1 | Criar o cartão da instrução com TextMeshPro, no topo da tela da rodada | 1 h · presentation |
| T-02.2.2 | Escrever a função que monta a frase pelo modelo da seção 9.2, com a concordância de gênero da forma | 2 h · gameplay |
| T-02.2.3 | Conferir na tela de teste as frases das 6 cores, sozinhas e com cada forma | 1 h · validação |

## 4.3.3 US-02.3 — Clicar e saber se acertou

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P1 · **Sprint sugerido:** 5

*Como criança, quero clicar numa forma, para que o jogo me diga se era a que a instrução pedia.*

**Requisitos do GDD que ela realiza:**

- `RT-02` — Em toda rodada, exatamente um objeto satisfaz a instrução, e os outros são distratores
- `RT-03` — No modo só cor, a instrução nomeia só uma cor, e o alvo é o único objeto daquela cor
- `RT-04` — No modo cor e forma, a instrução nomeia uma forma e uma cor, e o alvo é o único objeto que tem as duas
- `RT-06` — Selecionar o objeto que satisfaz a instrução conta como acerto, e selecionar qualquer outro conta como seleção incorreta
- `RT-11` — Um clique ou um toque sobre um objeto o seleciona
- `RT-12` — A seleção não exige arrastar, segurar nem duplo clique
- `RT-13` — O jogo não usa câmera, microfone nem outro sensor

**Cenários de aceite:**

- Dado a instrução 'Encontre o vermelho', quando ela clica na única forma vermelha, então o jogo registra acerto.
- Dado a mesma rodada, quando ela clica numa forma azul, então o jogo registra seleção incorreta.
- Dado o modo cor e forma, quando ela clica num quadrado vermelho e o pedido é a estrela vermelha, então é seleção incorreta.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.3.1 | Escrever a classe Rodada em C# puro: alvo, objetos, e o método que diz se uma escolha acerta | 2 h · gameplay |
| T-02.3.2 | Pôr as formas da rodada numa fileira simples, provisória até o layout do EP-06 | 1 h · presentation |
| T-02.3.3 | Ligar o clique de cada forma à regra, por um controlador fino na cena | 2 h · presentation |

## 4.3.4 US-02.4 — Errar e tentar de novo

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P1 · **Sprint sugerido:** 6

*Como criança, quero poder clicar de novo depois de errar, para que eu ache a forma sem perder nada.*

**Requisitos do GDD que ela realiza:**

- `RT-41` — Depois de um erro, a rodada continua aberta, e a criança pode selecionar de novo até acertar, ou até o tempo limite acabar
- `RT-85` — Rodada correta é a que acertou na primeira tentativa, e só ela conta para o portão; com erro, não resolvida e omissão não contam
- `RT-89` — O jogo não tem vidas nem pontuação

**Cenários de aceite:**

- Dado uma seleção incorreta, quando ela clica em outra forma, então o jogo aceita o clique e confere de novo.
- Dado uma rodada acertada só na segunda tentativa, quando ela fecha, então conta como rodada com erro, e não como correta.
- Dado qualquer rodada, quando o time procura vidas ou pontos, então não acha nenhum.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.4.1 | Contar as tentativas na Rodada e marcar 'correta' só no acerto de primeira | 1 h · gameplay |
| T-02.4.2 | Na cena, manter a rodada aberta depois de um erro | 1 h · presentation |
| T-02.4.3 | Escrever no Console, ao fechar cada rodada, se ela foi correta ou com erro, para conferir jogando | 1 h · validação |

## 4.3.5 US-02.5 — A rodada seguinte abre sozinha

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P1 · **Sprint sugerido:** 6

*Como criança, quero que a próxima rodada apareça depois do acerto, para que eu siga jogando sem apertar nada.*

**Requisitos do GDD que ela realiza:**

- `RT-38` — Depois do retorno de acerto, a troca para a rodada seguinte começa sem outra ação, enquanto houver rodadas
- `RT-77` — Durante o retorno de acerto, tocar num objeto não faz nada

**Cenários de aceite:**

- Dado um acerto, quando passam 500 ms, então a troca para uma rodada nova começa, com outra instrução.
- Dado um acerto, quando ela clica em outra forma antes da rodada nova, então nada acontece.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.5.1 | Gerar uma rodada nova 500 ms depois do acerto (por enquanto, rodadas fixas de teste) | 2 h · presentation |
| T-02.5.2 | Ignorar os cliques entre o acerto e a rodada nova | 1 h · presentation |

## 4.3.6 US-02.6 — Marco M1: uma sessão de rodadas no navegador

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 6 · **história de marco M1**

*Como criança, quero jogar 5 rodadas seguidas na build WebGL, para que o time veja o jogo de verdade, e não só peças.*

**Cenários de aceite:**

- Dado a build WebGL aberta no navegador, quando a pessoa joga 5 rodadas, errando em uma, então todas abrem, aceitam o clique e passam para a seguinte.
- Dado a mesma sessão, quando o time abre o console do navegador (F12), então não há nenhuma exceção.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-02.6.1 | Gerar a build WebGL e jogar 5 rodadas, anotando o que se viu | 1 h · validação |
| T-02.6.2 | Corrigir o que apareceu e repetir até passar | 2 h · validação |
| T-02.6.3 | Registrar no quadro as capturas da sessão | 1 h · docs |

## 4.4 EP-03 — Menus no visual CIATEC

O início, as configurações do mediador e a grade de fases, emulando a moldura dos menus dos pacotes CIATEC sem usar o pacote. Vem antes das fases porque a grade é onde as fases começam e terminam.

**Por que importa:** O mediador prepara a sessão sozinho, e o jogo fica com a cara dos outros jogos CIATEC.

**Pronto quando:**

- As três telas de menu têm a barra e o painel da moldura emulada;
- As configurações têm todos os campos e padrões da seção 7.3;
- A grade mostra liberada, concluída e bloqueada.

## 4.4.1 US-03.1 — A moldura dos menus

**Perfil:** Mediador · **Horas:** 3 · **Prioridade:** P2 · **Sprint sugerido:** 7

*Como mediador, quero ver os menus com a barra CIATEC e o painel, para que o jogo pareça parte da família CIATEC.*

**Requisitos do GDD que ela realiza:**

- `RT-63` — O início, as configurações e a grade de fases têm a barra e o painel da moldura dos menus CIATEC, com as cores e as medidas da pasta `visual-menus`
- `RT-64` — A barra das telas de menu traz o símbolo e a marca CIATEC
- `RT-92` — Os menus só têm o tema claro

**Cenários de aceite:**

- Dado qualquer tela de menu, quando ela abre, então há a barra com o símbolo e a marca CIATEC, e o painel translúcido no tema claro.
- Dado o projeto, quando o time procura o M3Kit, então não o acha: o visual é reproduzido com sprites e cores próprios.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.1.1 | Criar o prefab Barra e o prefab Painel com o símbolo, as fontes e as medidas de documentation/visual-menus, conferindo com as figuras menu-*.png | 2 h · presentation |
| T-03.1.2 | Pôr as cores do tema claro (tabela de visual-menus/README.md) no asset de configuração e usá-las nos prefabs | 1 h · presentation |

## 4.4.2 US-03.2 — A tela de início

**Perfil:** Mediador · **Horas:** 1 · **Prioridade:** P2 · **Sprint sugerido:** 7

*Como mediador, quero ver o nome do jogo e um botão de começar, para que eu saiba que o jogo abriu e por onde seguir.*

**Cenários de aceite:**

- Dado o jogo aberto, quando aparece o início, então há o nome e o botão Começar, como na figura menu-inicio.png.
- Dado o início, quando o mediador clica em Começar, então abrem as configurações.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.2.1 | Montar a tela de início na moldura, com o botão para as configurações | 1 h · presentation |

## 4.4.3 US-03.3 — As configurações do mediador

**Perfil:** Mediador · **Horas:** 4 · **Prioridade:** P2 · **Sprint sugerido:** 7

*Como mediador, quero digitar o código da criança e escolher as opções da sessão, para que a sessão comece do jeito que o estudo pede.*

**Requisitos do GDD que ela realiza:**

- `RT-18` — A tela de configurações vem depois do início e antes do tutorial
- `RT-35` — A tela de configurações tem o código da criança, as fases liberadas, o tempo limite, o áudio, a voz e a mãozinha do tutorial
- `RT-91` — Os padrões das configurações são fases liberadas até a 1, tempo limite desligado, áudio ligado, voz ligada e mãozinha ligada
- `RT-106` — O código pseudônimo é o que o mediador digita nas configurações
- `RT-20` — O limite de tempo vem desligado
- `RT-58` — O limite de tempo pode ser ligado na configuração, e ligado vale 15 s no padrão

**Cenários de aceite:**

- Dado as configurações abertas, quando o mediador não mexe em nada, então os padrões são fases liberadas até a 1, tempo desligado, áudio ligado, voz ligada e mãozinha ligada.
- Dado o código vazio, quando ele clica em Começar, então o campo pede o código e a sessão não começa.
- Dado o tempo limite ligado, quando a sessão começa, então ele vale 15 s.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.3.1 | Montar a tela pela figura janela-menus.png, com o campo de 48 dp e os seletores segmentados de 44 dp (Toggle e ToggleGroup) | 2 h · presentation |
| T-03.3.2 | Guardar as escolhas num objeto Sessao, com os padrões da seção 7.3 | 1 h · gameplay |
| T-03.3.3 | Exigir o código antes de começar, com o aviso no campo | 1 h · presentation |

## 4.4.4 US-03.4 — A grade de fases

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P2 · **Sprint sugerido:** 8

*Como criança, quero ver as fases em cards e clicar na que está liberada, para que eu escolha onde jogar e veja o que já fiz.*

**Requisitos do GDD que ela realiza:**

- `RT-19` — Tocar num card liberado da grade começa aquela fase
- `RT-83` — A grade abre com as fases liberadas até a escolhida nas configurações, e o padrão é só a 1; nada se guarda entre sessões
- `RT-134` — A grade mostra as cinco fases em cards de 140 dp ou mais: a liberada com a borda acesa, a concluída com ✓, a bloqueada com cadeado
- `RT-135` — O card mostra o número da fase, uma miniatura do que ela tem e uma linha curta para o mediador
- `RT-136` — Tocar num card bloqueado não abre a fase e diz qual fase passar para liberá-la
- `RT-137` — O voltar da barra da grade volta ao início
- `RT-33` — Nenhum estado da interface — acerto, erro, fase bloqueada ou concluída — se indica só pela cor

**Cenários de aceite:**

- Dado a sessão começando, quando a grade abre, então as cinco fases aparecem em cards de 140 dp ou mais, que preenchem a largura do painel.
- Dado as fases liberadas até a escolhida nas configurações, quando a grade abre, então essas são clicáveis e as outras têm cadeado.
- Dado uma fase bloqueada, quando ela é clicada, então nada abre e aparece 'Passe a fase N para liberar a fase N + 1'.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-03.4.1 | Criar o prefab Card pela figura menu-fases.png, com os três estados (liberada, concluída com o visto, bloqueada) | 2 h · presentation |
| T-03.4.2 | Montar a grade com os 5 cards de 140 dp ou mais, preenchendo a largura do painel | 1 h · presentation |
| T-03.4.3 | Ligar o clique: começar a fase ou mostrar o aviso | 1 h · presentation |
| T-03.4.4 | O voltar da barra leva ao início | 1 h · presentation |

## 4.5 EP-04 — Fases e sorteio

O gerador que sorteia cada rodada pelas regras da fase, as cinco fases, o portão de 4 acertos de primeira em 5, e o cartão do fim de cada fase, com tentar de novo e voltar às fases.

**Por que importa:** É o que transforma rodadas soltas num jogo com começo, meio e fim, e o que deixa a dificuldade comparável por fase.

**Pronto quando:**

- As garantias G-01, G-03, G-04 e G-05 foram conferidas jogando;
- Passar e tentar de novo funcionam, com a grade e o cartão do fim da fase;
- A história de marco M2 foi jogada do início à fase 5.

## 4.5.1 US-04.1 — As cinco fases como dados

**Perfil:** Time (IC) · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 8

*Como o time, quero descrever cada fase num asset, para que ajustar uma fase sem mexer no código.*

**Requisitos do GDD que ela realiza:**

- `RT-82` — Há cinco fases, da 1 à 5, e cada uma difere da anterior numa variável só
- `RT-26` — A dificuldade só muda de uma fase para outra; dentro da fase ela não muda
- `RT-08` — O tamanho dos objetos é o da fase — grande, médio ou pequeno — e todos os objetos da rodada têm o mesmo tamanho
- `RT-10` — O jogo aceita qualquer regra de fase com a forma certa, sem recusá-la por estar fora da faixa da seção 12
- `G-03` — Cada fase difere da vizinha em uma variável só

**Cenários de aceite:**

- Dado os 5 assets de fase, quando o time os compara com a tabela da seção 6, então cada um muda uma variável só da anterior.
- Dado um asset de teste com 2 objetos, fora da faixa da seção 12, quando a fase é jogada, então o jogo a monta, sem recusá-la.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.1.1 | Criar o ScriptableObject RegrasDaFase e os 5 assets pela tabela da seção 6 | 2 h · content |
| T-04.1.2 | Comparar os 5 assets com a tabela da seção 6, variável por variável | 1 h · validação |
| T-04.1.3 | Jogar um asset de teste fora das faixas da seção 12 e conferir que o jogo não o recusa | 1 h · validação |

## 4.5.2 US-04.2 — Sorteio no modo só cor

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 9

*Como criança, quero receber rodadas sempre diferentes no modo só cor, para que eu não decore onde está a cor.*

**Requisitos do GDD que ela realiza:**

- `RT-139` — Cada rodada é sorteada na hora, pelas regras da fase, e a cor-alvo não se repete em duas rodadas seguidas
- `RT-73` — No modo só cor, as formas dos objetos de uma rodada se sorteiam entre as quatro, e não são todas iguais
- `RT-75` — A semelhança dos distratores tem dois graus, vizinhos e distintos, pela tabela das vizinhas e das distintas das cores escolhidas (seção 2.2); no modo só cor, todo distrator tem outra cor, com outro nome, e no modo cor e forma a semelhança vale para os distratores de outra cor
- `RT-07` — O número de objetos da rodada é o da fase, e os distratores são todos eles menos o alvo
- `RT-09` — A semelhança dos distratores é a da fase, e não muda o número de objetos
- `G-01` — Toda rodada sorteada tem exatamente um alvo
- `G-04` — Os distratores vizinhos têm outra cor, com outro nome, e não um tom da cor do alvo

**Cenários de aceite:**

- Dado a fase 1, quando o gerador sorteia, então toda rodada tem um só objeto da cor-alvo, as formas variam, e os distratores são das cores distintas da tabela da seção 2.2.
- Dado a fase 3 (cores parecidas), quando o gerador sorteia, então há distratores das cores vizinhas da tabela, e nenhum da cor do alvo.
- Dado duas rodadas seguidas, quando o gerador sorteia a segunda, então a cor-alvo é outra.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.2.1 | Escrever o Gerador em C# puro para o modo só cor, com a tabela das vizinhas e das distintas das cores escolhidas (seção 2.2) | 2 h · gameplay |
| T-04.2.2 | Não repetir a cor-alvo em duas rodadas seguidas | 1 h · gameplay |
| T-04.2.3 | Jogar 10 rodadas das fases 1 e 3 conferindo, rodada a rodada, as garantias G-01 e G-04 | 1 h · validação |

## 4.5.3 US-04.3 — Sorteio no modo cor e forma

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P1 · **Sprint sugerido:** 9

*Como criança, quero receber rodadas em que a forma também importa, para que eu precise olhar a cor e a forma.*

**Requisitos do GDD que ela realiza:**

- `RT-04` — No modo cor e forma, a instrução nomeia uma forma e uma cor, e o alvo é o único objeto que tem as duas
- `RT-05` — O modo cor e forma só aparece nas fases que o usam
- `RT-59` — As fases podem usar o modo cor e forma
- `G-05` — Toda rodada no modo cor e forma tem ao menos um distrator com a cor do alvo e outra forma, e ao menos um com a forma do alvo e outra cor

**Cenários de aceite:**

- Dado a fase 4, quando o gerador sorteia, então há um distrator com a cor do alvo e outra forma, e um com a forma do alvo e outra cor.
- Dado as fases 1 a 3, quando o gerador sorteia, então nenhuma rodada é de cor e forma.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.3.1 | Acrescentar ao Gerador o modo cor e forma, com os dois distratores obrigatórios | 2 h · gameplay |
| T-04.3.2 | Jogar 10 rodadas da fase 4 conferindo a garantia G-05 | 1 h · validação |

## 4.5.4 US-04.4 — Jogar uma fase e passar

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P1 · **Sprint sugerido:** 10

*Como criança, quero jogar uma fase de 5 rodadas e passar acertando 4 de primeira, para que eu sinta que avancei.*

**Requisitos do GDD que ela realiza:**

- `RT-129` — Cada fase tem 5 rodadas
- `RT-130` — Com 4 rodadas corretas das 5, a fase é concluída, ganha um ✓ na grade, e a seguinte é liberada
- `RT-140` — Repetir uma fase traz rodadas novas
- `RT-133` — Concluída a fase 5, o cartão do fim da fase diz "Você terminou todas as fases!" e só oferece voltar à grade

**Cenários de aceite:**

- Dado a fase 1, quando ela acerta de primeira 4 das 5 rodadas, então a fase é concluída, ganha o visto na grade e a fase 2 é liberada.
- Dado uma fase concluída jogada de novo, quando as rodadas aparecem, então são outras, sorteadas na hora.
- Dado a fase 5 concluída, quando o cartão abre, então diz 'Você terminou todas as fases!' e só oferece voltar às fases.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.4.1 | Escrever a classe Fase: 5 rodadas, contar as corretas, decidir se passou | 2 h · gameplay |
| T-04.4.2 | Ligar a Fase à tela de jogo e à grade: 5 rodadas, o visto e a fase seguinte liberada | 2 h · presentation |
| T-04.4.3 | Concluída a fase 5, o cartão diz 'Você terminou todas as fases!' e só oferece voltar às fases | 1 h · presentation |

## 4.5.5 US-04.5 — O cartão do fim da fase

**Perfil:** Criança · **Horas:** 3 · **Prioridade:** P1 · **Sprint sugerido:** 10

*Como criança, quero ver um cartão no fim da fase dizendo se passei, para que eu saiba se sigo em frente ou tento de novo.*

**Requisitos do GDD que ela realiza:**

- `RT-27` — Ao fim de cada fase, um cartão sem números diz se ela foi concluída; concluída, leva à fase seguinte ou à grade (a fase 5, só à grade: `RT-133`), e não concluída, a tentar de novo ou à grade
- `RT-131` — Com menos de 4 corretas, a fase não é concluída, e o cartão oferece "Tentar de novo", com rodadas novas, e "Voltar às fases"; o jogo não leva a outra fase
- `RT-29` — Nem os cartões de fase nem o resumo trazem interpretação clínica ou diagnóstico

**Cenários de aceite:**

- Dado uma fase concluída, quando o cartão abre, então diz 'Fase concluída!' e oferece a próxima fase e a grade.
- Dado 3 corretas na fase 2, quando o cartão abre, então diz 'Vamos tentar de novo!' e oferece 'Tentar de novo', com rodadas novas, e 'Voltar às fases'.
- Dado qualquer cartão, quando a criança o lê, então não há número, nota, palavra de erro nem interpretação.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.5.1 | Criar o cartão do fim da fase com os dois textos da seção 5.2 | 2 h · presentation |
| T-04.5.2 | Ligar os botões: próxima fase, tentar de novo e voltar às fases | 1 h · presentation |

## 4.5.6 US-04.6 — Marco M2: do início à fase 5 no navegador

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P1 · **Sprint sugerido:** 11 · **história de marco M2**

*Como criança, quero jogar do início à fase 5 na build WebGL, para que o time veja os menus e as fases funcionando juntos.*

**Requisitos do GDD que ela realiza:**

- `RT-93` — Os textos estão em português

**Cenários de aceite:**

- Dado a build WebGL, quando a pessoa sai do início, configura, passa a fase 1, não passa a 2 e tenta de novo, e chega à 5, então tudo acontece como nas seções 5.2 e 7.3.
- Dado a mesma sessão, quando o time lê as telas, então todos os textos estão em português.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-04.6.1 | Jogar a sequência completa na build WebGL e anotar o que se viu, regra por regra | 2 h · validação |
| T-04.6.2 | Corrigir o que apareceu e repetir | 2 h · validação |

## 4.6 EP-05 — Feedback e tutorial

Os retornos da seção 8.1 (acerto, erro, troca, tempo, pausa), a voz da instrução, as chaves de áudio e de voz, e o tutorial de uma rodada com a mãozinha.

**Por que importa:** É o que faz a criança entender o resultado sem ser punida e jogar sem saber ler.

**Pronto quando:**

- Todos os efeitos da seção 8.1 acontecem do jeito que o time propôs, dentro das regras, em até 1 s cada;
- Nada alterna claro e escuro mais de uma vez por segundo, e nenhum estado se indica só pela cor;
- O tutorial ensina o clique com a mãozinha, e a voz fala a instrução.

## 4.6.1 US-05.1 — Celebrar o acerto

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P2 · **Sprint sugerido:** 11

*Como criança, quero ver e ouvir que acertei, para que eu sinta que venci a rodada.*

**Requisitos do GDD que ela realiza:**

- `RT-37` — Selecionar o alvo produz um retorno visual de acerto
- `RT-99` — O retorno de acerto destaca o alvo sem usar cor, e acaba em até 1 s
- `RT-111` — Com o áudio ligado, o acerto toca um som curto e suave; o erro não toca som
- `RT-102` — Nenhum retorno usa cor para dizer acerto ou erro
- `RT-46` — O mesmo evento produz sempre o mesmo retorno
- `RT-48` — Nenhum efeito alterna claro e escuro mais de uma vez por segundo, nem tem som abrupto
- `RT-33` — Nenhum estado da interface — acerto, erro, fase bloqueada ou concluída — se indica só pela cor

**Cenários de aceite:**

- Dado um acerto, quando o retorno começa, então o alvo se destaca, sem cor, do jeito que o time propôs, e o retorno acaba em até 1 s.
- Dado o áudio ligado, quando ela acerta, então toca um som curto e suave.
- Dado qualquer retorno, quando o time o observa, então nada alterna claro e escuro mais de uma vez por segundo, e o acerto não se indica por cor.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.1.1 | Propor a forma dos retornos (acerto, erro, troca, tempo) dentro das regras da seção 8.1, partindo da recomendação, e aprovar com o orientador | 1 h · ux |
| T-05.1.2 | O destaque do alvo no acerto, sem cor (recomendação: contorno grosso que cresce para 1,1 vez em 300 ms) | 2 h · presentation |
| T-05.1.3 | A celebração do acerto (recomendação: oito brilhos claros que saem do alvo em 600 ms) | 2 h · presentation |
| T-05.1.4 | O som curto e suave do acerto, só com o áudio ligado (recomendação: duas notas subindo) | 1 h · assets |

## 4.6.2 US-05.2 — O retorno do erro

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P2 · **Sprint sugerido:** 12

*Como criança, quero ver que a forma que cliquei não era a certa, sem levar bronca, para que eu tente outra.*

**Requisitos do GDD que ela realiza:**

- `RT-39` — Selecionar um distrator produz um retorno visual de que a seleção não corresponde ao alvo
- `RT-100` — O retorno de erro aparece no objeto escolhido, que continua na tela, e acaba em até 1 s
- `RT-40` — O retorno de erro não tem som punitivo
- `RT-117` — O retorno de erro não tem cor, som nem voz

**Cenários de aceite:**

- Dado uma seleção incorreta, quando o retorno começa, então o objeto escolhido mostra que não era o alvo, do jeito que o time propôs, continua na tela, e o retorno acaba em até 1 s.
- Dado o erro, quando o time confere, então não há som, voz nem cor.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.2.1 | O retorno de erro no objeto escolhido (recomendação: balança de leve e esmaece em 400 ms, como na figura fb-erro.gif) | 2 h · presentation |

## 4.6.3 US-05.3 — A troca suave de rodada

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P2 · **Sprint sugerido:** 12

*Como criança, quero ver as formas saírem e as novas entrarem, para que eu perceba que é uma rodada nova.*

**Requisitos do GDD que ela realiza:**

- `RT-112` — A troca de rodada é uma transição: as formas e a instrução da rodada que fecha saem, e as da nova entram, em até 1 s, e não de uma vez

**Cenários de aceite:**

- Dado o fim de uma rodada, quando a troca começa, então as formas e a instrução saem e as novas entram numa transição de até 1 s, e não de uma vez.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.3.1 | A saída das formas e da instrução (recomendação: encolher até sumir em 250 ms) | 1 h · presentation |
| T-05.3.2 | A entrada das formas e da instrução nova (recomendação: crescer do zero em 250 ms) | 1 h · presentation |

## 4.6.4 US-05.4 — A voz da instrução e as chaves de som

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P2 · **Sprint sugerido:** 12

*Como criança que ainda não lê, quero ouvir a instrução e poder ouvi-la de novo, para que eu saiba o que procurar.*

**Requisitos do GDD que ela realiza:**

- `RT-49` — Com a voz ligada, a instrução é falada quando a rodada abre
- `RT-42` — Tocar em repetir reapresenta a instrução: o texto, e a voz quando ligada
- `RT-103` — Tocar em repetir com a voz falando recomeça a fala
- `RT-78` — Com a voz falando, tocar num objeto o seleciona
- `RT-122` — Tocar em qualquer ponto do cartão da instrução repete a instrução
- `RT-50` — O áudio pode ser desligado inteiro, e com ele desligado toda rodada pode ser jogada até o fim
- `RT-51` — Desligar o áudio desliga também os sons do retorno
- `RT-105` — Há duas chaves de som: o áudio inteiro, e a voz na instrução

**Cenários de aceite:**

- Dado a voz ligada, quando a rodada abre, então a instrução é falada.
- Dado a voz falando, quando ela clica no cartão da instrução, então a fala recomeça.
- Dado o áudio desligado, quando ela joga uma rodada inteira, então consegue terminar só com o texto.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.4.1 | Gravar as frases (6 do modo só cor, 24 do cor e forma e a do tutorial) com voz humana, numa ferramenta local | 2 h · assets |
| T-05.4.2 | Tocar a frase certa quando a rodada abre, com a voz ligada | 2 h · presentation |
| T-05.4.3 | O cartão inteiro repete a instrução, e recomeça a fala | 1 h · presentation |
| T-05.4.4 | As duas chaves: o áudio inteiro, e a voz | 1 h · presentation |

## 4.6.5 US-05.5 — Pausar, retomar e sair

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P2 · **Sprint sugerido:** 13

*Como criança, quero pausar o jogo e voltar, ou sair da fase, para que eu descanse sem perder nada.*

**Requisitos do GDD que ela realiza:**

- `RT-43` — Tocar em pausar suspende a rodada, esconde os objetos e mostra retomar, sair e as chaves de áudio e de voz
- `RT-44` — Retomar volta à rodada pausada no estado em que ela estava
- `RT-67` — O tempo que a rodada passa pausada não entra no tempo de resposta nem no tempo limite
- `RT-45` — Tocar em sair pede confirmação, e confirmar sai da fase e volta à grade
- `RT-65` — O tutorial, as rodadas, o retorno e a pausa têm o tema do jogo, e não o M3

**Cenários de aceite:**

- Dado uma rodada, quando ela clica na pausa, então as formas somem e aparecem retomar, sair e as chaves de áudio e de voz.
- Dado a pausa, quando ela retoma, então a rodada volta igual, e o tempo pausado não contou.
- Dado sair, quando ela confirma, então volta à grade de fases.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.5.1 | Os botões de pausa e de sair em toda tela de jogo | 1 h · presentation |
| T-05.5.2 | A tela de pausa, no tema do jogo e não no dos menus: esconder as formas, retomar, sair e as chaves | 2 h · presentation |
| T-05.5.3 | A confirmação de sair, de volta à grade | 1 h · presentation |

## 4.6.6 US-05.6 — O tempo limite e o indicador

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P3 · **Sprint sugerido:** 13

*Como criança, quero ver um indicador que mostra o tempo, quando ele está ligado, para que eu saiba que há tempo sem ver números.*

**Requisitos do GDD que ela realiza:**

- `RT-115` — Com o limite ligado, um indicador sem número e sem cor de alerta mostra, em ritmo constante, o tempo que resta
- `RT-116` — O indicador do tempo para na pausa e no acerto, e na pausa continua de onde parou ao retomar
- `RT-101` — Quando o tempo limite acaba sem acerto, o jogo mostra qual era o alvo, e a rodada seguinte abre

**Cenários de aceite:**

- Dado o tempo ligado, quando a rodada abre, então um indicador sem número e sem cor de alerta mostra, em ritmo constante, o tempo que resta dos 15 s.
- Dado o tempo acabando sem acerto, quando chega a zero, então o jogo mostra qual era o alvo e a rodada seguinte abre.
- Dado a pausa, quando ela é retomada, então o indicador continua de onde parou.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.6.1 | Relógio da rodada que para na pausa e no acerto | 2 h · gameplay |
| T-05.6.2 | O indicador do tempo, sem número nem cor de alerta (recomendação: uma barra fina sob a instrução; o Image do tipo Filled precisa de um sprite, ou desenha um retângulo parado) | 1 h · presentation |
| T-05.6.3 | Mostrar o alvo quando o tempo acaba (recomendação: um contorno que pulsa por 1 s), e abrir a rodada seguinte | 1 h · presentation |

## 4.6.7 US-05.7 — O tutorial de uma rodada

**Perfil:** Criança · **Horas:** 6 · **Prioridade:** P2 · **Sprint sugerido:** 14

*Como criança no primeiro contato, quero ver a mãozinha mostrar o clique, para que eu entenda o que fazer sem ler.*

**Requisitos do GDD que ela realiza:**

- `RT-14` — Com a mãozinha ligada, a mãozinha vai até o alvo da rodada do tutorial e repete o gesto de tocar até a criança tocar, e só o toque da criança seleciona
- `RT-114` — A instrução da rodada do tutorial é "Vamos treinar! Toque no <cor>.", em texto e em voz, e a rodada é sempre a mesma: três formas grandes, de cores distintas, com o alvo sempre da mesma cor
- `RT-79` — Com a mãozinha desligada, a rodada do tutorial não tem mãozinha
- `RT-15` — O tutorial tem uma rodada só, que a criança resolve
- `RT-16` — A rodada do tutorial não tem limite de tempo
- `RT-80` — A rodada do tutorial não conta para o portão da fase nem para os indicadores
- `RT-17` — Depois da rodada do tutorial, um cartão oferece começar a fase
- `RT-81` — O tutorial abre uma vez por sessão, antes da primeira fase jogada
- `RT-32` — O cartão que repete a instrução e os botões de pausar e sair estão em toda tela de jogo, inclusive no tutorial

**Cenários de aceite:**

- Dado a primeira fase da sessão, quando ela começa, então a instrução diz 'Vamos treinar! Toque no <cor do tutorial>.' e a mãozinha vai até o alvo e repete o gesto, como na figura tutorial.gif.
- Dado o tutorial, quando ela clica no alvo, então um cartão diz 'Agora é com você!' e oferece começar a fase; o tutorial não conta para o portão.
- Dado o tutorial, quando ela olha a tela, então os botões de repetir, pausar e sair estão nela.
- Dado a segunda fase da sessão, quando ela começa, então não há tutorial.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-05.7.1 | A rodada fixa do tutorial — três formas grandes de cores distintas, o alvo sempre da mesma cor e a instrução 'Vamos treinar! Toque no <cor>.' —, sem tempo e fora da contagem | 2 h · gameplay |
| T-05.7.2 | Abrir o tutorial só antes da primeira fase jogada na sessão | 1 h · gameplay |
| T-05.7.3 | A mãozinha que vai ao alvo e repete o gesto de tocar | 2 h · presentation |
| T-05.7.4 | O cartão 'Agora é com você!', que oferece começar a fase, e a chave da mãozinha | 1 h · presentation |

## 4.7 EP-06 — Layout e cenário

O layout em dp que se reorganiza quando a janela fica mais alta que larga (retrato) ou mais larga que alta (paisagem), o botão pressionado, as configurações que rolam, e o jardim do cenário.

**Por que importa:** A janela do navegador muda de forma o tempo todo; sem este épico, o jogo só fica bem num tamanho.

**Pronto quando:**

- O jogo funciona em janelas em retrato e em paisagem, e redimensionar no meio da rodada não perde nada;
- Os tamanhos da seção 7.4 foram medidos numa captura;
- A história de marco M3 foi jogada nas duas formas de janela.

## 4.7.1 US-06.1 — O layout das duas orientações

**Perfil:** Criança · **Horas:** 10 · **Prioridade:** P2 · **Sprint sugerido:** 15

*Como criança, quero jogar com a janela em pé ou deitada, para que o jogo caiba em qualquer janela.*

**Requisitos do GDD que ela realiza:**

- `RT-118` — O jogo roda no navegador, em janelas em retrato (mais altas que largas) e em paisagem (mais largas que altas)
- `RT-119` — Em retrato e em paisagem, a instrução, os botões de pausar e sair e todos os objetos ficam visíveis, e os objetos não se sobrepõem nem ficam sob os botões
- `RT-95` — O objeto grande tem o maior diâmetro que cabe com 8 objetos no arranjo da orientação atual, até 200 dp, e o médio e o pequeno têm 80 % e 60 % dele
- `RT-96` — Dois objetos ficam a pelo menos 16 dp um do outro
- `RT-97` — Os botões de pausar e sair têm pelo menos 56 dp, o cartão da instrução pelo menos 56 dp de altura, e o texto da instrução pelo menos 26 dp
- `RT-34` — Os objetos de uma rodada não se sobrepõem
- `RT-127` — O sorteio dá a ordem dos objetos, sem posição; o jogo os põe nas posições do arranjo da orientação atual, na ordem
- `RT-71` — Uma rodada que a tela não comporta é montada com o que cabe, e o jogo avisa que reduziu

**Cenários de aceite:**

- Dado uma janela em retrato, quando uma rodada de 8 objetos abre, então todos aparecem no arranjo proposto, sem sobrepor nem ficar sob os botões, com 16 dp de folga ou mais.
- Dado a janela passando a paisagem, quando a mesma rodada abre, então o arranjo se reorganiza, e a instrução, os botões e os objetos continuam visíveis.
- Dado as duas orientações, quando o time mede, então o objeto grande é o maior que cabe com 8 objetos no arranjo, e os botões têm pelo menos 56 dp, a 16 dp das bordas ou mais.
- Dado uma fase que pede mais objetos do que a janela comporta, quando a rodada abre, então ela sai com o que cabe e o console do navegador avisa que reduziu.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.1.1 | Propor o arranjo da rodada nas duas orientações dentro das regras da seção 7.3 (pode partir do recomendado nas figuras janela-rodada.png e medidas.png) e aprovar com o orientador | 2 h · ux |
| T-06.1.2 | Fixar devicePixelRatio = 1 na configuração do index.html do template WebGL e pôr o Canvas Scaler em Constant Pixel Size com Scale Factor 1, para 1 unidade do Canvas valer 1 px do navegador (1 dp); conferir medindo um botão de 56 dp em duas janelas de tamanhos diferentes | 2 h · ux |
| T-06.1.3 | Calcular as posições dos objetos pelo arranjo proposto, pela orientação e pelo número de objetos, na ordem do sorteio | 2 h · presentation |
| T-06.1.4 | Calcular o tamanho grande (o que cabe com 8), e o médio e o pequeno | 1 h · presentation |
| T-06.1.5 | Posicionar a instrução e os botões pelo arranjo proposto, a 16 dp das bordas ou mais | 1 h · presentation |
| T-06.1.6 | Montar com o que cabe a rodada que não cabe, com o aviso no log | 1 h · gameplay |
| T-06.1.7 | Capturas das duas orientações com 3, 5 e 8 objetos | 1 h · validação |

## 4.7.2 US-06.2 — Redimensionar no meio da rodada

**Perfil:** Criança · **Horas:** 2 · **Prioridade:** P2 · **Sprint sugerido:** 16

*Como criança, quero que o jogo se arrume quando a janela muda de tamanho, para que eu não perca a rodada.*

**Requisitos do GDD que ela realiza:**

- `RT-120` — Redimensionar a janela no meio da rodada reorganiza a tela sem mudar a rodada, as tentativas nem o tempo

**Cenários de aceite:**

- Dado uma rodada com um erro já feito e o tempo correndo, quando a janela é redimensionada de paisagem para retrato, então a tela se reorganiza e a rodada, as tentativas e o tempo continuam iguais.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.2.1 | Detectar a mudança de tamanho da janela e reposicionar tudo sem recriar a rodada | 2 h · presentation |

## 4.7.3 US-06.3 — O botão pressionado

**Perfil:** Criança · **Horas:** 1 · **Prioridade:** P3 · **Sprint sugerido:** 16

*Como criança, quero ver a forma afundar quando aperto o mouse, para que eu saiba que o clique pegou.*

**Requisitos do GDD que ela realiza:**

- `RT-121` — Todo objeto e todo botão reagem ao botão pressionado em até 80 ms, antes de soltar: o objeto afunda, o botão escurece

**Cenários de aceite:**

- Dado o botão do mouse apertado sobre uma forma, quando passam 80 ms, então ela já afundou, antes de soltar.
- Dado o mesmo sobre um botão, quando passam 80 ms, então ele já escureceu.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.3.1 | Estado pressionado nas formas e nos botões (a cor Pressed do Button, ou o IPointerDownHandler) | 1 h · presentation |

## 4.7.4 US-06.4 — Configurações em qualquer janela

**Perfil:** Mediador · **Horas:** 3 · **Prioridade:** P3 · **Sprint sugerido:** 16

*Como mediador, quero ver todas as opções em qualquer janela, para que eu configure a sessão sem a tela cortar.*

**Requisitos do GDD que ela realiza:**

- `RT-124` — Quando a janela não comporta as configurações, elas rolam, e o Começar fica sempre visível embaixo

**Cenários de aceite:**

- Dado as configurações numa janela em retrato, quando ela abre, então há uma coluna, com o rótulo em cima do seletor, como na figura janela-menus.png.
- Dado uma janela em paisagem, quando ela abre, então há duas colunas, com o rótulo ao lado.
- Dado uma janela baixa demais, quando o mediador rola, então chega a todas as opções, e o Começar fica sempre visível embaixo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.4.1 | Uma coluna em retrato e duas em paisagem, com o rótulo em cima ou ao lado | 2 h · presentation |
| T-06.4.2 | Pôr as opções num ScrollRect com o Começar fixo embaixo | 1 h · presentation |

## 4.7.5 US-06.5 — O jardim do cenário

**Perfil:** Criança · **Horas:** 5 · **Prioridade:** P3 · **Sprint sugerido:** 16

*Como criança, quero jogar num jardim calmo, para que o jogo seja bonito sem me distrair.*

**Requisitos do GDD que ela realiza:**

- `RT-125` — O céu e o chão do cenário cobrem a tela inteira, sem faixas, em qualquer proporção
- `RT-126` — As peças do cenário ficam nos cantos de baixo, crescem pelo lado curto e não se deformam quando a tela gira; numa tela estreita, somem as flores e depois a cerca
- `RT-94` — Todas as rodadas usam o mesmo cenário, e nada nele se move
- `RT-142` — Nenhuma peça nem cor do cenário é uma das seis cores do jogo
- `RT-65` — O tutorial, as rodadas, o retorno e a pausa têm o tema do jogo, e não o M3
- `RT-98` — Os objetos têm contraste de pelo menos 3:1 com o cenário, e o texto, de pelo menos 4,5:1 com o fundo
- `G-02` — Nenhum objeto do cenário traz representação estereotipada

**Cenários de aceite:**

- Dado qualquer proporção de janela, quando o jogo abre, então o céu e o chão cobrem tudo, sem faixas.
- Dado a janela mudando de forma, quando o time olha a cerca e a árvore, então elas ficam nos cantos de baixo, crescem pelo lado curto da janela e não esticam.
- Dado uma janela estreita demais, quando o jogo abre, então somem as flores e, se ainda faltar espaço, a cerca; a árvore fica.
- Dado o cenário, quando o time confere as cores, então nenhuma é uma das seis do jogo, as formas têm contraste de 3:1 com ele, e o texto de 4,5:1 com o fundo.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.5.1 | Desenhar o céu, o chão, a cerca, a árvore e as flores, sem as seis cores do jogo | 2 h · assets |
| T-06.5.2 | Montar o cenário com as peças ancoradas nos cantos de baixo | 1 h · presentation |
| T-06.5.3 | Fazer as peças crescerem pelo lado curto da janela e, numa janela estreita, esconder as flores e depois a cerca | 1 h · presentation |
| T-06.5.4 | Medir o contraste das formas contra o cenário e do texto contra o fundo, e registrar | 1 h · validação |

## 4.7.6 US-06.6 — O jardim por trás dos menus

**Perfil:** Mediador · **Horas:** 1 · **Prioridade:** P4 · **Sprint sugerido:** 17

*Como mediador, quero ver o jardim por trás do painel dos menus, para que o jogo pareça um só, do menu à rodada.*

**Requisitos do GDD que ela realiza:**

- `RT-141` — Nos menus, o jardim do cenário aparece por trás do painel translúcido, e a barra de cima é opaca

**Cenários de aceite:**

- Dado qualquer menu, quando ele abre, então o jardim aparece por trás do painel translúcido, e a barra de cima é opaca.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.6.1 | Pôr o cenário atrás de todas as telas e conferir a transparência do painel | 1 h · presentation |

## 4.7.7 US-06.7 — Marco M3: o jogo completo, nas duas formas de janela

**Perfil:** Criança · **Horas:** 4 · **Prioridade:** P2 · **Sprint sugerido:** 17 · **história de marco M3**

*Como criança, quero jogar o jogo completo na build WebGL, para que o time veja tudo junto, nas duas orientações.*

**Requisitos do GDD que ela realiza:**

- `RT-36` — O fluxo segue a ordem da seção 7.3: início, configurações, fases, tutorial (uma vez), fase, cartão do resultado, e de volta às fases ou à fase seguinte

**Cenários de aceite:**

- Dado a build WebGL, quando a pessoa joga do início ao fim, em janela em retrato e em paisagem, redimensionando no meio, então o fluxo segue a ordem da seção 7.3, e os retornos, a pausa, a voz e o tutorial funcionam.
- Dado a mesma sessão, quando o time abre o console do navegador, então não há exceção.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-06.7.1 | Jogar a sessão completa nas duas formas de janela, anotando | 2 h · validação |
| T-06.7.2 | Corrigir o que apareceu e repetir | 2 h · validação |

## 4.8 EP-07 — Registro da sessão e validação final

O código pseudônimo, os eventos de cada rodada, fase e controle, o resumo por fase, o arquivo gravado sozinho, e a validação final do jogo com o GDD na mão.

**Por que importa:** É o que o pesquisador leva da sessão — sem o registro, o jogo diverte, mas não serve ao estudo —, e a prova de que o jogo é o que o GDD pediu.

**Pronto quando:**

- Uma sessão baixa o arquivo sozinho para a pasta de downloads quando termina;
- O arquivo tem os eventos da seção 13.1 e o resumo por fase, e nenhum dado identifica a criança;
- Todo requisito do GDD foi visto acontecer, ou virou task.

## 4.8.1 US-07.1 — Registrar a rodada

**Perfil:** Pesquisador · **Horas:** 5 · **Prioridade:** P2 · **Sprint sugerido:** 17

*Como pesquisador, quero ter registrada cada rodada e cada clique, para que eu saiba o que a criança viu e fez.*

**Requisitos do GDD que ela realiza:**

- `RT-52` — Todo evento registrado leva o código pseudônimo da sessão
- `RT-53` — O começo de cada rodada é registrado, com a fase, a cor-alvo, a forma-alvo no modo cor e forma e o número de objetos
- `RT-54` — Cada seleção é registrada, com o objeto, se foi acerto ou erro, e o instante
- `RT-55` — O instante de todo evento é relativo ao começo da sessão, e nenhum registro tem data ou hora do relógio
- `RT-68` — O começo de cada rodada registra também o tamanho, a semelhança dos distratores, o tempo limite e a voz
- `RT-107` — O começo de cada rodada registra o instante em que os objetos aparecem e, com a voz ligada, o instante em que ela termina
- `RT-108` — O fechamento de cada rodada é registrado numa só das quatro categorias — correta, com erro, não resolvida ou omissão —, pelas definições da seção 13.3
- `RT-138` — O começo de cada rodada registra a cor e a forma de cada objeto, na ordem

**Cenários de aceite:**

- Dado uma rodada, quando ela abre, então o registro guarda a fase, o alvo, a cor e a forma de cada objeto, a condição e o instante.
- Dado um clique, quando ele acontece, então o registro guarda o objeto, se acertou, e o instante desde o início da sessão.
- Dado qualquer evento, quando o time confere, então não há data nem hora do relógio, e todos levam o código.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.1.1 | Classe Registro e o modelo de evento | 2 h · content |
| T-07.1.2 | Registrar o começo da rodada, cada clique e o fechamento | 2 h · gameplay |
| T-07.1.3 | Jogar 3 rodadas e conferir o registro, campo por campo, com a seção 13.1 | 1 h · validação |

## 4.8.2 US-07.2 — Registrar as fases e os controles

**Perfil:** Pesquisador · **Horas:** 2 · **Prioridade:** P2 · **Sprint sugerido:** 18

*Como pesquisador, quero ter registrados o começo e o fim de cada fase e o uso dos controles, para que eu veja a progressão e se os controles foram usados.*

**Requisitos do GDD que ela realiza:**

- `RT-69` — O fim de cada fase é registrado, com a fase, as corretas, e se ela foi concluída
- `RT-70` — Todo uso de repetir, pausar, retomar, sair e das chaves de áudio e de voz é registrado, inclusive pela pausa

**Cenários de aceite:**

- Dado uma fase, quando ela começa e quando fecha, então o registro guarda a fase e, no fim, as corretas e se ela foi concluída.
- Dado o uso da pausa e das chaves, quando o registro é lido, então cada uso está lá, com o novo estado.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.2.1 | Registrar o começo e o fim da fase | 1 h · gameplay |
| T-07.2.2 | Registrar repetir, pausar, retomar, sair e as chaves de áudio e de voz | 1 h · gameplay |

## 4.8.3 US-07.3 — O resumo por fase

**Perfil:** Pesquisador · **Horas:** 3 · **Prioridade:** P3 · **Sprint sugerido:** 18

*Como pesquisador, quero ter um resumo de cada fase jogada, para que eu olhe a sessão sem ler evento por evento.*

**Requisitos do GDD que ela realiza:**

- `RT-28` — O arquivo da sessão traz o resumo por fase jogada: as rodadas iniciadas, as corretas, os acertos, o tempo mediano de resposta, as seleções incorretas, as omissões, e se a fase foi concluída *(o tempo de resposta depende da seção 14)*

**Cenários de aceite:**

- Dado uma sessão de duas fases, quando o resumo é gerado, então há uma linha por fase jogada, com rodadas, corretas, acertos, tempo mediano de resposta, seleções incorretas, omissões e se foi concluída.
- Dado o resumo, quando o time o lê, então não há interpretação nem diagnóstico.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.3.1 | Calcular o resumo por fase a partir dos eventos, com o tempo mediano nas duas bases da seção 13.3 (desde os objetos e desde o fim da voz) até os pesquisadores escolherem uma | 2 h · content |
| T-07.3.2 | Conferir o resumo de uma sessão jogada contando os eventos à mão | 1 h · validação |

## 4.8.4 US-07.4 — Gravar o arquivo sozinho

**Perfil:** Pesquisador · **Horas:** 5 · **Prioridade:** P2 · **Sprint sugerido:** 18

*Como pesquisador, quero que o arquivo seja gravado sem ninguém precisar lembrar, para que nenhuma sessão se perca.*

**Requisitos do GDD que ela realiza:**

- `RT-57` — O arquivo da sessão baixa sozinho uma vez, quando a sessão termina no voltar da grade
- `RT-62` — O registro fica no computador onde a sessão roda, na pasta de downloads, e nada é enviado para fora

**Cenários de aceite:**

- Dado o mediador voltando da grade ao início, quando a sessão termina, então o arquivo baixa sozinho, uma vez, para a pasta de downloads.
- Dado o arquivo baixado, quando o time confere, então nada foi enviado para fora do computador.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.4.1 | Combinar com o orientador o formato (CSV ou JSON) e o nome do arquivo | 1 h · research |
| T-07.4.2 | Escrever o arquivo no formato combinado | 2 h · content |
| T-07.4.3 | Baixar o arquivo sozinho quando a sessão termina (no voltar da grade), por um .jslib pequeno que dispara o download do navegador | 2 h · content |

## 4.8.5 US-07.5 — Privacidade

**Perfil:** Pesquisador · **Horas:** 1 · **Prioridade:** P2 · **Sprint sugerido:** 18

*Como pesquisador, quero que o registro só tenha o código, e nada que identifique a criança, para que o estudo respeite a LGPD.*

**Requisitos do GDD que ela realiza:**

- `RT-56` — Nenhum registro traz nome, imagem, voz ou outro dado que identifique a criança
- `RT-106` — O código pseudônimo é o que o mediador digita nas configurações

**Cenários de aceite:**

- Dado o arquivo de uma sessão, quando o time o lê inteiro, então só há o código digitado pelo mediador, e nenhum nome, imagem ou voz.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.5.1 | Revisar o arquivo procurando qualquer dado que identifique, e registrar a revisão | 1 h · research |

## 4.8.6 US-07.6 — Marco M4: validação final com o GDD na mão

**Perfil:** Pesquisador · **Horas:** 4 · **Prioridade:** P2 · **Sprint sugerido:** 19 · **história de marco M4**

*Como pesquisador, quero jogar com a seção 15 do GDD aberta, requisito por requisito, e abrir o arquivo da sessão, para que o jogo seja o que o documento pediu.*

**Cenários de aceite:**

- Dado cada requisito da seção 15, quando o time joga a build WebGL, então anota 'vi acontecer', 'não vi e devia' ou 'não dava para ver'.
- Dado uma sessão jogada, passando uma fase, saindo no meio da outra e voltando ao início, quando o pesquisador abre o arquivo baixado, então entende cada linha com a seção 13 ao lado.
- Dado um 'não vi e devia', quando a validação termina, então há uma task com o esperado e o visto.

| Task | O que fazer | Horas e camada |
| --- | --- | --- |
| T-07.6.1 | Dividir os requisitos da seção 15 entre as três pessoas | 1 h · validação |
| T-07.6.2 | Jogar e anotar cada requisito, e abrir o arquivo de uma sessão com o orientador | 2 h · validação |
| T-07.6.3 | Abrir as tasks do que faltou | 1 h · validação |

# 5 ROADMAP

A ordem dos sprints sai da capacidade do time: cerca de 8 h nos dois primeiros sprints e 10 h depois. Um sprint pode passar um pouco disso; o que não fechar passa para o seguinte. As semanas contam do começo do plano.

| Sprint | Semanas | Histórias e horas |
| --- | --- | --- |
| 1 | 1 e 2 | US-00.1 · 5 h |
| 2 | 3 e 4 | US-00.2, US-01.1 · 8 h |
| 3 | 5 e 6 | US-01.2, US-01.3 · 9 h |
| 4 | 7 e 8 | US-01.4, US-02.1 · 10 h |
| 5 | 9 e 10 | US-02.2, US-02.3 · 9 h |
| 6 | 11 e 12 | US-02.4, US-02.5, US-02.6 · 10 h |
| 7 | 13 e 14 | US-03.1, US-03.2, US-03.3 · 8 h |
| 8 | 15 e 16 | US-03.4, US-04.1 · 9 h |
| 9 | 17 e 18 | US-04.2, US-04.3 · 7 h |
| 10 | 19 e 20 | US-04.4, US-04.5 · 8 h |
| 11 | 21 e 22 | US-04.6, US-05.1 · 10 h |
| 12 | 23 e 24 | US-05.2, US-05.3, US-05.4 · 10 h |
| 13 | 25 e 26 | US-05.5, US-05.6 · 8 h |
| 14 | 27 e 28 | US-05.7 · 6 h |
| 15 | 29 e 30 | US-06.1 · 10 h |
| 16 | 31 e 32 | US-06.2, US-06.3, US-06.4, US-06.5 · 11 h |
| 17 | 33 e 34 | US-06.6, US-06.7, US-07.1 · 10 h |
| 18 | 35 e 36 | US-07.2, US-07.3, US-07.4, US-07.5 · 11 h |
| 19 | 37 e 38 | US-07.6 · 4 h |

# 6 VALIDAÇÃO FINAL

**O plano termina com o jogo na mão, e não com as tasks fechadas.** Na US-07.6, o time joga a build WebGL com a seção 15 do GDD aberta e, para cada requisito, pergunta *eu vi isto acontecer?*. Três respostas possíveis, e as três se anotam:

| Resposta | O que fazer |
| --- | --- |
| Vi acontecer | Anotar o que se viu: o valor medido, e não só 'ok' |
| Não vi, e devia | Uma task, com o que se esperava e o que aconteceu |
| Não dava para ver | O requisito não é exercitado por nenhum uso: falta um caminho no jogo, ou o requisito precisa voltar ao GDD |

# 7 RASTREIO DOS REQUISITOS

Todo requisito ativo do GDD está em ao menos uma história, e nenhum aposentado está. Esta tabela é gerada pelo script do plano, que para se algum faltar.

| Requisito | Histórias |
| --- | --- |
| G-01 | US-04.2 |
| G-02 | US-06.5 |
| G-03 | US-04.1 |
| G-04 | US-04.2 |
| G-05 | US-04.3 |
| RT-01 | US-02.2 |
| RT-02 | US-02.3 |
| RT-03 | US-02.3 |
| RT-04 | US-02.3, US-04.3 |
| RT-05 | US-04.3 |
| RT-06 | US-02.3 |
| RT-07 | US-04.2 |
| RT-08 | US-04.1 |
| RT-09 | US-04.2 |
| RT-10 | US-04.1 |
| RT-11 | US-02.3 |
| RT-12 | US-02.3 |
| RT-13 | US-02.3 |
| RT-14 | US-05.7 |
| RT-15 | US-05.7 |
| RT-16 | US-05.7 |
| RT-17 | US-05.7 |
| RT-18 | US-03.3 |
| RT-19 | US-03.4 |
| RT-20 | US-03.3 |
| RT-26 | US-04.1 |
| RT-27 | US-04.5 |
| RT-28 | US-07.3 |
| RT-29 | US-04.5 |
| RT-30 | US-02.2 |
| RT-31 | US-02.2 |
| RT-32 | US-05.7 |
| RT-33 | US-03.4, US-05.1 |
| RT-34 | US-06.1 |
| RT-35 | US-03.3 |
| RT-36 | US-06.7 |
| RT-37 | US-05.1 |
| RT-38 | US-02.5 |
| RT-39 | US-05.2 |
| RT-40 | US-05.2 |
| RT-41 | US-02.4 |
| RT-42 | US-05.4 |
| RT-43 | US-05.5 |
| RT-44 | US-05.5 |
| RT-45 | US-05.5 |
| RT-46 | US-05.1 |
| RT-48 | US-05.1 |
| RT-49 | US-05.4 |
| RT-50 | US-05.4 |
| RT-51 | US-05.4 |
| RT-52 | US-07.1 |
| RT-53 | US-07.1 |
| RT-54 | US-07.1 |
| RT-55 | US-07.1 |
| RT-56 | US-07.5 |
| RT-57 | US-07.4 |
| RT-58 | US-03.3 |
| RT-59 | US-04.3 |
| RT-61 | US-01.4 |
| RT-62 | US-07.4 |
| RT-63 | US-03.1 |
| RT-64 | US-03.1 |
| RT-65 | US-05.5, US-06.5 |
| RT-66 | US-01.1 |
| RT-67 | US-05.5 |
| RT-68 | US-07.1 |
| RT-69 | US-07.2 |
| RT-70 | US-07.2 |
| RT-71 | US-06.1 |
| RT-72 | US-02.1 |
| RT-73 | US-04.2 |
| RT-74 | US-02.1 |
| RT-75 | US-04.2 |
| RT-76 | US-02.2 |
| RT-77 | US-02.5 |
| RT-78 | US-05.4 |
| RT-79 | US-05.7 |
| RT-80 | US-05.7 |
| RT-81 | US-05.7 |
| RT-82 | US-04.1 |
| RT-83 | US-03.4 |
| RT-85 | US-02.4 |
| RT-89 | US-02.4 |
| RT-90 | US-02.2 |
| RT-91 | US-03.3 |
| RT-92 | US-03.1 |
| RT-93 | US-04.6 |
| RT-94 | US-06.5 |
| RT-95 | US-06.1 |
| RT-96 | US-06.1 |
| RT-97 | US-06.1 |
| RT-98 | US-06.5 |
| RT-99 | US-05.1 |
| RT-100 | US-05.2 |
| RT-101 | US-05.6 |
| RT-102 | US-05.1 |
| RT-103 | US-05.4 |
| RT-105 | US-05.4 |
| RT-106 | US-03.3, US-07.5 |
| RT-107 | US-07.1 |
| RT-108 | US-07.1 |
| RT-111 | US-05.1 |
| RT-112 | US-05.3 |
| RT-114 | US-05.7 |
| RT-115 | US-05.6 |
| RT-116 | US-05.6 |
| RT-117 | US-05.2 |
| RT-118 | US-06.1 |
| RT-119 | US-06.1 |
| RT-120 | US-06.2 |
| RT-121 | US-06.3 |
| RT-122 | US-05.4 |
| RT-124 | US-06.4 |
| RT-125 | US-06.5 |
| RT-126 | US-06.5 |
| RT-127 | US-06.1 |
| RT-129 | US-04.4 |
| RT-130 | US-04.4 |
| RT-131 | US-04.5 |
| RT-133 | US-04.4 |
| RT-134 | US-03.4 |
| RT-135 | US-03.4 |
| RT-136 | US-03.4 |
| RT-137 | US-03.4 |
| RT-138 | US-07.1 |
| RT-139 | US-04.2 |
| RT-140 | US-04.4 |
| RT-141 | US-06.6 |
| RT-142 | US-06.5 |

# 8 DECISÕES DESTE PLANO

Escolhas de organização, e não de design do jogo. As de design estão no GDD.

- **Não há épico de integração com a plataforma CIATEC.** O jogo é autônomo e só emula o visual dos menus (seção 11 do GDD); o `RT-66` garante que ele não dependa do pacote.
- **Unity 6 LTS, uGUI e TextMeshPro, com build WebGL.** A versão é a dos jogos CIATEC; o uGUI (Canvas) é o que o GDD cita na seção 11 e o que tem mais material para iniciantes.
- **O plano conta em horas, e as tasks têm 1 ou 2 h**: uma sessão semanal de uma pessoa. Pontos de história ficaram de fora, porque o arredondamento deles distorcia a soma e o time entende melhor a hora.
- **Sem testes automáticos.** É o primeiro jogo do time, e aprender a escrever testes no Unity custaria horas que o jogo precisa; tudo se confere jogando. As regras continuam em classes C# separadas da cena, o que deixa a porta aberta para testá-las depois.
- **Os menus vêm antes das fases** (EP-03 antes do EP-04): a grade é onde as fases começam e terminam, e o marco M2 só se joga com ela.
- **A voz é gravada por uma pessoa, numa ferramenta local** (US-05.4): o GDD diz que a voz ainda não existe (seção 14).
- **O formato do arquivo de registro (CSV ou JSON) se combina com o orientador** na US-07.4, porque o GDD o deixa em aberto (seção 14). O arquivo baixa sozinho para a pasta de downloads quando a sessão termina, como o GDD decide (`RT-57`).
- **A governança dos dados é do orientador, e não do time.** Ela não bloqueia o desenvolvimento; só a coleta com crianças espera a governança e, se o estudo pedir, o CEP.

# 9 GIT

O único estudo deste plano é o git (US-00.1). O resto se aprende por demanda, quando uma task pedir.

| Assunto | Onde |
| --- | --- |
| Git e GitHub, do zero | GitHub Skills, 'Introduction to GitHub' (skills.github.com) |
| Branch, pull request e conflito | GitHub Docs, 'About pull requests' e 'Resolving a merge conflict on GitHub' (docs.github.com) |
| O .gitignore do Unity | O modelo 'Unity.gitignore' do repositório github/gitignore |
