﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestApiFromSqlSchema.Components.Classes;
using RestApiFromSqlSchema.Components.Projects;
using RestApiFromSqlSchema.Components.Projects.Templates.Resources;
using RestApiFromSqlSchema.Components.Schema;
using RestApiFromSqlSchema.Components.Solution;
using RestApiFromSqlSchema.Components.Templates.Generators;
using RestApiFromSqlSchema.Rendering;

namespace RestApiFromSqlSchema.Builders
{
    public class SolutionBuilder
    {
        private readonly SolutionOptions _solutionOptions = new SolutionOptions();
        private readonly IList<ProjectOptions> _projectOptions = new List<ProjectOptions>();
        private const string StartupConnectionStringToken = "$connectionString$";

        public SolutionBuilder(Action<SolutionOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            options.Invoke(_solutionOptions);
        }

        public SolutionBuilder AddProject(Action<ProjectOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var projectOptions = new ProjectOptions();
            options.Invoke(projectOptions);
            _projectOptions.Add(projectOptions);
            return this;
        }

        public async Task<SolutionFile> BuildAsync()
        {
            var solution = new SolutionFile(_solutionOptions.Directory, _solutionOptions.Name);
            if (!_projectOptions.Any())
            {
                return solution;
            }

            foreach (var item in _projectOptions)
            {
                var project = await BuildProjectAsync(item).ConfigureAwait(false);
                solution.AddProject(project);
            }

            return solution;
        }

        private static async Task<ProjectFile> BuildProjectAsync(ProjectOptions item)
        {
            var project = new ProjectFile(item.Name);
            var classes = new List<Class>
            {
                new Class(project.FileName, "", TemplateContent.NetCoreWebApiCsproj)
            };
            classes.AddRange(GenerateAspNetCoreWebApiProject(item.ConnectionString));

            var tables = await item.SchemaExplorer.GetTablesAsync(CancellationToken.None);
            var tablesWithKeys = tables.Where(x => x.HasKeyColumn || x.HasCompositeKey).ToList();
            classes.AddRange(GenerateClasses(tablesWithKeys));
            classes.AddRange(GenerateApiControllers(tablesWithKeys));
            classes.Add(GenerateDbContext(tablesWithKeys));

            foreach (var @class in classes)
            {
                project.ClassFiles.Add(@class);
            }

            return project;
        }

        private static IEnumerable<Class> GenerateAspNetCoreWebApiProject(string connectionString)
        {
            return new List<Class>
            {
                new Class("launchSettings.json", "Properties", TemplateContent.NetCoreWebApiLaunchSettings),
                new Class("appSettings.json", "", TemplateContent.NetCoreWebApiAppSettings.Replace(StartupConnectionStringToken, connectionString)),
                new Class("Program.cs", "", TemplateContent.NetCoreWebApiProgram),
                new Class("Startup.cs", "", TemplateContent.NetCoreWebApiStartup)
            };
        }

        private static IEnumerable<Class> GenerateClasses(IList<Table> tables)
        {
            var fileNames = new List<string>();

            return (
                from table in tables
                let uniqueName = GenerateUniqueTableName(fileNames, table.Name.LegalCsharpName)
                let classTemplate = ClassTemplateGenerator.Generate(table, uniqueName)
                let content = ClassRenderer.Render(classTemplate)
                select new Class($"{uniqueName}.cs", $"Entities\\{table.SchemaName}", content, table)
            ).ToList();
        }

        private static IEnumerable<Class> GenerateApiControllers(IList<Table> tables)
        {
            foreach (var table in tables)
            {
                var template = ApiControllerTemplateGenerator.Generate(table);
                var content = ApiControllerRenderer.Render(template);
                yield return new Class($"{table.Name.LegalCsharpName}Controller.cs", $"Controllers\\{table.SchemaName}", content, table);
            }
        }

        private static Class GenerateDbContext(IList<Table> tables)
        {
            const string name = "ApplicationDbContext";
            var dbContextTemplate = DbContextTemplateGenerator.Generate(tables, "AutoGeneratedApi", name);
            var dbContextContent = DbContextRenderer.Render(dbContextTemplate);
            return new Class($"{name}.cs", "", dbContextContent);
        }

        private static void GenerateFluentValidators()
        {
            // todo - unique constraint checks
            // todo - string length checks
            // todo - not null checks
        }

        private static string GenerateUniqueTableName(ICollection<string> fileNames, string tableName)
        {
            var count = fileNames.Count(x => x == tableName);
            if (count == 0)
            {
                return tableName;
            }

            fileNames.Add(tableName);
            return $"{tableName}{count + 1}";
        }
    }
}