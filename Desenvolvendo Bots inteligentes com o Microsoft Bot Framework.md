<a name="HOLTitle"></a>
# Construindo Bots Inteligentes com o Microsoft Bot Framework #

---
<a name="Overview"></a>
### Visão geral ###

Os robôs de software estão em toda parte. Você provavelmente interage com eles todos os dias sem perceber. Bots, especialmente de bate-papo e mensagens, estão mudando a maneira como interagimos com negócios, comunidades e até mesmo entre nós mesmos. Graças aos avanços de velocidade leve na inteligência artificial (AI) e à pronta disponibilidade de serviços de AI, os bots não estão apenas se tornando mais avançados e personalizados, mas também são mais acessíveis aos desenvolvedores.

Independentemente da linguagem ou plataforma de destino, desenvolvedores que criam bots enfrentam os mesmos desafios. Os Bots devem ser capazes de processar entrada e saída de forma inteligente. Os Bots precisam ser responsivos, escaláveis ​​e extensíveis. Eles precisam trabalhar entre diferentes plataformas, e precisam interagir com os usuários de maneira conversacional e no idioma que o usuário escolhe.

O  [Microsoft Bot Framework](https://dev.botframework.com/) , combinado com o  [Microsoft QnA Maker](https://qnamaker.ai/) , fornece as ferramentas que os desenvolvedores precisam para construir e publicar bots inteligentes que interagem naturalmente com usuários que usam uma variedade de serviços. Neste laboratório, você criará um bot usando o Visual Studio Code e o Microsoft Bot Framework e vai conectá-lo a uma base de conhecimento construída com o QnA Maker. Então você irá interagir com o bot usando o Skype - um dos muitos serviços populares com os quais os bots construídos com o Microsoft Bot Framework podem ser integrados.

<a name="Objectives"></a>
### Objetivos ###

Neste laboratório prático, você aprenderá como:

- Criar um serviço de Bot no Azure para hospedar seu robo
- Criar uma base de conhecimentos no Microsoft QnA Maker, preenche-lá com dados e conecta-lá a um bot
- Implementar bots direto no código e depurá-los
- Publicar bots e usar a integração contínua para mantê-los atualizados
- Conectar um bot no Skype e interajir com ele por lá


<a name="Prerequisites"></a>
### Pré-requisitos ###

Para completar este laboratório prático, você precisará de:

- Uma assinatura ativa do Microsoft Azure. Se você não possui um,  [inscreva-se para uma avaliação gratuita](http://aka.ms/WATK-FreeTrial) .
- [Visual Studio Code](http://code.visualstudio.com/)
- [Git Client](https://git-scm.com/downloads)
- [Node.js](https://nodejs.org/)
- [Emulador do Microsoft Bot Framework](https://emulator.botframework.com/)
- [Skype](https://www.skype.com/pt-br/get-skype/)

<a name="Resources"></a>
### Recursos ###

[Clique aqui](https://a4r.blob.core.windows.net/public/bots-resources.zip) para baixar um arquivo zip contendo o conteúdo usado ​​neste laboratório. Copie o conteúdo do arquivo zip em uma pasta no seu disco.

---

<a name="Exercises"></a>
### Exercícios ###

Este laboratório prático inclui os seguintes exercícios:

- [Exercício 1: Criar um serviço de bot no Azure](#Exercise1)
- [Exercício 2: Comece com o Microsoft QnA Maker](#Exercise2)
- [Exercício 3: Expanda a base de conhecimento do QnA Maker](#Exercise3)
- [Exercício 4: Implante o bot e configure a integração contínua](#Exercise4)
- [Exercício 5: depurar o bot localmente](#Exercise5)
- [Exercício 6: Conecte o bot à base de conhecimento](#Exercise6)
- [Exercício 7: teste o bot com o Skype](#Exercise7)

Tempo estimado para completar este laboratório:  **60**  minutos.


<a name="Exercise1"></a>
## Exercício 1: Criar um serviço de bot no Azure ##

O primeiro passo na criação de um bot é fornecer um local para hospedar o bot, bem como configurar os serviços que o bot usará.  [O Azure Web Apps](https://azure.microsoft.com/services/app-service/web/) é perfeito para hospedar aplicativos de bot e o Azure Bot Service foi projetado para fornecer e conectar esses serviços para você. Neste exercício, você criará e configurará um Serviço Azure Bot.

1. Abra o  [Portal Azure](https://portal.azure.com/) no seu navegador. Se você for solicitado a fazer login, faça isso usando sua conta Microsoft.
1. Clique  **+ Novo** , seguido de  **Inteligência + análise**  e, em seguida, **Bot Service (preview)**.

    ![Creating a new Azure Bot Service](images/portal-new-bot-service.png)
_Criando um serviço Azure Bot_

1. Digite um nome como &quot;qnafactbot&quot; (sem aspas) na caixa  **Nome**  da  **aplicação**. Este nome deve ser exclusivo dentro de sua assinatura do Azure, portanto, verifique se uma marca de verificação verde aparece ao lado. Verifique se  **Criar novo**  está selecionado em  **Grupo de recursos**  e digite o nome do grupo de recursos &quot;BotsResourceGroup&quot; (novamente, sem aspas). Em seguida, selecione a localização mais próxima e clique em  **Criar**.

    ![Configuring a new Azure Bot Service](images/portal-create-new-bot-service.png)
_Configurando um novo serviço Azure Bot_

1. Clique em  **Grupos de recursos**  na barra à esquerda, seguido de  **BotsResourceGroup**  para abrir o grupo de recursos criado para o Serviço Bot.

    ![Opening the resource group](images/portal-open-resource-group.png)
_Abrindo o grupo de recursos_

1. Aguarde até que &quot;Implantando&quot; vire &quot;Sucesso&quot; indicando que o Serviço Bot foi implantado com sucesso. Você pode clicar no botão  **Atualizar**  na parte superior da lâmina para atualizar o status da implantação.

    ![Successful deployment](images/portal-app-deployment-status.png)
_Implementação bem-sucedida_

1. Clique em  **qnafactbot**  (ou no nome que você digitou na Etapa 3) para abrir o Serviço de Aplicativos criado para o seu bot.

    ![Opening the Bot Service](images/portal-click-bot-service.png)
_Abrindo o Serviço Bot_

1. Clique em  **Criar ID e senha da Microsoft App**. Se você for solicitado a fazer login novamente, faça isso usando sua conta Microsoft.

    ![Creating an app ID and password](images/portal-click-create-msft-app.png)
_Criando um ID e uma senha do aplicativo_

1. Clique em  **Gerar uma senha de aplicativo para continuar**.

    ![Generating an app password](images/portal-generate-password.png)
_Gerando uma senha de aplicativo_

1. Copie a senha para a área de transferência.  **Você não poderá recuperar essa senha após esta etapa** , mas será necessário para usá-la em um exercício posterior. Quando a senha for salva, clique em  **OK**  para descartar a caixa de diálogo.

    ![Copying the app password](images/portal-new-password-generated.png)
_Copiando a senha do aplicativo_

1. Revise as informações de registro do aplicativo e, em seguida, clique em  **Concluir e volte para o Bot Framework**.

    ![Finalizing the app registration](images/portal-click-finish.png)
_Finalizando o registro do aplicativo_

1. Cole a senha copiada para a área de transferência na etapa 9 na caixa de senha.

    ![Pasting the app password](images/portal-paste-app-password.png)
_Colando a senha do aplicativo_

1. Clique em  **Nodes**. Em seguida, clique em  **Pergunta e resposta**  e clique em  **Criar bot**. Se você for solicitado a fazer login novamente, faça isso usando sua conta Microsoft. Além disso, se você for solicitado a permissão para o QnA Maker acessar suas informações, clique em  **Sim**.

    ![Selecting a language and template](images/portal-select-template.png)
_Selecionando um idioma e um modelo_

1. Verifique a caixa de  **concordar**  e, em seguida, clique em  **OK**. (Se você for apresentado com a opção de se conectar a uma base de conhecimento existente ou criando uma nova, escolha a última.)

    ![Connecting to QnA Maker](images/connect-bot-to-qnamaker.png)
_Conectando-se ao QnA Maker_

1. Após uma breve pausa, o Serviço Bot abrirá no portal e exibirá o editor do Serviço Bot, conforme ilustrado abaixo. Por trás das cenas, o bot foi registrado, uma aplicação da Web Azure foi criada para hospedá-lo e o bot foi conectado ao Microsoft QnA Maker.

    ![The Bot Service editor](images/portal-editor-new.png)
_O editor do Bot Service_

1. Para garantir que esses serviços possam se comunicar entre si, você pode testar a comunicação do bot no editor do serviço Azure Bot. Para testar, digite a palavra &quot;Hi&quot; (sem aspas) na janela de bate-papo no lado direito da página. Em seguida, pressione  **Enter**  ou clique no ícone do papel-avião.

    ![Testing bot communication](images/portal-send-chat-test.png)
_Testando a comunicação do bot_

1. Aguarde que o bot responda com a palavra &quot;Hello&quot;, indicando que seu bot está configurado e pronto para ir.

    ![Chatting with your bot](images/portal-test-chat.png)
_Conversando com seu bot_

Com o Bot Service implantado e configurado, o próximo passo é atualizar o serviço Microsoft QnA Maker ao qual o bot está conectado.


<a name="Exercise2"></a>
## Exercício 2: Comece com o Microsoft QnA Maker ##

[O Microsoft QnA Maker](https://qnamaker.ai/) faz parte do  [Microsoft Cognitive Services](https://www.microsoft.com/cognitive-services/) , que é um conjunto de APIs para a construção de aplicativos inteligentes. Ao invés de infundir um bot com inteligência, escrevendo um código que tenta antecipar todas as perguntas que um usuário possa fazer e fornecer uma resposta, você pode conectá-lo a uma base de conhecimento de perguntas e respostas criadas com o QnA Maker. Um cenário de uso comum é criar uma base de conhecimento a partir de uma FAQ para que o bot possa responder a questões específicas do domínio, como &quot;Como faço para encontrar a chave do produto do Windows&quot; ou &quot;Onde posso baixar o Visual Studio Code?&quot;

Neste exercício, você usará o portal QnA Maker para editar a base de conhecimento que foi criada quando você conectou o bot ao QnA Maker. Essa base de conhecimento atualmente contém uma única pergunta e responde: &quot;Hi&quot; e &quot;Hello&quot;. Você editará a resposta e, no  [Exercício 3](https://github.com/CommunityBootcamp/Maratona-BOTs/blob/master/Desenvolvendo%20Bots%20inteligentes%20com%20o%20Microsoft%20Bot%20Framework.md#Exercise3) , preencha a base de conhecimento com perguntas e respostas adicionais.

1. Abra o  [portal Microsoft QnA Maker](https://qnamaker.ai/) no seu navegador. Se você não fez o login, clique  **em Iniciar sessão**  no canto superior direito e faça login com sua conta Microsoft. Se você for apresentado com um acordo de termos, marque a caixa de  **concordar**  e continue.

    ![Signing in to QnA Maker](images/qna-click-signin.png)
_Fazendo login no QnA Maker_

1. Certifique-se de que  **Meus serviços**  estão selecionados no topo. Em seguida, clique no ícone de lápis.

    ![Editing a QnA service](images/qna-click-edit-icon.png)
_Editando um serviço QnA_

1. Clique em  **Configurações**. Substitua o valor na caixa  **Nome**  do  **serviço**  por &quot;QnA Factbot&quot; (sem aspas). Em seguida, clique em  **Salvar e Armazenar**  para salvar a alteração.

    ![Updating the service name](images/qna-save-service-name.png)
_Atualizando o nome do serviço_

1. Clique em  **Base de Conhecimento**.

    ![Opening the Knowledge Base page](images/qna-select-kb-tab.png)
_Abrindo a página da Base de Conhecimento_

1. Substitua &quot;Hi&quot; na coluna Resposta com &quot;Bem-vindo ao QnA Factbot!&quot; Em seguida, clique em  **Salvar e Armazenar**  para salvar a alteração.

    ![Updating a response](images/qna-update-default-answer.png)
_Atualizando uma resposta_

1. Clique em  **Testar**.

    ![Opening the Test page](images/qna-select-test-tab.png)
_Abrindo a página de teste_

1. Digite &quot;hi&quot; na caixa na parte inferior da janela de bate-papo e pressione  **Enter**. Confirme se o bot responde com &quot;Bem-vindo ao QnA Factbot!&quot;

    ![Chatting with the bot](images/qna-updated-chat-response.png)
_Conversando com o bot_

Este é um excelente começo, mas uma resposta simples à saudação &quot;Hi&quot; não demonstra muito valor. Para dar ao seu bot um conteúdo significativo para trabalhar, o próximo passo é preencher a base de conhecimento com perguntas e respostas adicionais.


<a name="Exercise3"></a>
## Exercício 3: Expanda a base de conhecimento do QnA Maker ##

Você pode inserir perguntas e respostas em uma base de conhecimento do QnA Maker manualmente, ou pode importá-las de uma variedade de fontes, incluindo sites e arquivos de texto locais. Neste exercício, você usará ambas as técnicas para preencher a base de conhecimento com perguntas e respostas e, em seguida, publicar a base de conhecimento atualizada para o seu bot usar.

1. Clique em  **Configurações**  para retornar à página Configurações no  [portal Microsoft QnA Maker](https://qnamaker.ai/) .

    ![Opening the Settings page](images/qna-select-settings-tab.png)
_Abrindo a página Configurações_

1. Cole o seguinte URL na caixa  **URLs**:
    ```javascript
    https://traininglabservices.azurewebsites.net/help/faqs.html
    ```
1. Clique em  **Salvar e Armazenar**  para preencher a base de conhecimento com perguntas e respostas do site da Web, cujo URL você forneceu.

    ![Importing questions and answers from a URL](images/qna-add-faq-url.png)
_Importando perguntas e respostas de um URL_

1. Clique na  **Base de Conhecimento**  e confirme que foram adicionadas seis novas perguntas e respostas. Em seguida, clique em  **Salvar e Armazenar**  para salvar as alterações.

    ![The updated knowledge base](images/qna-updated-kb-01.png)
_A base de conhecimento atualizada_

1. Clique em  **Testar**  para retornar à página de teste. Digite &quot;Qual é a maior cidade do mundo?&quot; na caixa na parte inferior da janela de bate-papo e pressione  **Enter**. Confirme se o bot responde como mostrado abaixo.

    ![Testing the updated knowledge base](images/qna-test-largest-city.png)
_Testando a base de conhecimento atualizada_

1. A base de conhecimento contém apenas algumas perguntas e respostas, mas pode ser facilmente atualizada para incluir mais. Você pode até importar perguntas e respostas armazenadas em arquivos de texto em seu computador. Para demonstrar, clique em  **Substituir Base de Conhecimento**  no canto superior esquerdo do portal.

    ![Replacing the knowledge base](images/qna-click-replace-kb.png)
_Substituindo a base de conhecimento_

1. Navegue para os recursos que acompanham este laboratório e selecione o arquivo de texto chamado  **QnA.txt final**. Clique em  **OK**  quando solicitado a confirmar que importar este arquivo substituirá as perguntas e respostas existentes.
1. Clique em  **Base de Conhecimento**  e confirme que 14 novas perguntas e respostas aparecem na base de conhecimento. (Os seis que você importou do URL ainda estão lá, apesar de terem sido avisados ​​de que eles seriam substituídos.) Em seguida, clique em  **Salvar e Armazenar**  para salvar as alterações.

    ![The updated knowledge base](images/qna-updated-kb-02.png)
_A base de conhecimento atualizada_

1. Clique em  **Testar**  para retornar à página de teste. Digite &quot;Qual livro vendeu a maioria das cópias?&quot; na caixa na parte inferior da janela de bate-papo e pressione  **Enter**. Confirme se o bot responde como mostrado abaixo.

    ![Chatting with the bot](images/qna-test-book.png)
_Conversando com o bot_

1. A base de conhecimento agora contém 20 perguntas e respostas, mas um caractere inválido está presente na resposta na linha 7. Para remover o caractere, clique em  **Base de Conhecimento**  para retornar à página da Base de Conhecimento. Localize o caractere inválido na linha 7 entre as palavras &quot;most&quot; e &quot;Emmys&quot;, e substitua-o por um espaço. Em seguida, clique em  **Salvar e Armazenar**.

    ![Editing answer #7](images/qna-invalid-char.png)
_Editando a resposta #7_

1. Clique em  **Publicar**  para publicar as alterações na base de conhecimento.

    ![Publishing the knowledge base](images/qna-click-publish.png)
_Publicando a base de conhecimento_

1. Revise as alterações e clique em  **Publicar**. Após uma breve pausa, você deve ser notificado de que o serviço foi implantado.

    ![Reviewing changes](images/qna-review-publishing-changes.png)
_Revisando mudanças_

Com uma amostra de base de conhecimento implantada, agora é hora de prestar atenção ao próprio bot.


<a name="Exercise4"></a>
## Exercício 4: Implante o bot e configure a integração contínua ##

Quando você implantou um Serviço de Bot no  [Exercício 1](https://github.com/CommunityBootcamp/Maratona-BOTs/blob/master/Desenvolvendo%20Bots%20inteligentes%20com%20o%20Microsoft%20Bot%20Framework.md#Exercise1), um aplicativo da Web Azure foi criado para hospedar o bot. Mas o bot ainda precisa ser escrito e implantado no Azure Web App. Neste exercício, você codificará o bot usando o código-fonte gerado para você pelo QnA Maker. Em seguida, você criará um repositório Git local para o código, conectá-lo-á ao aplicativo Azure Web e publicará o bot para o Azure, todos usando o Visual Studio Code.

1. Se você não instalou o Visual Studio Code, tome um momento para fazê-lo agora. Você pode baixar o Visual Studio Code de  [http://code.visualstudio.com](http://code.visualstudio.com/) . Você também deve instalar [Node.js](https://nodejs.org/) e  [Git Client](https://git-scm.com/downloads) se eles ainda não estiverem instalados. Todos esses produtos funcionam cross-platform e podem ser instalados no Windows, MacOS ou Linux.

Uma maneira fácil de determinar se o Node.js está instalado é abrir uma janela de terminal ou janela do prompt de comando e executar um comando  **node -v**. Se o número de versão Node.js for exibido, Node.js está instalado.

1. Retorne ao Portal Azure e abra o Serviço Bot que você criou no  [Exercício 1](https://github.com/CommunityBootcamp/Maratona-BOTs/blob/master/Desenvolvendo%20Bots%20inteligentes%20com%20o%20Microsoft%20Bot%20Framework.md#Exercise1) se ainda não estiver aberto.

    ![Opening the Bot Service](images/portal-click-bot-service.png)
_Opening the Bot Service_

1. Clique em  **Configurações**  e, em seguida, clique em  **Configurar**.

    ![Configuring continuous integration](images/portal-expand-configure.png)
_Configurando integração contínua_

1. Clique no link para o arquivo zip que contém o código-fonte. Uma vez que o download está completo, descompacte o arquivo zip e copie seus conteúdos para a pasta local de sua escolha.

    ![Downloading the source code](images/portal-click-download-source.png)
_Carregando o código-fonte_

1. Desça a página e clique no botão  **Abrir**  à direita de &quot;Configurações avançadas&quot;.

    ![Opening advanced settings](images/portal-open-advanced-settings.png)
_Abrindo configurações avançadas_

1. Clique nas  **credenciais de implantação**.

    ![Viewing deployment credentials](images/portal-select-deployment-credentials.png)
_Visualizar credenciais de implantação_

1. Digite um nome de usuário como &quot;BotAdministrator&quot; (você provavelmente terá que inserir um nome de usuário diferente, pois estes devem ser únicos no Azure) e digite &quot;Password\_1&quot; como a senha. Clique em  **Salvar**  para salvar suas alterações. Em seguida, feche a lâmina clicando no  **x**  no canto superior direito.

    ![Entering deployment credentials](images/portal-enter-ci-creds.png)
_Inserindo as credenciais de implantação_

1. Clique em  **Configurar fonte de integração**.

    ![Setting up an integration source](images/portal-click-set-source.png)
_Configurando uma fonte de integração_

1. Clique em  **Configuração** , seguido de  **Escolher Origem**.

    ![Choosing a deployment source](images/portal-select-source.png)
_Escolhendo uma fonte de implantação_

1. Selecione  **Local Git Repository**  como a fonte de implantação e clique em  **OK**.

    ![Specifying a local Git repository as the deployment source](images/portal-set-local-git.png)
_Especificando um repositório Git local como fonte de implantação_

1. Inicie o Visual Studio Code. Selecione  **Abrir pasta**  no menu  **Arquivo**  e navegue até a pasta na qual você copiou o conteúdo do arquivo zip baixado na Etapa 4. Selecione a pasta &quot;mensagens&quot; e clique em  **Selecionar pasta**.

    ![Selecting the "messages" folder](images/fe-select-messages-folder.png)
_Selecionando a pasta &quot;mensagens&quot;_

1. Clique no botão  **Git**  na barra de exibição no lado esquerdo do Visual Studio Code e, em seguida, clique em  **Inicializar o depósito Git**. Isso iniciará um repositório Git local para o projeto.

    ![Initializing a local Git repository](images/vs-init-git-repo.png)
_Inicializando um repositório Git local_

1. Digite &quot;First commit&quot; na caixa de mensagem e, em seguida, clique na marca de seleção para confirmar suas alterações.

    ![Committing changes to the local Git repository](images/vs-first-git-commit.png)
_Cometer alterações no repositório Git local_

1. Inicie o terminal integrado do Visual Studio Code (**View -&gt; Integrated Terminal**). Execute o seguinte comando no terminal, substituindo &quot;BOT\_APP\_NAME&quot; em suas duas instâncias com o nome do Serviço Bot que você digitou no  [Exercício 1](https://github.com/CommunityBootcamp/Maratona-BOTs/blob/master/Desenvolvendo%20Bots%20inteligentes%20com%20o%20Microsoft%20Bot%20Framework.md#Exercise1) , Etapa 3.
    ```javascript
    git remote add qnafactbot https://BOT_APP_NAME.scm.azurewebsites.net:443/BOT_APP_NAME.git
    ```

1. Selecione a  **paleta de comandos**  no menu  **Exibir**  para abrir a paleta de comandos do Código do Visual Studio. Em seguida, digite &quot;git pub&quot; na paleta de comando e selecione  **Git: Publicar**  para publicar o código do bot para o Azure.

    ![Publishing the bot](images/vs-select-git-publish.png)
_Publicando o bot_

1. Se for solicitado a confirmar que deseja publicar, clique em  **Publicar**.

    ![Confirming Git publishing](images/vs-confirm-publish.png)
_Confirmando a publicação Git_

1. Se solicitado por credenciais, digite o nome de usuário e a senha (&quot;Password\_1&quot;) que você especificou na Etapa 7 deste exercício.

    ![Entering deployment credentials](images/vs-enter-git-creds.png)
_Inserindo as credenciais de implantação_

1. Aguarde até que seu código do bot seja publicado. Um relógio aparecerá sobre o botão Git na barra lateral enquanto a publicação estiver em andamento e desaparecerá quando a publicação estiver concluída.

    ![The Git publishing indicator](images/vs-git-delay-icon.png)
_O indicador de publicação Git_

Neste exercício, você criou um projeto para o seu bot no Visual Studio Code e configurou a integração contínua usando o Git para simplificar as mudanças de código de publicação. Seu bot foi publicado para o Azure e é hora de vê-lo em ação e aprender a depurá-lo no Visual Studio Code.


<a name="Exercise5"></a>
## Exercício 5: depurar o bot localmente ##

Tal como acontece com qualquer código de aplicação que você escreve, as alterações ao código do bot precisam ser testadas e depuradas localmente antes de serem implantadas na produção. Para ajudar a depurar bots, a Microsoft oferece o  [Emulador](https://emulator.botframework.com/) do  [Bot Framework](https://emulator.botframework.com/) . Neste exercício, você aprenderá a usar o Visual Studio Code e o Bot Framework Emulator para depurar seus bots.

1. Se você não instalou o Microsoft Bot Framework Emulator, tome um momento para fazê-lo agora. Você pode baixá-lo de  [https://emulator.botframework.com/](https://emulator.botframework.com/) .
1. Clique no botão  **Explorer**  na barra de visualização do Visual Studio Code. Em seguida, selecione  **js**  para abri-lo no editor de código. Este arquivo contém o código que dirige o código-base gerado pelo QnA Maker e baixado do portal QnA Maker.

    ![Opening index.js](images/vs-select-index-js.png)
_Opening index.js_

1. Substitua o conteúdo do  **arquivo js**  pelo seguinte código:

    ```JavaScript
        "use strict";
        var builder = require("botbuilder");
        var botbuilder_azure = require("botbuilder-azure");

        var useEmulator = (process.env.NODE_ENV == 'development');

        var connector = useEmulator ? new builder.ChatConnector() : new botbuilder_azure.BotServiceConnector({
            appId: process.env['MicrosoftAppId'],
            appPassword: process.env['MicrosoftAppPassword'],
            stateEndpoint: process.env['BotStateEndpoint'],
            openIdMetadata: process.env['BotOpenIdMetadata']
        });

        var bot = new builder.UniversalBot(connector);

        bot.dialog('/', [

        function (session) {
            builder.Prompts.text(session, "Hello, and welcome to QnA Factbot!What's your name?");
        },

        function (session, results) {

            session.userData.name = results.response;
            builder.Prompts.number(session, "Hi " + results.response + ", how many years have you been writing code?");
        },

        function (session, results) {

            session.userData.yearsCoding = results.response;
            builder.Prompts.choice(session, "What language do you love the most?", ["C#", "JavaScript", "TypeScript", "Visual FoxPro"]);
        },

        function (session, results) {

            session.userData.language = results.response.entity;

            session.send("Okay, " + session.userData.name + ", I think I've got it:" +
                        " You've been writing code for " + session.userData.yearsCoding + " years," +
                        " and prefer to use " + session.userData.language + ".");
        }]);

        if (useEmulator) {
            var restify = require('restify');
            var server = restify.createServer();
            server.listen(3978, function() {
                console.log('test bot endpoint at http://localhost:3978/api/messages');
            });
            server.post('/api/messages', connector.listen());
        } else {
            module.exports = { default: connector.listen() }
        }
    ```

1. Observe as instruções do Construtor de Bot nas linhas 19, 25 e 31. Defina um ponto de interrupção em cada uma dessas linhas clicando na margem à esquerda.

    ![Adding breakpoints to index.js](images/vs-add-breakpoints.png)
_Adding breakpoints to index.js_

1. Clique no botão  **Depurar**  na barra de exibição e, em seguida, clique na seta verde para iniciar uma sessão de depuração. Observe que &quot;teste ponto final do bot em  [http://localhost:3978/api/messages](http://localhost:3978/api/messages)&quot; aparece no console de depuração.

    ![Launching the debugger](images/vs-launch-debugger.png)
_Lançamento do depurador_

1. Seu código de bot está agora sendo executado localmente. Inicie o Emulador do Framework do Bot e digite o seguinte URL na caixa na parte superior da janela:

    ```javascript
    http://localhost:3978/api/messages
    ```

1. Deixe  **ID da aplicação Microsoft**  e a  **Microsoft App Password em**  branco por enquanto e clique em  **CONECTAR**  para conectar o emulador à sessão de depuração.

    ![Connecting the emulator to the debugging session](images/emulator-connect.png)
_Connecting the emulator to the debugging session_

1. Digite &quot;Hi&quot; (sem aspas) na caixa na parte inferior do emulador e pressione  **Enter**. O Visual Studio Code entrará na linha 19 do  **js**.

    ![Chatting with the bot](images/emulator-step-01.png)
_Conversando com o bot_

1. Clique no botão  **Continuar**  na barra de ferramentas de depuração do Visual Studio Code e volte ao emulador para ver a resposta do bot.

    ![Continuing in the debugger](images/vs-click-continue.png)
_Continuando no depurador_

1. Continue através da conversação de bot guiada, respondendo a cada pergunta e clicando em  **Continuar**  no Visual Studio Code cada vez que um ponto de interrupção for atingido.

    ![A guided bot conversation](images/emulator-complete-convo.png)
_Uma conversa guiada de bot_

1. Clique no botão  **Parar**  na barra de depuração do Visual Studio Code para finalizar a sessão de depuração.

Neste ponto, você tem um bot totalmente funcional e sabe como depurá-lo, iniciando-o no depurador no Visual Studio Code e conectando-se à sessão de depuração do Microsoft Bot Emulator. O próximo passo é tornar o bot mais inteligente ao conectá-lo à base de conhecimento que você implantou em [Exercício 3](https://github.com/CommunityBootcamp/Maratona-BOTs/blob/master/Desenvolvendo%20Bots%20inteligentes%20com%20o%20Microsoft%20Bot%20Framework.md#Exercise3).


<a name="Exercise6"></a>
## Exercício 6: Conecte o bot à base de conhecimento ##

Neste exercício, você conectará seu bot à base de conhecimento do QnA Maker que você criou anteriormente para que o bot possa conversar de forma mais inteligente. Isso envolve a recuperação de algumas chaves do Portal Azure, copiando-as para um arquivo de configuração no projeto do bot e redistribuindo o bot para o Azure.

1. No Visual Studio Code, clique no botão  **Explorer**  e selecione  **index.js** se ainda não estiver selecionado.

    ![Opening index.js](images/vs-reopen-index-js.png)
_Índice de abertura.js_

1. Clique no botão  **Depurar**  na barra de exibição. Em seguida, clique no ícone  **Remover todos os pontos de interrupção** para limpar os pontos de interrupção que você adicionou anteriormente.

    ![Removing all breakpoints](images/vs-remove-breakpoint.png)
_Removendo todos os pontos de interrupção_

1. Substitua o conteúdo do  **js**  pelo seguinte código:

    ```javascript
    // For more information about this template visit   http://aka.ms/azurebots-node-qnamaker

    "use strict";
    var builder = require("botbuilder");
    var botbuilder_azure = require("botbuilder-azure");
    var builder_cognitiveservices = require("botbuilder-cognitiveservices");

    var useEmulator = (process.env.NODE_ENV == 'development');

    var connector = useEmulator ? new builder.ChatConnector() : new botbuilder_azure.BotServiceConnector({
        appId: process.env['MicrosoftAppId'],
        appPassword: process.env['MicrosoftAppPassword'],
        stateEndpoint: process.env['BotStateEndpoint'],
        openIdMetadata: process.env['BotOpenIdMetadata']
    });

    var bot = new builder.UniversalBot(connector);

    var recognizer = new builder_cognitiveservices.QnAMakerRecognizer({
                    knowledgeBaseId: process.env.QnAKnowledgebaseId,
        subscriptionKey: process.env.QnASubscriptionKey});

    var basicQnAMakerDialog = new builder_cognitiveservices.QnAMakerDialog({
        recognizers: [recognizer],
                    defaultMessage: 'No match! Try changing the query terms!',
                    qnaThreshold: 0.3}
    );

    bot.dialog('/', basicQnAMakerDialog);

    if (useEmulator) {
        var restify = require('restify');
        var server = restify.createServer();
        server.listen(3978, function() {
            console.log('test bot endpoint at http://localhost:3978/api/messages');
        });
        server.post('/api/messages', connector.listen());
    } else {
        module.exports = { default: connector.listen() }
    }
    ```

1. Observe a chamada para _QnAMakerDialog_ na linha 23. Isso cria uma caixa de diálogo que integra um bot construído com o Microsoft Bot Framework com uma base de conhecimento construída do Microsoft QnA Maker.

    ![Creating a QnAMakerDialog](images/vs-using-qnamaker.png)
_Criando um QnAMakerDialog_

1. Expanda a pasta **.vscode**  no Explorer e selecione  **json**  para abri-lo para edição. Observe os valores da string vazia para &quot;QnAKnowledgebaseId&quot; e &quot;QnASubscriptionKey&quot;. Para conectar o bot à base de conhecimento, você deve substituir as cadeias vazias por um par de chaves geradas pelo Serviço Bot.

    ![Opening launch.json](images/vs-launch-file.png)
_Abertura launch.json_

1. Volte para o Portal Azure e abra seu Serviço Bot se ainda não estiver aberto. Em seguida, clique na guia  **Configurações**  .

    ![Opening the Settings page](images/portal-select-settings.png)
_Abrindo a página Configurações_

1. Clique em  **Abrir**  à direita de &quot;Configurações da aplicação&quot;.

    ![Viewing application settings](images/portal-open-app-settings.png)
_Visualizando as configurações do aplicativo_

1. Role para baixo até encontrar a configuração da aplicação chamada &quot;QnAKnowledgebaseId&quot; e copie seu valor para a área de transferência.

    ![Copying the knowledge-base ID](images/portal-app-setting-01.png)
_Copiando o ID da base de conhecimento_

1. Retorne ao Código do Visual Studio e cole o valor na área de transferência para o valor &quot;QnAKnowledgebaseId&quot;.

    ![Updating "QnAKnowledgebaseId" in launch.json](images/vs-updated-key-01.png)
_Atualizando &quot;QnAKnowledgebaseId&quot; no launch.json_

1. Repita esse processo para copiar o valor da configuração do aplicativo chamado &quot;QnASubscriptionKey&quot; do portal para  **json**  .
1. Inicie uma nova sessão de depuração no Visual Studio Code. Em seguida, inicie o Emulador do Bot Framework se ainda não estiver em execução e digite novamente o seguinte URL do nó de extremidade:

    ```javascript
    http://localhost:3978/api/messages
    ```

1. Lembre-se de deixar as caixas da  **Microsoft App ID**  e  **Microsoft Password**  vazias e clique em  **CONNECT**  para reconectar o emulador para a sessão de depuração.
1. No emulador, clique no ícone  **Atualizar**  para iniciar uma nova conversa.

    ![Starting a new conversation in the emulator](images/emulator-start-new.png)
_Iniciando uma nova conversa no emulador_

1. Digite &quot;Qual a linguagem de programação de software mais popular do mundo?&quot; na caixa na parte inferior da janela do chat do emulador e pressione  **Enter**  .

    ![Chatting with the bot](images/emulator-step-02.png)
_Conversando com o bot_

1. Observe que as respostas agora estão baseadas na base de conhecimento QnA. Pergunte ao bot outras perguntas e veja como ela responde. Por exemplo, pergunte-lhe qual é o jogo multiplataforma mais vendido de todos os tempos, ou quem ganhou o Super Bowl.

1. Clique no botão  **Parar**  na barra de depuração do Visual Studio Code para finalizar a sessão de depuração. Em seguida, selecione  **Exibir -&gt; Paleta de comando**  para abrir a paleta de comandos, digite &quot;Git Sy&quot; e selecione  **Git: Sincronizar**  .

    ![Syncing the local and remote repositories](images/vs-select-git-sync.png)
_Sincronizando os repositórios locais e remotos_

1. Se o Visual Studio Code o solicitar com um aviso de sincronização Git, clique em  **OK**  .

    ![Dismissing the synchronization warning](images/vs-git-warning.png)
_Rejeitando o aviso de sincronização_

Agora que seu bot foi escrito, atualizado e testado, o passo final é testá-lo fora do depurador em um canal conectado.

<a name="Exercise7"></a>
## Exercício 7: teste o bot com o Skype ##

Uma vez implantados, os bots podem ser conectados a canais como Skype, Slack, Microsoft Teams e Facebook Messenger, onde você pode interagir com eles da maneira como você interagir com qualquer outro usuário. Neste exercício, você testará seu bot com o Skype.

1. Se o Skype ainda não estiver instalado no seu computador, instale-o agora. Você pode baixar o Skype para Windows, MacOS e Linux em  [https://www.skype.com/pt-br/get-skype/](https://www.skype.com/pt-br/get-skype/).
2. Retorne ao seu Serviço Bot no Portal Azure e clique em  **Canais**  .

    ![Opening the Channels page](images/portal-bot-channel-tab.png)
_Abrindo a página Canais_

1. Clique em  **Editar**  na linha &quot;Skype&quot;.

    ![Editing the Skype channel](images/portal-edit-skype.png)
_Editando o canal do Skype_

1. Certifique-se de que o bot está habilitado no Skype e clique em **eu terminei de configurar** na parte inferior da página. Seu bot agora está pronto para testar em uma conversa do Skype.

    ![Enabling Skype integration](images/portal-enable-skype.png)
_Habilitando a integração do Skype_

1. Clique no botão **Adicionar ao Skype**

    ![Adding the bot to Skype](images/portal-click-add-to-skype.png)
_Adicionando o bot ao Skype_

1. Clique em **Adicionar aos Contatos** para adicionar o bot como um contato do Skype. O Skype irá iniciar e exibir um novo fio de conversação entre você e o bot.

    >Se o Skype não iniciar automaticamente uma conversa com o bot, selecione o bot na lista de &quot;Recentes&quot; do Skype para iniciar uma conversa manualmente.

    ![Adding the bot as a Skype contact](images/skype-add-to-contacts.png)
    _Adding the bot as a Skype contact_

1. Comece uma conversa com o bot digitando &quot;Hi&quot; na janela do Skype. O bot exibirá uma mensagem de boas-vindas e você pode iniciar um processo de perguntas e respostas usando as informações disponíveis em sua base de conhecimento QnA!

    ![Chatting with the bot in Skype](images/skype-responses.png)
_Conversando com o bot no Skype_

Você agora possui um bot totalmente funcional criado com o Microsoft Bot Framework, infundido com informações com o Microsoft QnA Maker, e está disponível para qualquer pessoa no mundo com quem interagir. Sinta-se à vontade para conectar o seu bot a outros canais e testá-lo em diferentes cenários. E se você quiser fazer o bot mais inteligente, considere expandir a base de conhecimento QnA com perguntas e respostas adicionais. Por exemplo, você poderia usar as  [FAQ online](https://docs.botframework.com/en-us/faq/) para o Bot Framework para treinar o bot para responder perguntas sobre o próprio framework.

<a name="Summary"></a>
## Resumo ##

Neste laboratório prático, você aprendeu a:

- Criar um serviço Azure Bot para hospedar um bot
- Criar uma base de conhecimentos Microsoft QnA, preenche-la com dados e conecta-la a um bot
- Implementar bots via código e depurar os bots que você construiu
- Publicar bots e usar a integração contínua para mantê-los atualizados
- Conectar um bot no Skype e interajir com ele lá

Há muito mais que você pode fazer para aproveitar o poder do Microsoft Bot Framework incorporando  [diálogos](http://aihelpwebsite.com/Blog/EntryId/9/Introduction-To-Using-Dialogs-With-The-Microsoft-Bot-Framework) ,  [FormFlow](https://blogs.msdn.microsoft.com/uk_faculty_connection/2016/07/14/building-a-microsoft-bot-using-microsoft-bot-framework-using-formflow/) e  [Microsoft Language Understanding e Intelligence Services (LUIS)](https://docs.botframework.com/en-us/node/builder/guides/understanding-natural-language/) . Com estes e outros recursos, você pode criar bots sofisticados que respondem às consultas e comandos dos usuários e interagem de forma fluida, conversacional e não-linear. Para obter mais informações, consulte  [https://blogs.msdn.microsoft.com/pt\_faculty\_connection/2016/04/05/what-is-microsoft-bot-framework-overview/](https://blogs.msdn.microsoft.com/uk_faculty_connection/2016/04/05/what-is-microsoft-bot-framework-overview/) .

Copyright 2016 Microsoft Corporation. Todos os direitos reservados. Exceto quando indicado de outra forma, esses materiais são licenciados sob os termos da Licença Apache, Versão 2.0. Você pode usá-lo de acordo com a licença, conforme apropriado para o seu projeto caso a caso. Os termos desta licença podem ser encontrados em  [http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0) .