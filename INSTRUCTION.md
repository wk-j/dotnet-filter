## Test Filter

- https://github.com/dotnet/cli/blob/master/src/dotnet/commands/dotnet-test/TestCommandParser.cs

```bash
# MSBuild properties
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest /p:VSTestListTests=true
dotnet msbuild src/DotNetFilter.IntegrateTests /t:VSTest /p:VSTestTestCaseFilter=DisplayName~test

# List test
dotnet test src/DotNetFilter.IntegrateTests -t 

# Filter by display name
dotnet test src/DotNetFilter.IntegrateTests --filter DisplayName~My
dotnet test src/DotNetFilter.IntegrateTests --filter DisplayName~shouldGetTests

# Full quality name
dotnet test src/DotNetFilter.IntegrateTests --filter "FullyQualifiedName~Tests.My test"

# Nested module
dotnet test src/DotNetFilter.Tests --filter "FullyQualifiedName~Tests+X+Y+Z.My test 2"
```