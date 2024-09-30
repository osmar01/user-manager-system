
## CRUD de Usuários com Autenticação JWT e Senha Segura

Esta aplicação é uma API RESTful desenvolvida em C# com ASP.NET Core e Entity Framework Core, que implementa um sistema de CRUD (Create, Read, Update, Delete) para gerenciar usuários. As senhas são armazenadas de forma segura usando BCrypt, e as rotas de usuários são protegidas com autenticação via JWT (JSON Web Token).



## Funcionalidades

- Criar, ler, atualizar e deletar usuários.
- Proteção de rotas com autenticação JWT.
- Senhas armazenadas de forma segura usando hashing com BCrypt.
- BCrypt.Net (para hashing de senhas)
- JWT (JSON Web Token) (para autenticação)


## Configuração do Projeto

Pré-requisitos
- .NET SDK (versão 6.0 ou superior)
- SQLite
- Gerenciador de pacotes NuGet para as dependências
Instalação
1. Clone o repositório:

```bash
  git clone https://github.com/osmar01/user-manager-system.git
```
1. 1 Navegue até o diretório: 'C:\api-manager-user' e execute:
```bash
  dotnet restore
```
1. 2 Execute as migrations para criar o banco de dados:
```bash
  dotnet ef database update
```
1. 3 Execute o projeto:

```bash
  dotnet run
```

O servidor estará rodando em http://localhost:5297.

Acesse o Swagger em: http://localhost:5297/swagger/index.html
## Documentação da API

#### Retorna todos os itens

```http
  GET /api/User
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `int` | **Obrigatório**.  |
| `nome` | `string` | **Obrigatório**.  |
| `nome` | `string` | **Obrigatório**.  |
| `dataDeCadastro` | `DateTime` | **Obrigatório**.  |

### Autenticação JWT

Login de Usuário

Descrição: Autentica um usuário com base no email e senha e retorna um token JWT.

Body (JSON):

{
  "email": "joao@example.com",
  "senha": "senhaSegura123"
}

Resposta:
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}


#### Proteger Rotas com JWT:
- Para acessar as rotas protegidas, inclua o token JWT no cabeçalho da requisição:

Authorization: Bearer {seu_token_jwt}

### Testando a API com Swagger
O Swagger permite testar todos os endpoints da API diretamente do navegador.

Acesse o endereço do Swagger: http://localhost:5297/swagger/index.html

Veja a resposta diretamente no Swagger UI, com os detalhes da requisição e resposta HTTP.

#### Login para Obter o Token JWT:

Use o endpoint de login (POST /api/login) no Swagger para obter o token JWT.
- Utilize o login do usuario administrador:
{
  "email": "admin@jabil.com",
  "senha": "admin2024"
}

O token retornado será algo assim:
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}

#### Adicionar o Token JWT nas Requisições no Postman:

- Abra o Postman e escolha o endpoint que você deseja testar.
- No Postman, vá para a aba Authorization.
- Em Type, selecione Bearer Token.
- Cole o token JWT que você obteve no campo Token.

Testar Endpoints Protegidos:

Agora você pode enviar requisições para endpoints protegidos, como GET /api/usuarios ou GET /api/User/{id}, com o token JWT incluído no cabeçalho da requisição.
- Exemplo de requisição com o token:

GET /api/usuarios

Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR...

## Hashing de Senhas com BCrypt
As senhas dos usuários são armazenadas de forma segura no banco de dados utilizando BCrypt. O hash da senha é gerado no momento do cadastro, e durante o login, a senha fornecida é comparada com o hash armazenado.
### Stack utilizada

**Back-end:** C#

**IDE:** Microsoft Visual Studio


## Aprendizados

O que você aprendeu construindo esse projeto? Quais desafios você enfrentou e como você superou-os?

- Hashing de Senhas com BCrypt