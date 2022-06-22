using AutoMapper;
using EmploymentAgencyApi.DataBase;
using EmploymentAgencyApi.Models;

namespace EmploymentAgencyApi
{
    public class AgencyMapperProfile : Profile
    {
        public AgencyMapperProfile()
        {
            CreateMap<AddEmployerDto, Employer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new EmployerAddress()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode,
                }))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => new DateOnly(src.BirthDate.Year, src.BirthDate.Month, src.BirthDate.Day)));

            CreateMap<Employer, EmployerDto>()
                .ForMember(dest => dest.IsAdult, opt => opt.MapFrom(src => isAdultFunction(src.Age)))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));
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
