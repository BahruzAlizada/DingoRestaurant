using Dingo.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dingo.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
