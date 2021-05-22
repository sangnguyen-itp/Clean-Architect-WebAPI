using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Queries.GetAllUsers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<GetAllUsersQuery, GetAllUsersParameter>();
            CreateMap<User, GetAllUsersViewModel>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
