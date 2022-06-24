using EmploymentAgencyApi.DataBase;
using AutoMapper;
using EmploymentAgencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgencyApi.Services
{
    public interface IContractService
    {
        public ContractDto GetContract(int id);
        public int AddContract(int employerId, int companyId, AddContractDto dto);
    }

    public class ContractService : IContractService
    {
        private readonly AgencyDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContractService(AgencyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ContractDto GetContract(int id)
        {
            var contract = _dbContext.Contracts
                .Include(c => c.Employer)
                .Include(c => c.Employer.Address)
                .Include(c => c.Company)
                .Include(c => c.Company.Address)
                .FirstOrDefault(c => c.Id == id);

            if (contract == null) return null;

            var dto = _mapper.Map<ContractDto>(contract);

            return dto;
        }

        public int AddContract(int employerId, int companyId, AddContractDto dto)
        {
            var employer = _dbContext.Employers.FirstOrDefault(e => e.Id == employerId);
            var company = _dbContext.Companies.FirstOrDefault(c => c.Id == companyId);

            if (employer == null) return 0;
            if (company == null) return -1;

            var contract = _mapper.Map<Contract>(dto);

            contract.EmployerId = employerId;
            contract.CompanyId = companyId;
            
            _dbContext.Add(contract);
            _dbContext.SaveChanges();

            return contract.Id;
        }
    }
}
