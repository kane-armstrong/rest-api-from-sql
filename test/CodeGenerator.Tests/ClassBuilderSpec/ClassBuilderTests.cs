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

            var method1 = new Method(MethodAccessibilityLevel.Public, "Task<IActionResult>", "Create",
                    @"await _context.Pets.AddAsync(pet);
await _context.SaveChangesAsync();
return Ok();");
            method1.AddArgument(new MethodArgument("Pet", "pet"));
            method1.AddModifier("async");

            var method2 = new Method(MethodAccessibilityLevel.Public, "Task<IActionResult>", "Get",
                @"var pet = await _context.Pets.FindAsync(id);
if (pet == null)
{
    return NotFound();
}
return Ok(pet);");
            method2.AddArgument(new MethodArgument("int", "id"));
            method2.AddModifier("async");

            var method3 = new Method(MethodAccessibilityLevel.Private, "Task<IActionResult>", "Feed");
            method3.AddModifier("async");
            method3.AddArgument(new MethodArgument("int", "id"));
            method3.AddArgument(new MethodArgument("FeedCommand", "command"));

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
                .WithProperty(new PropertyDefinition("string", "SomeProperty"))
                .WithProperty(new PropertyDefinition("PetsDbContext", "Context", " => _context;"))
                .UsingNamespace("MyApplication.Infrastructure.Database")
                .UsingNamespace("Microsoft.EntityFrameworkCore")
                .UsingNamespace("Microsoft.AspNetCore.Mvc")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(new FieldDefinition("PetsDbContext", "_context"))
                .WithField(new FieldDefinition("int", "_whatever", " = 42;"))
                .WithMethod(method1.Render())
                .WithMethod(method2.Render())
                .WithMethod(method3.Render())
                .Build();

            result.Should().Be(@"using MyApplication.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Controllers
{
    [Authorize]
    [SomeExceptionFilter]
    public sealed class PetsController : MyBaseController, IEmptyInterface, IAnotherEmptyInterface
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet(""{id}"")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpGet(""{id}/feed"")]
        [HttpGet(""feed/{id})]
        public async Task<IActionResult> Feed([FromRoute]int id, [FromBody]FeedCommand command)
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
