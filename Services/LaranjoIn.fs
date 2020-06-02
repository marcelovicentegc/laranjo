namespace Services

open Models

type LaranjoIn(data: SlackData) =

    member this.run =
        match data.text.StartsWith("help") with
        | true -> "/laranjin"
        | false -> data.user_name
