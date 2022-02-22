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


            //dependencias de servicios
            services.AddScoped<IServices<clsClientes>, ClientesService>();
            services.AddScoped<IServices<TbCategoria>, CategoriasService>();
            services.AddScoped<IPersonaService, PersonasService>();
            services.AddScoped<IServices<TbGrupo>, GruposService>();
            services.AddScoped<IServices<TbHorario>, HorariosService>();
            services.AddScoped<IServices<TbEstudiante>, EstudiantesService>();

            //dependencias de datos
            services.AddScoped<IData<clsClientes>, ClientesData>();
            services.AddScoped<IData<TbCategoria>, CategoriasData>();
            services.AddScoped<IPersonaData, PersonaData>();
            services.AddScoped<IData<TbGrupo>, GruposData>();
            services.AddScoped<IData<TbHorario>, HorariosData>();
            services.AddScoped<IData<TbEstudiante>, EstudiantesData>();

            //retornas las inyecciones agragadas al services
            return services;

        }

    }
}
