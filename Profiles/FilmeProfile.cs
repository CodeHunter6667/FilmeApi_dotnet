﻿using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile() 
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>().ReverseMap();
            CreateMap<Filme, ReadFilmeDto>().ForMember(filmeDto => filmeDto.Sessoes,
                        opt => opt.MapFrom(filme => filme.Sessoes));
        }
    }
}
