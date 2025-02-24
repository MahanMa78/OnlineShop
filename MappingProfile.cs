using AutoMapper;
using OnlineShop.DTOs;
using OnlineShop.Models;
namespace OnlineShop;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDTO, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
