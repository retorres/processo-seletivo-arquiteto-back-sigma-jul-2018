# Processo Seletivo Arquiteto de Software Back-End da Sigma/TJMT

### API GP - Gerenciador de patrimônios

------

### Conceitos aplicados

  Com as premissas impostas na problematica, foi-se entendido 3 tópicos fundamentais:

  1. **Necessidade de escalabilidade:** Visto que esta aplicação mesmo em estágio de MVP, deverá ser utilizada por todos os tribunais, ela deve ser de fácil escabilidade, por causa da quantidade de usuários ativos durante um determinado período.
  2. **Regra de negócio Complexa:** Como a tendência vista no problema é a de que se tenha muita regra de negocio, então, com isso, viu-se a necessidade de uma arquitetura que seja flexivel e também de fácil manutenção.
  3. **Diferentes níveis de programadores:** Com 2 times para dar manutenção/evolução em tal sistema, podemos dividir as atividades mais complexas como manutenção do dominio com os mais experientes e as atividades mais comuns como consultas, exposição de dados, com os menos experientes.

##### CQRS!

  Com esses 3 pontos visualizados, escolhi usar CQRS no projeto, já que com CQRS seria facilmente escalável, pois com a separação de escrita e leitura, podemos optar por escalar a leitura ou a escrita, ou então, ainda sim, usar mecanismos específicos de leituras em detrimento das tradicionais bases relacionais no futuro, em caso de necessidade.

 Com CQRS, devido a estrutura estar bem desacoplada, podemos colocar os desenvolvedores mais experientes para atuar diretamente no dominio da solução, visto que a tendência do mesmo, é ter um grande aumento de complexidade, assim os mantendo na evolução da aplicação.

------

### O projeto

  ![](https://user-images.githubusercontent.com/9832526/42257583-2576530a-7f25-11e8-87bf-3de901d5a8f1.PNG)

  - **GP.Api:** A api exposta na web. Ela será responsável por integrar todos os recursos do sistema.
  - **GP.CommandSide:** Será responsável por fazer as escritas do sistema. Nela, em um primeiro momento, conterá codigo de dominio *(Aggregates, Domain Events, DomainServices, Repositories),* infraestrutura *(comunicaçao com o database)* e aplicação *(Commands, Command Handlers e Domain Event Handlers)*, em um futuro proximo, na medida do necessário, pode-se adotar a separação deste produto em outras partes.
  - **GP.QuerySide:** Este é o projeto mais simples, neste primeiro momento (fase MVP), decidi que a base de escrita, será a mesma de leitura, para podermos fazer entregas mais rapidas neste momento, assim, podendo avaliar o MVP. No futuro, pode-se adotar sistemas de fila para materializar visões de acordo com a necessidade da aplicação.
  - **GP.UnitTest:** Neste primeiro momento será escrito somente testes de unidades do dominio. Afim de garantir que as regras solicitadas, estejam de acordo.

### Pacotes utilizados
  - **Mediatr** - Orquestrar os commands e as queries.
  - **Polly** - Lib para tratar de resiliências e tolerância a falhas.
  - **Fluent Validation** - Validar os commands antes de chegarem ao dominio.
  - **Entity Framework** - ORM para trabalhar com o dominio.
  - **Dapper** - Consultas com maior performance.
  - **IdGen** - Lib para geração de identificadores.
  - **xUnit** - Lib para testes.
  - **Moq** - Lib para simular objetos.
  - **Fluent Assertions** - Lib com linguagem mais natural para validar as saidas dos testes.

------

### Como rodar a aplicação?

Instale o Docker, clone o projeto e se estiver utilizando windows, clone na pasta do seu usuário do windows (por causa do docker) e então, abra uma linha de comando nesse diretorio e digite:

`docker-compose build && docker-compose up`

A aplicação estará exposta no endereço: `http://localhost:5000/swagger`

### Apis Expostas

#### Marcas:
| Verbo     | Url      | Descrição      |
| ---: | ---- | ---- |
|GET    | */marcas* | Carrega as marcas de acordo com filtros especificados |
| GET | */marcas/{marcaId}* | Obtem uma marca especifica |
| POST | */marcas* | Cria uma nova marca |
| PUT | */marcas/{marcaId}/renomear* | Renomeia uma marca já criada |
| DELETE | */marcas/{marcaId}* | Exclui uma marca |

#### 	Modelo:
|  Verbo | Url                                 | Descrição                      |
| -----: | ----------------------------------- | ------------------------------ |
|    GET | */modelos*                          | Carrega os modelos com filtros |
|    GET | */modelos/{marcaId}*                | Obtem um modelo especifico     |
|   POST | */modelos*                          | Cria um novo Modelo            |
|    PUT | */modelos/{modeloId}/renomear*      | Renomeia um modelo             |
|    PUT | */modelos/{modeloId}/alterar-marca* | Altera a marca de um modelo    |
| DELETE | */modelos/{modeloId}*               | Exclui um modelo               |

#### 	Patrimonio:
|  Verbo | Url                          | Descrição                          |
| -----: | ---------------------------- | ---------------------------------- |
|    GET | */patrimonios*               | Carrega os patrimonios com filtros |
|    GET | */patrimonios/{tomboNumero}* | Obtem um patrimonio especifico     |
|   POST | */patrimonios*               | Cria um novo patrimonios           |
|    PUT | */patrimonios/{tomboNumero}* | Altera dados de um patrimonio      |
| DELETE | */patrimonios/{tomboNumero}* | Exclui um patrimonio               |

------

### Referências de estudo

- *[CQRS and REST: the perfect match](https://lostechies.com/jimmybogard/2016/06/01/cqrs-and-rest-the-perfect-match/)*

- *[CQRS Journey](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/jj554200%28v%3Dpandp.10%29)*

- *[Tackling Business Complexity in a Microservice with DDD and CQRS Patterns](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/)*

- *[eShopOnContainers ](https://github.com/dotnet-architecture/eShopOnContainers)*

  
