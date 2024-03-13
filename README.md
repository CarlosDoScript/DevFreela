# Projeto ASP.NET utilizando .NET 6
Este projeto foi desenvolvido seguindo uma arquitetura limpa, utilizando ASP.NET Core com .NET 6 e incorporando as seguintes tecnologias e práticas:

- Entity Framework Core: Utilizado para mapeamento objeto-relacional (ORM) e gerenciamento de dados.
- CQRS com MediatR: Implementação do padrão CQRS (Command Query Responsibility Segregation) utilizando o framework MediatR para facilitar a separação de comandos e consultas.

- Padrão Repository: Adoção do padrão Repository para abstrair e isolar a lógica de acesso a dados.

- Validação de APIs com Fluent Validation: Utilização do Fluent Validation para garantir a validação consistente e flexível das requisições API.

- Autenticação e Autorização com JWT: Implementação de autenticação e autorização utilizando JSON Web Tokens (JWT) para garantir a segurança das APIs.

- Testes Unitários com XUnit: Desenvolvimento de testes unitários utilizando o framework XUnit para garantir a qualidade e integridade do código.

- Integração de Mensageria com RabbitMQ: Integração do RabbitMQ para comunicação assíncrona e escalável entre os componentes do sistema.

## Funcionalidades
O projeto oferece as seguintes funcionalidades:

- Cadastro, listagem, detalhes, atualização e exclusão de projetos.
- Início e finalização de projetos.
- Cadastro de comentários em projetos.
- Cadastro e detalhes de login de usuário.
- Início do desenvolvimento de autenticação de login com o Google.
