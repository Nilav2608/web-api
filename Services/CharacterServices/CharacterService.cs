using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;  // Assuming Character is defined in this namespace

namespace web_api.Services.CharacterServices
{
    public class CharacterServices : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterServices(IMapper mapper)
        {
            _mapper = mapper; 
        }
        private static List<Character> charactersList = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" },
            new Character { Id = 2, Name = "Bam" }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        { 
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = charactersList.Max(c => c.Id) + 1;
            charactersList.Add(character);
            serviceResponse.data = charactersList.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {   
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
             serviceResponse.data = charactersList.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {   
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = charactersList.FirstOrDefault(c => c.Id == id);
            serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

          try
          {  
           
              var character = charactersList.FirstOrDefault(c => c.Id == updatedCharacter.Id);

              if (character is null)
                 throw new Exception("$character with Id "+updatedCharacter.Id+ " is not found");
              

            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defence = updatedCharacter.Defence;
            character.Intellignece = updatedCharacter.Intellignece;
            character.Class = updatedCharacter.Class;

            serviceResponse.data = _mapper.Map<GetCharacterDto>(character);

            
          }
          catch (Exception ex)
          {
            
            serviceResponse.success = false;
            serviceResponse.message = ex.Message;
          }
          return serviceResponse;

        }
        
    }
}

