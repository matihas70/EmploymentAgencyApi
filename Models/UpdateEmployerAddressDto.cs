using System.ComponentModel.DataAnnotations;

namespace EmploymentAgencyApi.Models
{
    public class UpdateEmployerAddressDto
    {
        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(60)]
        public string Street { get; set; }

        [MaxLength(6)]
        public string PostalCode { get; set; }
    }
}
