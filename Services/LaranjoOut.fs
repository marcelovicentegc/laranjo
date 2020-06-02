namespace Services

open Models

type LaranjoOut(data: SlackData) =

    member this.run =
        match data.text.StartsWith("help") with
        | true -> "/laranjout"
        | false -> data.user_name
