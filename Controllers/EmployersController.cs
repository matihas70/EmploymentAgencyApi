using EmploymentAgencyApi.Services;
using EmploymentAgencyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentAgencyApi.Controllers
{
    [Route("api/employer")]
    public class EmployersController : Controller
    {
        private readonly IEmployerService _service;
        public EmployersController(IEmployerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<string> SayHi()
        {
            return Ok("Hello user");
        }

        [HttpGet("{id}")]
        public ActionResult<EmployerDto> GetEmployer([FromRoute]int id)
        {
            var employer = _service.GetEmployer(id);

            if(employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        [HttpPost("add")]
        public ActionResult AddEmployer([FromBody] AddEmployerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = _service.AddEmployer(dto);

            if(id == 0)
            {
                return BadRequest("Person with this e-mail addres already exist");
            }

            return Created($"api/employer/{id}", null);
        }
    }
}
