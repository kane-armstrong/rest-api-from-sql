using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class ClassTests
    {
        [Fact]
        public void A_single_class_is_added_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddClass(add);
            sut.Classes.Should().Contain(add);
        }

        [Fact]
        public void Multiple_classes_are_added_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add1 = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            var add2 = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass2");
            sut.AddClass(add1);
            sut.AddClass(add2);
            sut.Classes.Should().Contain(add1);
            sut.Classes.Should().Contain(add2);
        }

        [Fact]
        public void Classes_with_the_same_name_are_added_provided_they_are_in_different_namespaces()
        {
            var sut = new ProjectBuilder().Build();
            var add1 = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            var add2 = new Class("MyNamespace.Something", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddClass(add1);
            sut.AddClass(add2);
            sut.Classes.Should().Contain(add1);
            sut.Classes.Should().Contain(add2);
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_adding_a_class_that_has_already_been_added()
        {
            var sut = new ProjectBuilder().Build();
            var add1 = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            var add2 = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddClass(add1);
            Assert.Throws<InvalidOperationException>(() => sut.AddClass(add2));
        }

        [Fact]
        public void An_argument_null_exception_is_thrown_when_adding_a_class_that_is_null()
        {
            var sut = new ProjectBuilder().Build();
            Assert.Throws<ArgumentNullException>(() => sut.AddClass(null));
        }
    }
}
