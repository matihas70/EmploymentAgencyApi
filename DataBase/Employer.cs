namespace EmploymentAgencyApi.DataBase
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int EmployerAddressId { get; set; }
        public virtual EmployerAddress Address { get; set; }

        public virtual List<Contract> Contracts { get; set; }
    }
}
