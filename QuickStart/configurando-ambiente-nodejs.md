O Bot Builder SDK para Node.js é um framework para o desenvolvimento de bots. É fácil de usar e conectar com outras bibliotecas Node, como Express & Restify.

Este tutorial irá ajudá-lo a configurar seu ambiente e construir um bot simples usando o SDK do Bot Builder para Node.js. Você pode testar o bot em uma janela de console e com o Bot Framework Emulator.

Uma assinatura do Microsoft Azure é necessária para usar o Azure Bot Service. Caso ainda não tenha uma assinatura, é possível se registrar para o [**Trial Gratuito**](https://aka.ms/bots-azure-free).

## Pré-requisitos:
* Instalar o [Node.js](https://nodejs.org/) em sua máquina
* Instalar o [Bot Emulator](http://emulator.botframework.com/)
* Instalar o [Visual Studio Code](code.visualstudio.com)
* Criar uma pasta para o seu bot e abri-la no Visual Studio Code
* No terminal do Visual Studio Code, você deve executar o seguinte comando:
```javascript=
npm init
```

Siga os passos que irão aparecer no prompt e adicione as informações para o npm crie um o  arquivo **package.json**, que irá conter as informações do seu bot.

## Instalando a SDK
Em seguida, instale o SDK do Bot Builder para Node.js executando o seguinte comando npm:
```javascript
npm install --save botbuilder
```

Depois de ter o SDK instalado, você está pronto para escrever seu primeiro bot.

Para o seu primeiro bot, você criará um bot que simplesmente responde qualquer entrada do usuário. Para criar o seu bot, siga estas etapas:

* No mesmo projeto que você está trabalhando no Visual Studio Code, crie um novo arquivo chamado app.js.
* Com o app.js aberto, adicione o seguinte código ao arquivo:

```javascript
var builder = require('botbuilder');

var connector = new builder.ConsoleConnector().listen();
var bot = new builder.UniversalBot(connector, function (session) {
    session.send("Você disse: %s", session.message.text);
});
```

Salve o arquivo. Agora você está pronto para correr e testar seu bot.

## Iniciando o bot
Abra novamente o terminal do Visual Studio Code e inicie o seu bot com o seguinte comando:

```javascript
node app.js
```

Seu bot agora está sendo executado localmente. Teste o seu bot digitando algumas mensagens na janela do console. Você deve ver que o bot responde a cada mensagem que você envia fazendo eco de sua mensagem com prefixo com o texto "Você disse:".

## Instalando Restify
Os bots de console são bons clientes baseados em texto, mas para usar qualquer um dos canais do Bot Framework (ou executar o seu bot no emulador), seu bot precisará executar em uma porta de servidor. Para conseguir executar seu bot no emulador ou publicá-lo em algum canal, iremos utilizar a Restify. Em seu terminal, digite o seguinte comando npm:

```javascript
npm install --save restify
```

Uma vez que você tenha o Restify instalado, você está pronto para fazer algumas mudanças no seu bot.

## Editando seu bot
Você precisará fazer algumas alterações no seu arquivo **app.js**.

* Adicione uma linha de require para o módulo do restify
* Mude a chamada ```ConsoleConnector``` para ```ChatConnector```.
* Inclua suas credenciais de Microsoft App ID e App Password (você pode deixar em branco quando estiver testando localmente).
* Para instanciar o serviço, você deverá adicionar o seguinte código:

```javascript
var restify = require('restify');
var builder = require('botbuilder');

// Setup Restify Server
var server = restify.createServer();
server.listen(process.env.port || process.env.PORT || 3978, function () {
   console.log('%s listening to %s', server.name, server.url); 
});

// Crie um chat conector para se comunicar com o Bot Framework Service
var connector = new builder.ChatConnector({
    appId: process.env.MICROSOFT_APP_ID,
    appPassword: process.env.MICROSOFT_APP_PASSWORD
});

// Endpoint que irá monitorar as mensagens do usuário
server.post('/api/messages', connector.listen());

// Recebe as mensagens do usuário e responde repetindo cada mensagem (prefixado com 'Você disse:')
var bot = new builder.UniversalBot(connector, function (session) {
    session.send("Você disse: %s", session.message.text);
});
```

Salve o arquivo. Agora você está pronto para executar e testar seu bot no emulador.

## Teste o seu bot
Depois de instalar o [Bot Emulator](https://docs.microsoft.com/pt-BR/bot-framework/bot-service-debug-emulator), através do console, navegue até o diretório do seu bot e digite o seguinte comando:

```javascript
node app.js
```

Agora, seu bot está sendo executado localmente.

### Testando o bot no emulador
Depois de iniciar o seu bot, conecte-se ao seu bot no emulador:

* Digite ```http://localhost:3978/api/messages``` na barra de endereço do Bot Emulator. (Este é o endpoint padrão que o seu bot, quando estiver rodando localmente.)
* Click em Connect.


Agora que seu bot está sendo executado localmente e está conectado ao emulador, experimente o seu bot digitando algumas mensagens no emulador. Você deve ver que o bot responde a cada mensagem que você envia fazendo eco de sua mensagem com prefixo com o texto "Você disse:".
