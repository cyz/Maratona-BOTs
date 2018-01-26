using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace QnABotWithActiveLearning.Dialogs
{
    [Serializable]
    [QnAMaker("f23a3ceb8e6d4a11896b3e7b7214d94c", "57a2732f-4a65-4ae8-bc7f-7da280890e2a", "I don't understand this right now! Try another query!", 0.50, 3)]
    public class QnABotWithActiveLearning : QnAMakerDialog
    {
        
    }
}