using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class ClassBuilderTests
    {
        [Fact]
        public void Formatting_and_content_are_correct_when_the_builder_is_fully_configured()
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithName("PetsController")
                .WithBaseClass("MyBaseController")
                .ImplementingInterface("IEmptyInterface")
                .ImplementingInterface("IAnotherEmptyInterface")
                .WithAttribute("[Authorize]")
                .WithAttribute("[SomeExceptionFilter]")
                .WithConstructor(@"public PetsController(PetsDbContext context, ILogger<PetsController> logger) : base(logger) 
{
    _context = context;
}")
                .WithConstructor(@"public PetsController(ILogger<PetsController> logger) : base(logger) 
{
}")
                .WithNamespace("MyApplication.Controllers")
                // TODO Fix: no control over value e.g. public string SomeProperty => _someProperty;. Maybe just dumb it down - caller builds code
                .WithProperty(new PropertyDefinition("string", "SomeProperty"))
                .WithProperty(new PropertyDefinition("PetsDbContext", "Context", " => _context;"))
                .UsingNamespace("MyApplication.Infrastructure.Database")
                .UsingNamespace("Microsoft.EntityFrameworkCore")
                .UsingNamespace("Microsoft.AspNetCore.Mvc")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(new FieldDefinition("PetsDbContext", "_context"))
                .WithField(new FieldDefinition("int", "_whatever", " = 42;"))
                .WithMethod(new MethodBuilder()
                    .WithName("Create")
                    .WithAccessibilityLevel(MethodAccessibilityLevel.Public)
                    // TODO Fix: can't annotate with attribute (e.g. [FromBody]). Maybe just dumb it down - caller builds code
                    .WithArgument(new MethodArgument("Pet", "pet"))
                    // TODO Fix: can't add "virtual", "override", "async"...
                    .WithReturnType("IActionResult")
                    .WithBody(@"await _context.Pets.AddAsync(pet);
await _context.SaveChangesAsync();
return Ok();")
                    .Build())
                .WithMethod(new MethodBuilder()
                    .WithName("Get")
                    .WithAccessibilityLevel(MethodAccessibilityLevel.Public)
                    // TODO Fix: can't annotate with attribute (e.g. [FromBody]). Maybe just dumb it down - caller builds code
                    .WithArgument(new MethodArgument("int", "id"))
                    // TODO Fix: can't add "virtual", "override", "async"...
                    .WithReturnType("IActionResult")
                    .WithBody(@"var pet = await _context.Pets.FindAsync(id);
if (pet == null)
{
    return NotFound();
}
return Ok(pet);")
                    .Build())
                .WithMethod(new MethodBuilder()
                    .WithName("Nothing")
                    .WithAccessibilityLevel(MethodAccessibilityLevel.Public)
                    .WithReturnType("void")
                    .Build())
                .Build();

            result.Should().Be(@"using MyApplication.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Controllers
{
    [Authorize]
    [SomeExceptionFilter]
    public class PetsController : MyBaseController, IEmptyInterface, IAnotherEmptyInterface
    {
        private PetsDbContext _context;
        private int _whatever = 42;

        public string SomeProperty { get; set; }
        public PetsDbContext Context  => _context;

        public PetsController(PetsDbContext context, ILogger<PetsController> logger) : base(logger) 
        {
            _context = context;
        }

        public PetsController(ILogger<PetsController> logger) : base(logger) 
        {
        }

        public IActionResult Create(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public IActionResult Get(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        public void Nothing()
        {
        }
    }
}");
        }

        [Fact]
        public void There_is_no_excess_whitespace_when_configured_without_the_optional_parts()
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithName("PetsController")
                .WithNamespace("MyApplication.Controllers")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();

            result.Should().Be(@"namespace MyApplication.Controllers
{
    public class PetsController
    {
    }
}");
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
