using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductTSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "ID Loại SP")]
        public int ProductTID { get; set; }
        [Display(Name = "% Sale")]
        [Required(ErrorMessage = "Vui long nhập % Sale")]



        public float Sale { get; set; }

        [Display(Name = "Ngày bắt đầu Sale")]
        [Required(ErrorMessage = "Vui long nhập ngày")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



        public DateTime SaleTimeStart { get; set; }

        [Display(Name = "Ngày kết thúc Sale")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui long nhập ngày")]


        public DateTime SaleTimeEnd { get; set; }
        [Display(Name ="Banner")]
       
        public string Banner { get; set; }
        [Display(Name = "Tiêu đề")]
        
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        
        public string Content { get; set; }
    }

}
