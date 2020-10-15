# Monolito Asp.NET Core MVC

Um monolito com práticas Clean Code, SOLID e cara de DDD. 

Modelo de domínio separado de modelo de apresentação. 

Interface Segragations, Handlers, Resositories, AutoMapper, Notifications, Validações de Domínio, Testes de unidade, , etc.

#### Flunt
Validações de domínio usando Notifications com [Flunt](https://github.com/andrebaltieri/flunt) Validations.

### Autenticação 
Identity Core

### Persistência 
ORM Entity Framework

### Formulários
Bootstrap

### Validação no Cliente
Além da validação de Domínio, aplicamos também validação rápida ainda no clinte, utilizando todo o poder das DataAnnotations e ModelState.


![alt text](src/Projeto/wwwroot/images/01.jpg?raw=true=250x250 "Title")

![alt text](src/Projeto/wwwroot/images/02.jpg?raw=true=250x250 "Title")

![alt text](src/Projeto/wwwroot/images/03.jpg?raw=true=250x250 "Title")

![alt text](src/Projeto/wwwroot/images/04.jpg?raw=true=250x250 "Title")



### Executar
Como estamos utilizando o Banco de Dados portátil SqLite, já populado com dados, fica muito fácil ver a aplicação funcionando com pouquíssimo esforço. Siga as orientações abaixo.

Se ainda não possui o .NET Core SDK instalado, segue o [link](https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31) de suporte a instalação.

Obs: instale a versão 3.1

Faça o download do código fonte. Navegue para dentro da pasta 'Projeto' e execute a seguinte linha de comando no terminal do windows (power shel ou cmd):

```
dotnet restore
```

O comando acima restaura os pacotes utilizados na aplicação. Basta mais um comando para ver a aplicação funcionando:

```
dotnet run
```

Abra a seguinte url:
[https://localhost:5001](https://localhost:5001) 


Acesse o painel administrativo:
Email: admin@gmail.com
Senha: 123456



