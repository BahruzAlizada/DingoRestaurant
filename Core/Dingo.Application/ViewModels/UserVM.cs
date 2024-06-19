using System.ComponentModel.DataAnnotations;

namespace Dingo.Application.ViewModels
{
	public class UserVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Bu xana boş ola bilməz")]
		public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string FullName { get; set; }
		public bool Status { get; set; }
		public string RoleName { get; set; }
	}
}
