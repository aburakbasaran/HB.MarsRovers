using MarsRovers.Application.Services;
using MarsRovers.Contracts;
using MarsRovers.Domain.Models;
using Microsoft.Extensions.DependencyInjection;


namespace MarsRovers.Infrastructure.DI
{
    public class Installer
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();

            return services.BuildServiceProvider();
        }
    }
}
