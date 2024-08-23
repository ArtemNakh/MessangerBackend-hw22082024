using AutoMapper;
using MessangerBackend.Core.Models;
using MessangerBackend.DTOs;
using MessangerBackend.Requests;

namespace MessangerBackend.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserDTO>()
            /*.ForMember(dest => dest.Nickname, 
                opt => opt.MapFrom(
                    src => src.UserName))*/
            .ReverseMap();

        CreateMap<User, CreateUserRequest>().ReverseMap();
    }
}