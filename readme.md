# 💼 InvestmentAdvisor

Este é um projeto de **consultor de investimentos simples**, desenvolvido em **C#**, que demonstra a **arquitetura de software em camadas**.  
A aplicação gerencia **clientes e ativos financeiros**, além de **gerar recomendações de investimento** com base no perfil de risco de cada cliente.

---

## 📂 Estrutura do Projeto

```bash
InvestmentAdvisor/
├── Data/                       # Camada de persistência de dados
│   └── ApplicationDbContext.cs
├── Models/                     # Modelos de dados
│   ├── Ativo.cs
│   ├── Cliente.cs
│   └── Recomendacao.cs
├── Services/                   # Lógica de negócio
│   ├── AtivoService.cs
│   ├── ClienteService.cs
│   └── RecomendacaoService.cs
├── Utils/                      # Funções auxiliares
│   └── FileHandler.cs
│
├── InvestmentAdvisor.sln       # Arquivo de solução (Visual Studio)
├── InvestmentAdvisor.csproj    # Arquivo de projeto C#
├── Program.cs                  # Ponto de entrada da aplicação
└── README.md                   # Documentação do projeto
```
---

## 🏗️ Camadas e Funcionalidades

### 🔹 Models
Contém as entidades principais do sistema:
- 👤 **Cliente.cs** → Representa um cliente, com nome e perfil de risco.  
- 💹 **Ativo.cs** → Define um ativo financeiro com risco e retorno esperado.  
- 📊 **Recomendacao.cs** → Estrutura que armazena recomendações de investimento.

### 🔹 Services
Lida com a **lógica de negócio**:
- 👤 **ClienteService.cs** → Operações CRUD para clientes.  
- 💹 **AtivoService.cs** → Operações CRUD para ativos financeiros.  
- 📊 **RecomendacaoService.cs** → Gera recomendações com base no perfil do cliente.

### 🔹 Data
Gerencia a **persistência dos dados**:
- 💾 **ApplicationDbContext.cs** → Simula um banco de dados.  
  (Em projetos reais, pode ser configurado com **Entity Framework Core** + **SQL Server/SQLite**).

### 🔹 Utils
Contém utilitários de suporte:
- 🛠️ **FileHandler.cs** → Lida com persistência simples em arquivos JSON.

### 🔹 Program.cs
▶️ O **ponto de entrada** da aplicação:  
Inicializa os serviços, popula com dados de exemplo e demonstra a geração de recomendações.

---

## 🖼️ Diagrama da Arquitetura

https://www.mermaidchart.com/app/projects/1b83602b-fe83-4fc5-a840-9b5abf8e44b0/diagrams/ae4dc510-9efa-44b4-974a-6f16b5d8228c/share/invite/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkb2N1bWVudElEIjoiYWU0ZGM1MTAtOWVmYS00NGI0LTk3NGEtNmYxNmI1ZDgyMjhjIiwiYWNjZXNzIjoiVmlldyIsImlhdCI6MTc1ODQwNjQ2N30.Uxx9Eu2Bg3udHFe-6XbSsZ1oJ_qqdnQ9H_LnPouxB2Y

---

## 🚀 Começando

Siga as instruções abaixo para executar o projeto em seu ambiente local.

### Pré-requisitos

* [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior instalado.

### Instalação e Execução

1.  Clone o repositório:
    ```bash
    git clone [https://github.com/seu-usuario/InvestmentAdvisor.git](https://github.com/seu-usuario/InvestmentAdvisor.git)
    ```

2.  Acesse a pasta do projeto:
    ```bash
    cd InvestmentAdvisor
    ```

3.  Compile e execute a aplicação:
    ```bash
    dotnet run
    ```
O console exibirá as recomendações de investimento geradas para os clientes de exemplo.

---

## 📝 Próximos Passos

Este projeto é um ponto de partida didático. Algumas melhorias possíveis incluem:

-   [ ] Implementar persistência real com **Entity Framework Core** e um banco de dados (SQLite, SQL Server).
-   [ ] Desenvolver uma interface de usuário (Web API, Aplicação Desktop ou Web).
-   [ ] Adicionar mais perfis de risco e diversificar os tipos de ativos.
-   [ ] Criar testes unitários para a camada de serviços.

## 👩‍💻 Autoria

Projeto desenvolvido como um exemplo prático de arquitetura em camadas em C#.

Feito por:
- Julia Amorim     RM99609
- Lana Leite       RM551143
- Matheus Cavasini RM97722
