using System;
using System.ComponentModel;
using Pharmacy.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    [TableName("Patients")]
    public class Patient
    {
        [Key]
        [Identity]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("State Code")]
        public string StateCode { get; set; }

        [Required]
        [DisplayName("Pharmacy Name")]
        public string PharmacyName { get; set; }

        [Required]
        [DisplayName("Pharmacy Assign Date")]
        public DateTime PharmacyAssignDate { get; set; } = DateTime.UtcNow;
    }
}