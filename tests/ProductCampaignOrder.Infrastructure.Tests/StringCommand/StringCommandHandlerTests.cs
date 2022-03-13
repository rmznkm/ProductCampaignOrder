using ProductCampaignOrder.StringCommand;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Infrastructure.Tests.StringCommand
{
    public class StringCommandHandlerTests : TestsFor<StringCommandHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfHandlerNotFound_ThrowsException()
        {
            var handlers = new List<IStringCommandHandlerItem>();

            GetMockFor<IEnumerable<IStringCommandHandlerItem>>()
                .Setup(x => x.GetEnumerator())
                .Returns(handlers.GetEnumerator());

            await Assert.ThrowsAsync<Exception>(() => Instance.HandleAsync("command"));
        }

        [Fact]
        public async Task HandleAsync_Calls_CanHandleWithFirstArgument()
        {
            var handlerMock = new Mock<IStringCommandHandlerItem>();

            var handlers = new List<IStringCommandHandlerItem> { handlerMock.Object };

            GetMockFor<IEnumerable<IStringCommandHandlerItem>>()
                .Setup(x => x.GetEnumerator())
                .Returns(handlers.GetEnumerator());

            try
            {
                await Instance.HandleAsync("command arg1");
            }
            catch
            {
                //No need to catch
            }
            handlerMock.Verify(x => x.CanHandle("command"));
        }


        [Fact]
        public async Task HandleAsync_IfCanHandle_CallHandle()
        {
            var handlerMock = new Mock<IStringCommandHandlerItem>();
            handlerMock.Setup(x => x.CanHandle("command")).Returns(true);

            var handlers = new List<IStringCommandHandlerItem> { handlerMock.Object };

            GetMockFor<IEnumerable<IStringCommandHandlerItem>>()
                .Setup(x => x.GetEnumerator())
                .Returns(handlers.GetEnumerator());

            try
            {
                await Instance.HandleAsync("command arg1");
            }
            catch
            {
                //No need to catch
            }
            handlerMock.Verify(x => x.HandleAsync(It.IsAny<IEnumerable<string>>()));
        }
    }
}
