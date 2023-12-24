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
            Xunit.Assert.True(result.IsSuccessful);
        }
    }
}
