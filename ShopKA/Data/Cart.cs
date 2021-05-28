using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Cart
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ColorID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Status { get; set; }
        public bool checkSTT { get; set; }
        

        public Cart()
        {
            Status = true;
            checkSTT = true;
        }
        


    }
}
