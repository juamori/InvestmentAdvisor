namespace InvestmentAdvisor.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal RendaMensal { get; set; }
        public string PerfilRisco { get; set; }
    }
}