using System.Runtime.Diagnostics;
using System.Diagnostics;

Task("Publish").Does(() => {
    DotNetCorePublish("src/DotNetFilter/DotNetFilter.fsproj", new DotNetCorePublishSettings {
        OutputDirectory = "./publish/dotnet-filter",
        Configuration = "Release"
    });
});

Task("Zip")
    .IsDependentOn("Publish")
    .Does(() => {
        Zip("publish/dotnet-filter", "publish/dotnet-filter.0.1.0.zip");
    });


var target = Argument("target", "default");
RunTarget(target);

/* 
cake build.cake -target=Zip
*/