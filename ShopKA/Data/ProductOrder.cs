using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "ID đơn hàng")]
        [Required]
        public int OrderID { get; set; }
        [Display(Name = "ID sản phẩm")]
        [Required]
        public int ColorID { get; set; }
        [Display(Name = "Tên SP")]
        [Required]
        public string PDName { get; set; }
        [Display(Name = "SL")]
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "Giá")]
        [Required]

        public int Price { get; set; }
        [Display(Name = "Hình ảnh chính")]
        public string Image { get; set; }
    }
}
