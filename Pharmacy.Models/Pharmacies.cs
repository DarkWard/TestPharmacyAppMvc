using Pharmacy.Models.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    [TableName("Pharmacies")]
    public class Pharmacies
    {
        [Key]
        [Identity]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("State Code")]
        public string StateCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }

        [Required]
        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }
    }
}