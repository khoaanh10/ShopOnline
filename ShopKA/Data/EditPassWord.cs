using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class EditPassWord
    {
        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        [StringLength(600, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6-20 kí tự")]
        public string Oldpass { get; set; }
        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(600, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6-20 kí tự")]
        public string Newpass1 { get; set; }
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới")]
        [Compare("Newpass1", ErrorMessage = "Hai mật khẩu không giống nhau")]
        public string Newpass2 { get; set; }
    }
}
