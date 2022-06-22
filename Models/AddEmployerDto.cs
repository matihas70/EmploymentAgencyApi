using EmploymentAgencyApi.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmploymentAgencyApi.Models
{
    public class AddEmployerDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nationality { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}
