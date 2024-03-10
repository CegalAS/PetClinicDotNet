using Microsoft.AspNetCore.Mvc;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("vet")]
    public class VetController : ControllerBase
    {
        [HttpPost("upsert")]
        public async Task<ActionResult<int>> UpsertVet()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteVet(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("{month}")]
        public async Task<ActionResult<int>> GetVetsByIdsandMonth(List<int> vetIds, string month)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("{clinicId:int}")]
        public async Task<ActionResult<int>> GetVetsByClinicId(int clinicId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetVetsBySpecialties(
            [FromQuery] List<string> specialities
        )
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPost("{vetId:int}/specialty")]
        public async Task<ActionResult<int>> AddSpecialityToVet(int id, string specialty)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }
    }
}
