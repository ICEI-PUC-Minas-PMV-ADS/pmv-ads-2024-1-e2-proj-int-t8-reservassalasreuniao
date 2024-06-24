# Plano de Testes de Software

## Casos de Teste

| **Caso de Teste** | **CT-01 – Login com credenciais válidas** |
|:---:|:---:|
| **Requisito Associado** | RF-001 - A aplicação deve permitir que o usuário realize o login |
| **Objetivo do Teste** | Verificar se o sistema permite o acesso com credenciais corretas |
| **Passos** | 1. Abrir aplicação<br>2. Inserir usuário e senha válidos<br>3. Clicar em 'Entrar' |
| **Critério de Êxito** | O usuário é logado no sistema e a tela principal é exibida |
|   |   |
| **Caso de Teste** | **CT-02 – Login com credenciais inválidas** |
| **Requisito Associado** | RF-001 - A aplicação deve permitir que o usuário realize o login |
| **Objetivo do Teste** | Testar a segurança do sistema em relação a acessos não autorizados |
| **Passos** | 1. Abrir aplicação<br>2. Inserir usuário e senha inválidos<br>3. Clicar em 'Entrar' |
| **Critério de Êxito** | O sistema mostra uma mensagem de erro e não permite o acesso |
|   |   |
| **Caso de Teste** | **CT-03 – Login com campos vazios** |
| **Requisito Associado** | RF-001 - A aplicação deve permitir que o usuário realize o login |
| **Objetivo do Teste** | Verificar se o sistema trata entradas vazias corretamente |
| **Passos** | 1. Abrir aplicação<br>2. Deixar campos de usuário e senha em branco<br>3. Clicar em 'Entrar' |
| **Critério de Êxito** | O sistema mostra uma mensagem de erro solicitando preenchimento dos campos |
|   |   |
| **Caso de Teste** | **CT-04 – Criar usuário administrador** |
| **Requisito Associado** | RF-002, RF-003 - A aplicação deve permitir criar diferentes tipos de usuários (administrador, comum) e que o administrador adicione novos usuários |
| **Objetivo do Teste** | Assegurar que o sistema permite criar um usuário com privilégios administrativos |
| **Passos** | 1. Logar como administrador<br>2. Acessar a seção de gestão de usuários<br>3. Criar um novo usuário com perfil de administrador |
| **Critério de Êxito** | Um novo usuário administrador é criado com sucesso no sistema |
|   |   |
| **Caso de Teste** | **CT-05 – Criar usuário comum** |
| **Requisito Associado** | RF-002, RF-003 - A aplicação deve permitir criar diferentes tipos de usuários (administrador, comum) e que o administrador adicione novos usuários |
| **Objetivo do Teste** | Confirmar que o sistema pode criar usuários com perfis comuns |
| **Passos** | 1. Logar como administrador<br>2. Acessar a seção de gestão de usuários<br>3. Criar um novo usuário com perfil comum |
| **Critério de Êxito** | Um novo usuário comum é adicionado ao sistema |
|   |   |
| **Caso de Teste** | **CT-06 – Reservar sala para data e horário específicos** |
| **Requisito Associado** | RF-008, RF-009 - A aplicação deve permitir que todos os usuários possam reservar uma sala de reunião no dia, semana ou mês e não deve permitir reserva em horário já ocupado |
| **Objetivo do Teste** | Verificar se o sistema permite a reserva de salas corretamente |
| **Passos** | 1. Logar como usuário<br>2. Acessar a seção de reservas<br>3. Escolher sala, data e horário<br>4. Confirmar a reserva |
| **Critério de Êxito** | A sala é reservada para o usuário no horário especificado sem conflitos |
|   |   |
| **Caso de Teste** | **CT-07 – Tentativa de reserva em horário ocupado** |
| **Requisito Associado** | RF-009 - A aplicação não deve permitir que um usuário reserve uma sala em um horário já ocupado |
| **Objetivo do Teste** | Testar a gestão de conflitos de reserva no sistema |
| **Passos** | 1. Logar como usuário<br>2. Tentar reservar uma sala já ocupada no mesmo horário |
| **Critério de Êxito** | O sistema impede a reserva e alerta sobre o conflito de horário |
|   |   |
| **Caso de Teste** | **CT-08 – Emitir relatório do sistema** |
| **Requisito Associado** | RF-010, RF-011, RF-012 - A aplicação deve permitir que o usuário "administrador" emita relatórios do sistema, e deve possuir relatórios de utilização da sala e dos usuários |
| **Objetivo do Teste** | Verificar se os relatórios do sistema estão sendo gerados corretamente |
| **Passos** | 1. Logar como administrador<br>2. Acessar a seção de relatórios<br>3. Solicitar um relatório geral |
| **Critério de Êxito** | O sistema gera e exibe o relatório solicitado |
|   |   |
| **Caso de Teste** | **CT-09 – Cancelar reserva** |
| **Requisito Associado** | RF-013 - A aplicação permite que o usuário cancele suas reservas |
| **Objetivo do Teste** | Confirmar se o usuário pode cancelar uma reserva existente |
| **Passos** | 1. Logar como usuário<br>2. Acessar suas reservas<br>3. Selecionar uma reserva e cancelar |
| **Critério de Êxito** | A reserva é cancelada com sucesso e não aparece mais nas reservas ativas |
