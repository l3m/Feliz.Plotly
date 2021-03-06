namespace Fable.Plotly.Generator

module Program =
    open Fake.IO
    open Fake.IO.FileSystemOperators

    [<EntryPoint>]
    let main _ =
        let api = ApiParser.parseApi()
        let plotlyFile = __SOURCE_DIRECTORY__ @@ "../Feliz.Plotly/Plotly.fs"
        let interopFile = __SOURCE_DIRECTORY__ @@ "../Feliz.Plotly/Interop.fs"
        let customPropFile = __SOURCE_DIRECTORY__ @@ "../Feliz.Plotly/CustomProps.fs"
        let typesFile = __SOURCE_DIRECTORY__ @@ "../Feliz.Plotly/Types.fs"
        let propsDir = __SOURCE_DIRECTORY__ @@ "../Feliz.Plotly/Props"

        Shell.cleanDir propsDir

        Render.componentDocument api.GeneratorComponentApi |> File.writeString false plotlyFile

        Render.interopDocument api.GeneratorComponentApi |> File.writeString false interopFile

        Render.customPropsDocument api.GeneratorComponentApi |> File.writeString false customPropFile 

        Render.typesDocument api.GeneratorComponentApi |> File.writeString false typesFile

        api.GeneratorComponentApi
        |> Render.propsDocument true
        |> List.iter (fun (name, doc) ->
            let path = propsDir @@ (sprintf "%s.fs" (name |> String.upperFirst))
            File.writeString false path doc)

        0
