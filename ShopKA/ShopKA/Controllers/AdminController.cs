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
        public ActionResult Index()
        {
            var C = DBIO.getallProduct().OrderByDescending(i => i.ID).ToList();
           
            
            return View(C);
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
        public ActionResult EditProduct(int ID,int PCID=-1)
        {
            ViewBag.ID = PCID;
            ViewBag.TT = DBIO.getallProductT();
            var A = DBIO.get1Product(ID);
            return View(A);
        }
        [HttpPost]

        public ActionResult EditProduct(Product a, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5, int PCID)
        {
            if (ModelState.IsValid & a.ProducerID != 0)
            {
                a.Image = file1 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file1.InputStream, true, true)) : null;
                a.Image2 = file2 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file2.InputStream, true, true)) : null;
                a.Image3 = file3 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file3.InputStream, true, true)) : null;
                a.Image4 = file4 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file4.InputStream, true, true)) : null;
                a.Image5 = file5 != null ? CovertImage.convert64(System.Drawing.Image.FromStream(file5.InputStream, true, true)) : null;
                DBIO.EditProduct(a);
                if (PCID == -1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("DetailNSX", "Admin",new { ID=PCID});
                }
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

        public ActionResult DetailNSX(int ID)
        {
            ViewBag.ID = ID;
            var A = DBIO.getallProduct_ProducerID(ID);
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

        public ActionResult Index1(string status="true",int sell=1,int page = 1, int b = 10,int id=-1,int id2=-1,int ProducerID=-1)
        {
            if(id!=-1)
            {
                DBIO.DeleteProduct(id);
            }
            else if(id2!=-1)
            {
                var a = DBIO.get1SaleProduct(id2);
                var d = DB.Products.FirstOrDefault(i => i.ID == id2);
                d.Sale = 0;
                var c = DB.SaleProducts.FirstOrDefault(i => i.ID == a.ID);
                DB.SaleProducts.Remove(c);
                DB.SaveChanges();
            }    
            List<Product> A = new List<Product>();
            if (ProducerID == -1)
            {
                if (status == "true")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE'").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE>0").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE=0").ToList();
                    }

                }
                else if (status == "false")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' ").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE>0 ").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE=0  ").ToList();
                    }
                }
                else
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE LAUNCH='FALSE' ORDER BY ID DESC").ToList();
                }
            }
            else
            {
                if (status == "true")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND PRODUCERID='"+ProducerID+"'").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE>0 AND PRODUCERID='" + ProducerID + "'").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND SALE=0 AND PRODUCERID='" + ProducerID + "'").ToList();
                    }

                }
                else if (status == "false")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE>0 AND PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='FALSE' AND LAUNCH='TRUE' AND SALE=0 AND PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                }
                else
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE LAUNCH='FALSE' AND PRODUCERID='" + ProducerID + "' ORDER BY ID DESC").ToList();
                }
            }    

            
           
            
           
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

        //Thêm Sale
        public ActionResult AddSale(int ID)
        {
            ViewBag.ID = ID;
            return View();
        }
        [HttpPost]
        public ActionResult addSale(SaleProduct a)
        {
            if (ModelState.IsValid)
            {


                if (DB.SaleProducts.Count(i => i.ProductID == a.ProductID) == 0)
                {
                    if(a.SaleTimeEnd<=a.SaleTimeStart)
                    {
                        ModelState.AddModelError("", "Ngày không hợp lệ");
                        ViewBag.ID = a.ProductID;
                        return View(a);
                    }
                    a.Sale = a.Sale / 100;
                    DB.SaleProducts.Add(a);
                    DB.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                } }
            ViewBag.ID = a.ProductID;
            return View(a);
        }

        //Sửa Sale
        public ActionResult EditSale(int ID,int PCID=-1)
        {
            ViewBag.ID = PCID;
            var a = DBIO.get1SaleProduct(ID);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditSale(SaleProduct a,int PCID)
        {
            if (ModelState.IsValid)
            {


               
                    if (a.SaleTimeEnd <= a.SaleTimeStart)
                    {
                        ModelState.AddModelError("", "Ngày không hợp lệ");
                        ViewBag.ID = a.ProductID;
                        return View(a);
                    }
                    a.Sale = a.Sale / 100;
                    var b=DB.SaleProducts.FirstOrDefault(i => i.ID == a.ID);
                    b.Sale = a.Sale;
                    b.SaleTimeEnd = a.SaleTimeEnd;
                    b.SaleTimeStart = a.SaleTimeStart;
                    DB.SaveChanges();
                if (PCID == -1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("DetailNSX", "Admin",new { ID=PCID });
                }

            }
            
            return View(a);
        }

        public ActionResult User()
        {
            var A = DBIO.getallUser();
            return View(A);

        }

        public ActionResult ChangeSTTUser(int ID)
        {

            var A = DB.Users.SingleOrDefault(i=>i.ID==ID);
            A.Status = !A.Status;
            DB.SaveChanges();
            
            return View(A);

        }

        public ActionResult OrderAdmin()
        {
            var A = DBIO.getallOrderadmin();
            return View(A);
        }

        public ActionResult OrderAdmin1(int status)
        {
            if (status == -1)
            {
                var A = DBIO.getallOrderadmin();
                return View(A);
            }
            else
            {
                var A = DB.Orders.Where(i => i.Status == status).ToList();
                return View(A);
            }    
            
        }

        public ActionResult changeOrderSTT(int ID, int ID2 = -1)
        {
            if (ID2 == -1)
            {
                
                var A = DB.Orders.Single(i => i.ID == ID);
                
                if(A.Status==5)
                {
                    foreach (var item in DBIO.getallPDOrder(A.ID))
                    {
                        var C = DB.Colors.Single(i => i.ID == item.ColorID);
                        if (C != null)
                        {
                            C.Quantity = C.Quantity + item.Quantity;
                            DB.Products.Single(i => i.ID == C.ProductID).Status = true;
                            DB.SaveChanges();
                        }
                    }
                }    
                A.Status = A.Status + 1;
                DB.SaveChanges();
            }
            else
            {
                var A = DB.Orders.Single(i => i.ID == ID);
                if(ID2==4)
                {
                    foreach (var item in DBIO.getallPDOrder(A.ID))
                    {
                        var C = DB.Colors.Single(i => i.ID == item.ColorID);
                        
                       
                        if (C != null)
                        {
                            SellProduct F =null;
                            C.SellQuantity = C.SellQuantity + item.Quantity;
                            DB.SaveChanges();
                            if (DB.SellProducts.Any(i => i.ColorID == C.ID))
                            {
                                F = DB.SellProducts.Single(i => i.ColorID == C.ID);

                            }
                            else
                            {
                                SellProduct D = new SellProduct();
                                D.ColorID = C.ID;
                                D.PDName = item.PDName;
                                DB.SellProducts.Add(D);
                                DB.SaveChanges();
                                F = DB.SellProducts.Single(i=>i.ColorID==C.ID);
                            }
                            SellDate E = new SellDate();
                            E.BuyName = DBIO.get1User_ID(A.UserID).Username;
                            E.DateSell = DateTime.Now;
                            E.Price = item.Price;
                            E.Quantity = item.Quantity;
                            E.SellPDID = F.ID;
                            DB.SellDates.Add(E);
                            DB.SaveChanges();
                        }
                    }

                }
               
                A.Status = ID2;
                DB.SaveChanges();
            }
            var B = DB.Orders.Single(i => i.ID == ID);
            return View(B);
        }

        public ActionResult AdOrderDetail(int ID)
        {
            ViewBag.Order = DBIO.Get1Orders(ID);
            var A = DBIO.getallPDOrder(ID);
            return View(A);
        }    

        public ActionResult SellProduct()
        {
            var A = DBIO.getallSellPD();
            
            return View(A);
        }

        public ActionResult SellDate(int ID)
        {
            var A = DBIO.getallSellDate(ID);

            return View(A);
        }

    }
}