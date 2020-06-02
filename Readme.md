# Laranjo


## Infra

- Levantar API em F# :heavy_check_mark:

- Levantar banco de dados

## Deploy
    - Configurar uma imagem Docker
    - Github -> Actions -> Gitlab -> Deploy Kubernetes
    - Instancia Banco de Dados
    - API CALL`s ElasticSearch

## Integrar com Tangerino
    - GET checkUser -> funcionarioid username [] Marcelo
    - POST syncPunchCard []

## Integrar com Slack
    - https://api.slack.com/methods/pins.list []
    - https://api.slack.com/methods/users.info []
    - https://api.slack.com/methods/chat.postMessage []
    - https://api.slack.com/methods/pins.add []
    - https://api.slack.com/methods/pins.list []

## Criar Endpoints
- laranjoconfig [:heavy_check_mark:] Erick
- laranjoinit [:heavy_check_mark:] Erick
- laranjin [:heavy_check_mark:] Erick
- laranjout [:heavy_check_mark:] Erick

## Engenharia

- Pegar os dados dos usuários no chat com o Laranjo
    - MELHORIA
        - https://api.slack.com/surfaces/modals
    - ID do usuário `user_id` (vem no request)
    - PIN
    - Mensagem de entrada
    - Mensagem de saída
    - Canais de publicação
    - `/laranjo_config 1234 "Olá" "Tchau" "[#credteam, #orangino]"` (alternativa fácil)
        - Mensagem de sucesso/erro/algo inesperado
            - validar Parametros
            - validar PIN
                - checkUser -> usuário tá ok/não tá ok
            - validar Nome com Match de 80% no => se somente
                - nome completo do usuário
                - https://api.slack.com/methods/users.info
            - validar Canais
                - Pegar `channel_id`
                - https://api.slack.com/methods/conversations.list
                - Verificar se alguem configurou bot neste channel

- Configuração do Laranjo nos canais
    - Permissão especial
        - https://api.slack.com/methods/users.info
        - "is_admin": true
        - "is_owner": true
        - "is_primary_owner": true
    - ID do canal `channel_id` (vem no request)
    - ID do usuário `user_id`
    - `/laranjo_init ":house: Entradas e saídas {{date}}"`
        - Salvar do Banco de Dados

- Entrada/saída
    - `/laranjin`
    - ID do usuário `user_id` (vem no request)
    - Bater ponto e validar se o usuário entrou mesmo
        - Resposta do syncPunchCard
            - NOVO_PONTO_ABERTO
    - Verificar se a Thread foi iniciada
        - https://api.slack.com/methods/pins.list
    - Thread Nova
        - Iniciar uma thread
            - https://api.slack.com/methods/chat.postMessage
        - Pina thread
            - https://api.slack.com/methods/pins.add
        - Posta na thread
            - https://api.slack.com/methods/chat.postMessage
    - Thread pre-existente
        - Posta na thread
            - https://api.slack.com/methods/chat.postMessage
    - Mapear os canais que o usuário está inscrito

- Saída
    - `/laranjout`
    - ID do usuário `user_id` (vem no request)
    - Bater ponto e validar se o usuário entrou mesmo
        - Resposta do syncPunchCard
            - ULTIMO_PONTO_FECHADO_NOVO_ABERTO
    - Verificar se a Thread foi iniciada
        - https://api.slack.com/methods/pins.list
    - Thread Nova
        - Iniciar uma thread
            - https://api.slack.com/methods/chat.postMessage
        - Pina thread
            - https://api.slack.com/methods/pins.add
        - Posta na thread
            - https://api.slack.com/methods/chat.postMessage
    - Thread pre-existente
        - Posta na thread
            - https://api.slack.com/methods/chat.postMessage
    - Mapear os canais que o usuário está inscrito