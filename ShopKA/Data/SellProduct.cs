using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class SellProduct
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "ID SP")]
        [Required]
        public int ColorID { get; set; }
        [Display(Name = "Tên SP")]
        [Required]
        public string PDName { get; set; }
        
       
        
       
    }
}
