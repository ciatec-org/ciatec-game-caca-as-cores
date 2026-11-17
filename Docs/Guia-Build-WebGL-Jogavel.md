# Guia de build WebGL jogável — Caça às Cores

Este guia ensina a abrir a cena jogável, gerar uma build WebGL e jogar no Google Chrome. Os exemplos de terminal usam Windows/PowerShell. Não é necessário programar, instalar Node.js ou usar ferramentas de automação para seguir o procedimento.

**Base conferida em 17/11/2026:** `develop`, commit `ba4efe5a6dbc9979f5b53a15b96905ad16ad4798`, Unity **6000.5.7f1**. O [PR #77](https://github.com/ciatec-org/ciatec-game-caca-as-cores/pull/77) já está integrado nessa base.

> **Ponto principal:** abra e compile `Assets/Game/Scenes/MainScene.unity`. A lista compartilhada ainda aponta para `Assets/Scenes/Testing.unity`, que mostra formas de teste sem a interação de rodadas. Não basta abrir a MainScene no Editor: a lista efetivamente usada pelo build também precisa estar correta.
>
> Ainda não temos os logs, a URL ou a versão da execução relatada pelo orientador. A diferença de cenas é um fato verificado do projeto, mas **não comprova a causa daquele problema**.

## Consulta rápida

1. [Entenda os termos e prepare uma cópia](#1-entenda-os-termos-e-prepare-uma-cópia).
2. [Instale a Unity e abra o projeto](#2-instale-a-unity-e-abra-o-projeto).
3. [Abra a cena jogável](#3-abra-a-cena-jogável).
4. [Configure a cena inicial da build](#4-configure-a-cena-inicial-da-build).
5. [Confira as opções Web](#5-confira-as-opções-web).
6. [Gere e execute no Chrome](#6-gere-e-execute-no-chrome).
7. [Reabra uma build com servidor local](#7-reabra-uma-build-com-servidor-local).
8. [Jogue e confira o funcionamento](#8-jogue-e-confira-o-funcionamento).
9. [Diagnostique formas sem interação](#9-aparecem-formas-na-tela-mas-não-consigo-clicar).
10. [Colete os erros no Chrome](#10-colete-as-informações-do-chrome).
11. [Interprete os avisos conhecidos](#11-interprete-os-avisos-conhecidos).
12. [Consulte as verificações e referências](#12-verificações-e-referências).
13. [Preencha o checklist final](#13-checklist-final).

## 1. Entenda os termos e prepare uma cópia

| Termo | Significado neste procedimento |
| --- | --- |
| Unity Hub | Aplicativo que gerencia projetos, versões do Editor e módulos de plataforma. |
| Unity Editor | Programa em que você abre a cena, usa Play e gera a build. |
| Projeto Unity | Pasta que contém `Assets`, `Packages` e `ProjectSettings`. Essa é a raiz a selecionar no Hub. |
| Cena | Arquivo `.unity` com objetos, componentes e referências. Existem duas cenas chamadas MainScene; o caminho completo faz diferença. |
| Build Profile | Conjunto de opções para gerar uma versão; pode substituir a lista global de cenas. |
| Build | Pasta gerada para execução fora do Editor: neste caso, HTML, JavaScript, WebAssembly e dados do jogo. |

Use uma **cópia separada da develop atual**, especialmente se seu projeto de trabalho tem alterações locais. A seleção de cenas descrita abaixo pode gravar `ProjectSettings/EditorBuildSettings.asset`; um perfil personalizado também pode criar arquivos de perfil. Faça isso na cópia destinada a builds, sem alterar a configuração compartilhada ou enviar esses ajustes ao GitHub.

Se já recebeu uma cópia completa e atual da equipe, prossiga. Se usa Git, pode criar uma nova pasta a partir de um terminal aberto no local onde pretende guardar a cópia:

```powershell
git clone --branch develop https://github.com/ciatec-org/ciatec-game-caca-as-cores.git ciatec-webgl-local
Set-Location -LiteralPath '.\ciatec-webgl-local'
git rev-parse HEAD
git status --short
```

O destino `ciatec-webgl-local` deve ser uma pasta nova. Não apague trabalho existente para reutilizar esse nome. Registre o SHA mostrado por `git rev-parse HEAD` e qualquer alteração local: o SHA sozinho não descreve arquivos editados sem commit.

Se houver assets baixados apenas como ponteiros Git LFS, peça uma cópia com os arquivos materializados ou, tendo Git LFS instalado, use `git lfs pull` nessa cópia. Não recrie `.meta` ou GUIDs para resolver assets ausentes.

## 2. Instale a Unity e abra o projeto

### 2.1 Unity Hub e versão correta

1. Abra o **Unity Hub** e entre na sua conta se o programa solicitar.
2. Em **Installs**, procure **6000.5.7f1**. Confira também `ProjectSettings/ProjectVersion.txt` do projeto: essa é a versão exigida nesta base.
3. Se estiver ausente, use **Install Editor > Archive** e procure a versão exata. Outra entrada é a [página oficial da Unity 6000.5.7f1](https://unity.com/releases/editor/whats-new/6000.5.7f1), usando a instalação pelo Hub.
4. Na escolha de módulos, marque **WebGL Build Support**. Aguarde downloads e instalação terminarem.
5. Se o Editor já está instalado, abra o menu **Manage > Manage modules** daquela instalação e confira o módulo WebGL. Em versões anteriores do Hub, esse menu aparece como **Add modules**, no botão de três pontos.
6. Se a opção de módulos não aparecer, confira se o Hub reconheceu a instalação e consegue localizar os componentes dessa versão. Use a instalação correta pelo Hub ou peça ajuda à equipe; não abra o projeto em outra versão para contornar a ausência do módulo.

Não substitua a versão por outra apenas porque o Hub a recomenda. O ABD contém menções históricas a 6000.3; o arquivo atual do projeto especifica **6000.5.7f1**.

### 2.2 Abrir e aguardar a preparação

1. Em **Projects**, use a opção de adicionar/abrir um projeto do disco e selecione a **raiz da cópia**, onde estão `Assets`, `Packages` e `ProjectSettings`. Não selecione `Assets` nem a pasta de uma build pronta.
2. Confira a versão exibida ao lado do projeto e abra com **6000.5.7f1**.
3. Aguarde importação dos assets, resolução dos pacotes e compilação. O primeiro carregamento pode demorar; não interrompa apenas porque há processamento em andamento.
4. Abra **Window > General > Console**. Se houver erro vermelho de importação ou compilação, leia/copie a mensagem antes de continuar. Avisos amarelos exigem leitura, mas não significam automaticamente falha.

Não atualize pacotes, URP ou configurações gráficas para tentar fazer a importação terminar. A base usa Input System **1.20.0**, uGUI **2.5.0** e URP **17.5.0**, conferidos em `manifest.json` e `packages-lock.json`.

## 3. Abra a cena jogável

No painel **Project**, expanda **Assets > Game > Scenes** e dê dois cliques em **MainScene**. Se usar a busca por `MainScene`, confirme o caminho da pasta: os nomes iguais não distinguem as duas cenas.

| Caminho completo | Finalidade verificada |
| --- | --- |
| `Assets/Game/Scenes/MainScene.unity` | Cena jogável direta: contém `ControladorDaRodada`, `ControladorDeJogo`, câmera e EventSystem. **Use esta.** |
| `Assets/Scenes/MainScene.unity` | Protótipo de navegação entre painéis com `GerenciadorTelas`; não contém o controlador das rodadas. Não é a entrada deste teste jogável. |
| `Assets/Scenes/Testing.unity` | Exibe instâncias do prefab `Form`, com Image/sprite/cor. Não contém os Buttons nem o controlador que avalia as seleções da rodada. |

Para conferir no Editor:

1. Verifique na **Hierarchy** que a cena contém os objetos **ControladorDaRodada**, **ControladorDeJogo** e **EventSystem**.
2. Deixe apenas a cena desejada aberta, evitando cenas adicionais carregadas em conjunto. Não salve mudanças de outra cena sem saber sua origem.
3. Clique em **Play**, no topo do Editor, e abra a aba **Game**. Para dar foco, clique num espaço vazio da aba Game, fora das formas; a aba **Scene** é uma ferramenta de edição.
4. Na cópia sem mudanças, a primeira instrução é **“Encontre a estrela vermelha”**. A posição inicial vem do campo `rodadaDeExemplo = 1` da cena.
5. Confira o roteiro da seção 8 e depois saia do Play antes de preparar a build.

A interface da rodada é criada **durante a execução**. Não encontrar `Canvas_Rodada` ou os Buttons na Hierarchy antes de Play é esperado.

## 4. Configure a cena inicial da build

**Abrir uma cena não a inclui automaticamente na build.** A lista compartilhada da develop conferida contém somente `Assets/Scenes/Testing.unity`, habilitada no índice 0. Os passos seguintes ensinam a gerar outra saída na sua cópia isolada; não mudam o padrão da equipe.

### 4.1 Caminho simples: lista global na cópia de builds

1. Saia de Play e deixe aberta somente `Assets/Game/Scenes/MainScene.unity`.
2. Abra **File > Build Profiles**. Em **Platforms**, selecione **Web**. Se não estiver ativa, use **Switch Platform** e aguarde a troca/importação. Se estiver usando um perfil personalizado, a ação de ativação é **Switch Profile**.
3. Na **Scene List**, use **Add Open Scenes** ou arraste a MainScene correta do painel Project para a lista. Add Open Scenes adiciona todas as cenas abertas; por isso deixe só a jogável aberta.
4. Confira o caminho da entrada. Arraste `Assets/Game/Scenes/MainScene.unity` para o início, mantenha sua caixa marcada e confirme o índice **0**.
5. Para esta execução direta, deixe **somente essa cena habilitada**. Desmarque as outras entradas, especialmente Testing; não exclua seus arquivos do projeto.
6. Antes de gerar, confira novamente a lista do perfil/plataforma que realmente está ativo.

Resultado desejado:

```text
[marcada] Assets/Game/Scenes/MainScene.unity    índice 0
```

### 4.2 Se houver Build Profile com lista própria

Um perfil pode herdar a lista global ou substituí-la. Alterar a lista global não corrige automaticamente um perfil que usa sua própria lista.

1. Em **Build Profiles**, selecione o perfil Web que pretende usar e ative-o com **Switch Profile**.
2. Para uma lista específica, a documentação da Unity 6.5 orienta **Add Settings > Scene List**. A lista começa herdando as cenas globais; revise o conteúdo.
3. Se a interface apresentar **Override Global Scene List**, confira se a substituição está ativa ao usar cenas próprias. Não presuma que a lista global ainda é a efetiva.
4. Aplique o mesmo resultado da seção 4.1: só a MainScene jogável habilitada, no índice 0.

Se precisar criar um perfil nessa cópia: **Add Build Profile > Web**, dê um nome como `WebGL-Jogavel-Local`, confirme **Add Build Profile** e use **Switch Profile**. Não instale pacotes opcionais apenas para criar o perfil. Preserve os arquivos de perfil fora de qualquer envio não autorizado.

O caminho simples da seção 4.1 é suficiente; criar um perfil não é requisito para jogar. Não edite o YAML de `EditorBuildSettings.asset` manualmente nem leve a mudança local para a develop compartilhada.

## 5. Confira as opções Web

### Já salvas na base e o que selecionar localmente

| Item | Valor conferido / ação |
| --- | --- |
| Unity | `6000.5.7f1`. |
| Company Name | `CIATec`. |
| Product Name | `Caça às Cores`. |
| Web Template | `CacaAsCores` (`PROJECT:CacaAsCores`). |
| Compression Format | `Disabled` (`webGLCompressionFormat: 2`). |
| WebGL threads | Desativadas na base. Não habilite para seguir este guia. |
| Input System | Já configurado; não troque para o sistema antigo. |
| Plataforma ativa | Selecionar **Web** localmente; instalar o módulo não ativa a plataforma por si só. |
| Cena inicial | Selecionar a MainScene jogável na lista **efetiva**; o padrão compartilhado ainda é Testing. |
| Development Build | Marcar para esta conferência local. Não é necessário Deep Profiling. |

Em **Player Settings**, ou **Edit > Project Settings > Player**, selecione a aba Web:

1. Confira nome e empresa.
2. Em **Resolution and Presentation > Web Template**, confirme **CacaAsCores**.
3. Em **Publishing Settings > Compression Format**, confirme **Disabled**. Se o perfil substitui Player Settings, confira os valores desse perfil também.

O template usa o loader nativo e um canvas com 100% da área da página. Isso não é tela cheia do sistema: a barra de endereço pode permanecer. Não garante que todo layout futuro esteja validado em qualquer orientação.

Disabled facilita servir arquivos locais sem configurar cabeçalhos de descompressão Gzip/Brotli. A configuração deve continuar coerente com o servidor, especialmente em builds de distribuição. A documentação 6.5 informa que Development Builds não são comprimidas; não deduza a configuração de uma build release apenas pelo sucesso de uma Development Build.

Não mude formatos de textura, render pipeline, memória ou pacotes para seguir o procedimento. Se um valor salvo divergir, registre a versão e o perfil usado antes de alterar algo.

## 6. Gere e execute no Chrome

### 6.1 Opção recomendada: Build And Run

1. Em **Build Profiles**, confirme **Web** ativo e a MainScene correta como única cena habilitada no índice 0.
2. Habilite **Development Build**. Em **Client Browser Type**, escolha **Google Chrome**. Se aparecer **Path to Client Browser**, indique o executável do Chrome da sua instalação. Também é possível usar **System Default** se o Chrome for o navegador padrão.
3. Clique em **Build And Run**. Os botões de build só ficam disponíveis para o perfil ativo; se não aparecerem, confira a ativação.
4. Na seleção de saída, escolha/crie `Builds/WebGL` **na raiz da cópia do projeto**. Não salve a saída dentro de `Assets`.
5. Aguarde importação, compilação e empacotamento terminarem. Uma primeira build pode levar vários minutos. O navegador pode abrir antes de todos os dados estarem carregados: aguarde a instrução aparecer.
6. A Unity inicia a execução local e abre uma URL **HTTP**. Mantenha o serviço iniciado pela Unity disponível enquanto joga. Se outro navegador abrir, copie a mesma URL para o Chrome.
7. Confira o Console da Unity e o Console do Chrome. Depois execute a seção 8.

**Build And Run é o caminho mais simples:** gera a saída e prepara sua execução. **Build** gera a pasta, mas você precisa servi-la depois, como na seção 7. Não é necessário publicar na Unity Play ou configurar um serviço de nuvem.

### 6.2 Como reconhecer o resultado

- **Sucesso:** processo encerrado sem erro, mensagem como `Build completed with a result of 'Succeeded'` no log/Console e arquivos de saída atualizados. Em Build And Run, o jogo deve terminar de carregar no navegador.
- **Falha:** erro vermelho ou resultado `Failed`; copie o primeiro erro relevante e a sequência de chamadas. A pasta existir não comprova sucesso: ela pode conter restos de uma tentativa anterior.
- **Ainda trabalhando:** há etapas de build/importação em andamento. Espere o resultado final antes de abrir manualmente a saída.

Com compressão desativada, a saída tem uma estrutura semelhante a:

```text
Builds/WebGL/
  index.html
  Build/
    <nome>.loader.js
    <nome>.framework.js
    <nome>.wasm
    <nome>.data
  ...outros arquivos produzidos pelo Unity/template
```

Os nomes variam conforme a saída; preserve a pasta completa. O `index.html` em `Assets/WebGLTemplates/CacaAsCores` é **fonte do template**, com marcadores de geração, e não uma build executável. O arquivo a servir fica na pasta de saída.

### 6.3 Evite abrir uma build antiga

1. Registre SHA, alterações locais, perfil, lista de cenas e horário da geração.
2. Se já existe uma saída de outro teste, use uma pasta nova, por exemplo `Builds/WebGL-20261117`; não apague builds que alguém precisa preservar.
3. Confira a data dos arquivos gerados, a pasta servida pelo terminal e a URL aberta no Chrome. Recompilar em outra pasta não atualiza um servidor que ainda aponta para a anterior.
4. Com DevTools aberto, a opção **Network > Disable cache** ajuda durante a conferência; recarregue a página. Se precisar, use `Ctrl+Shift+R`.

`Builds/WebGL` e as demais subpastas de `Builds` já são ignoradas pelo `.gitignore`. Quem usa Git pode conferir na raiz:

```powershell
git check-ignore -v Builds/WebGL/index.html
git status --short
```

Gerar a build pode reserializar configurações na cópia de trabalho. Revise essas mudanças separadamente; elas não devem ser enviadas junto do guia ou tratadas como necessárias para jogar.

## 7. Reabra uma build com servidor local

Uma build WebGL deve ser entregue ao Chrome por **HTTP/HTTPS**. Não dê dois cliques no `index.html`: um endereço começando com `file://` não é o procedimento de execução.

Se acabou de usar **Build And Run**, mantenha a URL aberta por ele e não precisa de Python. Se usou apenas **Build**, ou quer reabrir a pasta depois, esta é uma alternativa com Python 3 instalado:

1. Abra no Explorador a pasta de saída, por exemplo `Builds/WebGL`. Ela deve conter `index.html` e a subpasta `Build`.
2. Abra um terminal nessa pasta: use **Abrir no Terminal** ou digite `powershell` na barra de endereço do Explorador. Confirme a pasta atual com `Get-Location`.
3. Confira Python 3 e inicie o servidor:

```powershell
py -3 --version
py -3 -m http.server 8000 --bind 127.0.0.1
```

4. Deixe o terminal aberto. A mensagem deve indicar que está servindo HTTP em `127.0.0.1`, porta `8000`.
5. No Chrome, digite **http://127.0.0.1:8000/** e aguarde o jogo carregar.
6. Para encerrar, volte ao terminal e pressione **Ctrl+C**.

Se seu Python 3 responde por `python`, o comando equivalente é:

```powershell
python -m http.server 8000 --bind 127.0.0.1
```

Em macOS/Linux, o executável costuma ser `python3`. Se aparecer `No installed Python found` ou comando não reconhecido, essa alternativa não está preparada: use **Build And Run** ou instale Python 3, se desejar. Python não é requisito da Unity. Se a porta 8000 já estiver ocupada, use `8001` no comando e na URL; não encerre serviços desconhecidos.

Se aparecer uma lista de arquivos em vez do jogo, confira a pasta servida e a presença de `index.html`. Se o terminal foi aberto na raiz do projeto, entre primeiro na saída com `Set-Location -LiteralPath '.\Builds\WebGL'`.

Esse servidor é uma alternativa local para a saída sem compressão. Arquivos comprimidos exigem configuração correspondente. `127.0.0.1` refere-se ao computador de quem abre o endereço; copiar essa URL para outra pessoa não disponibiliza sua build para ela. Para transferir o teste, envie a pasta completa ou use a hospedagem definida pela equipe.

## 8. Jogue e confira o funcionamento

### 8.1 Primeiro teste guiado

1. Aguarde a mensagem **Carregando…** desaparecer e a instrução aparecer no cartão branco do topo. Para dar foco, clique num espaço vazio do jogo, não nas formas nem no DevTools.
2. Na cena atual sem alterações, leia **“Encontre a estrela vermelha”**. Há um quadrado vermelho, uma estrela vermelha, uma estrela azul e um círculo verde.
3. Clique uma vez no **quadrado vermelho**, para errar de propósito. Deve aparecer **“Seleção incorreta”**, abaixo das formas. A rodada continua aberta e a instrução permanece.
4. Clique na **estrela vermelha**. Deve aparecer **“Acerto!”**. Não é necessário arrastar, segurar ou dar dois cliques.
5. Aguarde aproximadamente **meio segundo**. A próxima rodada abre automaticamente, limpa o resultado anterior e mostra **“Encontre o azul”**.
6. Nessa nova rodada, clique no **triângulo azul**. Confirme outro acerto e nova troca. Assim você verifica que a interação foi restaurada, não apenas que a primeira seleção funcionou.

A sequência fixa atual contém quatro instruções e se repete. A cena começa na posição 1, produzindo:

| Ordem a observar a partir dessa abertura | Instrução | Alvo |
| --- | --- | --- |
| 1 | Encontre a estrela vermelha | Estrela vermelha. |
| 2 | Encontre o azul | Triângulo azul. |
| 3 | Encontre o quadrado verde | Quadrado verde; o círculo verde não atende ao pedido de forma. |
| 4 | Encontre o vermelho | Quadrado vermelho. |
| 5 | Encontre a estrela vermelha | Estrela vermelha novamente. |

Esse é um **roteiro a executar**, não um registro de que sua build foi testada. Complete cinco rodadas, errando em pelo menos uma, e confira que a sexta abre. Cinco rodadas não precisam ter cinco instruções distintas.

### 8.2 O bloqueio durante a troca é esperado

O asset `Assets/Game/Data/ConfiguracaoDoJogo.asset` tem `esperaTrocaRodada = 0.5`, ou **500 ms**. A execução ocorre por frames; não espere precisão de cronômetro em todo computador. Mantenha a aba ativa, o jogo sem pausa e aguarde a troca na própria página.

Depois de acertar, a rodada antiga fica brevemente visível, já fechada. Os cliques nela são ignorados. O PR #77 acrescentou o bloqueio do ponteiro na Fileira e a limpeza da seleção para evitar novas reações visuais nesse intervalo, mantendo o texto “Acerto!”. A rodada seguinte deve voltar a aceitar interação. Isso realiza RT-77/RT-38; depois de errar, continuar clicando realiza RT-41.

Não deixe um valor temporário de 3 segundos usado em testes ser confundido com o padrão de 0,5 segundo. Não é necessário alterar esse tempo para apenas jogar.

### 8.3 Sinais de que você abriu a versão jogável

- Existe cartão de instrução e feedback textual de erro/acerto.
- No Console aparecem mensagens como `Configuração carregada!`, `[Rodada] tentativa`, `[Rodada] fechada`, `[Rodada] próxima rodada em 500 ms` e `[Rodada] nova rodada`.
- Após o acerto há outra instrução e novas formas; depois de um erro é possível tentar novamente.

O log sobre “tempo limite da rodada” mostra um dado lido da configuração; **não comprova um temporizador ativo**. Este acesso entra diretamente na sequência de teste. Não representa menus e fases completos, áudio, adaptação de dificuldade ou todos os recursos planejados no SGDD. A outra MainScene contém um protótipo de painéis, que não é necessário para esse fluxo direto.

Não existe no runtime atual um log automático com o caminho completo da cena ou o SHA Git. Para comprovar a origem, registre a lista efetiva contendo só a MainScene jogável, gere em pasta identificada e abra essa saída. A aparência e a versão da Unity sozinhas não comprovam qual commit foi compilado.

## 9. Aparecem formas na tela, mas não consigo clicar

Comece pelas verificações simples. **Formas visíveis não comprovam que aquela cena implementa uma rodada.** Não atribua a falha ao PR #77 sem identificar a versão e os sinais abaixo.

### 9.1 Identifique qual sintoma ocorreu

| O que acontece | Primeira verificação |
| --- | --- |
| Há formas, mas nenhuma instrução ou resposta de rodada | Confirme a cena efetiva. Testing possui formas de apresentação, não os Buttons do controlador de rodadas. |
| Continua em Carregando… ou aparece falha ao iniciar | Verifique Console/Network e os arquivos da saída antes de investigar os Buttons. |
| Clique não produz nenhum feedback | Confirme carregamento, saída recente, entrada de ponteiro, EventSystem e referências. |
| Aparece Seleção incorreta e não troca | Esse comportamento é esperado: a rodada só fecha depois do acerto. Tente o alvo correto. |
| Aparece Acerto!, mas nunca abre outra rodada | Confira tempo do asset, pausa/foco e exceções após o acerto. Não confunda os 500 ms esperados com travamento. |
| Há apenas um painel/protótipo de navegação | Confira se foi usada `Assets/Scenes/MainScene.unity` no lugar da cena em `Assets/Game/Scenes`. |

### 9.2 Fluxo de conferência

1. **Cena:** na lista do perfil ativo, confirme o caminho inteiro, a caixa marcada e o índice 0. Na base examinada, simplesmente gerar com a lista compartilhada produz Testing. Isso é uma possibilidade de configuração a conferir, não o diagnóstico já confirmado da execução do orientador.
2. **Carregamento:** espere a instrução; se houver mensagem de falha ou carregamento interrompido, procure o primeiro erro no navegador.
3. **Versão/saída:** confira pasta, horário, URL e cache. Não compare uma execução antiga com o código novo aberto no Editor.
4. **Erros da página:** abra DevTools conforme a seção 10. Registre exceções JavaScript/Unity e falhas de download.
5. **Canvas e foco:** clique na página do jogo, mantenha a aba ativa e confira se não há um aviso/elemento sobre o canvas. Formas Unity são desenhadas dentro dele: não são Buttons HTML individuais no painel Elements.
6. **EventSystem:** reproduza na cena correta do Editor em Play; confirme objeto ativo e componentes EventSystem/InputSystemUIInputModule habilitados. Não adicione outro EventSystem para tentar resolver sem saber se já existe um.
7. **Ações de entrada:** no InputSystemUIInputModule, confira `Actions Asset`, `Point` e `Left Click`: as referências originais estão atribuídas e não devem aparecer como None/Missing. Não substitua ações ou adicione StandaloneInputModule aleatoriamente.
8. **Mouse e Buttons:** use a aba Game em Play. Ao passar/pressionar, o Button pode mudar discretamente de intensidade; confirme também feedback e log de tentativa. Hover sozinho não comprova avaliação da seleção.
9. **Raycasts:** confira se o Canvas_Rodada tem GraphicRaycaster ativo e os objetos `Forma...` têm Image e Button. Um painel/imagem sobre as formas com Raycast Target ativo pode interceptar o ponteiro; registre o elemento antes de alterar algo. Não desligue todos os Raycast Targets.
10. **CanvasGroup:** confira a Fileira como descrito abaixo. O valor muda conforme a rodada está aberta ou fechada; não o force permanentemente.
11. **Rodada aberta:** erro mantém a rodada aberta; acerto fecha e agenda a próxima. Use o feedback e os logs. `RodadaAtual.Aberta` é uma propriedade C# e não um campo pronto no Inspector; não há comando global JavaScript de diagnóstico exposto pelo template para lê-la.
12. **Referências/exceções:** confira a configuração nos dois controladores e seis ColorData/cinco sprites no asset. Registre None/Missing, NullReferenceException ou InvalidOperationException e a sequência de chamadas. Peça ajuda à equipe para corrigir a referência original; não regenere GUIDs nem troque por assets quaisquer.

### 9.3 Inspecione a Fileira no Editor

Em **Play**, expanda na Hierarchy:

```text
ControladorDaRodada
  Canvas_Rodada
    Fileira
      Forma0_...
      Forma1_...
      ...
    Resultado
  Canvas_Instrucao
    CartaoDaInstrucao
      Instrucao
```

Selecione **Fileira** e observe seu **CanvasGroup**:

| Situação | Blocks Raycasts esperado | Significado |
| --- | --- | --- |
| Rodada aberta, inclusive depois de um erro | Marcado / `true`. | As formas podem receber os raycasts do ponteiro. |
| Depois do acerto, durante a espera | Desmarcado / `false`. | Os filhos da Fileira são ignorados pelos raycasts; os cliques não chegam às formas. |
| Próxima rodada aberta | Marcado / `true` novamente. | A interação da nova rodada foi restaurada. |

O nome Blocks Raycasts pode confundir: **false não libera o clique nas formas**; faz com que elas deixem de participar dessa detecção. O controlador mantém os Buttons interagíveis e não usa a aparência de Disabled para bloqueá-los.

O cartão e os textos criados pelo controlador não têm Raycast Target ativo. A ligação do clique dos Buttons é feita por código em tempo de execução; a lista persistente **On Click()** pode parecer vazia no Inspector sem que exista defeito. Não acrescente ligações manuais para “preencher” essa lista.

Para observar a espera de modo mais confortável, um desenvolvedor pode testar 3 s **somente numa cópia de validação**, registrar essa alteração e restaurar 0,5 s ao terminar. Assets ScriptableObject podem conservar alterações feitas em Play: sair de Play não é garantia de restauração do asset. Para apenas jogar, preserve 0,5 s.

## 10. Colete as informações do Chrome

### 10.1 Console

1. Abra a página do jogo e pressione **F12**; em alguns teclados, **Fn+F12**. **Ctrl+Shift+I** também abre DevTools.
2. Selecione **Console**, habilite a exibição de **Errors**, **Warnings** e **Info**, e recarregue para registrar o início.
3. Localize o primeiro erro vermelho associado à execução. Expanda a mensagem para mostrar a sequência de chamadas e copie o texto completo. Somente `WebGL.framework.js:2130` costuma identificar o ponto de impressão, não a causa.
4. Para acompanhar seleções, filtre por `[Rodada]`. Depois remova o filtro para não esconder erros com outro prefixo.
5. Use **Preserve log** se precisar manter mensagens ao recarregar. Faça uma captura com a página e o Console quando o problema ocorrer.

**Info** registra eventos, **Warning** indica condição a avaliar e **Error/Exception** indica falha a investigar. A cor da mensagem ajuda a localizar; o texto, a sequência e o sintoma determinam o impacto.

### 10.2 Network

1. Selecione **Network**, marque **Disable cache** durante a conferência e recarregue com DevTools aberto.
2. Procure `loader`, `framework`, `.wasm` e `.data`. As requisições devem terminar, sem falha de download. HTTP **200** é normal; **304** ou recurso vindo do cache não significa erro por si só.
3. Clique numa requisição problemática e abra **Headers**: copie URL, status HTTP e cabeçalhos. Confira **Response** se houver suspeita de ter recebido uma página HTML no lugar de JavaScript/WebAssembly.
4. O `.wasm` deve ser servido como `application/wasm`; JavaScript deve ter tipo adequado, como `text/javascript`/`application/javascript`. `.data` pode ser `application/octet-stream`.
5. Se houver compressão, o Content-Encoding deve corresponder ao arquivo: `gzip` para Gzip, `br` para Brotli. Na saída atual descomprimida esse cabeçalho não é necessário.

Um **404** num arquivo essencial da pasta Build pode impedir o carregamento. Um 404 isolado de `favicon.ico` não prova falha da interação. Um **200 com HTML no lugar de `.wasm`** também está errado: o status sozinho não basta.

### 10.3 Problemas comuns e próxima ação

| Sinal / exemplo | Ação indicada |
| --- | --- |
| Endereço `file://`, bloqueio de origem/CORS ao abrir o arquivo | Use Build And Run ou o servidor local; abra a URL HTTP. |
| `ERR_CONNECTION_REFUSED` | Confira se o servidor está ativo e se a porta da URL é a mesma. Reinicie o servidor correto, sem mudar o jogo. |
| Lista de arquivos, página 404, caminho inexistente | Sirva a pasta que contém o index.html gerado; confira URL e diretório do terminal. |
| Loader, `.data` ou `.wasm` ausente/incompleto | Confira se a build terminou e se a pasta inteira foi copiada. Não distribua só o index.html. |
| Página antiga mesmo após recompilar | Confira pasta de saída e servidor; desative cache para o teste e recarregue. |
| Erro de descompressão, arquivo `.gz`/`.br` com cabeçalhos incompatíveis | Confira o perfil e a configuração de publicação/servidor. Use a saída local prevista como Disabled ou peça ajuste correto do servidor; não renomeie extensões para contornar. |
| Erro JavaScript ou exceção Unity após carregar | Copie mensagem/stack e descreva a ação que a precedeu. Nem todo erro se resolve escolhendo outra cena. |
| Falha de contexto WebGL/WebAssembly ou contexto perdido | Registre Chrome, sistema, aceleração gráfica e texto completo; confira compatibilidade com a equipe. Não desative permanentemente proteções ou use flags inseguras. |
| Erro de configuração ausente | No Editor, confira `ConfiguracaoDoJogo` nos dois controladores. O aviso `Falta a ConfiguracaoDoJogo no ControladorDeJogo!` é diferente de erro de servidor. |

### 10.4 Informações a enviar à equipe

Copie este formulário e preencha ao reproduzir. Não preencha “sem erros” se o Console não foi verificado.

```text
Data/hora:
Sistema e versão do Chrome:
Unity usada para gerar:
SHA Git e alterações locais do projeto:
Perfil/plataforma ativos:
Cena inicial (caminho completo e índice):
Pasta de saída e horário da build:
Build: Succeeded/Failed; Development Build: sim/não:
Como abriu: Build And Run ou servidor; URL completa:
Qual instrução aparece:
Ação realizada (forma/cor escolhida):
Feedback observado:
A rodada seguinte abriu? Quanto tempo aproximadamente?
Primeiro erro completo e sequência de chamadas:
Requisições com falha (URL/status/Content-Type/Content-Encoding):
Captura da página e Console:
```

## 11. Interprete os avisos conhecidos

As evidências das tasks #27/#39 já registraram o aviso:

```text
Shader 'Hidden/Universal Render Pipeline/Edge Adaptive Spatial Upsampling' is not supported (in 'Blit FSR Upscaling'). PostProcessing render passes will not execute.
```

Ele **não significa automaticamente que o jogo parou**. A análise existente identificou a criação de um passe opcional FSR/EASU não suportado: o material fica inválido e esse passe não executa. Isso não desativa globalmente toda a renderização. A configuração examinada não seleciona esse filtro; a câmera da MainScene jogável também está com pós-processamento desligado.

As rodadas funcionaram nas execuções históricas com esse aviso presente. Portanto, ele sozinho não explica formas sem interação. Confira os erros, a cena, os logs de tentativa e a relação temporal com o sintoma. Se houver defeito visual ou configuração diferente, registre e investigue; não considere todo aviso inofensivo.

Também foram vistos avisos de política de autoplay de AudioContext e fallback do formato de cookies de luzes. Isso não certifica áudio ou todos os efeitos gráficos. O aviso CS0618 de API obsoleta compilou na base testada, mas um erro vermelho de compilação é outra situação.

Não atualize a URP, remova efeitos nem altere shaders só para esconder mensagens. A explicação técnica e os limites estão em [Build-WebGL.md](Build-WebGL.md#aviso-de-shader-da-urp) e na [validação da task #39](Validacao-WebGL-Task39.md#avisos).

## 12. Verificações e referências

### 12.1 O que foi verificado para escrever este guia

Em 17/11/2026 foram conferidos a develop remota, o merge do PR #77, a versão do projeto, as três cenas, scripts, asset de configuração, EventSystem/ações de entrada, manifesto/lock de pacotes, template, `.gitignore` e documentos históricos. O valor efetivo de espera é **0,5 s**; não foi modificado.

A comparação Git entre `ba4efe5a6dbc9979f5b53a15b96905ad16ad4798` e o HEAD auditado do PR #77, `73ce32a48ce8d28a4dd78a7a46c12ba2f9470066`, não mostrou diferença em **Assets, Packages ou ProjectSettings**. As diferenças são de documentação/evidências.

**Não foi gerada nova build nem executado o Unity/Build And Run nesta tarefa documental.** Os nomes de interface foram conferidos com a documentação Unity 6.5 e cadeias do Editor 6000.5.7f1 instalado; não se apresenta isso como uma sequência de cliques executada manualmente.

Foi verificada a alternativa HTTP usando Python **3.13.3** fornecido pelo SDK WebGL instalado, equivalente ao módulo `http.server` descrito: uma saída anterior foi servida por HTTP local, com HTML, loader, framework, `.wasm` e `.data` retornando **200**, e `.wasm` com `application/wasm`. Foi teste de entrega HTTP, **não nova execução de gameplay**. O atalho `py -3` deste ambiente informou ausência de Python instalado no sistema; por isso o guia o trata como alternativa condicionada à instalação, mantendo Build And Run como caminho principal.

Evidências anteriores, identificadas como históricas:

| Execução | Base e condições | Resultado registrado |
| --- | --- | --- |
| Task #39, 13/11/2026 | `e232ccad0eed67cfdb9d2bef944f5b1727f26e87`; Unity 6000.5.7f1; MainScene em Assets/Game/Scenes; build WebGL Development; Chrome 157.0.8103.51 headless/SwiftShader, 1280×720. | Build Succeeded, 0 erros/4 avisos; cinco rodadas, erro recuperado e avanço; sem exceção inesperada capturada. Anterior ao PR #77. |
| Auditoria local do PR #77, 16/11/2026 | `73ce32a48ce8d28a4dd78a7a46c12ba2f9470066`; mesma Unity/cena; WebGL Development; Chrome 157.0.8103.51 headless/SwiftShader; observador temporário na cópia de validação. | Build Succeeded, 0 erros/4 avisos; seis ciclos com esperas de 3 s e 0,5 s, reativação e abertura externa; zero erros/exceções do navegador capturados. Os cliques repetidos dentro dos 500 ms foram testados em player nativo com mouse virtual/EventSystem, não certificados nesse intervalo no Chrome. |

A auditoria de #77 tem registros locais do agente, não anexados ao PR nem distribuídos com este guia. Sua instrumentação não integra o projeto. As evidências portáteis já versionadas são a [validação #39](Validacao-WebGL-Task39.md), o [resumo JSON #39](Evidencias/Task-39-WebGL/resultados.json) e o [catálogo/capturas #41](Evidencias/Task-41-WebGL/README.md). A #41 organiza capturas da #39, **não uma sessão nova**.

Esses registros não diagnosticam a execução do orientador. Não houve nesta tarefa teste humano, de toque, de outros navegadores ou nova certificação de layout/desempenho. O código contém cinco formas, mas o retângulo não participa da sequência fixa; sua referência existe no asset. Comece por uma janela ampla; problemas em retrato devem ser registrados, sem prometer responsividade completa.

### 12.2 Documentos do projeto e fontes técnicas

- [Build-WebGL.md](Build-WebGL.md): preparação e testes históricos da task #27. Sua referência antiga a SampleScene descreve aquela etapa; **não é a cena a escolher para o jogo atual**. O arquivo foi preservado.
- [Validação WebGL da task #39](Validacao-WebGL-Task39.md) e [capturas da task #41](Evidencias/Task-41-WebGL/README.md).
- [SGDD v2](SGDD-CacaAsCores-v2.md): comportamento planejado, especialmente RT-38, RT-41 e RT-77. [ABD v1](ABD-CacaAsCores-v1.md): US-01.3 e US-02.5/02.6. Planejamento não é prova de implementação.
- [Unity Hub — instalar Editor](https://docs.unity.com/en-us/hub/add-editor) e [instalar módulos](https://docs.unity.com/en-us/hub/add-modules).
- [Unity 6.5 — gerenciar cenas da build](https://docs.unity3d.com/6000.5/Documentation/Manual/build-profile-scene-list.html) e [criar perfis](https://docs.unity.com/en-us/engine/6000.5/manual/building-and-publishing/build-settings/create-build-profile).
- [Unity 6.5 — opções de build Web](https://docs.unity3d.com/6000.5/Documentation/Manual/web-build-settings.html), [Player Settings Web](https://docs.unity3d.com/6000.5/Documentation/Manual/class-PlayerSettingsWebGL.html) e [publicação/compressão](https://docs.unity3d.com/6000.5/Documentation/Manual/webgl-deploying.html).
- [Python — servidor HTTP](https://docs.python.org/3/library/http.server.html).
- [Chrome — abrir DevTools](https://developer.chrome.com/docs/devtools/open), [Console](https://developer.chrome.com/docs/devtools/console/reference) e [Network](https://developer.chrome.com/docs/devtools/network/reference).

## 13. Checklist final

Preencha para **a sua execução**:

- [ ] Usei uma cópia identificada do projeto e preservei o trabalho existente.
- [ ] Registrei SHA Git e eventuais alterações locais.
- [ ] Unity **6000.5.7f1** instalada e selecionada para o projeto.
- [ ] Módulo **WebGL Build Support** instalado.
- [ ] Projeto importado/compilado sem erros impeditivos.
- [ ] Localizei **Assets/Game/Scenes/MainScene.unity**, sem confundir com a outra MainScene ou Testing.
- [ ] No perfil efetivamente ativo, essa é a única cena habilitada e está no índice **0**.
- [ ] Plataforma **Web** ativa; substituições do perfil conferidas.
- [ ] Template **CacaAsCores** e **Compression Format: Disabled** conferidos.
- [ ] Build terminou com sucesso em uma pasta de saída identificada, fora de Assets.
- [ ] Abri no **Chrome por HTTP/HTTPS**, sem usar file://.
- [ ] Confirmei que a pasta/URL corresponde à build recente.
- [ ] Cartão de instrução e formas aparecem corretamente.
- [ ] Clique errado mostra **Seleção incorreta** e permite tentar novamente.
- [ ] Clique correto mostra **Acerto!**.
- [ ] A próxima rodada abre automaticamente após a espera configurada de aproximadamente **500 ms**.
- [ ] O bloqueio durante a espera termina e os cliques voltam a funcionar na rodada seguinte.
- [ ] Completei algumas rodadas, incluindo ao menos um erro recuperado.
- [ ] Verifiquei Console e Network; registrei avisos e não há exceção inesperada sem explicação.
- [ ] Registrei versão, resultado e evidências para a equipe.
- [ ] Não enviei builds, perfis locais ou alterações automáticas de configuração sem autorização.
