using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DataBase;
using PagedList;

namespace ShopKA.Models
{
    public class DBIO
    {
        static MyDB DB = new MyDB();
        //ProductAdmin





        //

        // Lấy ra tất cả Sp
        public static List<Product> getallProduct()
        {
            return DB.Products.ToList();
        }
        //Lấy ra tất cả loại SP
        public static List<ProductT> getallProductT()
        {
            return DB.Database.SqlQuery<ProductT>("SELECT * FROM PRODUCTTS").ToList();
        }
        //Lấy ra tất cả NSX
        public static List<Producer> getProducer_type(int ID)
        {
            return DB.Database.SqlQuery<Producer>("SELECT * FROM PRODUCERS WHERE PRODUCTTID= '" + ID + "'").ToList();
        }

        //Lấy ra 1 SP dựa vào ID
        public static Product get1Product(int ID)
        {
            return DB.Products.FirstOrDefault(x => x.ID == ID);
        }
        //Lấy ra 1 NSX dựa vào ID
        public static Producer get1Producer_ProducerID(int ProducerID)
        {
            return DB.Database.SqlQuery<Producer>("SELECT * FROM PRODUCERS WHERE ID= '" + ProducerID + "'").FirstOrDefault();
        }
        //Lấy ra 1 loại SP dựa vào ID
        public static ProductT get1ProductT_ProductTID(int ProductTID)
        {

            return DB.ProductTs.FirstOrDefault(x => x.ID == ProductTID);
        }
        //xóa 1 sp dựa vào ID
        public static void DeleteProduct(int ID)
        {
            Product A = DB.Products.FirstOrDefault(x => x.ID == ID);
            DB.Products.Remove(A);
            DB.SaveChanges();
        }
        //Sửa 1 SP
        public static void EditProduct(Product B)
        {
            Product A = DB.Products.FirstOrDefault(x => x.ID == B.ID);

            A.ProductName = B.ProductName;
            A.ProducerID = B.ProducerID;
            A.Price = B.Price;
            A.Image = B.Image != null ? B.Image: A.Image;
            A.Image2 = B.Image2!= null ? B.Image2 : A.Image2;
            A.Image3 = B.Image3 != null ? B.Image3 : A.Image3;
            A.Image4 = B.Image4 != null ? B.Image4: A.Image4;
            A.Image5 = B.Image5!= null ? B.Image5 : A.Image5;
            A.Note = B.Note;
           
            A.Launch = B.Launch;
            A.Configuration = B.Configuration;

            DB.SaveChanges();
        }
        //Covert hình to base 64
        

        //Lấy ra tất cả màu của 1 SP có ID = ID
        public static List<Color> getallColor(int ID)
        {
            return DB.Database.SqlQuery<Color>("SELECT * FROM COLORS WHERE PRODUCTID= '" + ID + "'").ToList();
        }
        public static Color get1ColorFirst(int ID)
        {
            return DB.Database.SqlQuery<Color>("SELECT * FROM COLORS WHERE PRODUCTID= '" + ID + "'").FirstOrDefault();
        }

        //Thêm 1 màu
        public static void addColor(Color a)
        {
            DB.Colors.Add(a);
            DB.SaveChanges();
        }
        //Sửa 1 màu
        public static void editColor(Color a)
        {
            var A = DB.Colors.FirstOrDefault(x => x.ID == a.ID);
            A.Quantity = a.Quantity;
            A.ColorName = a.ColorName;

            DB.SaveChanges();
        }
        //Xóa 1 màu
        public static void deleteColor(int a)
        {
            var A = DB.Colors.FirstOrDefault(x => x.ID == a);
            DB.Colors.Remove(A);
            DB.SaveChanges();
        }
        //Lấy ra 1 màu dựa vào ID
        public static Color get1Color(int ID)
        {
            return DB.Colors.FirstOrDefault(x => x.ID == ID);
        }

