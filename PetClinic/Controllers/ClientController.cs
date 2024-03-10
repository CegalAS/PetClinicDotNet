using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Dto;
using PetClinic.Model;
using PetClinic.Model.Repository.Interfaces;
using PetClinic.Validation;

namespace PetClinic.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClientValidator _clientValidator;
        private readonly IPetClinicRepository _repository;

        public ClientController(
            IMapper mapper,
            ClientValidator clientValidator,
            IPetClinicRepository petClinicRepository
        )
        {
            _mapper = mapper;
            _clientValidator = clientValidator;
            _repository = petClinicRepository;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> RegisterClient(PostClientDto clientDto)
        {
            //validation
            var errors = _clientValidator.ValidatePostClient(clientDto);
            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }
            //mapping
            var client = _mapper.Map<Client>(clientDto);
            //save to db
            _repository.InsertClient(client);
            await _repository.SaveAsync();
            return Ok(client.Id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditClientDetails(int id, BaseClientDto putClientDto)
        {
            var client = await _repository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var errors = _clientValidator.ValidatePutClient(putClientDto);
            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }
            _repository.UpdateClient(_mapper.Map<Client>(putClientDto));
            return Ok(await _repository.SaveAsync());
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<int>> DeleteClient(int id)
        {
            var client = await _repository.GetClientByIdAsync(id);
            //TODO:check if client has pets with an active appointment
            if (client == null)
            {
                return NotFound();
            }
            _repository.DeleteClient(client);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpGet("clinic/{clinicId:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetClientsByClinicId(int clinicId)
        {
            return BadRequest("Not implemented");
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetClientDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetClientById(int id)
        {
            Client client = await _repository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetClientDto>(client));
        }
    }
}
