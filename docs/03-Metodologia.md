
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Esta seção descreve a organização da equipe para a execução das tarefas do projeto e as ferramentas utilizadas para a manutenção dos códigos e demais artefatos.

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `develop`: versão de desenvolvimento do software
- `feature`: versão com contendo novas funcionalidades ainda não testadas
- `hotfix`: versão do software com correção de problemas identificados

Para gerenciamento do repositório foi adotado o GitFlow como estratégia. Ele permite organizar o fluxo de trabalho de forma mais eficiente, facilitando a colaboração entre a equipe e garantindo uma abordagem estruturada para o desenvolvimento, teste e implementação de novas funcionalidades, bem como para correções de problemas identificados.

## Gerenciamento de Projeto

A equipe optou por trabalhar com Processos Ágeis, adotando o Scrum como metodologia.

### Divisão de Papéis

Desta forma, a equipe está organizada da seguinte maneira:

Scrum Master: Thais Bertini do Amaral

Product Owner: Leonardo Hideki Matsui

* Equipe de Desenvolvimento: 
  - Brendo William Rodrigues; 
  - Leonardo Hideki Matsui;
  - Raphael Diego de Oliveira L.;
  - Robert Luiz de S. Magnani;
  - Thais Bertini do Amaral.
  - Lucas Quintanilha Lacerda



### Processo

#### Tarefas
Para organização e acompanhamento das tarefas, a equipe utiliza o Github Project.

O quadro de tarefas foi estruturado com os seguintes tópicos:

- Product Backlog: Contém as histórias que serão trabalhadas
- Sprint Backlog: Esta lista representa as histórias da Sprint atual
- In Progress: Quando uma história/subtarefa do "Sprint Backlog" é iniciada, ele é movido para cá.
- In Review: Quando uma história/subtarefa do "Sprint Backlog" é finalizada e necessita de aprovação
- Done: Contém as história/subtarefas que passaram pela revisão e foram aprovadas.

<figure> 
  <img src="./img/backlog.png">
    <figcaption>Figura 1 - Github Project</figcaption>
</figure> 

### Milestones

Os milestones foram organizados para representarem as Etapas e seguirem o calendário de entregas do Projeto: Desenvolvimento de uma Aplicação Interativa

<figure> 
  <img src="./img/milestones.png">
    <figcaption>Figura 2 - Milestones</figcaption>
</figure> 

#### Artefatos

A integração entre o "project" e "repositório" tem como objetivo agilizar os processos de acompanhamento e atualização das tarefas, funcionando da seguinte maneira:
1. Assim que a tarefa é aprovada para execução, é transformada em uma "Issue", ficando disponível no repositório;
2. Quando o responsável pela tarefa finaliza, ele sobe os artefatos para um nova branch;
3. Com a nova branch disponível no repositório, é aberto o Pull Request vinculando a Issue que foi trabalhada;
4. Assim que o pull request for revisado e aprovado, a Issue é fechada e a tarefa no Github Project é movida para done de forma automática

### Ferramentas

As ferramentas utilizadas pela equipe são:
- Editor de texto/código:
  - [VsCode](https://code.visualstudio.com/)
- Ferramenta para criação de Wireframe/Protótipo e User-flow
  - [Figma](https://www.figma.com/)
- Ferramenta para criação de Diagramas
  - [Draw.io](https://app.diagrams.net/)
- Ferramenta para criação da base de dados
  - [MySQL Workbench](https://www.mysql.com/products/workbench/)
- Ferramentas de comunicação
  - [Microsoft Teams](https://www.microsoft.com/pt-br/microsoft-teams/log-in)
  - [WhatsApp](https://www.whatsapp.com/?lang=pt_BR)
- Ferramenta de versionamento de código
  - [Git](https://git-scm.com/)
- Ferramenta de repositório de código
  - [Github](https://github.com)
- Ferramenta para gestão de tarefas
  - [Github Project](https://github.com)