        //Lấy ra 1 màu dựa vào ID Product
        public static Color get1Color_ProductID(int ID)
        {
            return DB.Colors.FirstOrDefault(x => x.ProductID == ID);
        }
        //Loại SP và NSX









        //

        //Đếm số NSX trong Loại SP có ID=ID
        public static int Count_Producer_ProductT(int ID)
        {
            return DB.Producers.Count(x => x.ProductTID == ID);
        }
        //Đếm số SP của NSX có ID=ID
        public static int Count_Product_Producer(int ID)
        {
            return DB.Products.Count(x => x.ProducerID == ID);

        }
        //Đếm số sp của loại SP có ID=ID
        public static int Count_Product_ProductT(int ID)
        {
            List<Producer> a = DBIO.getProducer_type(ID);
            int s = 0;
            foreach (var item in a)
            {
                s = s + DBIO.Count_Product_Producer(item.ID);
            }
            return s;
        }
        //Thêm loại SP
        public static void addProductT(ProductT a)
        {
            DB.ProductTs.Add(a);
            DB.SaveChanges();
        }
        //Sửa loại SP
        public static void editProductT(ProductT a)
        {
            var A = DB.ProductTs.FirstOrDefault(x => x.ID == a.ID);
            A.ProducTName = a.ProducTName;

            DB.SaveChanges();
        }
        //Xóa 1 loại SP dựa vào ID
        public static void deleteProductT(int a)
        {
            var A = DB.ProductTs.FirstOrDefault(x => x.ID == a);
            DB.ProductTs.Remove(A);
            DB.SaveChanges();
        }
        //Thêm NSX
        public static void addProducer(Producer a)
        {
            DB.Producers.Add(a);
            DB.SaveChanges();
        }
        //Sửa NSX
        public static void editProducer(Producer a)
        {
            var A = DB.Producers.FirstOrDefault(x => x.ID == a.ID);
            A.ProducerName = a.ProducerName;

            DB.SaveChanges();
        }
        //Xóa 1 NSX dựa vào ID
        public static void deleteProducer(int a)
        {
            var A = DB.Producers.FirstOrDefault(x => x.ID == a);
            DB.Producers.Remove(A);
            DB.SaveChanges();
        }
        //Lấy các NSX của Loại SP có ID
        public static List<Producer> getallProducer_ProductT(int ID)
        {
            return DB.Database.SqlQuery<Producer>("SELECT * FROM PRODUCERS WHERE PRODUCTTID= '" + ID + "'").ToList();
        }
        //lấy ra tất cae SP của NSX
        public static List<Product> getallProduct_ProducerID(int ID)
        {
            return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE PRODUCERID='" + ID + "'").ToList();
        }
        //laays tat ca san pham xep theo ID giam dan
        public static List<Product> getall8ProductLasted()
        {

            return DB.Database.SqlQuery<Product>("SELECT TOP 8 * FROM PRODUCTS WHERE STATUS = 'TRUE' AND LAUNCH='TRUE' ORDER BY ID DESC").ToList();
        }

        //thay doi status SP
        public static void ChangeSTT(int ID)

        {
            var a = DB.Products.FirstOrDefault(i => i.ID == ID);
            a.Status = !a.Status;
            DB.SaveChanges();
        }
        // Lay ra 6 san pham cua loai SP

        public static List<Product> get8Product_ProductT(int ID)
        {
            List<Product> PD = new List<Product>();
            List<Producer> a = DBIO.getallProducer_ProductT(ID);
            foreach (var item in a)
            {
                var c = DBIO.getallProduct_ProducerID(item.ID).Where(i => i.Status == true);
                foreach (var d in c)
                {
                    PD.Add(d);
                }
            }
            return PD.OrderByDescending(i=>i.ID).ToList();

        }

        //Lay ra SP sale nhieu nhat
        public static List<Product> getallProductSale()
        {

            return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS = 'TRUE',SALE>0 ORDER BY SALE DESC").ToList();
        }

