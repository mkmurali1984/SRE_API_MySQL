using System.ComponentModel.DataAnnotations;

namespace SRE_API.Models
{
    public class PropertiesModel
    {

        [Key]
        public string? PId { get; set; }

        public string? PersonName { get; set; } = null!;

        public string? OwnershipType { get; set; } 

        public string? PersonAddress { get; set; } 

        public string? ContactNumber { get; set; } 

        public string? EmailAddress { get; set; } 

        public string? Purpose { get; set; }

        public string? PropertyType { get; set; } = null!;

        public string? PropertySubtype { get; set; } = null!;

        public string? Price { get; set; }

        public string? PropertyDescription { get; set; } 

        public string? dimensions { get; set; }

        public string? MapURL { get; set; } 

        public string? ImageFileName { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsApproved { get; set; }

    }
}
