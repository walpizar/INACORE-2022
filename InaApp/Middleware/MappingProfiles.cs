using AutoMapper;
using Entities;
using InaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaApp.Middleware
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ClientesVM, clsClientes>();
            CreateMap<clsClientes, ClientesVM>();


            CreateMap<TbEstudiante, EstudiantesVM>();
            CreateMap<EstudiantesVM, TbEstudiante>();

            CreateMap<TbPersona, PersonasVM>();
            CreateMap<PersonasVM, TbPersona>();


            CreateMap<TbCategoria, CategoriasVM>();
            CreateMap<CategoriasVM, TbCategoria>();

            CreateMap<TbGrupo, GrupoVM>();
            CreateMap<GrupoVM, TbGrupo>();

            CreateMap<TbHorario, HorariosVM>();
            CreateMap<HorariosVM, TbHorario>();


        }
    }
}
