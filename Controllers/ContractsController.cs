using Microsoft.AspNetCore.Mvc;
using EmploymentAgencyApi.Services;
using EmploymentAgencyApi.Models;

namespace EmploymentAgencyApi.Controllers
{
    [Route("api/contract")]
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;
        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("{id}")]
        public ActionResult<ContractDto> GetContract([FromRoute] int id)
        {
            var contract = _contractService.GetContract(id);

            if(contract == null) return NotFound();

            return Ok(contract);
        }

        [HttpPost("{employerId}/{companyId}")]
        public ActionResult AddContract([FromRoute] int employerId, [FromRoute] int companyId, [FromBody] AddContractDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contractService.AddContract(employerId, companyId, dto);

            if (id == 0)
            {
                return NotFound("This person doesn't exist");
            }
            else if(id == -1)
            {
                return NotFound("This company doesn't exist");
            }

            return Created($"api/contract/{id}", null);
        }
    }
}
