using Microsoft.AspNetCore.Mvc;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : Controller
    {
        [HttpPost("register")]
        public async Task<ActionResult<int>> RegisterAppointment()
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> EditAppointmentDetails(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteAppointment(int id)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPut("{id:int}/{vetId:int}")]
        public async Task<ActionResult<int>> ChangeAppointmentVet(int id, int vetId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPost("{id:int}/cancel")]
        public async Task<ActionResult<int>> CancelAppointment(int clinicId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }

        [HttpPost("{id:int}/status")]
        public async Task<ActionResult<int>> ChangeAppointmentStatus(int clinicId)
        {
            var newClientId = 1;
            return Ok(newClientId);
        }
    }
}
