using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AddressDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
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
        [Required(ErrorMessage ="Vui lòng nhập Phường/Xã")]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ cụ thể")]
        [Display(Name = "Số nhà- Áp/Thôn")]
        public string Detail { get; set; }

    }
}
