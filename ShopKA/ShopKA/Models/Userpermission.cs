using DataBase;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace ShopKA.Models // Chú ý tên namespace này
{
    public class Userpermission : RoleProvider
    {
        MyDB db = new MyDB(); //khai bao context
        //string name = DBIO.getUser_fromUserLogin((UserLogin)Session["SS"]);

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string name )
        {
            // tạo biến getrole, so sánh xem UserID đang đăng nhập có giống với tên trong db ko
            
            User account = db.Users.SingleOrDefault(x => x.Username == name);
            if (account != null) // Nếu giống
            {
                return new String[] { account.Permission.ToString() };
            }
            else
                return new String[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
