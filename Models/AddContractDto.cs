using System.ComponentModel.DataAnnotations;

namespace EmploymentAgencyApi.Models
{
    public class AddContractDto
    {
        [Required]
        [MaxLength(10)]
        public string ContractNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public int EmployerId { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
