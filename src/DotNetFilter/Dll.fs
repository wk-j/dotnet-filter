namespace DotNetFilter

open System
open System.IO
open System.Reflection

module Dll = 
    let init(dll) =
        let handler (o:Object) (args:ResolveEventArgs) :Reflection.Assembly =
            let folderPath = Path.GetDirectoryName(dll)
            let assemblyPath = Path.Combine(folderPath, (AssemblyName(args.Name)).Name + ".dll")
            let assembly = Assembly.LoadFrom(assemblyPath);
            assembly

        let currentDomain = AppDomain.CurrentDomain
        let resolve = ResolveEventHandler handler
        currentDomain.add_AssemblyResolve resolve