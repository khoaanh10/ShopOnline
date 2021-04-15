using DataBase;
using PagedList;
using ShopKA.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Color = DataBase.Color;

namespace ShopKA.Controllers
{
    public class AdminController : Controller
    { MyDB DB = new MyDB();
        // GET: Admin
        public ActionResult Index(int page =1,int b=20)
        {
            var C = DBIO.getallProduct().OrderByDescending(i => i.ID).ToList();
            var A = DBIO.getallProduct().OrderByDescending(i => i.ID).ToPagedList(page, b);
            int B = C.Count();
            if (B % b == 0)
            { ViewBag.page = B / b; }
            else { ViewBag.page = B / b + 1; }
            ViewBag.a = page;
            
            return View(A);
        }
        //Tạo SP
        public ActionResult CreatProduct()
        {
            ViewBag.TT = DBIO.getallProductT();
            return View();
        }
        [HttpPost]
        public ActionResult CreatProduct(Product a,HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            if (ModelState.IsValid & a.ProducerID!=0)
            {
                
                MyDB b = new MyDB();
                a.Image = file1 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file1.InputStream, true, true)) : null;
                a.Image2 = file2 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file2.InputStream, true, true)) : null;
                a.Image3 = file3 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file3.InputStream, true, true)) : null;
                a.Image4 = file4 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file4.InputStream, true, true)) : null;
                a.Image5 = file5 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file5.InputStream, true, true)) : null;
                a.Sale = (a.Sale) / 100;
                b.Products.Add(a);
                b.SaveChanges();
                return RedirectToAction("Index","Admin"); }
            else
            {
                ViewBag.TT = DBIO.getallProductT();
                if (a.ProducerID==0)
                {
                   
                    ModelState.AddModelError("", "Vui lòng chọn NSX");
                }    
            
               
                return View(a);
            }
        }
        //Partial view tạo SP
        public ActionResult Creat1(int id)
        {
            if (id != -1)
            {
                ViewBag.T = DBIO.getProducer_type(id);
                return View();
            }
            else
                return View();
        }
        //Xóa SP
        public ActionResult DeleteProduct(int ID)
        {
            MyDB DB = new MyDB();
            List<Color> c = DBIO.getallColor(ID);
            foreach (var item2 in c)
            {
                Color d = DB.Colors.FirstOrDefault(x => x.ID == item2.ID);
                DB.Colors.Remove(d);
                DB.SaveChanges();
            }
            DBIO.DeleteProduct(ID);
            return RedirectToAction("Index", "Admin");
        }
        //Sủa SP
        public ActionResult EditProduct(int ID)
        {
            ViewBag.TT = DBIO.getallProductT();
            var A = DBIO.get1Product(ID);
            return View(A);
        }
        [HttpPost]

        public ActionResult EditProduct(Product a, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            if (ModelState.IsValid & a.ProducerID != 0)
            {
                a.Image = file1 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file1.InputStream, true, true)) : null;
                a.Image2 = file2 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file2.InputStream, true, true)) : null;
                a.Image3 = file3 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file3.InputStream, true, true)) : null;
                a.Image4 = file4 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file4.InputStream, true, true)) : null;
                a.Image5 = file5 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file5.InputStream, true, true)) : null;
                DBIO.EditProduct(a);
               
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.TT = DBIO.getallProductT();
                if (a.ProducerID == 0)
                {

                    ModelState.AddModelError("", "Vui lòng chọn NSX");
                }


                return View(a);
            }
        }
        //Màu của SP
        public ActionResult Color(int ID)
        {
            var a =DBIO.getallColor(ID);
            ViewBag.TT = DBIO.get1Product(ID);
            return View(a);
        }
        //Thêm màu
        public ActionResult addColor(int ID2)
        {
            ViewBag.TT = DBIO.get1Product(ID2);

            return View();
        }
        [HttpPost]
        public ActionResult addColor(Color a,int ID2)
        {
            if (ModelState.IsValid)
            {
                a.ProductID = ID2;
                DBIO.addColor(a);

                return RedirectToAction("Color", new { ID = ID2 });
            }
            else
            {
                ViewBag.TT = DBIO.get1Product(ID2);
                return View();
            }    

        }
        //SỦa Màu
        public ActionResult editColor(int ID, int ID2)
        {
            ViewBag.TT = DBIO.get1Product(ID2);
            ViewBag.T = DBIO.get1Color(ID);

            return View();

        }
        [HttpPost]
        public ActionResult editColor(Color a,int ID2,int ID3)
        {
            if (ModelState.IsValid)
            {
                
                DBIO.editColor(a);

                return RedirectToAction("Color", new { ID = ID2 });
            }
            else
            {
                ViewBag.TT = DBIO.get1Product(ID2);
                ViewBag.T = DBIO.get1Color(ID3);
                return View();
            }

        }
        //Xóa màu
        public ActionResult deleteColor(int ID,int ID2)
        {
            DBIO.deleteColor(ID);

            return RedirectToAction("Color", new { ID = ID2 });
        }
        //Giao diện Loại SP
        public ActionResult ProductT()
        {
            var A = DBIO.getallProductT();
            return View(A);
        }
        //Thêm loại SP

        public ActionResult CreatProductT()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreatProductT(ProductT a)
        {
            if (ModelState.IsValid )
            {
                DBIO.addProductT(a);
                return RedirectToAction("ProductT", "Admin");
            }
            else
            {
                ViewBag.TT = DBIO.getallProductT();
               


                return View(a);
            }
        }
        //Xóa loại SP
        public ActionResult DeleteProductT(int ID)
        {
            MyDB DB = new MyDB();
            DBIO.deleteProductT(ID);
            List<Producer> i = DBIO.getallProducer_ProductT(ID);
            foreach (var item3 in i)
            {
                Producer k = DB.Producers.FirstOrDefault(x => x.ID == item3.ID);
                DB.Producers.Remove(k);
                DB.SaveChanges();

                List<Product> a = DBIO.getallProduct_ProducerID(item3.ID);

                foreach (var item in a)
                {
                    Product b = DB.Products.FirstOrDefault(x => x.ID == item.ID);
                    DB.Products.Remove(b);
                    DB.SaveChanges();
                    List<Color> c = DBIO.getallColor(item.ID);
                    foreach (var item2 in c)
                    {
                        Color d = DB.Colors.FirstOrDefault(x => x.ID == item2.ID);
                        DB.Colors.Remove(d);
                        DB.SaveChanges();
                    }
                }
            }
            return RedirectToAction("ProductT", "Admin");
        }
        //Sủa Loại SP
        public ActionResult EditProductT(int ID)
        {
            
            var A = DBIO.get1ProductT_ProductTID(ID);
            return View(A);
        }
        [HttpPost]

        public ActionResult EditProductT(ProductT a,int ID2)
        {
            if (ModelState.IsValid )
            {

                DBIO.editProductT(a);

                return RedirectToAction("ProductT", "Admin");
            }
            else
            {
                
               


                return View(a);
            }
        }
        //Giao diện NSX
         public ActionResult Producer(int ID)
        {
            var A = DBIO.getallProducer_ProductT(ID);
            ViewBag.TT = DBIO.get1ProductT_ProductTID(ID);
            return View(A);
        }

        //Thêm NSX
        public ActionResult CreatProducer(int ID )
        {
            ViewBag.TT = DBIO.get1ProductT_ProductTID(ID);
            return View();
        }
        [HttpPost]
        public ActionResult CreatProducer(Producer a,int ID)
        {
            if (ModelState.IsValid)
            {
                a.ProductTID = ID;
                DBIO.addProducer(a);
                return RedirectToAction("Producer", "Admin",new { ID = ID });
            }
            else
            {


                ViewBag.TT = DBIO.get1ProductT_ProductTID(ID);

                return View(a);
            }
        }
        //Sủa NSX
       
        public ActionResult EditProducer(int ID)
        {

            var A = DBIO.get1Producer_ProducerID(ID);
            return View(A);
        }
        [HttpPost]

        public ActionResult EditProducer(Producer a, int ID1,int ID2)
        {
            if (ModelState.IsValid)
            {
                
                DBIO.editProducer(a);

                return RedirectToAction("Producer", "Admin",new { ID = ID2 });
            }
            else
            {




                return View(a);
            }
        }

        //Xóa NSX
        public ActionResult DeleteProducer(int ID,int ID1)
        {
            List<Product> a = DBIO.getallProduct_ProducerID(ID);
            MyDB DB = new MyDB();
            foreach(var item in a)
            {
                Product b = DB.Products.FirstOrDefault(x => x.ID == item.ID);
                DB.Products.Remove(b);
                DB.SaveChanges();
                List<Color> c = DBIO.getallColor(item.ID);
                foreach(var item2 in c)
                {
                    Color d = DB.Colors.FirstOrDefault(x => x.ID == item2.ID);
                    DB.Colors.Remove(d);
                    DB.SaveChanges();
                }    
            }    
            DBIO.deleteProducer(ID);
            return RedirectToAction("Producer", "Admin",new { ID = ID1 });
        }

        public ActionResult DetailNSX(int ID,int page=1,int b=10)
        {
            ViewBag.ID = ID;
            var A = DBIO.getallProduct_ProducerID(ID).ToPagedList(page,b);
            return View(A);
        }
        //Thay doi stt Product
        public ActionResult ChangeSTT(int ID)
        {
            if (DBIO.CountProductofColor(ID) != 0 | DBIO.get1Product(ID).Status==true)
            {
                DBIO.ChangeSTT(ID);
               
            }
            else
            { ViewBag.TB = "Không có hàng"; }    
            var a = DBIO.get1Product(ID);
            return View(a);

        }
        //Xóa Sale
        public ActionResult DeleteSale(int ID)
        {
            MyDB a = new MyDB();
            Product b = a.Products.FirstOrDefault(i => i.ID == ID);
            b.Sale = 0;
            
            a.SaveChanges();
            return Content("Không");
        }

        public ActionResult Index1(string status="true",int sell=1,string sort="ID DESC",int page = 1, int b = 10,int id=-1)
        {
            if(id!=-1)
            {
                DBIO.DeleteProduct(id);
            }    
            List<Product> A = new List<Product>();
            if(status=="true")
            {
                if (sell == 1)
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' ORDER BY " + sort + " ").ToList();
                }
                else if (sell == 2)
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE>0  ORDER BY " + sort + " ").ToList();
                }
                else
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE=0  ORDER BY " + sort + " ").ToList();
                } 
                    
            }
            else if(status=="false")
            {
                if (sell == 1)
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' ORDER BY " + sort + " ").ToList();
                }
                else if (sell == 2)
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE>0  ORDER BY " + sort + " ").ToList();
                }
                else
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE=0  ORDER BY " + sort + " ").ToList();
                }
            }    
            else
            {
                A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE LAUNCH='FALSE' ORDER BY ID DESC").ToList();
            }    


            var C= A;
            var D = A.ToPagedList(page,b);
            int B = C.Count();
            if (B%b==0)
            { ViewBag.page = B / b; }
            else { ViewBag.page = B / b + 1; }
            ViewBag.a = page;
            return View(D);
        }

        public ActionResult Index2(int page = 1, int b = 20)
        {
            MyDB kk = new MyDB();
            var A = DBIO.getallProduct().ToPagedList(page, b);
            
            int B = kk.Products.Count();
            if (B % b == 0)
            { ViewBag.page = B / b; }
            else { ViewBag.page = B / b + 1; }
            ViewBag.a = page;
            return View(A);
        }

        public ActionResult DetailNSX1(int ID, int page = 1, int b = 10)
        {
            var A = DBIO.getallProduct_ProducerID(ID).Where(i=>i.Sale!=0).ToPagedList(page, b);
            return View(A);
        }

        public ActionResult DetailNSX2(int ID, int page = 1, int b = 10)
        {
            var A = DBIO.getallProduct_ProducerID(ID).ToPagedList(page, b);
            return View(A);
        }


        public ActionResult CreatProduct2(int ID)
        {
            ViewBag.KA = ID;
            ViewBag.TT = DBIO.getallProductT();
            return View();
        }
        [HttpPost]
        public ActionResult CreatProduct2(Product a,int ID, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            if (ModelState.IsValid & a.ProducerID != 0)
            {
                MyDB b = new MyDB();
                a.Image = file1 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file1.InputStream, true, true)) : null;
                a.Image2 = file2 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file2.InputStream, true, true)) : null;
                a.Image3 = file3 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file3.InputStream, true, true)) : null;
                a.Image4 = file4 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file4.InputStream, true, true)) : null;
                a.Image5 = file5 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file5.InputStream, true, true)) : null;
                a.Sale = (a.Sale) / 100;
                b.Products.Add(a);
                b.SaveChanges();
                return RedirectToAction("DetailNSX", "Admin", new { ID = ID });
            }
            else
            {
                ViewBag.TT = DBIO.getallProductT();
                if (a.ProducerID == 0)
                {
                    
                    ModelState.AddModelError("", "Vui lòng chọn NSX");
                }

                ViewBag.KA = ID;
                return View(a);
            }
        }

        // thay doi launch
        public ActionResult ChangeLaunch(int ID)
        {
            DBIO.ChangeLaunch(ID);
            var a = DBIO.get1Product(ID);
            return View(a);
        }
    }
}