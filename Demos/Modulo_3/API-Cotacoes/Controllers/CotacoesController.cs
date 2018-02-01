using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API_Cotacoes.Model;
using System;

namespace API_Cotacoes.Controllers
{
    [Route("api/[controller]")]
    public class CotacoesController : Controller
    {

        private static Random RANDON = new Random();

        [HttpGet("{moedas}")]
        public IActionResult Get(string moedas) => Magica(moedas);

        private IActionResult Magica(string moedas)
        {
            List<string> RetornaFiltro()
            {
                var dicionario = new Dictionary<string, List<string>>
                {
                    ["USD"] = new List<string> { "dólar", "dolar", "usd" },
                    ["EUR"] = new List<string> { "euro", "eu", "eur" },
                    ["BTC"] = new List<string> { "bitcoin", "bit coin", "btc" },
                };

                if (string.IsNullOrEmpty(moedas))
                    return dicionario.Select(d => d.Key).ToList();

                var parts = moedas.ToLower().Replace(" ", "").Split(',');
                var chaves = new List<string>();
                foreach (var part in parts)
                {
                    var keyvalue = dicionario.FirstOrDefault(d => d.Value.Contains(part));
                    if (!string.IsNullOrEmpty(keyvalue.Key))
                        chaves.Add(keyvalue.Key);
                }
                return chaves;
            }

            float ObterValor()
            {
                var a = RANDON.Next(2, 4);
                var b = RANDON.Next(0, 9);
                var c = RANDON.Next(0, 9);
                var valor = float.Parse($"{a}.{b}{c}");
                return valor;
            }

            var listaMoedas = RetornaFiltro();
            var cotacoes = new List<Moeda>();
            foreach (var item in listaMoedas)
            {
                cotacoes.Add(new Moeda { Nome = item, Sigla = item, Valor = ObterValor() });
            }

            return Ok(cotacoes);
        }
    }
}