using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Voucherlog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Mã giảm giá")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "Người nhập")]
        [Required]
        public int UserID { get; set; }

    }
}
