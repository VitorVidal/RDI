using Core.Interfaces;
using Infrastructure.DateProvider;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CardContext>(opt => opt.UseInMemoryDatabase("CardDatabase"));
            services.AddScoped<IDateTimeProvider, DefaultDateTimeProvider>();
            services.AddScoped<ICardRepository, CardRepository>();          

            return services;
        }
    }
}
