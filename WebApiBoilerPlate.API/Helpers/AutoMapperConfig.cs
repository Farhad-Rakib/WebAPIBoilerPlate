using AutoMapper;
using WebApiBoilerPlate.API.DTOs.Responses;
using WebApiBoilerPlate.API.Entities;

namespace WebApiBoilerPlate.API.Helpers;
public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<UserRegisterRequest, User>();
            config.CreateMap<User, UserAuthenticateResponse>();
          
        });

        return mappingConfig;
    }

}

