using ProductCampaignOrder.StringCommand.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ProductCampaignOrder.StringCommand;

namespace ProductCampaignOrder
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("Press X To Exit Or Write Command");

            string command = null;
            while (command != "X")
            {
                command = Console.ReadLine();
                if (command == "X")
                {
                    break;
                }

                var stringCommandHandler = serviceProvider.GetRequiredService<IStringCommandHandler>();
                try
                {
                    var result = await stringCommandHandler.HandleAsync(command);
                    Console.WriteLine(result.ToString());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
