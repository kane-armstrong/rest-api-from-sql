using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class ClassBuilderTests
    {
        [Fact]
        public void A_fully_configured_builder_produces_the_expected_output()
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithName("PetsController")
                .WithBaseClass("MyBaseController")
                .ImplementingInterface("IEmptyInterface")
                .WithAttribute("[Authorize]")
                .WithConstructor(@"
public PetsController(PetsDbContext context, ILogger<PetsController> logger) : base(logger) 
{
    _context = context;
}
")
                .WithNamespace("MyApplication.Controllers")
                // TODO Fix: no control over value e.g. public string SomeProperty => _someProperty;. Maybe just dumb it down - caller builds code
                .WithProperty(new PropertyDefinition("string", "SomeProperty"))
                .UsingNamespace("MyApplication.Infrastructure.Database")
                .UsingNamespace("Microsoft.EntityFrameworkCore")
                .UsingNamespace("Microsoft.AspNetCore.Mvc")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(new FieldDefinition("PetsDbContext", "_context"))
                .WithMethod(new MethodDefinitionBuilder()
                    .WithName("Create")
                    .WithAccessibilityLevel(MethodAccessibilityLevel.Public)
                    // TODO Fix: can't annotate with attribute (e.g. [FromBody]). Maybe just dumb it down - caller builds code
                    .WithArgument(new MethodArgument("Pet", "pet"))
                    // TODO Fix: can't add "virtual", "override", "async"...
                    .WithReturnType("IActionResult")
                    .WithBody(@"
await _context.Pets.AddAsync(pet);
await _context.SaveChangesAsync();
return Ok();
")
                    .Build())
                .Build();

            result.Should().Be(@"using MyApplication.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Controllers
{
    [Authorize]
    public class PetsController : MyBaseController, IEmptyInterface
    {
        private PetsDbContext _context;
        public string SomeProperty { get; set; }

        public PetsController(PetsDbContext context, ILogger<PetsController> logger) : base(logger)
        {
            _context = context;
        }

        public IActionResult Create(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
");
        }

        [Fact]
        public void No_error_occurs_on_build_when_only_accessibility_namespace_and_class_name_are_provided()
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithName("MyClass")
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().NotBeNullOrEmpty();
        }
    }
}
