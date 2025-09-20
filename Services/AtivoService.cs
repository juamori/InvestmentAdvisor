using InvestmentAdvisor.Data;
using InvestmentAdvisor.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentAdvisor.Services
{
    public class AtivoService
    {
        private readonly ApplicationDbContext _context;

        public AtivoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ativo> ObterTodos()
        {
            return _context.Ativos.ToList();
        }

        public void Adicionar(Ativo ativo)
        {
            _context.Ativos.Add(ativo);
            _context.SaveChanges();
        }
    }
}