using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }

        [Required(ErrorMessage = "Category name is required.")]
        public String? CategoryName { get; init; } = String.Empty;       
          
    }
}