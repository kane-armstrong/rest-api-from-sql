using CodeGenerator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Projects
{
    public class Project
    {
        private readonly List<Class> _classes = new();
        private readonly List<PackageReference> _packageReferences = new();

        /// <remarks>Defaults to Microsoft.NET.Sdk.Web</remarks>>
        public string Sdk { get; private set; }
        public string Name { get; }
        public string TargetFramework { get; }
        public IReadOnlyList<Class> Classes => _classes.AsReadOnly();
        public IReadOnlyList<PackageReference> PackageReferences => _packageReferences.AsReadOnly();
        public string Path { get; }

        public Project(string name, string targetFramework, string directoryPath)
        {
            // TODO validate name properly (project system/file system constraints)
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is invalid", nameof(name));
            }

            // TODO validate properly (known set of target frameworks, perhaps enum)
            if (string.IsNullOrEmpty(targetFramework))
            {
                throw new ArgumentException("Target framework is invalid", nameof(targetFramework));
            }

            // TODO validate properly (just format, don't check if exists)
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentException("Target framework is invalid", nameof(directoryPath));
            }

            Name = name;
            TargetFramework = targetFramework;
            Path = @$"{directoryPath}\{Name}.csproj";
            Sdk = "Microsoft.NET.Sdk.Web";
        }

        public void SetSdk(string sdk)
        {
            if (string.IsNullOrEmpty(sdk))
            {
                throw new ArgumentException("Sdk is required", nameof(sdk));
            }

            // TODO set this via ctor, maybe use something better than string
            Sdk = sdk;
        }

        public void AddClass(Class value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_classes.Any(x => x.Namespace == value.Namespace && x.ClassName == value.ClassName))
            {
                throw new InvalidOperationException("A class with the same name and namespace has already been added to the project.");
            }

            _classes.Add(value);
        }

        public void AddPackageReference(PackageReference packageReference)
        {
            if (packageReference == null)
            {
                throw new ArgumentNullException(nameof(packageReference));
            }

            if (_packageReferences.Any(x => x.Name == packageReference.Name))
            {
                throw new InvalidOperationException("The specific package has already been added");
            }

            _packageReferences.Add(packageReference);
        }

        public string Render()
        {
            return "";
        }
    }
}