using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RoslynPad
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public class ExecutionPlatform
    {
        public string Name { get; }
        public string TargetFrameworkMoniker { get; }
        public IReadOnlyList<PlatformVersion> Versions { get; }
        public bool HasVersions => Versions.Count > 0;
        internal Architecture Architecture { get; }
        internal string HostPath { get; }
        internal string HostArguments { get; }
        public bool IsDesktop { get; }
        internal bool IsCore => !IsDesktop;

        internal ExecutionPlatform(string name, string targetFrameworkMoniker, IReadOnlyList<PlatformVersion> versions, Architecture architecture, string hostPath, string hostArguments, bool isDesktop = false)
        {
            Name = name;
            TargetFrameworkMoniker = targetFrameworkMoniker;
            Versions = versions;
            Architecture = architecture;
            HostPath = hostPath;
            HostArguments = hostArguments;
            IsDesktop = isDesktop;
        }

        public override string ToString() => Name;
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public class PlatformVersion
    {
        internal PlatformVersion(string targetFrameworkMoniker, string frameworkName, string frameworkVersion)
        {
            TargetFrameworkMoniker = targetFrameworkMoniker;
            FrameworkName = frameworkName;
            FrameworkVersion = frameworkVersion;
        }

        public string TargetFrameworkMoniker { get; }
        internal string FrameworkName { get; }
        public string FrameworkVersion { get; }

        public override string ToString() => FrameworkVersion;
    }
}