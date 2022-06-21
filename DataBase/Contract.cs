namespace EmploymentAgencyAPI.DataBase
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string Position { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly ExpireDate { get; set; }

        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
