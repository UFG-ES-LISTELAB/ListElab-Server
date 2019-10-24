# ListElab Server

## Sobre
O ListElab é um software que fornece uma solução para gestão de questões e lista de questões. Com ele é possível cadastrar questões de variados tipos e montar listas com parâmetros dinâmicos, possibilitando manter listas de questões dinâmicas e eficazes para diversas turmas.

O ListElab Server fornece uma API Rest para manter listas e questões. O usuário estando cadastrado terá condições de cadastrar, atualizar e excluir listas e questões, além de poder fornecer filtros para trazer as questões desejadas.

Esse software é uma demanda da Fábrica de Software da UFG.

## Como Usar

[Api](http://sifo.tech/api/)

[Documentação](http://sifo.tech/swagger/index.html)

#### Login

**Endpoint:** [Post] /api/usuario/login

*Body*:

```
{
  "email": "admin@ufg.br"
  "password": "123456"
}
```

#### Questão / Lista

As informações sobre as requisições podem ser adquiridas aqui:

[Documentação](http://sifo.tech/swagger/index.html)

Todas as requisições devem ter no header a tag [Authorization] que deve conter:

**Bearer Token**

## Arquitetura API

A api foi dividida em camadas utilizando a seguinte organização:

![diagrama do projetista](https://raw.githubusercontent.com/UFG-ES-LISTELAB/ListElab-Server/dev/diagramas/visaoProjetista.png)

As classes obedecem a seguinte organização:
![diagrama de classes](https://raw.githubusercontent.com/UFG-ES-LISTELAB/ListElab-Server/dev/diagramas/digramaDeClasses.jpg)

## Para rodar a api

Caso você queira baixar o código e rodá-lo em sua máquina você precisará atender os seguintes passos:

* Instalar o .NET Core 2.1
* Instalar Visual Studio 2017 ou superior
