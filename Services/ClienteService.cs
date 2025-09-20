using InvestmentAdvisor.Data;
using InvestmentAdvisor.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentAdvisor.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}