using System.ComponentModel.DataAnnotations;

namespace EmploymentAgencyApi.Models
{
    public class UpdateEmployerContactDto
    {
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}