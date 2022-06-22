using EmploymentAgencyApi.DataBase;
using EmploymentAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EmploymentAgencyApi.Services
{

    public interface IEmployerService
    {
        public int AddEmployer(AddEmployerDto dto);
        public EmployerDto GetEmployer(int id);
    }

    public class EmployerService : IEmployerService
    {
        private readonly AgencyDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployerService(AgencyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public EmployerDto GetEmployer(int id)
        {
            var employer = _dbContext.Employers
                .Include(e => e.Address)
                .FirstOrDefault(e => e.Id == id);

            if (employer == null) return null;

            var dto = _mapper.Map<EmployerDto>(employer);

            return dto;
        }

        public int AddEmployer(AddEmployerDto dto)
        {
            var emp = _dbContext.Employers.FirstOrDefault(e => e.Email == dto.Email);

            if (emp != null) return 0;

            var employer = _mapper.Map<Employer>(dto);
            
            _dbContext.Employers.Add(employer);
            _dbContext.SaveChanges();

            int id = employer.Id;

            return id;
        }

    }
}
