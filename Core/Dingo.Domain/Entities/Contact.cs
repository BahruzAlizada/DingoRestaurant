﻿using Dingo.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dingo.Domain.Entities
{
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ünvanınızı düzgün daxil edin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string FullName { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
