namespace EmploymentAgencyApi.DataBase
{
    public class EmployerAddress : Address
    {
        public virtual Employer Employer { get; set; }
    }
}
