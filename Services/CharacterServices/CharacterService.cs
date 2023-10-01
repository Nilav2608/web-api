using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;  // Assuming Character is defined in this namespace

namespace web_api.Services.CharacterServices
{
    public class CharacterServices : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterServices(IMapper mapper,DataContext context)
        {
            _context = context;
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
            var dbContext = await _context.Characters.ToListAsync();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = charactersList.Max(c => c.Id) + 1;
            dbContext.Add(character);
            serviceResponse.data = dbContext.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {   
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
             var dbContext = await _context.Characters.ToListAsync();
             serviceResponse.data = dbContext.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {   
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbContext = await _context.Characters.ToListAsync();
            var character = dbContext.FirstOrDefault(c => c.Id == id);
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
                 throw new Exception("character with Id "+updatedCharacter.Id+ " is not found");
              

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

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharater(int id)
        {
            
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character = charactersList.First(c => c.Id == id);

                if(character is null)
                   throw new Exception("character with Id "+id+ " is not found");
                
                charactersList.Remove(character);
                serviceResponse.data = charactersList.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
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

