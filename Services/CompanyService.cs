using AutoMapper;
using EmploymentAgencyApi.DataBase;
using EmploymentAgencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgencyApi.Services
{
    public interface ICompanyService
    {
        public CompanyDto GetCompany(int id);
        public int AddCompany(AddCompanyDto dto);
    }
    public class CompanyService : ICompanyService
    {
        private readonly AgencyDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyService(AgencyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CompanyDto GetCompany(int id)
        {
            var company = _dbContext.Companies
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);

            if (company == null) return null;

            var dto = _mapper.Map<CompanyDto>(company);

            return dto;
        }

        public int AddCompany(AddCompanyDto dto)
        {
            var com = _dbContext.Companies
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Address.City == dto.City && c.Address.Street == dto.Street);

            if (com != null) return 0;

            var company = _mapper.Map<Company>(dto);

            _dbContext.Add(company);
            _dbContext.SaveChanges();

            return company.Id;
        }
    }
}
