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
        [Display(Name ="Mã giảm giá")]
        [Required]
        public int Code { get; set; }
        [Display(Name = "% giảm giá đơn hàng")]
        [Required]
        public float OrderSale { get; set; }
        [Display(Name = "% giảm giá ship")]
        [Required]
        public float ShipSale { get; set; }
        [Display(Name = "Loại điều kiện ")]
        [Required]
        //True: điều kiện theo số lượng SP
        //False: điều kiện theo giá đơn hàng
        public bool TypeCondition { get; set; }
        [Display(Name = "Điều kiện")]
        [Required]
        public int Condition { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [Required]
        public DateTime Start { get; set; }
        [Display(Name = "Ngày kết thúc")]
        [Required]
        public DateTime End { get; set; }
        [Display(Name = "Trạng thái")]
        [Required]
        public bool Status { get; set; }
        public Voucher()
        {
            Status = true;
        }

    }
}
