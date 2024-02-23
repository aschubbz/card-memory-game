using AutoMapper;
using Base.Service;
using Business.Maping;
using Business.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();


            // mapping
            services.AddSingleton<Profile, GameCardMappingProfile>();


            return services;
        }
    }
}
