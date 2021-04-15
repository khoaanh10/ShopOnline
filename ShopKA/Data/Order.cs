using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "ID người dùng")]
        [Required]
        public int UserID { get; set; }

        [Display(Name = "địa chỉ giao hàng")]
        [Required]
        public string ShipAddress { get; set; }
        [Display(Name = "tên người nhận")]
        [Required]
        public string ShipName { get; set; }
        [Display(Name = "SDT nhận hàng")]
        [Required]
        public string ShipPhone { get; set; }
        [Display(Name = "tên người thanh toán")]
        [Required]
        public string BillName { get; set; }
        [Display(Name = "địa chỉ thanh toán")]
        [Required]
        public string BillAddress { get; set; }
        [Display(Name = "SDT thanh toán")]
        [Required]
        public string BillPhone { get; set; }

        [Display(Name = "Trạng thái")]
        [Required]
        public int Status { get; set; }

        [Display(Name = "Hình thức thanh toán")]
        [Required]
        public int payment { get; set; }
        public DateTime CreatDate { get; set; }
        public Order()
        {
            CreatDate = DateTime.Now;
        }

    }
}
