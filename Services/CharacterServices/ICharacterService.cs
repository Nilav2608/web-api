using web_api.models;

namespace web_api.Services.CharacterServices
{
    public interface ICharacterService
    {
         
         Character GetCharacterById(int id);
         List<Character> GetAllCharacters();
         List<Character> AddCharacter(Character character);
    }
}