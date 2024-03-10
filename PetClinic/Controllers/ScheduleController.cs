using Microsoft.AspNetCore.Mvc;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("schedule")]
    public class ScheduleController : Controller
    {
        [HttpPost("register")]
        public async Task<ActionResult<int>> RegisterSchedule()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> EditSchedule(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteSchedule(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("clinic/{clinicId:int}/{month}")]
        public async Task<ActionResult<int>> GetSchedulesByClinicIdAndMonth(
            int clinicId,
            string month
        )
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<int>> GetScheduleById(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }
    }
}
