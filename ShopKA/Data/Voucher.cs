using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Voucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]

        public int ID { get; set; }
        [Display(Name = "Mã giảm giá")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "Loại giảm giá")]
        [Required]
        public bool Type { get; set; }
        [Display(Name = "% giảm giá đơn hàng")]
        [Required]
        public float OrderSale { get; set; }
        [Display(Name = "% giảm giá ship")]
        [Required]
        public float ShipSale { get; set; }
        [Display(Name = "Điều kiện theo giá đơn hàng >=")]
        [Required]
        
        public int PriceOrderCondition { get; set; }
        [Display(Name = "Điều kiện theo SL sản phẩm >=")]
        [Required]
        public int QuantityCondition { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [Required]
        public DateTime Start { get; set; }
        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage ="Vui lòng nhập ngày")]
        public DateTime End { get; set; }
        [Display(Name = "Trạng thái")]
        [Required]
        public bool Status { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Tối đa")]
        [Required(ErrorMessage = "Vui lòng nhập tối đa")]
        public int Maximum { get; set; }
        public Voucher()
        {
            Status = true;
        }

    }
}
