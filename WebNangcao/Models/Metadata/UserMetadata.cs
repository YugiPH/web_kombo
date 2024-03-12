using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNangcao.Models.Metadata
{
    public class UserMetadata
    {
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage ="Vui lòng nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6,ErrorMessage ="Mật khẩu không được ít hơn 6 ký tự")]
        public string MatKhau { get; set; }
    }
}