using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Services.CharacterService;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        // private static Character knight = new Character();

        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        /*
            WeatherForecastController, we could have added an [HttpGet] attribute.
            But it’s not necessary for the CharacterController because the Web API supports naming conventions 
            and if the name of the method starts with Get...(), the API assumes that the used HTTP method is also GET. 
            Apart from that we only have one Get() method in our controller so far, 
            so the web service knows exactly what method is requested.
        */
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            //NOTE: This enables us to send specific HTTP status codes 
            // back to the client together with the actual data that was requested.
            return Ok(this.characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(this.characterService.GetCharacterById(id));
        }

        [HttpPost]
        public IActionResult AddCharacter(Character newCharacter)
        {
            return Ok(this.characterService.AddCharacter(newCharacter));
        }
    }
}