

using Microsoft.AspNetCore.Mvc;
using web_api.models;

namespace web_api.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]//http://localhost:5080/api/Character
    public class CharacterController : ControllerBase{
      
    //    private static Character knight = new Character();
       private static List<Character> characters = new List<Character>{
              new Character(),
              new Character { Id = 1 ,Name = "Sam"},
              new Character { Id = 2,Name = "Bam"}
       };
          
        [HttpGet("GetAll")] //combining both attribute and route name as http://localhost:5080/api/Character/GetAll
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }
 
        [HttpGet("{id}")]//So here we haven't specified any routes so that it returns
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        //post
        [HttpPost("post")]
        public ActionResult<List<Character>> PostCharater(Character newCharacter){
           characters.Add(newCharacter);
           return Ok(newCharacter);
        }
    }
}