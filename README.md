# MarvelApp

# Teste técnico. 

## OBJETIVO
	O objetivo deste teste é avaliar as habilidades do desenvolvedor em consumir a API da Marvel para obter informações sobre o personagem Hulk e seus quadrinhos. 
	O desenvolvedor deve seguir as diretrizes estabelecidas e demonstrar o uso correto de cache, manipulação de requisições HTTP e hashing.

## REQUISITOS

## SOBRE .NET
	Usar .net Core 8 

## PERSONAGENS
	O personagem a ser utilizado é Hulk.
	O ID do personagem para obter os quadrinhos é 1009351.

# USO DO MD5
	O desenvolvedor deve implementar o hash MD5 das chaves e timestamps conforme especificado na documentação da API da Marvel.
	O formato do hash deve ser md5(timestamp + privateKey + publicKey).

## IMPLEMENTAÇÃO DO CÓDIGO
	O código deve tem um Host.CreateDefaultBuilder(args) e implementar a classe MarvelApi, com os seguintes métodos:
		O método GetCharactersAsync deve buscar informações sobre o Hulk, utilizando o cache onde possível.
		O método GetComicsAsync deve buscar os quadrinhos usando o ID 1009351.

## USO DO CACHE
	Implemente o cache em memória para armazenar as respostas e evitar chamadas desnecessárias à API.

## DOCUMENTAÇÃO DO CÓDIGO
	O código deve ser bem documentado, explicando a lógica utilizada e como as requisições são feitas.

## CRITÉRIOS DE AVALIAÇÃO
	Funcionalidade do código.
	Clareza e organização do código.
	Uso correto do MD5 e da API da Marvel.
	Tratamento de erros.
	Qualidade da documentação.

## DEPENDÊNCIAS
	O desenvolvedor poderá utilizar os pacotes homologados pela Microsoft, sendo eles:
		Microsoft.Extensions.Caching.Memory;
		Microsoft.Extensions.DependencyInjection;
		Microsoft.Extensions.Hosting;
		System.Security.Cryptography;
		System.Text;
		System.Text.Json;

## DOCUMENTAÇÃO DAS APIs
	https://developer.marvel.com/docs#!/public