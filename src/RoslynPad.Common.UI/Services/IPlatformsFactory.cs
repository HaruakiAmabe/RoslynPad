using System.Collections.Generic;

namespace RoslynPad.UI
{
    public interface IPlatformsFactory
    {
        IEnumerable<ExecutionPlatform> GetExecutionPlatforms();
    }
}