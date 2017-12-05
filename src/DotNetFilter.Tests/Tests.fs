module Tests

open System
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)


module X = 
    module Y = 
        module Z = 
            [<Fact>]
            let ``My test 2``() = 
                ()
