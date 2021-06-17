using DataBase;
using PagedList;
using ShopKA.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Color = DataBase.Color;

namespace ShopKA.Controllers
{

    [Authorize(Roles = "0")]
    public class AdminController : Controller
    {


        MyDB DB = new MyDB();
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
        public ActionResult CreatProduct(Product a, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            if (ModelState.IsValid & a.ProducerID != 0)
            {
                MyDB b = new MyDB();
                a.Image = null;
                a.Image2 = null;
                a.Image3 = null;
                a.Image4 = null;
                a.Image5 = null;
                if (file1 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image = "/Image/" + fname;
                }
                if (file2 != null && file2.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file2.FileName);
                    file2.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image2 = "/Image/" + fname;
                }
                if (file3 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file3.FileName);
                    file3.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image3 = "/Image/" + fname;
                }
                if (file4 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file4.FileName);
                    file4.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image4 = "/Image/" + fname;
                }
                if (file5 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file5.FileName);
                    file5.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image5 = "/Image/" + fname;
                }



                a.Sale = (a.Sale) / 100;
                b.Products.Add(a);
                b.SaveChanges();
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
            if (c != null)
            {
                foreach (var item2 in c)
                {
                    Color d = DB.Colors.FirstOrDefault(x => x.ID == item2.ID);
                    DB.Colors.Remove(d);
                    DB.SaveChanges();
                }
            }
            var a = DB.Products.SingleOrDefault(i => i.ID == ID);

            if (System.IO.File.Exists(Server.MapPath(a.Image)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Image));
            }
            if (System.IO.File.Exists(Server.MapPath(a.Image2)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Image2));
            }
            if (System.IO.File.Exists(Server.MapPath(a.Image3)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Image3));
            }
            if (System.IO.File.Exists(Server.MapPath(a.Image4)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Image4));
            }
            if (System.IO.File.Exists(Server.MapPath(a.Image5)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Image5));
            }


            DBIO.DeleteProduct(ID);
            return RedirectToAction("Index", "Admin");
        }
        //Sủa SP
        public ActionResult EditProduct(int ID, int PCID = -1)
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
                a.Image = null;
                a.Image2 = null;
                a.Image3 = null;
                a.Image4 = null;
                a.Image5 = null;
                var t = DB.Products.SingleOrDefault(i => i.ID == a.ID);
                if (file1 != null && file1.ContentLength > 0)
                {
                    if (t.Image != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(t.Image)) == true)
                        {
                            System.IO.File.Delete(Server.MapPath(t.Image));
                        }
                       
                    }
                    string fname = a.ID.ToString() + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image = "/Image/" + fname;
                }
                if (file2 != null && file2.ContentLength > 0)
                {
                    if (t.Image2 != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(t.Image2)) == true)
                        {
                            System.IO.File.Delete(Server.MapPath(t.Image2));
                        }
                       
                    }
                    string fname = a.ID.ToString() + Path.GetFileName(file2.FileName);
                    file2.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image2 = "/Image/" + fname;
                }
                if (file3 != null && file1.ContentLength > 0)
                {
                    if (t.Image3 != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(t.Image3)) == true)
                        {
                            System.IO.File.Delete(Server.MapPath(t.Image3));
                        }
                        
                    }
                    string fname = a.ID.ToString() + Path.GetFileName(file3.FileName);
                    file3.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image3 = "/Image/" + fname;
                }
                if (file4 != null && file1.ContentLength > 0)
                {
                    if (t.Image4 != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(t.Image4)) == true)
                        
                            {
                            System.IO.File.Delete(Server.MapPath(t.Image4));
                        }
                        
                    }
                    string fname = a.ID.ToString() + Path.GetFileName(file4.FileName);
                    file4.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image4 = "/Image/" + fname;
                }
                if (file5 != null && file1.ContentLength > 0)
                {
                    if (t.Image5 != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(t.Image5)) == true)
                        {
                            System.IO.File.Delete(Server.MapPath(t.Image5));
                        }
                       
                    }
                    string fname = a.ID.ToString() + Path.GetFileName(file5.FileName);
                    file5.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image5 = "/Image/" + fname;
                }


                DBIO.EditProduct(a);
                if (PCID == -1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("DetailNSX", "Admin", new { ID = PCID });
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
            var a = DBIO.getallColor(ID);
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
        public ActionResult addColor(Color a, int ID2)
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
        public ActionResult editColor(Color a, int ID2, int ID3)
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
        public ActionResult deleteColor(int ID, int ID2)
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
        public ActionResult CreatProductT(ProductT a, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                a.Image = null;

                if (file1 != null && file1.ContentLength > 0)
                {
                    string fname = "PT" + a.ID + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image = "/Image/" + fname;
                }
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
            var t = DB.ProductTs.SingleOrDefault(j => j.ID == ID);
            if (System.IO.File.Exists(Server.MapPath(t.Image)) == true)
            {
                System.IO.File.Delete(Server.MapPath(t.Image));
            }
            
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

        public ActionResult EditProductT(ProductT a, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                a.Image = a.Image;
                if (a.Image != null)
                {
                     if (System.IO.File.Exists(Server.MapPath(a.Image)) == true) { 
           
                        System.IO.File.Delete(Server.MapPath(a.Image));
                    }
                    
                }
                if (file1 != null && file1.ContentLength > 0)
                {
                    string fname = "PT" + a.ID + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image = "/Image/" + fname;
                }
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
        public ActionResult CreatProducer(int ID)
        {
            ViewBag.TT = DBIO.get1ProductT_ProductTID(ID);
            return View();
        }
        [HttpPost]
        public ActionResult CreatProducer(Producer a, int ID)
        {
            if (ModelState.IsValid)
            {
                a.ProductTID = ID;
                DBIO.addProducer(a);
                return RedirectToAction("Producer", "Admin", new { ID = ID });
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

        public ActionResult EditProducer(Producer a, int ID1, int ID2)
        {
            if (ModelState.IsValid)
            {

                DBIO.editProducer(a);

                return RedirectToAction("Producer", "Admin", new { ID = ID2 });
            }
            else
            {




                return View(a);
            }
        }

        //Xóa NSX
        public ActionResult DeleteProducer(int ID, int ID1)
        {
            List<Product> a = DBIO.getallProduct_ProducerID(ID);
            MyDB DB = new MyDB();
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
            DBIO.deleteProducer(ID);
            return RedirectToAction("Producer", "Admin", new { ID = ID1 });
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
            if (DBIO.CountProductofColor(ID) != 0 | DBIO.get1Product(ID).Status == true)
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

        public ActionResult Index1(string status = "true", int sell = 1, int page = 1, int b = 10, int id = -1, int id2 = -1, int ProducerID = -1)
        {
            if (id != -1)
            {
                DBIO.DeleteProduct(id);
            }
            else if (id2 != -1)
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
                else if (status == "trueandfalse")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS ").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE SALE>0 ").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE SALE=0  ").ToList();
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
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND PRODUCERID='" + ProducerID + "'").ToList();
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
                else if (status == "trueandfalse")
                {
                    if (sell == 1)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                    else if (sell == 2)
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE SALE>0 AND PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                    else
                    {
                        A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE SALE=0 AND PRODUCERID='" + ProducerID + "' ").ToList();
                    }
                }
                else
                {
                    A = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE LAUNCH='FALSE' AND PRODUCERID='" + ProducerID + "' ORDER BY ID DESC").ToList();
                }
            }




            ViewBag.ProducerID = ProducerID;
            return View(A);
        }





        public ActionResult CreatProduct2(int ID)
        {
            ViewBag.KA = ID;
            ViewBag.TT = DBIO.getallProductT();
            return View();
        }
        [HttpPost]
        public ActionResult CreatProduct2(Product a, int ID, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            if (ModelState.IsValid & a.ProducerID != 0)
            {
                MyDB b = new MyDB();
                a.Image = null;
                a.Image2 = null;
                a.Image3 = null;
                a.Image4 = null;
                a.Image5 = null;
                if (file1 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image = "/Image/" + fname;
                }
                if (file2 != null && file2.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file2.FileName);
                    file2.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image2 = "/Image/" + fname;
                }
                if (file3 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file3.FileName);
                    file3.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image3 = "/Image/" + fname;
                }
                if (file4 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file4.FileName);
                    file4.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image4 = "/Image/" + fname;
                }
                if (file5 != null && file1.ContentLength > 0)
                {
                    string fname = a.ID.ToString() + Path.GetFileName(file5.FileName);
                    file5.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    a.Image5 = "/Image/" + fname;
                }


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
                    if (a.SaleTimeEnd <= a.SaleTimeStart)
                    {
                        ModelState.AddModelError("", "Ngày không hợp lệ");
                        ViewBag.ID = a.ProductID;
                        return View(a);
                    }
                    a.Sale = a.Sale / 100;
                    DB.SaleProducts.Add(a);
                    DB.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.ID = a.ProductID;
            return View(a);
        }

        //Sửa Sale
        public ActionResult EditSale(int ID, int PCID = -1)
        {
            ViewBag.ID = PCID;
            var a = DBIO.get1SaleProduct(ID);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditSale(SaleProduct a, int PCID)
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
                var b = DB.SaleProducts.FirstOrDefault(i => i.ID == a.ID);
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
                    return RedirectToAction("DetailNSX", "Admin", new { ID = PCID });
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

            var A = DB.Users.SingleOrDefault(i => i.ID == ID);
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

                var A = DB.Orders.SingleOrDefault(i => i.ID == ID);

                if (A.Status == 5)
                {
                    foreach (var item in DBIO.getallPDOrder(A.ID))
                    {
                        var C = DB.Colors.SingleOrDefault(i => i.ID == item.ColorID);

                        if (C != null)
                        {
                            if (DB.Products.SingleOrDefault(i => i.ID == C.ProductID) != null)
                            {
                                C.Quantity = C.Quantity + item.Quantity;
                                DB.Products.SingleOrDefault(i => i.ID == C.ProductID).Status = true;
                                DB.SaveChanges();
                            }
                        }
                    }
                }
                if (A.Status <= 5)
                {
                    A.Status = A.Status + 1;
                }
                DB.SaveChanges();
            }
            else
            {
                var A = DB.Orders.SingleOrDefault(i => i.ID == ID);
                if (ID2 == 4)
                {
                    foreach (var item in DBIO.getallPDOrder(A.ID))
                    {
                        var C = DB.Colors.SingleOrDefault(i => i.ID == item.ColorID);


                        if (C != null)
                        {
                            SellProduct F = null;
                            C.SellQuantity = C.SellQuantity + item.Quantity;
                            DB.SaveChanges();
                            if (DB.SellProducts.Any(i => i.ColorID == C.ID))
                            {
                                F = DB.SellProducts.SingleOrDefault(i => i.ColorID == C.ID);

                            }
                            else
                            {
                                SellProduct D = new SellProduct();
                                D.ColorID = C.ID;
                                D.PDName = item.PDName;
                                DB.SellProducts.Add(D);
                                DB.SaveChanges();
                                F = DB.SellProducts.SingleOrDefault(i => i.ColorID == C.ID);
                            }
                            SellDate E = new SellDate();



                            E.BuyName = DBIO.get1User_ID(A.UserID).Username;
                            E.DateSell = DateTime.UtcNow.AddHours(7);
                            E.Price = item.Price - (int)(A.Maximum >= item.Price * A.SalePrice ? item.Price * A.SalePrice : (A.Maximum / DBIO.getallPDOrder(A.ID).Sum(i => i.Quantity)));
                            if (A.SalePrice > 0)
                            {
                                E.Voucher = "(Voucher giảm " + A.SalePrice * 100 + "% giá trị đơn hàng, tối đa: " + A.Maximum + "đ)";
                            }
                            else
                            {
                                E.Voucher = "";
                            }
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
            var B = DB.Orders.SingleOrDefault(i => i.ID == ID);
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
        public ActionResult SellProduct1(int date)
        {
            if (date == 0)
            {
                DateTime a = new DateTime(2020, 1, 1);
                ViewBag.time = a;
                var A = DBIO.getallSellPD();
                return View(A);
            }
            else
            {
                if (DateTime.UtcNow.AddHours(7).Month >= date)
                {
                    DateTime a = new DateTime(DateTime.UtcNow.AddHours(7).Year, (DateTime.UtcNow.AddHours(7).Month - date) + 1, 1);
                    ViewBag.time = a;
                    var A = DBIO.getallSellPD().Where(i => DBIO.getallSellDate(i.ID).Any(j => j.DateSell >= a) == true).ToList();

                    return View(A);
                }
                else
                {
                    DateTime a = new DateTime(DateTime.UtcNow.AddHours(7).Year - 1, (12 - date + DateTime.UtcNow.AddHours(7).Month) + 1, 1);
                    ViewBag.time = a;
                    var A = DBIO.getallSellPD().Where(i => DBIO.getallSellDate(i.ID).Any(j => j.DateSell >= a) == true).ToList();

                    return View(A);
                }
            }


        }

        public ActionResult SellDate(int ID)
        {
            var A = DBIO.getallSellDate(ID);
            ViewBag.ID = ID;
            return View(A);
        }
        public ActionResult SellDate1(int ID, int date)
        {
            if (date == 0)
            {

                var A = DBIO.getallSellDate(ID);

                return View(A);
            }
            if (DateTime.UtcNow.AddHours(7).Month >= date)
            {
                DateTime a = new DateTime(DateTime.UtcNow.AddHours(7).Year, (DateTime.UtcNow.AddHours(7).Month - date) + 1, 1);
                ViewBag.time = a;
                var A = DBIO.getallSellDate(ID).Where(i => i.DateSell >= a).ToList();

                return View(A);
            }
            else
            {

                DateTime a = new DateTime(DateTime.UtcNow.AddHours(7).Year - 1, (12 - date + DateTime.UtcNow.AddHours(7).Month) + 1, 1);
                ViewBag.time = a;
                var A = DBIO.getallSellDate(ID).Where(i => i.DateSell >= a).ToList();

                return View(A);
            }
        }


        public ActionResult addProductTSale(int ID)
        {
            ViewBag.ProductT = DBIO.get1ProductT_ProductTID(ID);

            return View();
        }
        [HttpPost]
        public ActionResult addProductTSale(ProductTSale a, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                MyDB DB = new MyDB();
                if (DB.ProductTSales.Any(i => i.ProductTID == a.ProductTID) == false)
                {
                    if (a.SaleTimeEnd <= a.SaleTimeStart)
                    {
                        ModelState.AddModelError("", "Ngày không hợp lệ");
                        ViewBag.ProductT = DBIO.get1ProductT_ProductTID(a.ProductTID);
                        return View(a);
                    }
                    a.Banner = null;
                    if (file1 != null && file1.ContentLength > 0)
                    {
                        string fname = "Banner" + a.ProductTID + Path.GetFileName(file1.FileName);
                        file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                        a.Banner = "/Image/" + fname;
                    }
                    a.Sale = a.Sale / 100;
                    DB.ProductTSales.Add(a);
                    DB.SaveChanges();


                    var b = DBIO.getallProducer_ProductT(a.ProductTID);
                    foreach (var item in b)
                    {
                        var c = DBIO.getallProduct_ProducerID(item.ID);
                        foreach (var item2 in c)
                        {
                            if (DB.SaleProducts.Any(i => i.ProductID == item2.ID))
                            {
                                var d = DB.SaleProducts.SingleOrDefault(i => i.ProductID == item2.ID);
                                DB.SaleProducts.Remove(d);
                                DB.SaveChanges();

                            }
                            SaleProduct e = new SaleProduct();
                            e.ProductID = item2.ID;
                            e.Sale = a.Sale;
                            e.SaleTimeEnd = a.SaleTimeEnd;
                            e.SaleTimeStart = a.SaleTimeStart;
                            DB.SaleProducts.Add(e);
                            DB.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("ProductT", "Admin");

            }
            else
            {
                ViewBag.ProductT = DBIO.get1ProductT_ProductTID(a.ProductTID);

                return View(a);
            }

        }

        public ActionResult EditProductTSale(int ID)
        {
            ViewBag.ProductT = DBIO.get1ProductT_ProductTID(ID);
            ViewBag.Sale = DB.ProductTSales.SingleOrDefault(i => i.ProductTID == ID);
            return View();
        }
        [HttpPost]
        public ActionResult EditProductTSale(ProductTSale a, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                MyDB DB = new MyDB();
                if (a.SaleTimeEnd <= a.SaleTimeStart)
                {
                    ModelState.AddModelError("", "Ngày không hợp lệ");
                    ViewBag.ProductT = DBIO.get1ProductT_ProductTID(a.ProductTID);
                    ViewBag.Sale = DB.ProductTSales.SingleOrDefault(i => i.ProductTID == a.ProductTID);
                    return View(a);
                }

                var b = DB.ProductTSales.SingleOrDefault(i => i.ID == a.ID);
                b.Sale = a.Sale / 100;
                b.SaleTimeEnd = a.SaleTimeEnd;
                b.SaleTimeStart = a.SaleTimeStart;
                b.Title = a.Title;
                b.Content = a.Content;
                b.Banner = a.Banner;
                if (b.Banner != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.Banner)) == true)
                    {
                        System.IO.File.Delete(Server.MapPath(b.Banner));
                    }
                    
                }
                if (file1 != null && file1.ContentLength > 0)
                {
                    string fname = "Banner" + a.ProductTID + Path.GetFileName(file1.FileName);
                    file1.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fname));
                    b.Banner = "/Image/" + fname;
                }
                DB.SaveChanges();

                var f = DBIO.getallProducer_ProductT(a.ProductTID);
                foreach (var item in f)
                {
                    var c = DBIO.getallProduct_ProducerID(item.ID);
                    foreach (var item2 in c)
                    {

                        if (DB.SaleProducts.Any(i => i.ProductID == item2.ID))
                        {
                            var d = DB.SaleProducts.SingleOrDefault(i => i.ProductID == item2.ID);

                            DB.SaleProducts.Remove(d);
                            DB.SaveChanges();

                        }
                        SaleProduct e = new SaleProduct();
                        e.ProductID = item2.ID;
                        e.Sale = a.Sale / 100;
                        e.SaleTimeEnd = a.SaleTimeEnd;
                        e.SaleTimeStart = a.SaleTimeStart;
                        DB.SaleProducts.Add(e);
                        DB.SaveChanges();
                    }

                }
                return RedirectToAction("ProductT", "Admin");
            }
            else
            {
                ViewBag.ProductT = DBIO.get1ProductT_ProductTID(a.ProductTID);
                ViewBag.Sale = DB.ProductTSales.SingleOrDefault(i => i.ProductTID == a.ProductTID);
                return View(a);
            }
        }

        public ActionResult DeleteProductTSale(int ID)
        {
            var f = DBIO.getallProducer_ProductT(ID);
            foreach (var item in f)
            {
                var c = DBIO.getallProduct_ProducerID(item.ID);
                foreach (var item2 in c)
                {

                    if (DB.SaleProducts.Any(i => i.ProductID == item2.ID))
                    {
                        var d = DB.SaleProducts.SingleOrDefault(i => i.ProductID == item2.ID);

                        DB.SaleProducts.Remove(d);
                        DB.SaveChanges();

                    }
                    var e = DB.Products.SingleOrDefault(i => i.ID == item2.ID);
                    e.Sale = 0;
                    DB.SaveChanges();
                }
            }
            var a = DB.ProductTSales.SingleOrDefault(i => i.ProductTID == ID);
            if (System.IO.File.Exists(Server.MapPath(a.Banner)) == true)
            {
                System.IO.File.Delete(Server.MapPath(a.Banner));
            }
            
            DB.ProductTSales.Remove(a);
            DB.SaveChanges();
            var E = DBIO.getallProductT();
            return View(E);
        }

        public ActionResult Voucher()
        {
            DBIO.checkVoucher();
            var A = DB.Vouchers.ToList();
            return View(A);
        }
        public ActionResult AddVoucher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVoucher(Voucher a, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                if (a.End <= DateTime.UtcNow.AddHours(7))
                {
                    ModelState.AddModelError("", "Ngày không hợp lệ");
                    return View(a);
                }
                if (a.Quantity <= 0)
                {
                    ModelState.AddModelError("", "Số lượng không hợp lệ");
                    return View(a);
                }
                if (int.Parse(f["Sale"]) < 0 | int.Parse(f["Sale"]) > 100)
                {
                    ModelState.AddModelError("", "% giảm giá phải từ 0 - 100%");
                    return View(a);
                }
                //    string c = f["Type"];
                //a.Type = f["Type"] == "true" ? true : false;  
                if (a.Type == true)
                {
                    a.OrderSale = float.Parse(f["Sale"]) / 100;

                }
                else
                {
                    a.ShipSale = float.Parse(f["Sale"]) / 100;
                }
                a.Code = DBIO.RandomString(6);
                while (DB.Vouchers.Any(i => i.Code == a.Code))
                { a.Code = DBIO.RandomString(6); ; }

                DB.Vouchers.Add(a);
                DB.SaveChanges();
                return RedirectToAction("Voucher", "Admin");
            }
            else
            {
                return View(a);
            }
        }
        public ActionResult deleteVoucher(int id)
        {
            var a = DB.Vouchers.SingleOrDefault(i => i.ID == id);
            var b = DB.Voucherlogs.Where(i => i.Code == a.Code);
            DB.Voucherlogs.RemoveRange(b);
            DB.SaveChanges();
            DB.Vouchers.Remove(a);
            DB.SaveChanges();
            var A = DB.Vouchers.ToList();
            return View(A);

        }

        public ActionResult Chart()
        {
            DateTime Now = DateTime.UtcNow.AddHours(7);
            DateTime Start = new DateTime(2021, 4, 1);
            ViewData["StartSell"] = Start;
            if (DateTime.UtcNow.AddHours(7).AddMonths(-12) > Start)
            {
                Start = DateTime.UtcNow.AddHours(7).AddMonths(-12);
            }
            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            var SellPD = DB.SellProducts.ToList().Where(i=>DBIO.getallSellDate(i.ID).Any(j=>j.DateSell>=Start&j.DateSell<= Now) ==true);
            List<string> month = new List<string>();
            List<long> Earn = new List<long>();
            List<string> TypePD = new List<string>();
            List<float> percent = new List<float>();
            float sum2;
            for (DateTime i = Start; i <= DateTime.UtcNow.AddHours(7); i = i.AddMonths(1))
            {

                string text = "T" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                month.Add(text);

                Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));


            }
            float sum = Earn.Sum();
            foreach (var item in DBIO.getallProductT())
            {
                TypePD.Add(DBIO.RemoveUnicode(item.ProducTName));
                sum2 = 0;
                foreach(var item2 in SellPD.Where(i=>DBIO.getProductT_colorID(i.ColorID)!=null).Where(i=>DBIO.getProductT_colorID(i.ColorID).ID == item.ID))
                {
                    sum2 = sum2 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= Now).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum2/sum*100,1));
                
            }
            float sum3 = 0;
            if(SellPD.Any(i => DBIO.getProductT_colorID(i.ColorID) == null)==true)
            {
                TypePD.Add("Khac");
                foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) == null))
                    {
                    sum3 = sum3 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= Now).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum3 / sum * 100, 1));
            }    

            ViewData["type"] = TypePD;
            ViewData["percent"] = percent;
            ViewData["start"] = Start;
            ViewData["end"] = DateTime.UtcNow.AddHours(7);
            ViewData["month"] = month;
            ViewData["Earn"] = Earn;
            return View();
        }

        public ActionResult Chart2(int startmonth=0, int startyear=0, int endmonth=0, int endyear=0)
        {
            DateTime Start = new DateTime();
            DateTime End = new DateTime();
            if (startmonth != 0)
            {
                Start = new DateTime(startyear, startmonth, 1);

                End = new DateTime(endyear, endmonth, 30);
                if (endyear == DateTime.UtcNow.AddHours(7).Year & endmonth == DateTime.UtcNow.AddHours(7).Month)
                {
                    End = DateTime.UtcNow.AddHours(7);
                }
            }
            else
            {
                DateTime StartSell = new DateTime(2021, 4, 1);
                Start = DateTime.UtcNow.AddHours(7).AddMonths(-12)>StartSell?DateTime.UtcNow.AddHours(7).AddMonths(-12):StartSell;
                End = DateTime.UtcNow.AddHours(7);
               
            }
            


            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            List<string> month = new List<string>();
            List<long> Earn = new List<long>();



            for (DateTime i = Start; i <= End; i = i.AddMonths(1))
            {

                string text = "T" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                month.Add(text);
                Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));

            }

            ViewData["month"] = month;
            ViewData["Earn"] = Earn;
            return View();
        }

        public ActionResult Chart3(int startmonth = 0, int startyear = 0, int endmonth = 0, int endyear = 0)
        {
            DateTime Start = new DateTime();
            DateTime End = new DateTime();
            if (startmonth != 0)
            {
                Start = new DateTime(startyear, startmonth, 1);

                End = new DateTime(endyear, endmonth, 30);
                if (endyear == DateTime.UtcNow.AddHours(7).Year & endmonth == DateTime.UtcNow.AddHours(7).Month)
                {
                    End = DateTime.UtcNow.AddHours(7);
                }
            }
            else
            {
                DateTime StartSell = new DateTime(2021, 4, 1);
                Start = DateTime.UtcNow.AddHours(7).AddMonths(-12) > StartSell ? DateTime.UtcNow.AddHours(7).AddMonths(-12) : StartSell;
                End = DateTime.UtcNow.AddHours(7);

            }

            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            List<string> month = new List<string>();
            List<long> Earn = new List<long>();



            for (DateTime i = Start; i <= End; i = i.AddMonths(1))
            {

                string text = "T" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                month.Add(text);
                Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));

            }

            ViewData["month"] = month;
            ViewData["Earn"] = Earn;
            return View();
        }
        public ActionResult Chart4(int startmonth = 0, int startyear = 0, int endmonth = 0, int endyear = 0)
        {
            DateTime Start = new DateTime();
            DateTime End = new DateTime();
            
            if (startmonth != 0)
            {
                Start = new DateTime(startyear, startmonth, 1);

                End = new DateTime(endyear, endmonth, 30);
                if (endyear == DateTime.UtcNow.AddHours(7).Year & endmonth == DateTime.UtcNow.AddHours(7).Month)
                {
                    End = DateTime.UtcNow.AddHours(7);
                }
            }
            else
            {
                DateTime StartSell = new DateTime(2021, 4, 1);
                Start = DateTime.UtcNow.AddHours(7).AddMonths(-12) > StartSell ? DateTime.UtcNow.AddHours(7).AddMonths(-12) : StartSell;
                End = DateTime.UtcNow.AddHours(7);

            }
            var SellPD = DB.SellProducts.ToList().Where(i => DBIO.getallSellDate(i.ID).Any(j => j.DateSell >= Start & j.DateSell <= End) == true);
            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            

            List<string> TypePD = new List<string>();
            List<float> percent = new List<float>();
            float sum = 0;
            for (DateTime i = Start; i <= End; i = i.AddMonths(1))
            {

                sum = sum + Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity);

             

            }
            float sum2;
            foreach (var item in DBIO.getallProductT())
            {
                TypePD.Add(DBIO.RemoveUnicode(item.ProducTName));
                sum2 = 0;
                foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) != null).Where(i => DBIO.getProductT_colorID(i.ColorID).ID == item.ID))
                {
                    sum2 = sum2 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum2 / sum * 100, 1));

            }
            float sum3 = 0;
            if (SellPD.Any(i => DBIO.getProductT_colorID(i.ColorID) == null) == true)
            {
                TypePD.Add("Khac");
                foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) == null))
                {
                    sum3 = sum3 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum3 / sum * 100, 1));
            }

            ViewData["type"] = TypePD;
            ViewData["percent"] = percent;
            return View();
        }
        public ActionResult Month(int startmonth, int startyear, int endmonth, int endyear, int check)
        {
            if (check == 0)
            {
                ViewBag.End = new DateTime(endyear, endmonth, 1);
            }
            else
            {
                ViewBag.End = DateTime.UtcNow.AddHours(7);
            }

            ViewBag.Start = new DateTime(startyear, startmonth, 1);
            return View();
        }

        public ActionResult Day(string startday, string endday, int check)
        {
            if (check == 0)
            {
                ViewBag.End = DateTime.ParseExact(endday, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); 
            }
            else
            {
                ViewBag.End = DateTime.UtcNow.AddHours(7);
            }

            ViewBag.Start = DateTime.ParseExact(startday, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); 
            return View();
        }
        public ActionResult ChartDay(string daystart=null,string dayend=null)
        {
            DateTime Now = DateTime.UtcNow.AddHours(7);
            DateTime Start = new DateTime(2021, 4, 1);
            DateTime End = DateTime.UtcNow.AddHours(7);
            if (dayend != null)
            {
                End = DateTime.ParseExact(dayend, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            if (daystart!=null)
            {
                Start = DateTime.ParseExact(daystart, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); 
            }    
            else if (DateTime.UtcNow.AddHours(7).AddDays(-30) > Start)
            {
                Start = DateTime.UtcNow.AddHours(7).AddDays(-30);
            }
            
            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            List<string> month = new List<string>();
            List<long> Earn = new List<long>();


            if (dayend == null)
            {
                for (DateTime i = Start; i <= DateTime.UtcNow.AddHours(7); i = i.AddDays(1))
                {

                    string text = i.Day.ToString() + "-" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                    month.Add(text);
                    Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month&j.DateSell.Day==i.Day&j.DateSell.Year==i.Year).Sum(j => j.Price * j.Quantity));

                }
            }
            else
            {
                for (DateTime i = Start; i <= DateTime.ParseExact(dayend, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); i = i.AddDays(1))
                {

                    string text = i.Day.ToString() + "-" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                    month.Add(text);
                    Earn.Add(Sell.Where(j=>j.DateSell.Month == i.Month & j.DateSell.Day == i.Day & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));

                }
            }
          
            ViewData["month"] = month;
            ViewData["Earn"] = Earn;
            return View("Chart2");
        }

        public ActionResult ChartDay2(string daystart = null, string dayend = null)
        {
            DateTime Now = DateTime.UtcNow.AddHours(7);
            DateTime Start = new DateTime(2021, 4, 1);
            if (daystart != null)
            {
                Start = DateTime.ParseExact(daystart, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); ;
            }
            else if (DateTime.UtcNow.AddHours(7).AddDays(-30) > Start)
            {
                Start = DateTime.UtcNow.AddHours(7).AddDays(-30);
            }

            var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            List<string> month = new List<string>();
            List<long> Earn = new List<long>();


            if (dayend == null)
            {
                for (DateTime i = Start; i <= DateTime.UtcNow.AddHours(7); i = i.AddDays(1))
                {

                    string text = i.Day.ToString() + "-" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                    month.Add(text);
                    Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Day == i.Day & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));

                }
            }
            else
            {
                for (DateTime i = Start; i <= DateTime.ParseExact(dayend, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); i = i.AddDays(1))
                {

                    string text = i.Day.ToString() + "-" + i.Month.ToString() + " - " + i.Year.ToString().Substring(2);

                    month.Add(text);
                    Earn.Add(Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Day == i.Day & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity));

                }
            }

            ViewData["month"] = month;
            ViewData["Earn"] = Earn;
            return View("Chart3");
        }

        public ActionResult ChartDay3(string daystart = null, string dayend = null)
        {
            DateTime Now = DateTime.UtcNow.AddHours(7);
            DateTime Start = new DateTime(2021, 4, 1);
            DateTime End = DateTime.UtcNow.AddHours(7);
            if(dayend != null)
            {
                End = DateTime.ParseExact(dayend, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            if (daystart != null)
            {
                Start = DateTime.ParseExact(daystart, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); ;
            }
            else if (DateTime.UtcNow.AddHours(7).AddDays(-30) > Start)
            {
                Start = DateTime.UtcNow.AddHours(7).AddDays(-30);
            }
            var SellPD = DB.SellProducts.ToList().Where(i => DBIO.getallSellDate(i.ID).Any(j => j.DateSell >= Start & j.DateSell <= End) == true);
               var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();


               List<string> TypePD = new List<string>();
               List<float> percent = new List<float>();

            float sum = 0;
            if (dayend == null)
            {
                for (DateTime i = Start; i <= DateTime.UtcNow.AddHours(7); i = i.AddDays(1))
                {

                   
                    sum= sum + Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Day == i.Day & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity);

                }
            }
            else
            {
                for (DateTime i = Start; i <= DateTime.ParseExact(dayend, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture); i = i.AddDays(1))
                {

                    sum = sum + Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Day == i.Day & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity);

                }
            }
            float sum2;
            foreach (var item in DBIO.getallProductT())
            {
                TypePD.Add(DBIO.RemoveUnicode(item.ProducTName));
                sum2 = 0;
                foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) != null).Where(i => DBIO.getProductT_colorID(i.ColorID).ID == item.ID))
                {
                    sum2 = sum2 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum2 / sum * 100, 1));

            }
            float sum3 = 0;
            if (SellPD.Any(i => DBIO.getProductT_colorID(i.ColorID) == null) == true)
            {
                TypePD.Add("Khac");
                foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) == null))
                {
                    sum3 = sum3 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
                }
                percent.Add((float)Math.Round(sum3 / sum * 100, 1));
            }

            ViewData["type"] = TypePD;
            ViewData["percent"] = percent;
            return View("Chart4");
        }

         //var SellPD = DB.SellProducts.ToList().Where(i => DBIO.getallSellDate(i.ID).Any(j => j.DateSell >= Start & j.DateSell <= End) == true);
         //   var Sell = DB.SellDates.Where(i => i.DateSell >= Start).ToList();
            

         //   List<string> TypePD = new List<string>();
         //   List<float> percent = new List<float>();
         //   float sum = 0;
         //   for (DateTime i = Start; i <= End; i = i.AddMonths(1))
         //   {

         //       sum = sum + Sell.Where(j => j.DateSell.Month == i.Month & j.DateSell.Year == i.Year).Sum(j => j.Price * j.Quantity);

             

         //   }
         //   float sum2;
         //   foreach (var item in DBIO.getallProductT())
         //   {
         //       TypePD.Add(DBIO.RemoveUnicode(item.ProducTName));
         //       sum2 = 0;
         //       foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) != null).Where(i => DBIO.getProductT_colorID(i.ColorID).ID == item.ID))
         //       {
         //           sum2 = sum2 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
         //       }
         //       percent.Add((float)Math.Round(sum2 / sum * 100, 1));

         //   }
         //   float sum3 = 0;
         //   if (SellPD.Any(i => DBIO.getProductT_colorID(i.ColorID) == null) == true)
         //   {
         //       TypePD.Add("Khac");
         //       foreach (var item2 in SellPD.Where(i => DBIO.getProductT_colorID(i.ColorID) == null))
         //       {
         //           sum3 = sum3 + DBIO.getallSellDate(item2.ID).Where(j => j.DateSell >= Start & j.DateSell <= End).Sum(j => j.Price * j.Quantity);
         //       }
         //       percent.Add((float)Math.Round(sum3 / sum * 100, 1));
         //   }

         //   ViewData["type"] = TypePD;
         //   ViewData["percent"] = percent;
         //   return View();
    }
}