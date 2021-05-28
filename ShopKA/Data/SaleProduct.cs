using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class SaleProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "ID SP")]
        public int ProductID { get; set; }
        [Display(Name = "% Sale")]
        [Required(ErrorMessage ="Vui long nhập % Sale")]



        public float Sale { get; set; }
        [Required(ErrorMessage = "Vui long nhập ngày")]
        [Display(Name = "Ngày bắt đầu Sale")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



        public DateTime SaleTimeStart { get; set; }

        [Display(Name = "Ngày kết thúc Sale")]
        [Required(ErrorMessage = "Vui long nhập ngày")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



        public DateTime SaleTimeEnd { get; set; }
    }
}
