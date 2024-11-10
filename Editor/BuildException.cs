using System;


namespace Editor
{
    public class BuildException : Exception
    {
        public BuildException(string message) : base(message)
        {
        }
    }
}
