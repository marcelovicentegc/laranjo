namespace Services

open Models

type LaranjoInit(data: SlackData) =

    member this.run =
        match data.text.StartsWith("help") with
        | true -> "/laranjo_init :house: Entradas e saídas {{date}}"
        | false -> data.user_name
