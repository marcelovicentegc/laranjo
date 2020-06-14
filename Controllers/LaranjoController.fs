namespace FSharpWebApi.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Models
open Services

[<ApiController>]
[<Route("[controller]")>]
type Laranjo(logger: ILogger<Laranjo>) =
    inherit ControllerBase()

    [<HttpPost>]
    member __.Post([<FromForm>] data: SlackData): string =
        logger.LogInformation(data.user_name)

        match data.command with
        | txt when txt.EndsWith("laranjo_config") -> LaranjoConfig(data).run
        | txt when txt.EndsWith("laranjo_init") -> LaranjoInit(data).run
        | txt when txt.EndsWith("laranjin") -> LaranjoIn(data).run
        | txt when txt.EndsWith("laranjout") -> LaranjoOut(data).run
        | __ -> "Comando não reconhecido"


    [<HttpGet>]
    member __.Get(): string =
        let commands =
            " { commands: [ \"laranjo_config\", \"laranjo_init\", \"laranjin\", \"laranjout\"] }"

        logger.LogInformation(commands)
        commands
