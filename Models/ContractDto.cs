namespace EmploymentAgencyApi.Models
{
    public class ContractDto
    {
        public string ContractNumber { get; set; }
        public string Position { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public EmployerDto Employer { get; set; }
        public CompanyDto Company { get; set; }
    }
}
