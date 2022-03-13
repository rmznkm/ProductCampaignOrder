using ProductCampaignOrder.StringCommand.Handlers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Tests.StringCommand
{
    public class GetCampaignStringCommandHandlerItemTests : TestsFor<GetCampaignStringCommandHandlerItem>
    {
        [Fact]
        public void CanHandle_Ifget_campaign_info_ReturnsTrue()
        {
            var result = Instance.CanHandle("get_campaign_info");
            result.Should().BeTrue();
        }

        [Fact]
        public void CanHandle_IfNotget_campaign_info_ReturnsFalse()
        {
            var result = Instance.CanHandle("");
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HandleAsync_IfParameterIsNull_ThrowsException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfParameterIsNotValid_ThrowsException()
        {
            await Assert.ThrowsAsync<Exception>(() => Instance.HandleAsync(new List<string>()));
        }

        [Fact]
        public async Task HandleAsync_IfParameterIsValid_CallCommandSender()
        {
            var commands = new List<string> { "C1" };
            await Instance.HandleAsync(commands);

            GetMockFor<ICommandSender>().Verify(x => x.SendAsync(It.IsAny<GetCampaignCommandRequest>()));
        }
    }
}
