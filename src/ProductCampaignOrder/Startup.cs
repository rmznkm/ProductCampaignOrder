using ProductCampaignOrder.StringCommand.Handlers;
using Microsoft.Extensions.DependencyInjection;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Business.Handlers.Campaign;
using ProductCampaignOrder.Business.Handlers.Order;
using ProductCampaignOrder.Business.Handlers.Product;
using ProductCampaignOrder.Business.Handlers.Time;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.StringCommand;
using ProductCampaignOrder.Business.Command;

namespace ProductCampaignOrder
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddRepositories()
                    .AddBusinessess()
                    .AddCommands()
                    .AddCommandBuilder();
        }

        private static IServiceCollection AddCommandBuilder(this IServiceCollection serviceCollaection)
        {
            serviceCollaection.AddTransient<IStringCommandHandler, StringCommandHandler>();

            serviceCollaection.AddTransient<IStringCommandHandlerItem, CreateCampaignStringCommandHandlerItem>();
            serviceCollaection.AddTransient<IStringCommandHandlerItem, GetCampaignStringCommandHandlerItem>();

            serviceCollaection.AddTransient<IStringCommandHandlerItem, CreateOrderStringCommandHandlerItem>();

            serviceCollaection.AddTransient<IStringCommandHandlerItem, CreateProductStringCommandHandlerItem>();
            serviceCollaection.AddTransient<IStringCommandHandlerItem, GetProductStringCommandHandlerItem>();

            serviceCollaection.AddTransient<IStringCommandHandlerItem, GetTimeStringCommandHandlerItem>();
            serviceCollaection.AddTransient<IStringCommandHandlerItem, IncreaseTimeStringCommandHandlerItem>();
            serviceCollaection.AddTransient<IStringCommandHandlerItem, DecreaseTimeStringCommandHandlerItem>();

            return serviceCollaection;
        }

        private static IServiceCollection AddCommands(this IServiceCollection serviceCollaection)
        {
            serviceCollaection.AddTransient<ICommandSender, CommandSender>();

            serviceCollaection.AddTransient<ICommandRequestHandler<CreateCampaignCommandRequest, CreateCampaignCommandResponse>, CreateCampaignCommandRequestHandler>();
            serviceCollaection.AddTransient<ICommandRequestHandler<GetCampaignCommandRequest, GetCampaignCommandReponse>, GetCampaignCommandRequestHandler>();

            serviceCollaection.AddTransient<ICommandRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>, CreateOrderCommandRequestHandler>();

            serviceCollaection.AddTransient<ICommandRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>, CreateProductCommandRequestHandler>();
            serviceCollaection.AddTransient<ICommandRequestHandler<GetProductCommandRequest, GetProductCommandResponse>, GetProductCommandRequestHandler>();

            serviceCollaection.AddTransient<ICommandRequestHandler<DecreaseTimeCommandRequest, DecreaseTimeCommandResponse>, DecreaseTimeCommandRequestHandler>();
            serviceCollaection.AddTransient<ICommandRequestHandler<IncreaseTimeCommandRequest, IncreaseTimeCommandResponse>, IncreaseTimeCommandRequestHandler>();
            serviceCollaection.AddTransient<ICommandRequestHandler<GetTimeCommandRequest, GetTimeCommandResponse>, GetTimeCommandRequestHandler>();

            return serviceCollaection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollaection)
        {
            serviceCollaection.AddSingleton<ICurrentTimeProvider, CurrentTimeProvider>();
            serviceCollaection.AddSingleton<IProductRepository, ProductInMemoryRepository>();
            serviceCollaection.AddSingleton<IOrderRepository, OrderInMemoryRepository>();
            serviceCollaection.AddSingleton<ICampaignRepository, CampaignInMemoryRepository>();
            serviceCollaection.AddSingleton<ICampaignOrderRepository, CampaignOrderInMemoryRepository>();

            return serviceCollaection;
        }


        private static IServiceCollection AddBusinessess(this IServiceCollection serviceCollaection)
        {
            serviceCollaection.AddSingleton<IProductService, ProductService>();
            serviceCollaection.AddSingleton<IOrderService, OrderService>();
            serviceCollaection.AddSingleton<ICampaignService, CampaignService>();

            return serviceCollaection;
        }
    }
}