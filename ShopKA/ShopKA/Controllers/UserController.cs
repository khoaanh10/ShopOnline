using DataBase;
using ShopKA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopKA.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User a, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                if (DBIO.checkUsername(a) == true)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View(a);
                }
                if (DBIO.checkEmail(a) == true)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    return View(a);
                }

                a.Birthday = f["day"].ToString() + '-' + f["month"].ToString() + '-' + f["year"].ToString();
                a.Password1 = DBIO.MD5(a.Password1);
                a.Password2 = DBIO.MD5(a.Password2);
                DBIO.addUser(a);
                return RedirectToAction("Login", "User", new { tb = true });
            }
            else
            {
                return View(a);
            }
        }

        public ActionResult Login(bool tb = false)
        {
            ViewBag.tb = tb;
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin a)
        {
            if (ModelState.IsValid)
            {
                int check = DBIO.checkLogin(a);
                if (check == 1)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc Email không đúng");
                    return View(a);
                }
                else if (check == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                    return View(a);
                }
                else if (check == 3)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa. Liên hệ ADMIN");
                    return View(a);
                }
                else
                {
                    Session.Add("SS", a);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(a);
            }
        }

        public ActionResult Logout()
        {
            Session["SS"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            User a = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"]));
            return View(a);
        }

        public ActionResult EditProfile()
        {
            ViewBag.User = DBIO.getUser_fromUserLogin((UserLogin)(Session["SS"]));
            return View();
        }
        [HttpPost]
        public ActionResult EditProfile(EditUser a, FormCollection f)
        {
            UserLogin UserL = (UserLogin)(Session["SS"]);
            User User1 = DBIO.getUser_fromUserLogin(UserL);
            
            if (ModelState.IsValid)
            {
                MyDB DB = new MyDB();
              
                if (DB.Users.Any(i=>i.Email==a.Email)&a.Email!=User1.Email)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    ViewBag.User = User1;
                    return View(a);
                }
               
                a.Birthday = f["day"].ToString() + '-' + f["month"].ToString() + '-' + f["year"].ToString();
                DBIO.EditProfile(User1, a);
                return RedirectToAction("Profile", "User");

            }
            ViewBag.User = User1;
            return View(a);
        }

       

        public ActionResult addAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addAddress(AddressDTO a)
        {
            if (ModelState.IsValid)
            {
               if (DBIO.checkAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false)
                {
                    ModelState.AddModelError("", "Tối đa được thêm 4 địa chỉ");
                    return View(a);
                }
                else
                {
                    Address b = new Address();
                    b.UserID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
                    b.Detail = a.Detail;
                    b.DistrictID = a.DistrictID;
                    b.Fullname = a.Fullname;
                    b.Phone = a.Phone;
                    b.ProvinceID = a.ProvinceID;
                    b.Ward = a.Ward;
                    if(DBIO.checkShipSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) ==false|DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID)==null)
                    {
                        b.ShipStatus = true;
                    }
                    if (DBIO.checkBillSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false|DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == null)
                    {
                        b.BillStatus = true;
                    }
                    DBIO.addAddress(b);
                    return RedirectToAction("Address","User");
                }
            }
            if(a.ProvinceID==null)
            {
                ModelState.AddModelError("", "Vui lòng chọn tỉnh");
            }    
            return View(a);
        }

        //Lấy huyện từ tỉnh 
        public ActionResult getDistrict(string ID)
        {
            var a = DBIO.getDistrict_Provice(ID);
            return View(a);
        }

        //

        public ActionResult Address()
        {
            var a = DBIO.getallAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            return View(a);
        }

        public ActionResult MakedefaultSTT(int ID)
        {
            ViewBag.type = ID;
            var a = DBIO.getallAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            return View(a);
        }
        [HttpPost]
        public ActionResult MakedefaultSTT(int ID,FormCollection f)
        {
            MyDB DB = new MyDB();
            UserLogin UserL = (UserLogin)(Session["SS"]);
            User User1 = DBIO.getUser_fromUserLogin(UserL);
            if (ID==0)
            {
                var a = DB.Addresss.FirstOrDefault(i => i.ShipStatus == true & i.UserID== User1.ID);
                if (a != null)
                {
                    a.ShipStatus = false;

                    DB.SaveChanges();
                }
                int c = int.Parse(f["check"]);
                var b = DB.Addresss.FirstOrDefault(i => i.ID == c);
                b.ShipStatus = true;
                DB.SaveChanges();
            }
            else
            {
                var a = DB.Addresss.FirstOrDefault(i => i.BillStatus == true & i.UserID==User1.ID);
                if (a != null)
                {
                    a.BillStatus = false;
                    DB.SaveChanges();
                }
                int c = int.Parse(f["check"]);
                var b = DB.Addresss.FirstOrDefault(i => i.ID == c);
                b.BillStatus = true;
                DB.SaveChanges();
            }


            return RedirectToAction("Address", "User") ;
        }

        public ActionResult DeleteAddress(int ID)
        {
            MyDB DB = new MyDB();
            if (DBIO.get1address(ID).BillStatus == true & DBIO.get1address(ID).ShipStatus == true)
            {
                DBIO.deleteAddress(ID);
                var a = DB.Addresss.FirstOrDefault();
                if (a != null)
                {
                    a.BillStatus = true;
                    a.ShipStatus = true;
                    DB.SaveChanges();
                }

            }
            else if(DBIO.get1address(ID).BillStatus == true | DBIO.get1address(ID).ShipStatus == true)
            {
                if (DBIO.get1address(ID).BillStatus == true)
                {
                    DBIO.deleteAddress(ID);
                    var a = DB.Addresss.FirstOrDefault();
                    if (a != null)
                    {
                        a.BillStatus = true;
                        DB.SaveChanges();
                    }
                }
                else if (DBIO.get1address(ID).ShipStatus == true)
                {
                    DBIO.deleteAddress(ID);
                    var a = DB.Addresss.FirstOrDefault();
                    if (a != null)
                    {
                        a.ShipStatus = true;
                        DB.SaveChanges();
                    }
                }
            }
            else
            {
                DBIO.deleteAddress(ID);
            }

            return RedirectToAction("Address", "User");
        }

        public ActionResult editAddress(int ID)
        {
            ViewBag.Address = DBIO.get1address(ID);
            return View();
        }
        [HttpPost]
        public ActionResult editAddress(AddressDTO a,int ID)
        {
            if (ModelState.IsValid)
            {

                    MyDB DB = new MyDB();
                    var b = DB.Addresss.FirstOrDefault(i => i.ID == ID);
                    b.Detail = a.Detail;
                    b.DistrictID = a.DistrictID;
                    b.Fullname = a.Fullname;
                    b.Phone = a.Phone;
                    b.ProvinceID = a.ProvinceID;
                    b.Ward = a.Ward;
                    if (DBIO.checkShipSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false)
                    {
                        b.ShipStatus = true;
                    }
                    if (DBIO.checkBillSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false)
                    {
                        b.BillStatus = true;
                    }
                    DB.SaveChanges();
                    return RedirectToAction("Address", "User");
                
            }
            if (a.ProvinceID == null)
            {
                ModelState.AddModelError("", "Vui lòng chọn tỉnh");
            }
            return View(a);
        }

        public ActionResult checkoutCart()
        {
            ViewBag.Cart = DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i=>i.checkSTT==true).ToList();
            
                ViewBag.ShipAddress = DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
                
            
            
            ViewBag.Address = DBIO.getallAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            
          
                ViewBag.BillAddress = DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);

            ViewBag.NumOrder = DBIO.GetallOrders((DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID)).Count();
            return View();
        }
        [HttpPost]
        public ActionResult checkoutshipaddress(FormCollection f,int ID,string type)
        {
            int ID1;
            int ID2;
            if(type=="ship")
            {
                ID1 = int.Parse(f["checkship"]);
                ID2 = ID;
            }
            else
            {
                ID2 = int.Parse(f["checkbill"]);
                ID1 = ID;
            }
            ViewBag.type = type;
            ViewBag.ship = DBIO.get1address(ID1);
            ViewBag.bill = DBIO.get1address(ID2);
            return View();

        }
        [HttpPost]
        public ActionResult checkoutbilladdress(FormCollection f, int ID1)
        {
            int ID2 = int.Parse(f["checkbill"]);
            return RedirectToAction("checkoutCart", "User", new { ID1 = ID1, ID2 = ID2 });

        }
        [HttpPost]
        public ActionResult addAddress2(AddressDTO a)
        {
            if (ModelState.IsValid)
            {
                if (DBIO.checkAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false)
                {
                    ModelState.AddModelError("", "Tối đa được thêm 4 địa chỉ");
                    return View(a);
                }
                else
                {
                    Address b = new Address();
                    b.UserID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
                    b.Detail = a.Detail;
                    b.DistrictID = a.DistrictID;
                    b.Fullname = a.Fullname;
                    b.Phone = a.Phone;
                    b.ProvinceID = a.ProvinceID;
                    b.Ward = a.Ward;
                    if (DBIO.checkShipSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false | DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == null)
                    {
                        b.ShipStatus = true;
                    }
                    if (DBIO.checkBillSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false | DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == null)
                    {
                        b.BillStatus = true;
                    }
                    DBIO.addAddress(b);
                    ViewBag.tb = "Thêm thành công";
                    return View(a);

                }
            }
            if (a.ProvinceID == null)
            {
                ModelState.AddModelError("", "Vui lòng chọn tỉnh");
            }
            return View(a);
        }

        public ActionResult checkoutPD(int ID)
        { MyDB DB = new MyDB();

            var a = DB.Carts.FirstOrDefault(i => i.ID == ID);
            a.checkSTT = false;
            DB.SaveChanges();
            var b = DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList();
            return View(b);

        }

        public ActionResult checkoutMoney()
        {
            
            int Money = 0;
            foreach (var item in DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList())
            {
                var r = DBIO.getProduct_Cart(item).Price * DBIO.getProduct_Cart(item).Sale;
                int b = (int)(DBIO.getProduct_Cart(item).Price - r);
                Money = Money + b * item.Quantity; }
            
            return View(Money);

        }

        public ActionResult addOrder(int payment,int shipID, int billID)
        {
            MyDB DB = new MyDB();
            Order order = new Order();
            int ID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
           
                order.UserID = ID;
            order.payment = payment;
            Address ship = DBIO.get1address(shipID);
            order.ShipAddress = ship.Detail + " - " + ship.Ward + " - " + DBIO.get1District(ship.DistrictID).Name + " - "  + DBIO.get1Province(ship.ProvinceID).Name;
            order.ShipPhone = ship.Phone;
            order.ShipName = ship.Fullname;
            Address bill = DBIO.get1address(billID);
            order.BillAddress = bill.Detail + " - "  + bill.Ward + " - "  + DBIO.get1District(bill.DistrictID).Name + " - " + DBIO.get1Province(bill.ProvinceID).Name;
            order.BillPhone = bill.Phone;
            order.BillName = bill.Fullname;



            DBIO.addOrder(order);
                var e = DB.Orders.OrderByDescending(i => i.ID).FirstOrDefault(i => i.UserID == ID);

                foreach (var item in DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList())
            {
                var d = DB.Colors.Single(i => i.ID == item.ColorID);
                ProductOrder b = new ProductOrder();
                    b.OrderID = e.ID;
                    b.ColorID = item.ColorID;
                    b.Image = DBIO.getProduct_Cart(item).Image;
                    b.PDName = DBIO.getProduct_Cart(item).ProductName + " - " + DBIO.getColor_Cart(item).ColorName;
                if (d.Quantity == 0)
                {
                    return RedirectToAction("Cart", "Home");
                }
                else if (d.Quantity > item.Quantity)
                {
                    b.Quantity = item.Quantity;
                    d.Quantity = d.Quantity - item.Quantity;
                    DB.SaveChanges();
                    var h = DB.Carts.Where(i => i.ColorID == d.ID &i.Quantity>d.Quantity & i.UserID != ID).ToList();
                    if (h.Count > 0) { 
                    foreach (var item2 in h)
                    {
                        var cart = DB.Carts.Single(i => i.ID == item2.ID);
                        cart.Quantity = d.Quantity;
                        DB.SaveChanges();
                    } }
                }
                else if(d.Quantity<=item.Quantity)
                {
                    b.Quantity = d.Quantity;
                    d.Quantity = 0;
                    DB.SaveChanges();
                    var h = DB.Carts.Where(i => i.ColorID == d.ID &i.UserID!=ID).ToList();
                    if (h.Count() > 0)
                    {
                        foreach (var item2 in h)
                        {
                            var cart = DB.Carts.Single(i => i.ID == item2.ID);
                            DB.Carts.Remove(cart);
                            DB.SaveChanges();
                        }
                    }
                }    
                    b.Price = (int)(DBIO.getProduct_Cart(item).Price - (float)(DBIO.getProduct_Cart(item).Sale * DBIO.getProduct_Cart(item).Price));
                    DB.ProductOrders.Add(b);
                    DB.SaveChanges();
                   
                
               
                    
                    
                    if (DBIO.CountProductofColor(d.ProductID) == 0)
                    {
                        DB.Products.Single(i => i.ID == d.ProductID).Status = false;
                        DB.SaveChanges();
                    }
                    var c = DB.Carts.FirstOrDefault(i => i.ID == item.ID);
                    DB.Carts.Remove(c);
                    DB.SaveChanges();



                }

                return RedirectToAction("Order", "User");
            
        }

        public ActionResult Order()
        {
            var a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            return View(a);
        }

        public ActionResult DeleteOrder(int ID)
        { MyDB DB = new MyDB();

            var c = DBIO.getallPDOrder(ID);
            foreach(var item in c)
            {
                var d = DB.Colors.Single(i=>i.ID==item.ColorID);
                if(d!=null)
                {
                    d.Quantity = item.Quantity + d.Quantity;
                    DB.SaveChanges();
                }
                if (DBIO.CountProductofColor(d.ProductID) > 0)
                {
                    DB.Products.Single(i => i.ID == d.ProductID).Status = true;
                    DB.SaveChanges();
                }
            }
            
            DBIO.deleteorder(ID);
            var a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            return View(a);
        }

        public ActionResult ManagerAcc()
        {
            int ID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            var a = DBIO.GetallOrders(ID).Take(5).ToList();
            ViewBag.ShipAddress= DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            ViewBag.BillAddress= DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            ViewBag.User = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]);
            return View(a);
        }

        public ActionResult SortOrder(int ID)
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            MyDB DB = new MyDB();
            List<Order> a= new List<Order>();
            if(ID==1)
            {
                a = DB.Orders.OrderByDescending(i=>i.ID).Where(i =>i.UserID==id & i.Status < 4).ToList();
                
            }
            else if (ID == 4)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i =>i.UserID==id& i.Status == 4).ToList();
                
            }
            else if (ID == 5)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID==id&i.Status >= 5).ToList();
                
            }
            else
            {
                a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
                
            }
            return View(a);

        }

        public ActionResult ManageOrder(int ID)
        {
            var a = DBIO.getallPDOrder(ID);
            var order = DBIO.Get1Orders(ID);
            ViewBag.ShipAddress = order.ShipAddress;
            ViewBag.ShipPhone = order.ShipPhone;
            ViewBag.ShipName = order.ShipName;
            ViewBag.BillAddress = order.BillAddress;
            ViewBag.BillPhone = order.BillPhone;
            ViewBag.BillName = order.BillName;
            ViewBag.Orther = order;
            int Money = 0;
            foreach(var item in a)
            {

                int b = item.Price;
                Money = Money + b*item.Quantity ;
            }
            ViewBag.Money = Money;
           
            
            return View(a);
        }





    }
}