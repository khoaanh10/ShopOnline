using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Producer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Tên NSX")]
        [Required(ErrorMessage = "Bạn chưa nhập tên NSX")]
        public string ProducerName { get; set; }
        [Required]
        public int ProductTID { get; set; }
    }
}
