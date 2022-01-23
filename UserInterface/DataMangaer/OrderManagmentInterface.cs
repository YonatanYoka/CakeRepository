using CakesData.DataAccess;
using CakesData.Model;
using CakesData.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace UserInterface.DataMangaer
{
    public static class OrderManagmentInterface
    {
        public static Cake CreateNewCake()
        {
            Console.WriteLine("Enter Cake Size : 1 = Small, 2 = Medium, 3 = 4 = Large , 5 = Extra Large");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Cake Type : 1 = Chocolate, 2 = Cheese, 3 = 4 = Suger Coated , 5 = Vegeterian Chocolate, 6 = Other");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("Special Description for cake : ");
            string description = Console.ReadLine();

            return CakeAccsess.CreateCake(size, type, description);
        }
        public static async Task GetOrdersByID()
        {
            Console.WriteLine("Enter user id");
            int id = int.Parse(Console.ReadLine());

            var userorders = await OrderAccsess.GetOrdersByIDAsync(id);

            foreach (Order item in userorders.ToArray())
            {
                MachineControl.PrintUserDetails(item.User);
                MachineControl.PrintOrderDetails(item);
            }
        }
        public static async Task GetOrderByOrderID()
        {
            using (var context = new DBContext())
            {
                try
                {
                    Console.WriteLine("Enter Order ID");
                    int id = int.Parse(Console.ReadLine());
                    var order = await OrderAccsess.GetOrderByIDAsync(id);
                    MachineControl.PrintUserDetails(order.User);
                    Console.WriteLine(order.ToString());
                    Console.WriteLine(order.Cake.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task GetOrderByPhoneNumber()
        {
            using (var context = new DBContext())
            {
                try
                {
                    var user = await UserManagmentInterface.Getuser();
                    MachineControl.PrintUserDetails(user);
                    foreach (Order item in user.Orders)
                    {
                        MachineControl.PrintOrderDetails(item);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task GetOrdersByOrderDate()
        {
            int year, month, day;
            Console.WriteLine("Enter Order Date Year");
            string yearinput = Console.ReadLine();
            int.TryParse(yearinput, out year);
            Console.WriteLine("Enter Order Date Month");
            string Monthinput = Console.ReadLine();
            int.TryParse(Monthinput, out month);
            Console.WriteLine("Enter Order Date Day");
            string Dayinput = Console.ReadLine();
            int.TryParse(Dayinput, out day);

            var ordate = new DateTime(year, month, day);
            List<Order> list = await OrderAccsess.GetOrdersByDateAsync(ordate.Date);

            foreach (Order item in list.ToArray())
            {
                MachineControl.PrintUserDetails(item.User);
                MachineControl.PrintOrderDetails(item);
            }
        }
        public static async Task GetOrdersByUnfinished()
        {
            List<Order> list = await OrderAccsess.GetAllNotFinished();
            foreach (Order item in list)
            {
                MachineControl.PrintUserDetails(item.User);
                MachineControl.PrintOrderDetails(item);
            }
        }
        public static async Task GetOrdersALL()
        {
            List<Order> list = await OrderAccsess.GetAllOrderAsync();
            foreach (Order item in list)
            {
                MachineControl.PrintUserDetails(item.User);
                MachineControl.PrintOrderDetails(item);

            }
        }
        public static async Task CancelOrder()
        {
            Console.WriteLine("Enter the order ID you would like to cancel : ");
            int id = int.Parse(Console.ReadLine());
            await OrderAccsess.CancelOrder(id);
        }
        public static async Task GetOrdersCanceld()
        {
            await OrderAccsess.GetCanceldOrdersAsync();
            foreach (Order item in await OrderAccsess.GetCanceldOrdersAsync())
            {
                
                MachineControl.PrintOrderDetails(item);
               
            }
        }
        public static async Task MarkOrderFinished()
        {
            Console.WriteLine("Enter the order ID you would like to mark as FINISHED : ");
            int id = int.Parse(Console.ReadLine());
            await OrderAccsess.ChangeOrderToPreparedAsync(id);
           
        }
    }
}
