# REST API Generator

This is a simple, unamabitious code generation tool. It looks at the schema of a SQL database 
and generates a REST API for it, with typical CRUD endpoints that support both filtering on 
primary key and (optionally) on unique key, as additional endpoints.

Quick summary of the generated API:

* ASP.NET Core 2.1
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
* No tests

Planned:

* Generate FluentValidation validators and plug them into the MVC request pipeline with a filter to map ModelState validation errors
to an error schema

Maybes:

* Support generating an alternative API - CQRS/Mediator/ProjectTo
* Implement support for other database engines (sort of already there as the schema exploration is behind an interface and 
pluggable via builder - but makes liberal use of schema names, not all engines treat schema the same way MSSQL does)
