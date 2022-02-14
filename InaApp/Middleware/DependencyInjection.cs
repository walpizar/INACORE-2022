using AutoMapper;
using Common.Interfaces;
using Data;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaApp.Middleware
{
    public static class DependencyInjection
    {
        public static IServiceCollection addDependencies(this IServiceCollection services)
        {

            ////inyeccion para al auto mapper
            services.AddAutoMapper(typeof(Startup));


            //dependicias de servicios
            services.AddSingleton<IServices<clsClientes>, ClientesService>();
            services.AddScoped<IServices<TbCategoria>, CategoriasService>();

            //dependencias de datos
            services.AddSingleton<IData<clsClientes>, ClientesData>();
            services.AddScoped<IData<TbCategoria>, CategoriasData>();

            //retornas las inyecciones agragadas al services
            return services;

        }


    }
}
