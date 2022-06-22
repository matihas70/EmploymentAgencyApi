namespace EmploymentAgencyApi.DataBase
{
    public class CompanyAddress : Address
    {
        public virtual Company Company { get; set; }
        
    }
}
