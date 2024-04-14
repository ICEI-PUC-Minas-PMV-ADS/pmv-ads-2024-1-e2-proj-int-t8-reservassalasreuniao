# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-00X - A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, CPF, senha, confirmação de senha) <br> - Aceitar os termos de uso <br> - Clicar em "Registrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |

 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)



ID do Caso de Teste 

Descrição do Teste 

Objetivo do Teste 

Passos para Execução 

Critério de Êxito 

Requisito Associado 

Descrição do Requisito 

1.1 

Login com credenciais válidas 

Verificar se o sistema permite o acesso com credenciais corretas 

1. Abrir aplicação<br>2. Inserir usuário e senha válidos<br>3. Clicar em 'Entrar' 

O usuário é logado no sistema e a tela principal é exibida 

RF-001 

A aplicação deve permitir que o usuário realize o login 

1.2 

Login com credenciais inválidas 

Testar a segurança do sistema em relação a acessos não autorizados 

1. Abrir aplicação<br>2. Inserir usuário e senha inválidos<br>3. Clicar em 'Entrar' 

O sistema mostra uma mensagem de erro e não permite o acesso 

RF-001 

A aplicação deve permitir que o usuário realize o login 

1.3 

Login com campos vazios 

Verificar se o sistema trata entradas vazias corretamente 

1. Abrir aplicação<br>2. Deixar campos de usuário e senha em branco<br>3. Clicar em 'Entrar' 

O sistema mostra uma mensagem de erro solicitando preenchimento dos campos 

RF-001 

A aplicação deve permitir que o usuário realize o login 

2.1 

Criar usuário administrador 

Assegurar que o sistema permite criar um usuário com privilégios administrativos 

1. Logar como administrador<br>2. Acessar a seção de gestão de usuários<br>3. Criar um novo usuário com perfil de administrador 

Um novo usuário administrador é criado com sucesso no sistema 

RF-002, RF-003 

A aplicação deve permitir criar diferentes tipos de usuários (administrador, comum) e que o administrador adicione novos usuários 

2.2 

Criar usuário comum 

Confirmar que o sistema pode criar usuários com perfis comuns 

1. Logar como administrador<br>2. Acessar a seção de gestão de usuários<br>3. Criar um novo usuário com perfil comum 

Um novo usuário comum é adicionado ao sistema 

RF-002, RF-003 

A aplicação deve permitir criar diferentes tipos de usuários (administrador, comum) e que o administrador adicione novos usuários 

4.1 

Reservar sala para data e horário específicos 

Verificar se o sistema permite a reserva de salas corretamente 

1. Logar como usuário<br>2. Acessar a seção de reservas<br>3. Escolher sala, data e horário<br>4. Confirmar a reserva 

A sala é reservada para o usuário no horário especificado sem conflitos 

RF-008, RF-009 

A aplicação deve permitir que todos os usuários possam reservar uma sala de reunião no dia, semana ou mês e não deve permitir reserva em horário já ocupado 

4.2 

Tentativa de reserva em horário ocupado 

Testar a gestão de conflitos de reserva no sistema 

1. Logar como usuário<br>2. Tentar reservar uma sala já ocupada no mesmo horário 

O sistema impede a reserva e alerta sobre o conflito de horário 

RF-009 

A aplicação não deve permitir que um usuário reserve uma sala em um horário já ocupado 

5.1 

Emitir relatório do sistema 

Verificar se os relatórios do sistema estão sendo gerados corretamente 

1. Logar como administrador<br>2. Acessar a seção de relatórios<br>3. Solicitar um relatório geral 

O sistema gera e exibe o relatório solicitado 

RF-010, RF-011, RF-012 

A aplicação deve permitir que o usuário "administrador" emita relatórios do sistema, e deve possuir relatórios de utilização da sala e dos usuários 

6.1 

Cancelar reserva 

Confirmar se o usuário pode cancelar uma reserva existente 

1. Logar como usuário<br>2. Acessar suas reservas<br>3. Selecionar uma reserva e cancelar 

A reserva é cancelada com sucesso e não aparece mais nas reservas ativas 

RF-013 

A aplicação permite que o usuário cancele suas reservas 

 