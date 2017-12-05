## Test Filter

- https://github.com/dotnet/cli/blob/master/src/dotnet/commands/dotnet-test/TestCommandParser.cs

```
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest /p:VSTestListTests=true
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest /p:VSTestTestCaseFilter=DisplayName~test

dotnet test src/DotNetFilter.IntegrateTests -t 
dotnet test src/DotNetFilter.IntegrateTests --filter DisplayName~My
```