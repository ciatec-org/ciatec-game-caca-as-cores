# Como abrir e jogar o Caça às Cores no navegador

Este guia mostra como abrir o projeto na Unity e gerar uma versão jogável para o Google Chrome.

**Use uma cópia local indicada pela equipe.** Ajuste apenas essa cópia; preserve a configuração compartilhada.

## 1. Abra o projeto

1. Abra o **Unity Hub** e clique em **Projects**.
2. Selecione **Caça às Cores**. Se não aparecer, use **Add > Add project from disk** e escolha a pasta da cópia local, que contém **Assets**, **Packages** e **ProjectSettings**.
3. Confira a versão **6000.5.7f1**, abra o projeto e aguarde o carregamento terminar.

**Se faltar a versão:** use **Installs > Install Editor > Archive** no Hub. Instale **6000.5.7f1** com **WebGL Build Support** marcado. Se o Editor já estiver instalado, adicione o módulo por **Manage > Manage modules** (ou **Add modules**, conforme o Hub).

## 2. Abra a cena correta

1. Na aba **Project**, abra **Assets > Game > Scenes**.
2. Dê dois cliques em **MainScene**.

> **A cena correta é `Assets/Game/Scenes/MainScene.unity`.** Não escolha a MainScene de outra pasta nem Testing. Deixe só essa cena aberta.

## 3. Abra Build Profiles

1. No menu superior, clique em **File > Build Profiles**.
2. Em **Platforms**, selecione **Web**.
3. Se necessário, clique em **Switch Platform** e aguarde. Em um perfil personalizado, a ativação pode aparecer como **Switch Profile**.

## 4. Confira a Scene List — etapa essencial

1. Em **Build Profiles**, localize **Scene List** e clique em **Add Open Scenes** para adicionar a MainScene aberta.
2. Confira o caminho completo e arraste essa cena para a primeira posição, no **índice 0**.
3. Mantenha sua caixa marcada. **Desmarque todas as outras cenas, principalmente Testing**, sem apagar os arquivos.
4. Se o perfil marcado **Active** tiver lista própria, confira essa lista.

O resultado deve ser apenas:

```text
[X] Assets/Game/Scenes/MainScene.unity    índice 0
```

**Abrir a cena no Editor não a seleciona para a build.** Confira a Scene List: o padrão compartilhado pode apontar para Testing.

## 5. Confira as opções WebGL

1. Em **Build Profiles**, marque **Development Build** para a conferência local.
2. Clique em **Player Settings** e selecione a aba **Web**.
3. Em **Resolution and Presentation > Web Template**, confirme **CacaAsCores**.
4. Em **Publishing Settings > Compression Format**, confirme **Disabled**.

## 6. Gere e abra no Chrome

1. Volte à janela **Build Profiles**. Em **Client Browser Type**, escolha **Google Chrome**. Se aparecer **Path to Client Browser** vazio, selecione o `chrome.exe`, normalmente em `C:\Program Files\Google\Chrome\Application\chrome.exe`.
2. Clique em **Build And Run**.
3. Escolha **Builds/WebGL** na cópia local: crie **Builds** ao lado de **Assets** e **WebGL** dentro dela. Não use uma pasta dentro de Assets.
4. Aguarde a conclusão. A primeira build pode demorar vários minutos. O Chrome abrirá o jogo; espere carregar.

**Use Build And Run para gerar e executar. Não abra index.html manualmente.** Se outro navegador abrir, copie a URL aberta pela Unity para o Chrome.

## 7. Teste o jogo

A primeira instrução esperada é **“Encontre a estrela vermelha”**.

1. Clique no **quadrado vermelho**, para errar de propósito.
2. Observe a mensagem **“Seleção incorreta”**.
3. Clique na **estrela vermelha**.
4. Observe **“Acerto!”**.
5. Aguarde aproximadamente **500 ms — meio segundo**.
6. Confira se abre a próxima rodada, com **“Encontre o azul”**. Clique no triângulo azul para confirmar que a interação continua funcionando.

Se isso acontecer, a execução básica está funcionando. Durante os 500 ms de espera, o bloqueio dos cliques é normal.

## Se o jogo não funcionar

- **Formas não respondem:** confira a cena correta e sua seleção na Scene List do perfil ativo.
- **Não carrega:** confirme se a build terminou sem erros; consulte **Window > General > Console** na Unity.
- **Falha no navegador:** pressione **F12**, abra **Console** e registre a mensagem para enviar à equipe.
- **Parece uma versão antiga:** confira se a pasta e a URL correspondem à build recém-gerada.

Para outras situações, consulte o [guia técnico completo](Guia-Build-WebGL-Jogavel.md).

## Checklist final

- [ ] Unity **6000.5.7f1**.
- [ ] **WebGL Build Support** instalado.
- [ ] MainScene correta aberta.
- [ ] Scene List: somente a cena correta, habilitada no índice **0**.
- [ ] Plataforma **Web** ativa.
- [ ] **Build And Run** concluído.
- [ ] Jogo aberto no **Chrome**.
- [ ] Cliques e transições funcionando.
