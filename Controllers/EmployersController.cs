using EmploymentAgencyApi.Services;
using EmploymentAgencyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentAgencyApi.Controllers
{
    [Route("api/employer")]
    public class EmployersController : Controller
    {
        private readonly IEmployerService _employerService;
        public EmployersController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public ActionResult<string> SayHi()
        {
            return Ok("Hello user");
        }

        [HttpGet("{id}")]
        public ActionResult<EmployerDto> GetEmployer([FromRoute]int id)
        {
            var dto = _employerService.GetEmployer(id);

            if(dto == null)
            {
                return NotFound("This person don't exist");
            }

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult AddEmployer([FromBody] AddEmployerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = _employerService.AddEmployer(dto);

            if(id == 0)
            {
                return BadRequest("Person with this e-mail addres already exist");
            }
            else if (id == -1)
            {
                return BadRequest("Person with this phone number addres already exist");
            }

            return Created($"api/employer/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveEmployer([FromRoute] int id)
        {
            bool result = _employerService.RemoveEmployer(id);

            if(result) return NoContent();
            
            return NotFound();
        }

    }
}
