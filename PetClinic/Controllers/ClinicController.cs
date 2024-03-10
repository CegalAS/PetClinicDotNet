using Microsoft.AspNetCore.Mvc;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("clinic")]
    public class ClinicController : ControllerBase
    {
        [HttpPost("upsert")]
        public async Task<ActionResult<int>> UpsertClinic()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteClinic(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<int>> GetClinicsByIds(int ownerId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetClinicsBySpecialties(
            [FromQuery] List<string> specialities
        )
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("specialties")]
        public async Task<ActionResult<int>> GetSpecialities()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }
    }
}
