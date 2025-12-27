using System.ComponentModel.DataAnnotations;

namespace InternalManagementSystem.Api.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = "General";
    }
}
