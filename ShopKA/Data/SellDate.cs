using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class SellDate
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "ID SP da ban")]
        [Required]
        public int SellPDID { get; set; }
        [Display(Name = "SL")]
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "Ngày bán")]
        [Required]
        public DateTime DateSell { get; set; }
        [Display(Name = "Tên người mua")]
        [Required]
        public string BuyName { get; set; }
        [Display(Name = "Giá")]
        [Required]

        public int Price { get; set; }
    }
}
