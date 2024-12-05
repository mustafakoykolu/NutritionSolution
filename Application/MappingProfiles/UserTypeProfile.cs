using Application.Features.UserType.Commands.CreateUserType;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile() {
            CreateMap<CreateUserTypeCommand, UserType>();
        }
    }
}
