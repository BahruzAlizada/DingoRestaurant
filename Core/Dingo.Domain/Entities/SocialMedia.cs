using Dingo.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dingo.Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Link { get; set; }
    }
}
