using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Tên đănng nhập từ 5-20 kí tự")]
        public string Username { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(600,MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6-20 kí tự")]
        public string Password1 { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("Password1",ErrorMessage ="Hai mật khẩu không giống nhau")]
        public string Password2 { get; set; }
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên ")]
        public string Fullname { get; set; }
        [Display(Name = "SDT")]
        public string Phone { get; set; }

        public string Birthday { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        public bool Status { get; set; }
        public User()
        {
            Status = true;
            Permission = 2;
        }

        public bool Gender { get; set; }

        public int Permission { get; set; }

    }
}
