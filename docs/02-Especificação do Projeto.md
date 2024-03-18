# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

DOs desafios cruciais para o projeto foram identificados através de um processo de imersão, envolvendo observação e entrevistas com os usuários em seu contexto natural. Essas informações foram sintetizadas em personas e histórias de usuário, proporcionando uma compreensão precisa das necessidades e dores dos usuários. Essa abordagem orientou a construção de um sistema mais eficaz e centrado no usuário.



## Personas

Pedro Paulo tem 26 anos, é arquiteto recém-formado e autônomo. Pensa em se desenvolver profissionalmente através de um mestrado fora do país, pois adora viajar, é solteiro e sempre quis fazer um intercâmbio. Está buscando uma agência que o ajude a encontrar universidades na Europa que aceitem alunos estrangeiros.



## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir que o usuário realize o login | ALTA | 
|RF-002| A aplicação deve permitir criar diferentes tipos de usuários (administrador, comum)   | ALTA |
|RF-003| A aplicação deve permitir que o usuário "administrador" adicione novos usuários   | ALTA |
|RF-004| A aplicação deve permitir que o usuário "administrador" delete usuários   | ALTA |
|RF-005| A aplicação deve permitir que o usuário "administrador" atualize usuários   | ALTA |
|RF-006| A aplicação deve permitir que o usuário "administrador" liste os usuários   | ALTA |
|RF-007| A aplicação deve permitir que o usuário "administrador" cadastre salas de reuniões   | ALTA |
|RF-008| A aplicação deve permitir que todos os usuários possam reversar uma sala de reunião   | ALTA |
|RF-009| A aplicação não deve permitir que um usuário reserve uma sala em um horário já ocupado   | ALTA |
|RF-010| A aplicação deve permitir que o usuário "administrador" emita relatórios do sistema   | ALTA |
|RF-011| A aplicação deve possuir um relatório de utilização da sala que deve informar a sala e quantidade de horas reservadas   | ALTA |
|RF-012| A aplicação deve possuir um relatório de utilização dos usuários que deve informar o usuário e quantidade de horas reservadas   | MÉDIA |
|RF-013| A aplicação permitir que o usuário cancele sua reserva   | MÉDIA |
|RF-014| A aplicação deve permitir que o usuário "administrador" delete salas de reuniões   | BAIXA |
|RF-015| A aplicação deve permitir que o usuário "administrador" atualize salas de reuniões   | BAIXA |
|RF-016| A aplicação deve permitir que o usuário "administrador" liste as salas de reuniões   | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | ALTA | 
|RNF-002| A aplicação deve ser acessada através de um navegador de internet |  ALTA | 
|RNF-003| A aplicação deve processar requisições do usuário em no máximo 3s |  MÉDIA | 
|RNF-004| A aplicação deve compatível com os principais navegadores de internet |  MÉDIA | 
|RNF-005| A aplicação deve compatível com os principais navegadores de internet |  BAIXA | 
|RNF-006| A aplicação deve ser segura permitindo apenas a utilização se senhas "FORTES" |  BAIXA | 


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
