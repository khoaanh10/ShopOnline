using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "ID người dùng")]
        [Required]
        public int UserID { get; set; }
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên ")]
        public string Fullname { get; set; }
        [Display(Name = "SDT")]
        [Required(ErrorMessage = "Vui lòng nhập tên ")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "SDT không đúng")]
        public string Phone { get; set; }
        [Display(Name = "Tỉnh/TP")]
        [Required]
        public string ProvinceID { get; set; }
        [Required]
        [Display(Name = "Quận/Huyện/Thị Trấn")]
        public string DistrictID { get; set; }
        [Required]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }
        [Required]
        [Display(Name = "Số nhà- Áp/Thôn")]
        public string Detail  { get; set; }
        
        public bool ShipStatus { get; set; }
        public bool BillStatus { get; set; }



    }
}
