using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class EditUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]

        public string Email { get; set; }
        
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên ")]
        public string Fullname { get; set; }
        [Display(Name = "SDT")]
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public string Birthday { get; set; }
        
    }
}
