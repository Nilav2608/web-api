


using web_api.models;

namespace web_api.Services.CharacterServices{


    public class CharacterServices : ICharacterService {
    

        private static List<Character> charactersList = new List<Character> {
              new Character(),
              new Character { Id = 1 ,Name = "Sam"},
              new Character { Id = 2,Name = "Bam"}
              //*character3///////
       };
        public List<Character> AddCharacter(Character character)
        {
            charactersList.Add(character);
            return charactersList;
        }

        public List<Character> GetAllCharacters()
        {
            return charactersList;
        }

        public Character GetCharacterById(int id)
        {
            var character =  charactersList.FirstOrDefault(c => c.Id == id);
            if(character is not null)
               return character;
            throw new Exception("Character not found");   
        }

       
    }
}