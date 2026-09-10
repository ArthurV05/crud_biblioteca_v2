# crud_biblioteca_v2
Segunda versão do crud de biblioteca, aplicando melhorias arquiteturais e de processo

Regras de configuração da conexão com banco de dados:

Para configuração, a aplicação utiliza uma variável de ambiente com o seguinte formato:

Nome: BIBLIOTECA_CONNECTION_STRING

Valor: Host=localhost;Port=5432;Database=SEU_BANCO;Username=SEU_USUARIO;Password=SUA_SENHA

É necessário substituir o valor das variáveis pelas credências reais (ex: Database=biblioteca), salvar a variável de ambiente nas configurações da máquina e atualizar o processo da aplicação.

