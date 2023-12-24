using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace= "Application";
        private const string InfrastructureNamespace= "Data";
        private const string PresentationNamespace= "REST";
        private const string WebNamespace = "Web";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //arrange
            var assembly = typeof(Domain.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace, 
                PresentationNamespace, 
                WebNamespace,
            };
            
            //act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            //arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                InfrastructureNamespace,
                PresentationNamespace,
                WebNamespace,
            };

            //act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Handlers_Should_Have_DependencyOnDomain()
        {
            // Arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            // Act
            var result = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            // Assert
            Assert.True (result.IsSuccessful);
        }

        [Fact]
        public void Data_Should_Not_HaveDependencyOnOtherProjects()
        {
            //arrange
            var assembly = typeof(Data.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                PresentationNamespace,
                WebNamespace,
            };

            //act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void REST_Should_Not_HaveDependencyOnOtherProjects()
        {
            //arrange
            var assembly = typeof(REST.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
                InfrastructureNamespace,
                WebNamespace,
            };

            //act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Controllers_Should_HaveDependencyOnMediatR()
        {
            //arrange
            var assembly = typeof(REST.AssemblyReference).Assembly;


            //act
            var result = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }
    }
}
