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

        [HttpPost]
        public ActionResult AddCompany([FromBody] AddCompanyDto dto)
        {
            int id = _companyService.AddCompany(dto);

            if (id == 0) return BadRequest("Company with this address already exist");

            return Created($"ap/company/{id}", null);
        }
    }
}
