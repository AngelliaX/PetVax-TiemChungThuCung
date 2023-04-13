using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Admin.Models
{
    public class CreateStaffAccountModel
    {
        [Required(ErrorMessage = "Hãy nhập tên đăng nhập")]
        public string username { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string password { get; set; }
        [Required(ErrorMessage = "Hãy chọn vai trò")]
        public int account_type { get; set; }
    }
}