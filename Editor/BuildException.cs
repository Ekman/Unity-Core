using System;

namespace Nekman.Core.Editor
{
    public class BuildException : Exception
    {
        public BuildException(string message) : base(message)
        {
        }
    }
}
