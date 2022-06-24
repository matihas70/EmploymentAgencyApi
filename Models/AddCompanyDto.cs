using System.ComponentModel.DataAnnotations;

namespace EmploymentAgencyApi.Models
{
    public class AddCompanyDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int Size { get; set; }
        public string Industry { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(60)]
        public string Street { get; set; }

        [Required]
        [MaxLength(6)]
        public string PostalCode { get; set; }
    }
}
