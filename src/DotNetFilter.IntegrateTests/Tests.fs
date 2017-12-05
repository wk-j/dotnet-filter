module Tests

open Xunit
open System.Reflection

[<Fact>]
let shouldGetTests() = 
    let dll = "/Users/wk/Source/DotNetFilter/src/DotNetFilter.Tests/bin/Debug/netcoreapp2.0/DotNetFilter.Tests.dll"
    let asm = Assembly.LoadFile(dll)
    let info = 
        query {
            for types in asm.GetTypes() do
            for method in types.GetMethods() do
            for att in method.GetCustomAttributes() do
            where (att.GetType().Name = "FactAttribute")
            select (types.FullName, method.Name)
        }

    for t in info do
        t |> printfn "-- %A"

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Your test``() = 
    Assert.True(true)