        public static List<Product> get8ProductSale()
        {

            return DB.Database.SqlQuery<Product>("SELECT TOP 8 * FROM PRODUCTS WHERE STATUS = 'TRUE' AND SALE>0 ORDER BY SALE DESC").ToList();
        }
        //thay doi launch
        public static void ChangeLaunch(int ID)

        {
            var a = DB.Products.FirstOrDefault(i => i.ID == ID);
            a.Launch = !a.Launch;
            DB.SaveChanges();
        }

        public List<Product> GetProductForPaging()
        {
            List<Product> pr = DB.Products.Take(10).Skip(1).ToList();
            string sql = "getlistProductForPaging";

            DB.Database.ExecuteSqlCommand(sql, new SqlParameter("@pageSize", 0), new SqlParameter("@pageIndex", 1));
            return pr;
        }


        //Lay ra 4 SP tuong tu
        public static List<Product> get4SameProduct(int ID)
        {
            var a = DB.Products.First(i => i.ID == ID).ProducerID;
            return DB.Database.SqlQuery<Product>("SELECT TOP 4 * FROM PRODUCTS WHERE STATUS = 'TRUE' AND LAUNCH ='TRUE' AND PRODUCERID='" + a + "' AND ID != '" + ID + "' ORDER BY ID DESC").ToList();
        }
        //Lay ra 2 sản phẩm sale sắp hết hạn

        //public static List<Product> get2Sale()
        //{
        //    return DB.Products.Where(i => i.Sale > 0).OrderBy(i =>i.SaleTimeEnd).Take(2).ToList();
        //}



        //User






        //thêm User

        public static void addUser(User a)
        {
            DB.Users.Add(a);
            DB.SaveChanges();
        }

        //Kiem tra UserName va Email co bi trung ko
        public static bool checkUsername(User a)
        {
            return DB.Users.Any(i => i.Username == a.Username);
        }
        public static bool checkEmail(User a)
        {
            return DB.Users.Any(i => i.Email == a.Email);
        }
        //ma hoa mat khau

        public static string MD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        //Kiem tra dang nhap
        public static int checkLogin(UserLogin a)
        {
            if (DB.Users.Any(i => i.Username == a.UserName || i.Email == a.UserName))
            {
                var b = DB.Users.FirstOrDefault(i => i.Username == a.UserName || i.Email == a.UserName);
                if (DBIO.MD5(a.Password) == b.Password1)
                {
                    if (b.Status == true)
                    {
                        return 0;
                    }
                    else
                    {
                        return 3;
                    }

                }
                else { return 2; }
            }
            else { return 1; }
        }
        //Lấy ra User từ UserLogin
        public static User getUser_fromUserLogin(UserLogin a)
        {
            return DB.Users.FirstOrDefault(i => i.Username == a.UserName);
        }
        //lấy ra User từ ID
        public static User get1User_ID(int ID)
        {
            return DB.Users.FirstOrDefault(i => i.ID == ID);
        }
        //Sửa Profile

        public static void EditProfile(User a, EditUser c)
        {
            var b = DBIO.get1User_ID(a.ID);
            b.Fullname = c.Fullname;
            b.Email = c.Email;
            b.Phone = c.Phone;
            b.Birthday = c.Birthday;
            b.Gender = c.Gender;
            DB.SaveChanges();

        }



        //Home//








