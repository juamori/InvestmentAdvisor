using InvestmentAdvisor.Data;
using InvestmentAdvisor.Models;
using InvestmentAdvisor.Services;
using System;
using System.Linq;

class Program
{
    private static ClienteService _clienteService;
    private static AtivoService _ativoService;
    private static readonly RecomendacaoService _recomendacaoService = new RecomendacaoService();

    static void Main(string[] args)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.Database.EnsureCreated();

            _clienteService = new ClienteService(dbContext);
            _ativoService = new AtivoService(dbContext);

            Console.WriteLine("Bem-vindo ao InvestmentAdvisor!");
            
            PopularDadosIniciaisSeNecessario();

            while (true)
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        ListarAtivos();
                        break;
                    case "4":
                        GerarRecomendacao();
                        break;
                    case "5":
                        Console.WriteLine("Saindo do programa. Obrigado por utilizar!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("\n--- Assessor Virtual de Investimentos ---");
        Console.WriteLine("1 - Cadastrar novo cliente");
        Console.WriteLine("2 - Listar clientes cadastrados");
        Console.WriteLine("3 - Listar ativos disponíveis");
        Console.WriteLine("4 - Gerar recomendação de investimentos");
        Console.WriteLine("5 - Sair");
        Console.Write("Digite a opção desejada: ");
    }

    private static void CadastrarCliente()
    {
        Console.WriteLine("--- Cadastro de Novo Cliente ---");

        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        int idade = LerInteiro("Idade: ");
        decimal renda = LerDecimal("Renda Mensal: ");
        
        Console.Write("Perfil (Conservador/Moderado/Agressivo): ");
        var perfil = Console.ReadLine();

        _clienteService.Adicionar(new Cliente { Nome = nome, Idade = idade, RendaMensal = renda, PerfilRisco = perfil });
        
        Console.WriteLine("\nCliente cadastrado com sucesso! Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    
    private static void ListarClientes()
    {
        Console.WriteLine("--- Lista de Clientes ---");
        var clientes = _clienteService.ObterTodos();

        if (!clientes.Any())
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
        }
        else
        {
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Perfil: {c.PerfilRisco}");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    
    private static void ListarAtivos()
    {
        Console.WriteLine("--- Lista de Ativos Disponíveis ---");
        var ativos = _ativoService.ObterTodos();
        
        foreach (var a in ativos)
        {
            Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome} | Tipo: {a.Tipo} | Risco: {a.Risco}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    
    private static void GerarRecomendacao()
    {
        Console.WriteLine("--- Gerar Recomendação ---");
        ListarClientes(); 
        
        var id = LerInteiro("Digite o ID do cliente para gerar a recomendação: ");
        var cliente = _clienteService.ObterPorId(id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado!");
        }
        else
        {
            var ativosDisponiveis = _ativoService.ObterTodos();
            var recomendacao = _recomendacaoService.GerarRecomendacao(cliente, ativosDisponiveis);

            Console.WriteLine($"\n--- Recomendação para {recomendacao.Cliente.Nome} ---");
            Console.WriteLine($"Justificativa: {recomendacao.Justificativa}");
            Console.WriteLine("Ativos Recomendados:");

            foreach (var ativo in recomendacao.AtivosRecomendados)
            {
                Console.WriteLine($"- {ativo.Nome} (Tipo: {ativo.Tipo}, Risco: {ativo.Risco})");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    private static void PopularDadosIniciaisSeNecessario()
    {
        if (!_clienteService.ObterTodos().Any())
        {
            Console.WriteLine("Executando primeiro setup: populando banco de dados com dados de exemplo...");
            _clienteService.Adicionar(new Cliente { Nome = "João Silva", RendaMensal = 5000, Idade = 35, PerfilRisco = "Moderado" });
            _clienteService.Adicionar(new Cliente { Nome = "Maria Santos", RendaMensal = 10000, Idade = 50, PerfilRisco = "Conservador" });
            _clienteService.Adicionar(new Cliente { Nome = "Pedro Costa", RendaMensal = 8000, Idade = 25, PerfilRisco = "Agressivo" });

            _ativoService.Adicionar(new Ativo { Nome = "CDB DI", Tipo = "Renda Fixa", Risco = 1.0m, RetornoEsperado = 0.08m });
            _ativoService.Adicionar(new Ativo { Nome = "Tesouro Selic", Tipo = "Renda Fixa", Risco = 1.2m, RetornoEsperado = 0.07m });
            _ativoService.Adicionar(new Ativo { Nome = "Fundo Imobiliário XYZ", Tipo = "Fundos Imobiliários", Risco = 2.5m, RetornoEsperado = 0.10m });
            _ativoService.Adicionar(new Ativo { Nome = "Ações Petrobras", Tipo = "Ações", Risco = 4.5m, RetornoEsperado = 0.15m });
            _ativoService.Adicionar(new Ativo { Nome = "Fundo de Ações Tech", Tipo = "Ações", Risco = 5.0m, RetornoEsperado = 0.20m });
            Console.WriteLine("Dados de exemplo carregados.");
            System.Threading.Thread.Sleep(2000);
        }
    }

    private static int LerInteiro(string mensagem)
    {
        int numero;
        Console.Write(mensagem);
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Entrada inválida. Por favor, digite um número inteiro: ");
        }
        return numero;
    }

    private static decimal LerDecimal(string mensagem)
    {
        decimal numero;
        Console.Write(mensagem);
        while (!decimal.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Entrada inválida. Por favor, digite um número decimal: ");
        }
        return numero;
    }
}
