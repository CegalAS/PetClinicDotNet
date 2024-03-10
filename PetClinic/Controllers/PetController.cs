using Microsoft.AspNetCore.Mvc;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("pet")]
    public class PetController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<int>> RegisterPet()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> EditPetDetails(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeletePet(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("owner/{ownerId:int}")]
        public async Task<ActionResult<int>> GetPetsByOwnerId(int ownerId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<int>> GetPetById(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("clinic/{ownerId:int}")]
        public async Task<ActionResult<int>> GetPetsByClinicId(int ownerId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }
    }
}
