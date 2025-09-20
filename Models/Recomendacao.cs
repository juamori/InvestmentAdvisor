using System.Collections.Generic;

namespace InvestmentAdvisor.Models
{
    public class Recomendacao
    {
        public Cliente Cliente { get; set; }
        public List<Ativo> AtivosRecomendados { get; set; }
        public string Justificativa { get; set; }
    }
}