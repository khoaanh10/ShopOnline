using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        
        [Required(ErrorMessage = "Vui long chọn NSX")]
        public int ProducerID { get; set; }
        [Display(Name = "Tên SP")]
        [Required(ErrorMessage = "Vui long nhap Tên SP")]
        

        
        public string ProductName { get; set; }
        [Display(Name = "Cấu hình")]
        
        public string Configuration { get; set; }
        [Display(Name = "Giá SP")]
        [Required(ErrorMessage = "Vui long nhap Giá")]
        public int? Price { get; set; }

        [Display(Name = "Giá trị % sale hiện tại")]
        



        public float Sale { get; set; }

        //[Display(Name = "% Sale")]




        //public float Sale2 { get; set; }

        //[Display(Name = "Ngày bắt đầu Sale")]
        
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



        //public DateTime SaleTimeStart { get; set; }

        //[Display(Name = "Ngày kết thúc Sale")]
        
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



        //public DateTime SaleTimeEnd { get; set; }


        public bool Status { get; set; }
        public Product()
        {
            Status = false;
            Sale = 0;
            //Sale2 = 0;
            //SaleTimeStart = DateTime.Now;
            //SaleTimeStart = DateTime.Now;
        }

        
        [Display(Name = "Hình ảnh chính")]
        public string Image { get; set; }
        [Display(Name = "Hình ảnh 2")]
        public string Image2 { get; set; }
        [Display(Name = "Hình ảnh 3")]
        public string Image3 { get; set; }
        [Display(Name = "Hình ảnh 4")]
        public string Image4 { get; set; }
        [Display(Name = "Hình ảnh 5")]
        public string Image5 { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

     




        public int View1 { get; set; }
        public int SellQuantity { get; set; }

        public bool Launch { get; set; }
        
    }
}
