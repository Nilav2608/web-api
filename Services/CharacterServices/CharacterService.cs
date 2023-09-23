using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;  // Assuming Character is defined in this namespace

namespace web_api.Services.CharacterServices
{
    public class CharacterServices : ICharacterService
    {
        private static List<Character> charactersList = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" },
            new Character { Id = 2, Name = "Bam" }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        { 
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            charactersList.Add(newCharacter);
            serviceResponse.data = charactersList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {   
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
             serviceResponse.data = charactersList;
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {   
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = charactersList.FirstOrDefault(c => c.Id == id);
            serviceResponse.data = character;
            return serviceResponse;
            
        }
    }
}
