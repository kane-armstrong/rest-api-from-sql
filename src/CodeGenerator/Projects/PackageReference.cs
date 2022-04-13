using System;

namespace CodeGenerator.Projects;

public class PackageReference
{
    public string Name { get; }
    public string Version { get; }

    public PackageReference(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name is required", nameof(name));
        }

        Name = name;
    }

    public PackageReference(string name, string version)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name is required", nameof(name));
        }

        if (string.IsNullOrEmpty(version))
        {
            throw new ArgumentException("Version is required", nameof(version));
        }

        Name = name;
        Version = version;
    }
}