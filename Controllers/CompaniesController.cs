using Microsoft.AspNetCore.Mvc;
using EmploymentAgencyApi.Services;
using EmploymentAgencyApi.Models;

namespace EmploymentAgencyApi.Controllers
{
    [Route("api/company")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDto> GetCompany([FromRoute] int id)
        {
            var dto = _companyService.GetCompany(id);

            if (dto == null) return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult AddCompany([FromBody] AddCompanyDto dto)
        {
            int id = _companyService.AddCompany(dto);

            if (id == 0) return BadRequest("Company with this address already exist");

            return Created($"ap/company/{id}", null);
        }
    }
}