        //sp sap ras mawts
        public static List<Product> GetProductLaunch()
        {
            return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS = 'TRUE' AND LAUNCH='FALSE' ORDER BY ID DESC").ToList();
        }
        //lay ra san pham cua nsx theo dieu kien 
        public static List<Product> GetProduct_home(int ProducerID, string Sort, int max, int min, string dk = "DESC")
        {
            if (max == 0)
            { max = (int)DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS ORDER BY PRICE DESC").First().Price; }
            if (Sort == "Price")
            { Sort = "Price-Price*Sale"; }
            if (Sort == "Price2")
            { dk = ""; Sort = "Price-Price*Sale"; }
            if (ProducerID != -1)
            {
                return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE PRODUCERID= '" + ProducerID + "' AND STATUS='TRUE' AND LAUNCH='TRUE' AND PRICE-PRICE*SALE>='" + min + "' AND PRICE-PRICE*SALE<='" + max + "' ORDER BY " + Sort + " " + dk + "").ToList();
            }
            else
            {
                return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE STATUS='TRUE' AND LAUNCH='TRUE' AND LAUNCH='TRUE' AND PRICE-PRICE*SALE>='" + min + "' AND PRICE-PRICE*SALE<='" + max + "' ORDER BY " + Sort + " " + dk + "").ToList();
            }
        }


        //Dem so luong mau cua sp
        public static int CountColor(int ID)
        {
            return DB.Colors.Count(i => i.ProductID == ID);
        }

        //Dem so luong san pham moi mau cua sp
        public static int CountProductofColor(int ID)
        {
            int Q = 0;
            var a = DB.Database.SqlQuery<Color>("SELECT * FROM COLORS WHERE PRODUCTID='" + ID + "'").ToList();
            foreach (var item in a)
            {
                Q = Q + item.Quantity;
            }
            return Q;

        }



        //Lay ra dsach SP theo ProductT
        public static List<Product> getProduct_ProductT_home(string Sort, int max, int min, int ProductTID)
        {
            List<Product> DS = new List<Product>();
            var a = DBIO.getallProducer_ProductT(ProductTID);
            if (max == 0)
            { max = (int)DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS ORDER BY PRICE DESC").First().Price; }
            foreach (var item in a)
            {
                var b = DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE PRODUCERID= '" + item.ID + "' AND STATUS='TRUE' AND LAUNCH='TRUE' AND PRICE-PRICE*SALE>='" + min + "' AND PRICE-PRICE*SALE<='" + max + "'").ToList();
                DS.AddRange(b);

            }
            if (Sort == "Price2")
            { DS = DS.OrderBy(i => (i.Price - i.Price * i.Sale)).ToList(); }
            else if (Sort == "Price")
            { DS = DS.OrderByDescending(i => (i.Price - i.Price * i.Sale)).ToList(); }
            else if (Sort == "ID")
            { DS = DS.OrderByDescending(i => i.ID).ToList(); }
            else if (Sort == "Sale")
            { DS = DS.OrderByDescending(i => i.Sale).ToList(); }
            return DS;
        }

        public static Product get1ProductHome(int ID)
        {
            return DB.Products.FirstOrDefault(i => i.ID == ID & i.Status == true);
        }

        //Thêm Review
        public static void addReview(Review a)
        {

            DB.Reviews.Add(a);
            DB.SaveChanges();
        }
        //Lay ra tat ca review

        public static List<Review> getallReview_Product(int ID, string Sort)
        {
            if (Sort != "Rate2")
            {
                return DB.Database.SqlQuery<Review>("SELECT * FROM REVIEWS WHERE PRODUCTID = '" + ID + "' ORDER BY " + Sort + " DESC").ToList();
            }
            else
            {
                return DB.Database.SqlQuery<Review>("SELECT * FROM REVIEWS WHERE PRODUCTID = '" + ID + "' ORDER BY RATE").ToList();
            }
        }

        //Thêm Review
        public static void DeleteReview(int ID)
        {

            var a = DB.Reviews.FirstOrDefault(i => i.ID == ID);
            DB.Reviews.Remove(a);
            DB.SaveChanges();

        }

        public static bool CountReview_ofUser(int ID, int ProductID)
        {

            return DB.Reviews.Any(i => i.UserID == ID & i.ProductID == ProductID);

        }
        //Tinh TB rating cuar 1 Product

        public static float AVGRatingReview(int ID)
        {


            var b = DB.Database.SqlQuery<Review>("SELECT * FROM REVIEWS WHERE PRODUCTID='" + ID + "'").ToList();
            float s = 0;
            foreach (var item in b)
            {
                s = s + item.Rate;
            }
            float a = (float)b.Count();
            return (float)Math.Round(s / a, 1);


        }


        //Thêm object vào Cart
        public static void addCart(Cart a)
        {
            bool c = DB.Carts.Any(i => i.ColorID == a.ColorID & i.UserID == a.UserID);
            if (c == false)
            {
                DB.Carts.Add(a);

            }
            else
            {
                var b = DB.Carts.FirstOrDefault(i => i.ColorID == a.ColorID & i.UserID == a.UserID);
                b.Quantity = b.Quantity + a.Quantity;
            }
            DB.SaveChanges();

        }

        //Lấy ra giỏ hàng của 1 người dung

        public static List<Cart> getCart(int UserID)
        {
            return DB.Database.SqlQuery<Cart>("SELECT * FROM CARTS WHERE USERID='" + UserID + "' AND STATUS='TRUE' ORDER BY ID DESC").ToList();
        }

        //Lấy ra SP tương ứng vs Color ID trong giỏ hàng
        public static Product getProduct_Cart(Cart a)
        {
            var b = DB.Colors.First(i => i.ID == a.ColorID);
            return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE id='" + b.ProductID + "'").FirstOrDefault();
        }

        public static Color getColor_Cart(Cart a)
        {
            return DB.Colors.First(i => i.ID == a.ColorID);

        }

        //Xóa 1 SP trong giỏ hàng 
        public static void DeleteCart(int ID)
        {
            var a = DB.Carts.FirstOrDefault(i => i.ID == ID);
            DB.Carts.Remove(a);
            DB.SaveChanges();
        }

        //Xóa tất cả SP trong giỏ hàng

        public static void ClearCart(int UserID)
        {
            var a = DB.Database.SqlQuery<Cart>("SELECT * FROM CARTS WHERE USERID = '" + UserID + "'").ToList();
            foreach (var item in a)
            {
                var b = DB.Carts.FirstOrDefault(i => i.ID == item.ID);
                DB.Carts.Remove(b);
                DB.SaveChanges();
            }

        }
        //Đếm số sản phẩm trong giỏ hàng
        public static int CountCart(int ID)
        {
            int a = DB.Carts.Count(i => i.UserID == ID & i.Status == true);
            return a;

        }

        //kiểm tra sp trong giỏ hàng khi sp ẩn

        public static void checkcart(int ID)
        {
            var cart = DB.Database.SqlQuery<Cart>("SELECT * FROM CARTS WHERE USERID='" + ID + "' ORDER BY ID DESC").ToList();
            foreach (var item in cart)
            {
                var a = DB.Colors.FirstOrDefault(i => i.ID == item.ColorID);

                if (a == null)
                {
                    var b = DB.Carts.FirstOrDefault(i => i.ID == item.ID);
                    DB.Carts.Remove(b);
                    DB.SaveChanges();
                }
                else
                {
                    var b = DB.Carts.FirstOrDefault(i => i.ID == item.ID);
                    b.Status = DBIO.getProduct_Cart(item).Status;
                    DB.SaveChanges();
                }
            }
        }

        //Kiểm tra SL địa chỉ cua1 1 người
        public static bool checkAddress(int Userid)
        {
            bool a = DB.Addresss.Count(i => i.UserID == Userid) <= 3;
            return a;
        }

        //Thêm địa chỉ
        public static void addAddress(Address a)
        {
            DB.Addresss.Add(a);
            DB.SaveChanges();
        }

        //Lấy tất cả tỉnh

        public static List<Province> getallProvince()
        {
            return DB.Database.SqlQuery<Province>("SELECT * FROM PROVINCES").ToList();
        }
        //lẤY HUYỆN THEO TỈNH
        public static List<District> getDistrict_Provice(string ProvinceID)
        {
            return DB.Database.SqlQuery<District>("SELECT * FROM DISTRICTS WHERE PROVINCEID='" + ProvinceID + "'").ToList();
        }
        //Lấy hết địa chỉ

        public static List<Address> getallAddress(int ID)
        {
            return DB.Database.SqlQuery<Address>("SELECT * FROM ADDRESSES WHERE USERID='" + ID + "'").ToList();
        }

        //Lấy ra 1 tỉnh từ ID
        public static Province get1Province(string ID)
        {
            return DB.Provinces.FirstOrDefault(i => i.ID == ID);
        }
        //Lấy ra 1 huyện 
        public static District get1District(string ID)
        {
            return DB.Districts.FirstOrDefault(i => i.ID == ID);
        }
        //Kiểm tra defaul status address
        public static bool checkShipSTTaddress(int UserID)
        {
            return DB.Addresss.Any(i => i.ShipStatus == true);
        }

        public static bool checkBillSTTaddress(int UserID)
        {
            return DB.Addresss.Any(i => i.BillStatus == true);
        }

        //Xóa địa chỉ
        public static void deleteAddress(int ID)
        {
            var a = DB.Addresss.FirstOrDefault(i => i.ID == ID);
            DB.Addresss.Remove(a);
            DB.SaveChanges();
        }
        // //Lấy ra 1 địa chỉ
        public static Address get1address(int ID)
        {
            return DB.Addresss.FirstOrDefault(i => i.ID == ID);
        }

        //Lấy ra địa chỉ nhận hàng mặc định
        public static Address getshipaddress(int ID)
        {
            return DB.Addresss.FirstOrDefault(i => i.ShipStatus == true & i.UserID == ID);
        }

        //Lấy ra địa chỉ thanh toán

        public static Address getbilladdress(int ID)
        {
            return DB.Addresss.FirstOrDefault(i => i.BillStatus == true & i.UserID == ID);
        }

        //thêm đơn hàng
        public static void addOrder(Order a)
        {
            DB.Orders.Add(a);
            DB.SaveChanges();
        }
        //Kiem tra sl don hang
        public static bool checkorder(int ID)
        {
            return DB.Orders.Count(i => i.UserID == ID) < 6;
        }

        //Lây 1 cart từ ID
        public static Cart get1cartfromID(int ID)
        {
            return DB.Carts.FirstOrDefault(i => i.ID == ID);
        }

        //Lấy tất cả order
        public static List<Order> GetallOrders(int ID)
        {
            return DB.Orders.OrderByDescending(i=>i.ID).Where(i => i.UserID == ID).ToList();
        }
        //lấy 1 order theo ID
        public static Order Get1Orders(int ID)
        {
            return DB.Orders.FirstOrDefault(i => i.ID == ID);
        }

        //Lấy tất cả SP của Đơn hàng
        public static List<ProductOrder> getallPDOrder(int id)
        {
            return DB.ProductOrders.Where(i => i.OrderID == id).ToList();
        }
        //Lấy 1 Product từ ProductOrder
        public static Product getProduct_ProductOrder(ProductOrder a)
        {
            var b = DB.Colors.FirstOrDefault(i => i.ID == a.ColorID);
            return DB.Database.SqlQuery<Product>("SELECT * FROM PRODUCTS WHERE id='" + b.ProductID + "'").FirstOrDefault();
        }

        public static Color getColor_ProductOrder(ProductOrder a)
        {
            return DB.Colors.First(i => i.ID == a.ColorID);

        }

        //Xoas 1 order
        public static void deleteorder(int id)
        {
            var a = DB.Orders.FirstOrDefault(i => i.ID == id);
            if (a.Status < 2)
            { foreach (var item in DB.ProductOrders.Where(i => i.OrderID == id).ToList()) 
                {
                    var b = DB.ProductOrders.FirstOrDefault(i => i.ID == item.ID);
                    DB.ProductOrders.Remove(b);
                    DB.SaveChanges();
                }
                DB.Orders.Remove(a);
                DB.SaveChanges();
                    
                        }
        
        }
    }
}