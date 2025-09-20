using InvestmentAdvisor.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentAdvisor.Services
{
    public class RecomendacaoService
    {
        public Recomendacao GerarRecomendacao(Cliente cliente, List<Ativo> todosOsAtivos)
        {
            var recomendacao = new Recomendacao { Cliente = cliente };
            string perfil = cliente.PerfilRisco.ToLower();

            if (perfil == "conservador")
            {
                recomendacao.AtivosRecomendados = todosOsAtivos.Where(a => a.Risco <= 2.0m).ToList();
                recomendacao.Justificativa = "Foco em preservação de capital com baixo risco.";
            }
            else if (perfil == "moderado")
            {
                recomendacao.AtivosRecomendados = todosOsAtivos.Where(a => a.Risco > 1.5m && a.Risco <= 4.0m).ToList();
                recomendacao.Justificativa = "Busca por um equilíbrio entre segurança e rentabilidade.";
            }
            else if (perfil == "agressivo")
            {
                recomendacao.AtivosRecomendados = todosOsAtivos.Where(a => a.Risco > 3.5m).ToList();
                recomendacao.Justificativa = "Foco em maximizar o retorno, aceitando maior volatilidade.";
            }
            else
            {
                recomendacao.AtivosRecomendados = new List<Ativo>();
                recomendacao.Justificativa = "Perfil de risco não reconhecido.";
            }

            return recomendacao;
        }
    }
}