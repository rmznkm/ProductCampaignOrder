using FluentAssertions;
using Moq;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.TestHelper;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductCampaignOrder.Tests.CommandManager
{
    public class FooResponse { }
    public class FooRequest : ICommandRequest<FooResponse> { }

    public class FooRequestHandler : ICommandRequestHandler<FooRequest, FooResponse>
    {
        public Task<FooResponse> HandleAsync(FooRequest request)
        {
            return Task.FromResult(new FooResponse());
        }
    }

    public class CommandSenderTests : TestsFor<CommandSender>
    {
      
        [Fact]
        public async Task SendAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.SendAsync<string>(null));
        }

        [Fact]
        public async Task SendAsync_IfNotRegistered_ThrowsInvalidOperationException()
        {
            var requestMock = new Mock<ICommandRequest<string>>();
            await Assert.ThrowsAsync<InvalidOperationException>(() => Instance.SendAsync(requestMock.Object));
        }

        [Fact]
        public async Task SendAsync_IfRegistered_CallHandler()
        {
            GetMockFor<IServiceProvider>()
                .Setup(x => x.GetService(typeof(ICommandRequestHandler<FooRequest, FooResponse>)))
                .Returns(new FooRequestHandler());
            
            var result= await Instance.SendAsync(new FooRequest());

            result.Should().BeOfType<FooResponse>();
        }
    }
}
