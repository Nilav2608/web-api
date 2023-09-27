using AutoMapper;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;

namespace web_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                     //sourceType  //Destination type 
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}