
# Tech Challenge - Fase 1

O Tech Challenge desta fase será desenvolver um aplicativo utilizando a plataforma .NET 8 para cadastro de
contatos regionais, considerando a persistência de dados e a qualidade do software.


## Funcionalidades

- Cadastro de contatos: permitir o cadastro de novos contatos, incluindo nome, telefone e e-mail. As-
socie cada contato a um DDD correspondente à região.
- Consulta de contatos: implementar uma funcionalidade para consultar e visualizar os contatos ca-
dastrados, os quais podem ser filtrados pelo DDD da região.
- Atualização e exclusão: possibilitar a atualização e exclusão de contatos previamente cadastrados.

## Deploy

Para fazer o deploy desse projeto rode, na pasta raiz do projeto:

```bash
   docker-compose up -d --build
```

É necessário ter o docker em execução para a realização do comando.

Ao realizar o deploy execute as migrations na pasta:
- ``` Infra/Data/Domain/Cadastro/Infra.Data.Cadastro ```

Com o comando:
```bash
   dotnet ef database update
```
