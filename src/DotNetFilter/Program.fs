namespace DotNetFilter 

open System.Reflection
open DotNetFilter.Dll

module Program = 

    let getTestMethods(dll) = 
        let asm = Assembly.LoadFile(dll)
        query {
            for types in asm.GetTypes() do
            for method in types.GetMethods() do
            for attribute in method.GetCustomAttributes() do
            where (attribute.GetType().Name = "FactAttribute")
            select (types, method)
        } |> Seq.toList

    let returnZero f = 
        try f(); 0
        with 
            | ex -> 
                printfn "-- error | %A" ex.Message
                printfn "-- stack | %A" ex.StackTrace
                -1

    [<EntryPoint>]
    let main argv =
        let start() = 
            if argv.Length = 1 then
                let dll = argv.[0]
                Dll.init dll

                let tests = getTestMethods dll
                for (types, method) in tests do
                    printfn "%s.%s" (types.FullName) (method.Name)
            else
                printfn "-- invalid argument"

        returnZero start