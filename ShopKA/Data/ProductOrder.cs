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
        [Display(Name = "ID SP")]
        [Required]
        public int ColorID { get; set; }
        [Display(Name = "SL")]
        [Required]
        public int Quantity { get; set; }
    }
}
