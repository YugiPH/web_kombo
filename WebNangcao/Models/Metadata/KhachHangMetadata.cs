using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebNangcao.Models.Metadata
{
    public class KhachHangMetadata
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(3, ErrorMessage = "Mật khẩu không được ít hơn 3 ký tự")]
        public string Pass { get; set; }
    }
}
