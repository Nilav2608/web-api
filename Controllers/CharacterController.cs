

using Microsoft.AspNetCore.Mvc;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;
using web_api.Services.CharacterServices;

namespace web_api.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]//http://localhost:5080/api/Character
    public class CharacterController : ControllerBase{
      
    //    private static Character knight = new Character();
       private static List<Character> charactersList = new List<Character>{
              new Character(),
              new Character { Id = 1 ,Name = "Sam"},
              new Character { Id = 2,Name = "Bam"}
       };
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }  



        [HttpGet("GetAll")] //combining both attribute and route name as http://localhost:5080/api/Character/GetAll
        //here Task<> represents asynchronous calls
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

     

        [HttpGet("{id}")]//So here we haven't specified any routes so that it returns
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }


        //post
        [HttpPost("post")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> PostCharater(AddCharacterDto newCharacter){
           
           
           return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut("put")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCharacter){
           
            var response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.data is null)
            {
                return NotFound(response);
            }

             return Ok(response);
        }
////Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

          [HttpDelete("{id}")]//So here we haven't specified any routes so that it returns
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id){
            
            var response = await _characterService.DeleteCharater(id);

            if(response.data is null)
                return NotFound(response);

            return Ok(response);    
        }




    }
}