using System.Linq;
using System.Threading.Tasks;
using Easify.Template.Client;
using Easify.Template.WebApi.IntegrationTests.Setup;
using Easify.Testing.Integration;
using FluentAssertions;
using Xunit;

namespace Easify.Template.WebApi.IntegrationTests
{
    public class SampleControllerTests : IClassFixture<IntegrationTestFixture<TestStartup>>
    {
        private readonly IntegrationTestFixture<TestStartup> _fixture;

        public SampleControllerTests(IntegrationTestFixture<TestStartup> fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_GetSampleListAsync_ReturnTheSamples_WhenTheRequestIsValid()
        {
            // Arrange
            using var pair = _fixture.CreateClientFromServer<ISampleClient>(s => { });

            // Act
            var actual = (await pair.Client.GetSampleListAsync()).ToArray();

            // Assert
            actual.Should().NotBeNull();
            actual.Should().HaveCount(2)
                .And.Contain(m => m.Name == "Sample #1")
                .And.Contain(m => m.Name == "Sample #2");
        }
    }
}
