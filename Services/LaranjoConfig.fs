namespace Services

open Models

type LaranjoConfig(data: SlackData) =

    member this.run =
        match data.text.StartsWith("help") with
        | true -> "/laranjo_config 1234 Olá Tchau [#credteam, #orangino]"
        | false -> data.user_name
