using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using RoslynPad.UI;

namespace RoslynPad
{
    [Export(typeof(IPlatformsFactory))]
    public class PlatformsFactory : IPlatformsFactory
    {
        public IEnumerable<ExecutionPlatform> GetExecutionPlatforms()
        {
            var platform = IntPtr.Size == 8 ? "x64" : "x86";
            var architecture = IntPtr.Size == 8 ? Architecture.X64 : Architecture.X86;

            var processExe = Process.GetCurrentProcess().MainModule.FileName;
            if (Path.GetFileNameWithoutExtension(processExe).Equals("dotnet", StringComparison.InvariantCultureIgnoreCase))
            {
                // TODO: get all versions on non-Windows platforms
                yield return new ExecutionPlatform("Core " + platform, "netcoreapp", ImmutableArray.Create(
                    new PlatformVersion("netcoreapp2.2", "Microsoft.NETCore.App", "2.2.0")),
                    architecture,
                    processExe,
                    hostArguments: string.Empty);
            }
        }
    }
}