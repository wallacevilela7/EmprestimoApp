# 📚 Sistema de Empréstimo de Livros

Bem-vindo ao Sistema de Empréstimo de Livros, um projeto incrível desenvolvido por Wallace Vilela para amantes da leitura e entusiastas de tecnologia! 👋

Este é um projeto de estudo em ASP.NET Core que simula um ambiente de biblioteca, onde você pode gerenciar empréstimos de livros de maneira prática e eficiente.

## 💻 Configuração do Ambiente

Antes de começar, certifique-se de ter o [SDK do .NET Core](https://dotnet.microsoft.com/download) instalado na sua máquina. Isso vai garantir que você possa rodar o projeto sem problemas.

## 🛠️ Configuração do Banco de Dados

O Sistema de Empréstimo de Livros utiliza o poderoso Entity Framework Core para se comunicar com o banco de dados. Antes de executar a aplicação, você precisa configurar a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaStringDeConexaoAqui"
  },
  // ... outras configurações ...
}
```
Não se esqueça de substituir "SuaStringDeConexaoAqui" pela sua string de conexão real.

Em seguida, execute as migrações para criar o banco de dados:

```c#
dotnet ef database update
```

## ▶️ Executando o Projeto
Para ver o Sistema de Empréstimo de Livros em ação, basta rodar o seguinte comando:

```c#
dotnet run
```
A aplicação estará esperando por você em http://localhost:5206 no seu navegador.

## 🚀 Funcionalidades Principais
- Cadastro de Livros: Adicione novos livros à sua biblioteca virtual.
- Empréstimo de Livros: Registre quem está pegando emprestado e quando.
- Devolução de Livros: Marque os livros de volta à prateleira.
- Histórico de Empréstimos: Visualize todo o histórico de movimentação dos seus livros.
## 🤝 Contribuição
Este projeto é aberto para contribuições! Se você tem ideias ou melhorias, sinta-se à vontade para enviar um pull request. Todos são bem-vindos!
