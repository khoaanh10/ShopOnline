using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Đánh giá")]
        [Required(ErrorMessage = "Không được để trống")]
        
        public string Text { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Rate { get;set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}",
               ApplyFormatInEditMode = true)]
        public DateTime CreatDate { get; set; } 
        public Review()
        {
            CreatDate = DateTime.Now;
        }

    }
}
