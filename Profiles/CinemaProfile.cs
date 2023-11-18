﻿using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>().ReverseMap();
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.Endereco, 
                        opt => opt.MapFrom(cinema => cinema.Endereco)).ForMember(cinemaDto => cinemaDto.Sessoes,
                        opt => opt.MapFrom(cinema => cinema.Sessoes));
        }
    }
}
