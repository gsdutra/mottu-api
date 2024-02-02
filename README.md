<p align="center">
  <img src="./mottu_logo.png" width="200" alt="Mottu Logo" />
</p>

## Descrição

O Mottu-api é o back-end de um sistema de aluguel de motos.

## Para rodar o projeto
```
Terminal:
  dotnet restore
  dotnet build

Aplicar as migrations:
  dotnet ef database update --project MottuApi.Repository --startup-project MottuApi

Visual Studio:
Abra a solução (MottuApi.sln) e rode normalmente.
```
## Tecnologias utilizadas
O projeto foi desenvolvido com .NET 8.0, PostgreSQL e Entity framework.

## Testando as rotas
Existem dois tipos de usuários: entregadores e admins. Não é possível criar usuários admins. No entando, a migration já cria um com as seguintes credenciais:

email: admin@admin.com

senha: admin123

As rotas /Motorcycle são autenticadas e só podem ser acessadas por usuários admins.

As rotas /DeliveryPerson e /Rental também são autenticadas mas podem ser acessadas por todos os usuários.

Para acessar uma rota autenticada, basta adicionar um Header "Authorization": "Bearer [seu-token-retornado-pela-rota-de-login]"
