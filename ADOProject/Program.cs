using ADBLLibrary;
using ADOModelsLibrary;
using System;

namespace MoreADOApplication
{
    class Program
    {
        UserBL userBL;
        public Program()
        {
            userBL = new UserBL();
        }
        void UserLoginCheck()
        {
            User user = GetLoginData();
            user = userBL.CheckLogin(user);
            if (user == null)
            {
                Console.WriteLine("Invalid username or password");
                return;
            }
            Console.WriteLine("Welcome " + user.Username + " you are a " + user.Role);
            List<Product> products = userBL.CheckRole(user);
            if (products != null)
            {
                foreach (Product product in products)
                {
                    Console.WriteLine(product.ToString());
                    Console.WriteLine();
                }
                return;
            }
            Console.WriteLine("You don't have enough rights to see all products");

        }        

        private User GetLoginData()
        {
            User user = new User();
            Console.WriteLine("Please enter your username");
            user.Username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            user.Password = Console.ReadLine();
            return user;
        }

        static void Main(string[] args)
        {
            new Program().UserLoginCheck();
            Console.ReadKey();
        }
    }
}
//Show all produts (If user login is success and is an admin)
//call SP in DAL -> U can use Adapter/Reader
//BL-> Check for role
//FE -> Show Products
//If role is not admin, Inform user login success but not enough rights