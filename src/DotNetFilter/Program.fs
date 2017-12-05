open System.Reflection

let getTestMethods(dll) = 
    let asm = Assembly.LoadFile(dll)
    query {
        for types in asm.GetTypes() do
        for method in types.GetMethods() do
        for attribute in method.GetCustomAttributes() do
        where (attribute.GetType().Name = "FactAttribute")
        select (types, method)
    }

let returnZero f = 
    try f(); 0
    with | _ -> -1

[<EntryPoint>]
let main argv =
    let start() = 
        if argv.Length = 1 then
            let dll = argv.[0]
            let tests = getTestMethods dll
            for (types, method) in tests do
                printfn "%s.%s" (types.FullName) (method.Name)
        else
            printfn "-- invalid argument"

    returnZero start