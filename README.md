#  My Movies API
Esse projeto trata de um exercício de Pós-Graduação Latus Sensu do curso de Arquitetura de Software Distribuído da PUC Minas. 

Trata-se de uma API Rest, utiliza CQRS pattern (Command Query Responsibility Segregation - Segregação de Responsabilidade de Comando e Consulta), com dois bancos de dados, um de leitura e outro de escrita.

:construction: Projeto em construção :construction:

## 📍 Como executar o projeto

### 🏠 local

- pré-requisitos:
    - SDK .NET7
        https://dotnet.microsoft.com/pt-br/download/dotnet/7.0
    - Redis
        https://redis.io/downloads/

```
### 🐳 docker

- pré-requisitos:
    - Docker Engine
    - Docker Compose

- Baixar a imagem do Docker Hub: 
   - docker pull 2gsilva/my-movies-api:tag-desejada

- Docker-Compose
   - baixar o repo no github
   - abra um terminal e navegue até a pasta do projeto
   - execute o comando: docker compose up 
```
## 🛠️ Construído com (tecnologias e técnicas)

* ASP.NET Web API
* .Net7
* C#
* Entity Framework Core In-Memory
* CQRS pattern
* Estratégia de cache com Redis
* Docker
* Docker-Compose
* Pipeline de build automatizado com Git Action

## Poc Azure Pipeline
