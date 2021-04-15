using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Display(Name ="Tên màu")]
        [Required(ErrorMessage ="Bạn chưa nhập tên màu")]
        public string ColorName { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage ="Bạn chưa nhập số lượng")]
        public int Quantity { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
