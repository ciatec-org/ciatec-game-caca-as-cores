---
tipo: referencia
---

# O visual dos menus

Os menus do Caça às Cores emulam a moldura dos menus dos pacotes CIATEC, sem usar o pacote da plataforma (seções 7.3 e 11 do GDD, `RT-63`). Esta pasta traz tudo o que o time precisa para reproduzir esse visual no Unity: as figuras de referência, o símbolo, as fontes, as cores e as medidas.

## As figuras de referência

São desenhos feitos para o GDD com estes mesmos arquivos e valores, e não capturas de um jogo: mostram como cada tela deve ficar.

| Figura | Tela |
| --- | --- |
| [`menu-inicio.png`](menu-inicio.png) | O início: a barra, o painel, o nome do jogo e o botão Começar |
| [`janela-menus.png`](janela-menus.png) | As configurações, em paisagem e em retrato: o campo de texto e os seletores segmentados |
| [`menu-fases.png`](menu-fases.png) | A grade de fases: os cards liberado, concluído (com o visto) e bloqueado (com o cadeado) |

## Os arquivos

| Arquivo | O que é | De onde veio |
| --- | --- | --- |
| `ciatec-simbolo-vinco.png` | O símbolo CIATEC da barra, 1304 × 1301, com transparência | Pacote do core CIATEC, `Runtime/Shared/Texturas` |
| `Roboto-Medium.ttf` | A fonte dos títulos, botões e seletores | M3Kit, `Runtime/Fonts` |
| `Roboto-Regular.ttf` | A fonte do texto corrido dos menus | M3Kit, `Runtime/Fonts` |
| `LICENSE-Roboto.txt` | A licença das duas fontes: Apache 2.0, Copyright 2015 Google Inc. | Declarada dentro das próprias fontes (Roboto 2.001047); a licença vai junto quando as fontes são redistribuídas |

## As cores (tema claro)

| Nome | Cor | Onde se usa |
| --- | --- | --- |
| primary | #006878 | O botão cheio dos menus (Começar), a borda do card liberado, o visto da fase concluída |
| on-primary | #FFFFFF | O texto sobre o primary |
| secondary-container | #FCD9E8 | A opção escolhida num seletor segmentado |
| surface | #F8FAFA | O fundo da barra, dos campos e dos seletores |
| surface-container | #ECEEEF | O preenchimento do painel, a 75 % (o jardim aparece por trás), e o card bloqueado |
| on-surface | #191C1D | O texto principal |
| on-surface-variant | #3F484B | Os rótulos das configurações e a linha do mediador nos cards |
| outline | #70797B | O contorno dos campos e seletores, e o cadeado |
| outline-variant | #BFC8CB | O filete da barra e a borda do painel e dos cards |

## As medidas

Em dp, como no resto do GDD (seção 7.4).

| Peça | Medida | Observação |
| --- | --- | --- |
| Barra | 56 dp de altura, 24 dp de margem lateral, fundo surface e filete outline-variant de 1 dp embaixo | O símbolo tem 32 dp e fica a 12 dp do texto "CIATEC", em Roboto Medium de 22 dp |
| Painel | Raio de 16 dp, borda outline-variant de 1 dp, preenchimento surface-container a 75 % | A translucidez é o que deixa o jardim aparecer (`RT-141`) |
| Botão cheio | 40 dp de altura, cantos inteiramente redondos, primary com texto on-primary | Texto em Roboto Medium de 15 dp |
| Seletor segmentado | 44 dp de altura (seção 7.4 do GDD), cantos redondos, contorno outline | A opção escolhida em secondary-container; texto em Roboto Medium de 14 dp |
| Campo de texto | 48 dp de altura (seção 7.4 do GDD), raio de 4 dp, contorno outline, fundo surface | O código da criança |
