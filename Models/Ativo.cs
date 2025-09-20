namespace InvestmentAdvisor.Models
{
    public class Ativo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Risco { get; set; }
        public decimal RetornoEsperado { get; set; }
    }
}