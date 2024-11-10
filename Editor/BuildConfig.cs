using System;

namespace Editor
{
    public readonly struct BuildConfig
    {
        private const string EnvVersion = "VERSION";
        private const string EnvOutputPath = "OUTPUT_PATH";

        private static string GetEnvVarThrowIfInvalid(string envName)
        {
            var envValue = Environment.GetEnvironmentVariable(envName);

            if (string.IsNullOrEmpty(envValue))
            {
                throw new BuildException($"Environment variable \"{envName}\" must be set.");
            }

            return envValue;
        }

        public static BuildConfig CreateThrowIfInvalid()
            => new(
                GetEnvVarThrowIfInvalid(EnvVersion),
                GetEnvVarThrowIfInvalid(EnvOutputPath)
            );

        public string Version { get; }

        public string OutputPath { get; }

        public BuildConfig(string version, string outputPath)
        {
            Version = version;
            OutputPath = outputPath;
        }
    }
}
