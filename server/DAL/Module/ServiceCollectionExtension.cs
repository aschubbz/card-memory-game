using DAL.Repository.Abstract;
using DAL.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Module
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDALService(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGamePlayerRepository, GamePlayerRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IGameCardRepository, GameCardRepository>();
            return services;
        }
    }
}
