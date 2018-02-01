using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;

namespace MaratonaBots.Dialogs
{
    [Serializable]
    [LuisModel("d75a835d-ea0c-4d51-a0e1-aee4e991466b", "a2b9d6bd1c31416ca3fd18e09238b545")]
    public class CotacaoDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase {result.Query}");
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu sou um bot e estou sempre aprendendo. Tenha paciência comigo");
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá! Eu sou um bot que faz cotação de moedas.");
        }

        [LuisIntent("Cotacao")]
        public async Task Cotacao(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", moedas.ToArray());
            var endpoint = $"http://api-cotacoes-maratona-bots.azurewebsites.net/api/Cotacoes/{filtro}";

            await context.PostAsync("Aguarde um momento enquanto eu obtenho os valores...");

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Ocorreu algum erro... tente mais tarde");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Cotacao[]>(json);
                    var cotacoes = resultado.Select(c => $"{c.Nome}: {c.Valor}" );
                    await context.PostAsync($"{string.Join(",", cotacoes.ToArray())}");
                }
            }
        }
    }
}