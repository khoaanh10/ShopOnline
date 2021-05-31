using DataBase;
using Facebook;
using PagedList;
using reCAPTCHA.MVC;
using ShopKA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace ShopKA.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;

            }
        }
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidator(RequiredMessage ="Vui lòng xác minh")]
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
                ViewBag.User = a;
                string code = DBIO.RandomString(6);
                DBIO.SendEmail(a.Email, "Mã xác nhận đăng ký", "Mã xác nhận đăng ký tài khoản của bạn là " + code);
                Session.Add("code", code);
                TempData["User"] = a;
                //ViewData["User"] = a;
                //DBIO.addUser(a);
                return RedirectToAction("Confirm", "User") ;
            }
            else
            {
                return View(a);
            }
        }
        public ActionResult Confirm()
        {
            User a = (User)TempData["User"];
            TempData.Remove("User");
            
            return View(a);
        }
        public ActionResult SendAgain(string email)
        {
            string code = DBIO.RandomString(6);
            Session["code"] = code;
            DBIO.SendEmail(email, "Mã xác nhận đăng ký", "Mã xác nhận đăng ký tài khoản của bạn là " + code);
            return Content("Gửi lại mã xác nhận sau: <span id='countdown'>60</span> giây.");
        }
        [HttpPost]
        public ActionResult Confirm(FormCollection a)
        {
            User User = (User)TempData["User"];
            TempData.Remove("User");
            string code = a["code"];
            if (code ==(string)Session["code"])
            {
                DBIO.addUser(User);
                Session.Remove("code");
                return RedirectToAction("Login", "User", new { tb = true });
            }
            else
            {
                ViewBag.TB = "Mã xác nhận không đúng";
                return View(User);
            }
        }
        public ActionResult LoginFb()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new { 
            client_id = ConfigurationManager.AppSettings["IDFB"],
            client_secret = ConfigurationManager.AppSettings["Secret"],
            redirect_uri = RedirectUri.AbsoluteUri,
            response_type="code",
            scope="email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["IDFB"],
                client_secret = ConfigurationManager.AppSettings["Secret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if(!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string username = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                MyDB DB = new MyDB();
                if(DB.Users.Any(i=>i.Email==email)==false)
                {
                    User FBuser = new User();
                    FBuser.Email = email;
                   
                    FBuser.Username = email;
                    
                    FBuser.Birthday = (new DateTime(1990, 1, 1)).ToString();
                    FBuser.Fullname = firstname + " " + middlename + " " + lastname;
                    FBuser.Gender = true;
                    FBuser.Address = "";
                    FBuser.Phone="";
                    FBuser.Password1 = DBIO.MD5(DBIO.RandomString(6));
                    FBuser.Password2 = FBuser.Password1;
                    DB.Users.Add(FBuser);
                    DB.SaveChanges();
                    UserLogin a = new UserLogin();
                    a.UserName = FBuser.Email;
                    a.Password = "facebook";
                    Session.Add("SS", a);
                    FormsAuthentication.SetAuthCookie(a.UserName, false);
                    


                }
                else
                {
                    UserLogin a = new UserLogin();
                    
                   
                    a.UserName = email;
                    
                    a.Password = "facebook";
                    Session.Add("SS", a);
                    FormsAuthentication.SetAuthCookie(a.UserName, false);
                    
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login(bool tb = false)
        {
            ViewBag.tb = tb;
            return View();
        }
        [HttpPost]
        [CaptchaValidator(RequiredMessage = "Vui lòng xác minh")]
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
                    FormsAuthentication.SetAuthCookie(a.UserName,false);
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

            FormsAuthentication.SignOut();
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

                if (DB.Users.Any(i => i.Email == a.Email) & a.Email != User1.Email)
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
                    if (DBIO.checkShipSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false | DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == null)
                    {
                        b.ShipStatus = true;
                    }
                    if (DBIO.checkBillSTTaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == false | DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID) == null)
                    {
                        b.BillStatus = true;
                    }
                    DBIO.addAddress(b);
                    return RedirectToAction("Address", "User");
                }
            }
            if (a.ProvinceID == null)
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
        public ActionResult MakedefaultSTT(int ID, FormCollection f)
        {
            MyDB DB = new MyDB();
            UserLogin UserL = (UserLogin)(Session["SS"]);
            User User1 = DBIO.getUser_fromUserLogin(UserL);
            if (ID == 0)
            {
                var a = DB.Addresss.FirstOrDefault(i => i.ShipStatus == true & i.UserID == User1.ID);
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
                var a = DB.Addresss.FirstOrDefault(i => i.BillStatus == true & i.UserID == User1.ID);
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


            return RedirectToAction("Address", "User");
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
            else if (DBIO.get1address(ID).BillStatus == true | DBIO.get1address(ID).ShipStatus == true)
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
        public ActionResult editAddress(AddressDTO a, int ID)
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
            DBIO.checkVoucher();
            ViewBag.Cart = DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList();

            ViewBag.ShipAddress = DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);



            ViewBag.Address = DBIO.getallAddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);


            ViewBag.BillAddress = DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);

            ViewBag.NumOrder = DBIO.GetallOrders((DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID)).Count(i=>i.Status<4);
            return View();
        }
        [HttpPost]
        public ActionResult checkoutshipaddress(FormCollection f, int ID, string type)
        {
            int ID1;
            int ID2;
            if (type == "ship")
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
        {
            MyDB DB = new MyDB();

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
                Money = Money + b * item.Quantity;
            }

            return View(Money);

        }

        public ActionResult addOrder(int payment, int shipID, int billID,string Code)
        {
            var id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            MyDB DB = new MyDB();
            if (DB.Carts.Count(i => i.UserID == id & i.checkSTT == true) > 0)
            {
                Order order = new Order();
                int ID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;

                order.UserID = ID;
                order.payment = payment;
                Address ship = DBIO.get1address(shipID);
                order.ShipAddress = ship.Detail + " - " + ship.Ward + " - " + DBIO.get1District(ship.DistrictID).Name + " - " + DBIO.get1Province(ship.ProvinceID).Name;
                order.ShipPhone = ship.Phone;
                order.ShipName = ship.Fullname;
                Address bill = DBIO.get1address(billID);
                order.BillAddress = bill.Detail + " - " + bill.Ward + " - " + DBIO.get1District(bill.DistrictID).Name + " - " + DBIO.get1Province(bill.ProvinceID).Name;
                order.BillPhone = bill.Phone;
                order.BillName = bill.Fullname;
                if (DB.Vouchers.Any(i => i.Code == Code & i.Status == true))
                {
                    var a = DB.Vouchers.FirstOrDefault(i => i.Code == Code);

                    if (DB.Voucherlogs.Any(i => i.Code == a.Code & i.UserID == id)==false)
                    {

                        Voucherlog log = new Voucherlog();
                        log.Code = Code;
                        log.UserID = id;
                        DB.Voucherlogs.Add(log);
                        DB.SaveChanges();
                        a.Quantity = a.Quantity - 1;
                        DB.SaveChanges();
                        if(a.Quantity==0)
                        {
                            a.Status = false;
                            DB.SaveChanges();
                        }    
                        order.Voucher = Code;
                        order.Maximum = a.Maximum;
                        order.SalePrice = a.OrderSale;
                        order.SaleShip = a.ShipSale;
                    }
                }



                DBIO.addOrder(order);

                var e = DB.Orders.OrderByDescending(i => i.ID).FirstOrDefault(i => i.UserID == ID);

                foreach (var item in DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList())
                {
                    var d = DB.Colors.SingleOrDefault(i => i.ID == item.ColorID);
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
                        var h = DB.Carts.Where(i => i.ColorID == d.ID & i.Quantity > d.Quantity & i.UserID != ID).ToList();
                        if (h.Count > 0)
                        {
                            foreach (var item2 in h)
                            {
                                var cart = DB.Carts.SingleOrDefault(i => i.ID == item2.ID);
                                cart.Quantity = d.Quantity;
                                DB.SaveChanges();
                            }
                        }
                    }
                    else if (d.Quantity <= item.Quantity)
                    {
                        b.Quantity = d.Quantity;
                        d.Quantity = 0;
                        DB.SaveChanges();
                        var h = DB.Carts.Where(i => i.ColorID == d.ID & i.UserID != ID).ToList();
                        if (h.Count() > 0)
                        {
                            foreach (var item2 in h)
                            {
                                var cart = DB.Carts.SingleOrDefault(i => i.ID == item2.ID);
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
                        DB.Products.SingleOrDefault(i => i.ID == d.ProductID).Status = false;
                        DB.SaveChanges();
                    }
                    var c = DB.Carts.FirstOrDefault(i => i.ID == item.ID);
                    DB.Carts.Remove(c);
                    DB.SaveChanges();



                }
            }

            return RedirectToAction("Order", "User");

        }

        public ActionResult Order(int page=1, int b=5)
        {
            var a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).ToPagedList(page,b);
            var count1 = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            return View(a);
        }

        public ActionResult DeleteOrder(int ID,int ID2,int page=1,int b=5)
        {
            MyDB DB = new MyDB();
            int id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            if (ID != -1)
            {
                var c = DBIO.getallPDOrder(ID);
                foreach (var item in c)
                {
                    var d = DB.Colors.SingleOrDefault(i => i.ID == item.ColorID);
                    if (d != null)
                    {
                        d.Quantity = item.Quantity + d.Quantity;
                        DB.SaveChanges();

                        if (DBIO.CountProductofColor(d.ProductID) > 0 & DB.Products.SingleOrDefault(i => i.ID == d.ProductID) != null)
                        {
                            DB.Products.SingleOrDefault(i => i.ID == d.ProductID).Status = true;
                            DB.SaveChanges();
                        }
                    }
                }
                
                var order = DB.Orders.SingleOrDefault(i => i.ID == ID);
                var vc = DB.Vouchers.SingleOrDefault(i => i.Code == order.Voucher);
                if (vc != null)
                {
                    vc.Quantity = vc.Quantity + 1;
                    if (vc.End > DateTime.UtcNow.AddHours(7))
                    {
                        vc.Status = true;
                        DB.SaveChanges();
                    }

                }
                var log = DB.Voucherlogs.SingleOrDefault(i => i.Code == order.Voucher & i.UserID == id);
                if (log != null)
                {
                    DB.Voucherlogs.Remove(log);
                    DB.SaveChanges();
                }

                DBIO.deleteorder(ID);
            }
            var a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            if (ID2 == 1)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status < 4).ToList();

            }
            else if (ID2 == 4)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status == 4).ToList();

            }
            else if (ID2 == 5)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status >= 5).ToList();

            }
            else
            {
               

            }
            var count1 = a.Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            var a1 = a.ToPagedList(page, b);
            return View(a1);
            
        }

        public ActionResult ManagerAcc()
        {
            int ID = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            var a = DBIO.GetallOrders(ID).Take(5).ToList();
            ViewBag.ShipAddress = DBIO.getshipaddress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            ViewBag.BillAddress = DBIO.getbilladdress(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);
            ViewBag.User = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]);
            return View(a);
        }

        public ActionResult SortOrder(int ID,int page=1,int b=5)
        {
            int id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
            MyDB DB = new MyDB();
            List<Order> a = new List<Order>();
            if (ID == 1)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status < 4).ToList();

            }
            else if (ID == 4)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status == 4).ToList();

            }
            else if (ID == 5)
            {
                a = DB.Orders.OrderByDescending(i => i.ID).Where(i => i.UserID == id & i.Status >= 5).ToList();

            }
            else
            {
                a = DBIO.GetallOrders(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID);

            }
            var count1 = a.Count();
            if (count1 % b == 0)
            { ViewBag.page = count1 / b; }
            else { ViewBag.page = count1 / b + 1; }
            ViewBag.number = page;
            var a1 = a.ToPagedList(page, b);
            return View(a1);

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
            foreach (var item in a)
            {

                int b = item.Price;
                Money = Money + b * item.Quantity;
            }
            ViewBag.Money = Money;


            return View(a);
        }

        public ActionResult EditPassWord()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidator(RequiredMessage = "Vui lòng xác minh")]
        public ActionResult EditPassWord(EditPassWord a)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TB = false;
                MyDB DB = new MyDB();
                var c = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]);
                var b = DB.Users.SingleOrDefault(i => i.ID == c.ID);
                if (DBIO.MD5(a.Oldpass) != b.Password1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                    return View(a);
                }
                else
                {
                    b.Password1 = DBIO.MD5(a.Newpass1);
                    b.Password2 = DBIO.MD5(a.Newpass2);
                    DB.SaveChanges();
                    ViewBag.TB = true;
                    return View(a);
                }
            }
            else
            {
                return View(a);
            }
        }

        public ActionResult ForgetPassWord()
        {
            ViewBag.TB = null;
            return View();
        }
        [HttpPost]
        [CaptchaValidator(RequiredMessage = "Vui lòng xác minh")]
        public ActionResult ForgetPassWord(FormCollection f)
        {
            MyDB DB = new MyDB();
            var username = f["username"];
            var email = f["email"];
            ViewBag.TB2 = null;
            ViewBag.TB = null;
            if (DB.Users.Any(i => i.Username.ToLower() == username.ToLower()) == false)
            {
                ViewBag.TB2 = "Tên tài khoản không tồn tại";
                return View(f);
            }
            else
            {
                var a = DB.Users.SingleOrDefault(i => i.Username.ToLower() == username.ToLower());
                if (DBIO.isEmail(email) == false)
                {
                    ViewBag.TB2 = "Email không đúng định dạng";
                    return View(f);
                }
                else
                {
                    if (a.Email.ToLower() != email.ToLower())
                    {
                        ViewBag.TB2 = "Email không đúng";
                        return View(f);
                    }
                    else
                    {
                        string random = DBIO.RandomString(6);
                        a.Password1 = DBIO.MD5(random);
                        a.Password2 = DBIO.MD5(random);
                        DB.SaveChanges();
                        DBIO.SendEmail(email, "Lấy lại mật khẩu", "Mật khẩu mới của bạn là " + random);
                        ViewBag.TB = "Mật khẩu mới đã được gửi đến email " + email;
                        return View(f);
                    }
                }
            }
        }

        public ActionResult CheckVoucher(string code, int SLSP, int money, int test = -1)
        {
            if (test == -1)
            {
                MyDB DB = new MyDB();
                if (DB.Vouchers.Any(i => i.Code == code & i.Status == true) == false)
                {
                    if (DB.Vouchers.Any(i => i.Status == false & i.Code == code))
                    {
                        ViewBag.check = 5;

                        return View();
                    }
                    else
                    {
                        ViewBag.check = 1;
                        return View();
                    }
                }
                else
                {
                    var a = DB.Vouchers.FirstOrDefault(i => i.Code == code);
                    var id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
                   
                    if (DB.Voucherlogs.Any(i => i.Code == a.Code & i.UserID == id))
                    {
                        ViewBag.check = 2;

                        return View();
                    }
                    else if ((SLSP >= a.QuantityCondition & money >= a.PriceOrderCondition) == false)
                    {
                        ViewBag.check = 3;

                        return View();
                    }
                    else
                    {
                        ViewBag.type = false;
                        if (a.Type == true)
                        {
                            ViewBag.type = true;
                        }
                        ViewBag.voucher = a;
                        ViewBag.check = 4;
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.check = 0;
                return View();
            }
        }

        public ActionResult MoneyVoucher(string code,int SLSP,int money)
        {
            MyDB DB = new MyDB();
            int Money = 0;
            
           
            
            

            foreach (var item in DBIO.getCart(DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID).Where(i => i.checkSTT == true).ToList())
            {
                var r = DBIO.getProduct_Cart(item).Price * DBIO.getProduct_Cart(item).Sale;
                int b = (int)(DBIO.getProduct_Cart(item).Price - r);
                Money = Money + b * item.Quantity;
            }

            if (DB.Vouchers.Any(i => i.Code == code & i.Status == true) == false)
            {
                ViewBag.Money = Money;
                ViewBag.ship = 100000;
                ViewBag.voucher = null;
                return View();
            }
            else
            {
                var a = DB.Vouchers.FirstOrDefault(i => i.Code == code);
                var id = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]).ID;
                if (DB.Voucherlogs.Any(i => i.Code == a.Code & i.UserID == id))
                {
                    ViewBag.Money=Money;
                    ViewBag.ship = 100000;
                    ViewBag.voucher = null;
                    return View();
                }
                else if ((SLSP >= a.QuantityCondition & money >= a.PriceOrderCondition) == false)
                {
                    ViewBag.Money = Money;
                    ViewBag.ship = 100000;
                    ViewBag.voucher = null;
                    return View();
                }
                else
                {
                    ViewBag.voucher=a;
                    if (a.Type == true)
                    {
                        if (Money * a.OrderSale > a.Maximum)
                        {

                            ViewBag.Money = Money - a.Maximum;
                        }
                        else
                        {
                            ViewBag.Money = Money - Money * a.OrderSale;
                        }
                        ViewBag.ship = 100000;
                    }
                    else
                    {
                        ViewBag.ship = 100000 - 100000 * a.ShipSale;
                        ViewBag.Money = Money;
                    }
                    return View();
                    
                }
            }

            




        }

       
    }
}