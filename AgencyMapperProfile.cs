using AutoMapper;
using EmploymentAgencyApi.DataBase;
using EmploymentAgencyApi.Models;

namespace EmploymentAgencyApi
{
    public class AgencyMapperProfile : Profile
    {
        private readonly Dictionary<int, string> companySize = new Dictionary<int, string>
        {
            [1] = "very small",
            [2] = "small",
            [3] = "medium",
            [4] = "big",
            [5] = "large"
        };

        public AgencyMapperProfile()
        {
            CreateMap<AddEmployerDto, Employer>()
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => new EmployerAddress()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode,
                }))
                .ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => new DateOnly(src.BirthDate.Year, src.BirthDate.Month, src.BirthDate.Day)));

            CreateMap<Employer, EmployerDto>()
                .ForMember(dst => dst.IsAdult, opt => opt.MapFrom(src => isAdultFunction(src.Age)))
                .ForMember(dst => dst.City, opt => opt.MapFrom(src => src.Address.City));

            CreateMap<AddCompanyDto, Company>()
                .ForMember(dst => dst.Size, opt => opt.MapFrom(src => companySize[src.Size]))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => new CompanyAddress()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Company, CompanyDto>()
                .ForMember(dst => dst.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dst => dst.Street, opt => opt.MapFrom(src => src.Address.Street));

            CreateMap<AddContractDto, Contract>()
                .ForMember(dst => dst.EffectiveDate, opt => opt.MapFrom(src => new DateOnly(src.EffectiveDate.Year, src.EffectiveDate.Month, src.EffectiveDate.Day)))
                .ForMember(dst => dst.ExpireDate, opt => opt.MapFrom(src => new DateOnly(src.ExpireDate.Year, src.ExpireDate.Month, src.ExpireDate.Day)));

            CreateMap<Contract, ContractDto>()
                .ForMember(dst => dst.Employer, opt => opt.MapFrom(src => new EmployerDto()
                {
                    Name = src.Employer.Name,
                    LastName = src.Employer.LastName,
                    IsAdult = isAdultFunction(src.Employer.Age),
                    PhoneNumber = src.Employer.PhoneNumber,
                    Email = src.Employer.Email,
                    City = src.Employer.Address.City
                }))
                .ForMember(dst => dst.Company, opt => opt.MapFrom(src => new CompanyDto()
                {
                    Name = src.Company.Name,
                    Size = src.Company.Size,
                    Industry = src.Company.Industry,
                    City = src.Company.Address.City,
                    Street = src.Company.Address.Street
                }))
                .ForMember(dst => dst.EffectiveDate, opt => opt.MapFrom(src => new DateTime(src.EffectiveDate.Year, src.EffectiveDate.Month, src.EffectiveDate.Day)))
                .ForMember(dst => dst.ExpireDate, opt => opt.MapFrom(src => new DateTime(src.ExpireDate.Year, src.ExpireDate.Month, src.ExpireDate.Day)));
        }
   
        private bool isAdultFunction(int age)
        {
            if(age >= 18)
            {
                return true;
            }
            return false;
        }
    }
}
