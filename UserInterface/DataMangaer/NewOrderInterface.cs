using CakesData.Model;
using CakesData.Utilities;
using System;
using System.Threading.Tasks;


namespace UserInterface.DataMangaer
{
    public static class NewOrderInterface
    {
        public static async Task NewOrderExistingUser_KeepAddressAsync()
        {
            User user =await UserManagmentInterface.Getuser();
            MachineControl.PrintUserDetails(user);
            Console.WriteLine("Enter Request For Delivery Date (Day/Month/Year)");
            string delverydate = Console.ReadLine();

            Console.WriteLine("Enter additional fees to order");
            double addonamount = double.Parse(Console.ReadLine());

            await OrderAccsess.NewOrder(delverydate, user, OrderManagmentInterface.CreateNewCake(), addonamount);
        }
        public static async Task NewOrderExistingUser_NewAddressAsync()
        {
            User user = await UserManagmentInterface.Getuser();
            MachineControl.PrintUserDetails(user);
            Console.WriteLine("Enter Request For Delivery Date (Day/Month/Year)");
            string delverydate = Console.ReadLine();

            Console.WriteLine("In case of Special Requests for the order - insert additional fee to add to new order");
            double addonamount = double.Parse(Console.ReadLine());

            await OrderAccsess.NewOrder(delverydate, user, OrderManagmentInterface.CreateNewCake(), addonamount,UserManagmentInterface.EditAddress().ToString());
        }
        public static async Task NewOrderNewUser()
        {
            Console.WriteLine("Enter Request For Delivery Date (Day/Month/Year)");
            string delverydate = Console.ReadLine();

            Console.WriteLine("In case of Special Requests for the order - insert additional fee to add to new order");
            double addonamount = double.Parse(Console.ReadLine());

            await OrderAccsess.NewOrder(delverydate,UserManagmentInterface.CreateUserInOrder(), OrderManagmentInterface.CreateNewCake(), addonamount);

        }
    }
}
