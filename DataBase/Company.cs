namespace EmploymentAgencyAPI.DataBase
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Industry { get; set; }

        public int CompanyAddressId { get; set; }
        public virtual CompanyAddress Address { get; set; }

        public virtual List<Contract> Contracts { get; set; }
    }
}
