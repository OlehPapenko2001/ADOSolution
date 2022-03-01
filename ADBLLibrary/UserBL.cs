using ADODALLibrary;
using ADOModelsLibrary;
using System;

namespace ADBLLibrary
{
    public class UserBL
    {
        UserDAL userDAL;
        public UserBL()
        {
            userDAL = new UserDAL();
        }
        public User CheckLogin(User user)
        {
            if (user.Username != null && user.Password != null)
            {
                string result = userDAL.Login(user);
                if (result == "invalid")
                {
                    return null;
                }
                else
                {
                    user.Role = result;
                    user.Password = "";
                    return user;
                }
            }
            return null;
        }
        public List<Product> CheckRole(User user)
        {
            if (user.Role == "admin")
            {
                return new ProductDAL().GetAllProducts();
            }
            return null;
        }
    }
}
