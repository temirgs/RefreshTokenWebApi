using AutoMapper;
using RefreshTokenWebApi.Dto;
using RefreshTokenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshTokenWebApi.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
