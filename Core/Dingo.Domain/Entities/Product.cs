using Dingo.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dingo.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Image { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public double Price { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
