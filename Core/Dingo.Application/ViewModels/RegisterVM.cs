﻿

using System.ComponentModel.DataAnnotations;

namespace Dingo.Application.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email adresini düzgün qeyd edin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrəni düzgün daxil edin")]
        public string CheckPassword { get; set; }
        public bool IsRemember { get; set; }
    }
}
