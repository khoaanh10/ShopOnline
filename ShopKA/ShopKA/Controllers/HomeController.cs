using PagedList;
using ShopKA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;
using System.Threading;

namespace ShopKA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var a = DBIO.getallProductT();

            ViewBag.Sale = DBIO.get8ProductSale().Where(i => i.Launch == true);
            ViewBag.Feature = DBIO.GetProductLaunch().Take(8);
            ViewBag.SalePD = DBIO.get2ProductSale(DateTime.Now);
            return View(a);
        }

        public ActionResult Product(int ProducerID = -1, string Sort = "ID", int page = 1, int b = 12, int max = 0, int min = 0, int ProductTID = -1)
        {
            ViewBag.ProducerID = ProducerID;
            List<Product> tam = new List<Product>();
            if (ProductTID == -1)
            { tam = DBIO.GetProduct_home(ProducerID, Sort, max, min); }
            else
            { tam = DBIO.getProduct_ProductT_home(Sort, max, min, ProductTID); }
            var a = tam.ToPagedList(page, b);
            int count = tam.Count();
            if (count % b == 0)
            { ViewBag.page = count / b; }
            else { ViewBag.page = count / b + 1; }
            ViewBag.number = page;
            ViewBag.ProductTID = ProductTID;
            return View(a);
        }
        public ActionResult Product1(int ProducerID = -1, string Sort = "ID", int page = 1, int b = 12, int max = 0, int min = 0, string type = "Grid", int ProductTID = -1)
        {
            ViewBag.ProducerID = ProducerID;
            ViewBag.Type = type;
            List<Product> tam = new List<Product>();
            if (ProductTID == -1)
            { tam = DBIO.GetProduct_home(ProducerID, Sort, max, min); }
            else
            { tam = DBIO.getProduct_ProductT_home(Sort, max, min, ProductTID); }

            var a = tam.ToPagedList(page, b);
            int count = tam.Count();
            if (count % b == 0)
            { ViewBag.page = count / b; }
            else { ViewBag.page = count / b + 1; }
            ViewBag.number = page;
            ViewBag.ProductTID = ProductTID;
            return View(a);
        }

        public ActionResult ProductDetail(int ID, int page = 1, int b = 5, string Sort = "ID")
        {
           
            var a = DBIO.get1ProductHome(ID);
            
            ViewBag.ProductID = ID;
            ViewBag.Review = DBIO.getallReview_Product(ID, Sort).ToPagedList(page, b);
            int count1 = DBIO.getallReview_Product(ID, Sort).Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            ViewBag.NumberReview = count1;
            ViewBag.AVG = DBIO.AVGRatingReview(ID);
            ViewBag.Quantity = DBIO.get1Color_ProductID(ID).Quantity;
            ViewBag.SameProduct = DBIO.get4SameProduct(ID);
            return View(a);
        }

        public ActionResult Review(Review a, int ProductID, string Sort = "ID")
        {
            a.ProductID = ProductID;
            UserLogin UserL = (UserLogin)(Session["SS"]);
            User User1 = DBIO.getUser_fromUserLogin(UserL);
            a.UserID = User1.ID;
            DBIO.addReview(a);
            ViewBag.ProductID = ProductID;


            return RedirectToAction("ProductDetail", "Home", new { ID = ProductID });
        }
        public ActionResult Review1(int ProductID, int page = 1, int b = 5, string Sort = "ID")
        {



            ViewBag.ProductID = ProductID;
            var d = DBIO.getallReview_Product(ProductID, Sort).ToPagedList(page, b);
            int count1 = DBIO.getallReview_Product(ProductID, Sort).Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            return PartialView(d);
        }

        public ActionResult DeleteReview(int ID, int ProductID, int page = 1, int b = 5, string Sort = "ID")
        {
            DBIO.DeleteReview(ID);
            ViewBag.ProductID = ProductID;
            var d = DBIO.getallReview_Product(ProductID, Sort).ToPagedList(page, b);
            int count1 = DBIO.getallReview_Product(ProductID, Sort).Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            ViewBag.NumberReview = count1;
            ViewBag.AVG = DBIO.AVGRatingReview(ProductID);
            if (Sort == "ID") { ViewBag.Sort = 1; }
            else if (Sort == "Rate") { ViewBag.Sort = 2; }
            else { ViewBag.Sort = 3; }
            return PartialView(d);
        }

        public ActionResult ColorQuantity(int ID)
        {
            int a = DBIO.get1Color(ID).Quantity;
            return Content(a.ToString() + " trong kho");
        }

        public ActionResult AddCart(Cart a)
        {
            a.UserID = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            DBIO.addCart(a);
            return View();

        }

        public ActionResult TB()
        {
            UserLogin UserL = (UserLogin)(Session["SS"]);
            User User1 = DBIO.getUser_fromUserLogin(UserL);
            int a =DBIO.getCart(User1.ID).Count();
            return Content("Có " + a.ToString() + " sản phẩm trong giỏ hàng");

        }

        public ActionResult Cart()
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;

            var a = DBIO.getCart(id);
            int count1 = DBIO.getCart(id).Count();
            

            return View(a);

        }

        public ActionResult Cart1()
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            var a = DBIO.getCart(id);
            int count1 = DBIO.getCart(id).Count();
            if (count1==0)
            {
                return View("ClearCart");
            }    

            return View(a);

        }

        public ActionResult CartPage(int page = 1, int page2 = 1)
        {


            ViewBag.number = page;
            ViewBag.page = page2;

            return View();

        }

        public ActionResult DeleteCart(int ID, int pagenum = 1)
        {

            DBIO.DeleteCart(ID);
            ViewBag.number = pagenum;
           
            return RedirectToAction("Cart1", "Home", new { page = pagenum });

        }

        public ActionResult DeleteCartmini(int ID)
        {

            DBIO.DeleteCart(ID);

            return RedirectToAction("DeleteCart2", "Home");

        }


        public ActionResult DeleteCart2()
        {

            return View();

        }

        public ActionResult CountCart()
        {

            return Content(DBIO.CountCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).ToString());

        }

        public ActionResult CountCart2(int ID)
        { MyDB DB = new MyDB();
            int h = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            bool c = DB.Carts.Any(i => i.ColorID == ID & i.UserID ==h );
            if (c == true)
            {
                return Content(DBIO.CountCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).ToString());
            }
            else { return Content((DBIO.CountCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID)+1).ToString()); }


        }

        public ActionResult UpdateCart(FormCollection f)
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            MyDB DB = new MyDB();
            foreach (var a in DBIO.getCart(id))
            {
                var b = DB.Carts.FirstOrDefault(i => i.ID == a.ID);
                string name = 'c' + a.ID.ToString();
                b.Quantity = int.Parse(f[name]);
                DB.SaveChanges();
            }
            int Money = 0;
            var d = DBIO.getCart(id).Where(i=>i.checkSTT==true);
            foreach (var item in d)
            {
                var r = DBIO.getProduct_Cart(item).Price * DBIO.getProduct_Cart(item).Sale;
                int b = (int)(DBIO.getProduct_Cart(item).Price - r);
                int Sale = (int)(DBIO.getProduct_Cart(item).Sale * 100);
                Money = Money + b * item.Quantity;
            }
            ViewBag.Money = Money;

            return View("Pricetotal");

        }

        public ActionResult ClearCart()
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            DBIO.ClearCart(id);

            return View();

        }

        public ActionResult deletecheck()
        {
            MyDB DB = new MyDB();
            int id = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID;
            var a = DB.Carts.Where(i => i.UserID == id & i.checkSTT == true).ToList();
            foreach(var item in a)
            { DBIO.DeleteCart(item.ID); }    

            return RedirectToAction("Cart1", "Home");

        }

        public ActionResult Pricetotal()
        {
            var a = DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"])).ID).Where(i=>i.checkSTT==true);
            int Money = 0;
            foreach(var item in a)
            {
                var r = DBIO.getProduct_Cart(item).Price * DBIO.getProduct_Cart(item).Sale;
                int b = (int)(DBIO.getProduct_Cart(item).Price - r);
                int Sale = (int)(DBIO.getProduct_Cart(item).Sale * 100);
                Money = Money + b * item.Quantity;
            }
            ViewBag.Money = Money;
            return View();
        }

        public ActionResult changecheck(bool check,int ID)
        {
            MyDB DB = new MyDB();
            var b =DB.Carts.FirstOrDefault(i => i.ID == ID);
            b.checkSTT = check;
            DB.SaveChanges();

            return RedirectToAction("Pricetotal", "Home");

        }

        public ActionResult total()
        {
            int Money = 0;
            foreach (var item in DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList())
            {
                var r = DBIO.getProduct_Cart(item).Price * DBIO.getProduct_Cart(item).Sale;
                int b = (int)(DBIO.getProduct_Cart(item).Price - r);
                Money = Money + b * item.Quantity;
            }

            return View(Money);

        }






    }
}