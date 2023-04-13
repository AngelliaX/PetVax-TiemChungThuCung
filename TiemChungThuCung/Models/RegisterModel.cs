using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Hãy nhập tên đăng nhập")]
        public string username { set; get; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string password { set; get; }
        [Required(ErrorMessage = "Hãy xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string confirmPassword { set; get; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Hãy chấp nhận điều khoản")]
        public bool agreePolicy { set; get; }
    }
}