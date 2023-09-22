using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
        { 
            var serviceResponse = new ServiceResponse<List<Character>>();
            charactersList.Add(character);
            serviceResponse.data = charactersList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {   
             var serviceResponse = new ServiceResponse<List<Character>>();
             serviceResponse.data = charactersList;
             return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {   
            var serviceResponse = new ServiceResponse<Character>();
            var character = charactersList.FirstOrDefault(c => c.Id == id);
            serviceResponse.data = character;
            return serviceResponse;
            
        }
    }
}
