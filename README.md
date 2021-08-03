# REST API Generator

This is a simple, unambitious code generation tool. It looks at the schema of a SQL database 
and generates a REST API for it, with typical CRUD endpoints that support both filtering on 
primary key and (optionally) on unique key, as additional endpoints.

See the samples folder for an example of how to call the executable and the output of a successful invocation.

Example PowerShell invocation:

```
.\apigen.exe `
-c "Server=localhost;Initial Catalog=Chinook;Persist Security Info=False;Integrated Security=true;" `
-s "ChinookApi" `
-d "c:\temp\generated code\Chinook" `
-p "ChinookApi" 
```

The `apigen.exe` executable can be found in the releases page, or compiled using `dotnet build`. The executable will then be in the
`rest-api-from-sql\src\RestApiFromSqlSchema.Console\bin\Debug\net5.0` folder.

Quick summary of the generated API:

  * ASP.NET 5.0 (C#)
  * Swagger support
  * Generates one class per table 
  * Generates an EntityFramework DbContext with support for both primary and composite keys
  * Generates an API controller for each entity (typical CRUD, i.e.. paginated index, get by id/unique key, create, edit, delete)
  * Maps schema/table name to namespace/type name, e.g. HumanResources.Shift becomes `namespace HumanResources { public class Shift { ... } }`
  * Always includes both schema and table name when naming or referencing things (to avoid ambiguity errors)
  * Modifies class/property names as necessary for syntax/conflict purposes (annotates using data annotations to keep the ORM happy)

Limitations:

  * Does not support tables without primary keys
  * Does not support generating navigation properties
  * Does not support the SQL hierarchyid system data type (currently maps to string, but untested for create/edit)
  * No tests

Planned:

  * Generate FluentValidation validators and plug them into the MVC request pipeline with a filter to map ModelState validation errors to an error schema
  * Avoid IDENTITY_INSERT errors on write (e.g. separate object with the IDENTITY column removed on generated POST endpoints)

Maybes:

  * Support generating an alternative API - CQRS/Mediator/ProjectTo
  * Implement support for other database engines
  * Desktop UI for flexibility in what to generate and configuration
  * Use Roslyn instead of string templates
  * Nicer looking generated code
  * More than just REST (probably not graphql, but maybe grpc - code first? grpc first? both?)