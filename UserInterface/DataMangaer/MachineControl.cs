using CakesData.Model;
using System;
using System.Threading.Tasks;

namespace UserInterface.DataMangaer
{
    public static class MachineControl
    {
        public static void PrintUserDetails(User user)
        {
            Console.WriteLine("_____________________\n");
            Console.WriteLine($"\n\nUser Details:\n\n" +
                       $"Full Name : {user.FirstName} {user.LastName}\n" +
                       $"Address : {user.Address}\n" +
                       $"Email : {user.EmailAddress}\n" +
                       $"Phone Number : {user.PhoneNumber}\n" +
                       $"ID : {user.UserID}\n\n");
            Console.WriteLine("_____________________\n");
        }
        public static void PrintOrderDetails(Order order)
        {
            Console.WriteLine("_____________________\n");
            Console.WriteLine(order.ToString());
            Console.WriteLine(order.Cake.ToString());
            Console.WriteLine("_____________________\n");
        }
        public static async Task MainMenu()
        {
            Console.WriteLine("----Cake Factory V1--- :\n");
            Console.WriteLine("Welcome! in order to use this system you will be requierd\nto insert numbers as input in order to navigate the software\n");
            int choice;
            bool working = true;
            do
            {
                Console.WriteLine("" +
                    "Add New Order -Press 1 and then ENTER\n\n" +
                    "Watch Order/s -Press 2 and then ENTER\n\n" +
                    "Quit Program - Press 3 and then ENTER\n\n");
                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice >= 4)
                {
                    Console.WriteLine("invalid option");
                    return;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            await SneworderAsync();
                            break;
                        case 2:
                            await SOrderWatch();
                            break;
                        default:
                            working = false;
                            break;
                    }
                }
            } while (working);
        }
        public static async Task SneworderAsync()
        {
            int choice;

            Console.WriteLine("Enter order for new user - Enter 1 \n\n" +
                "Enter order for existing user - Enter 2\n\n");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await NewOrderInterface.NewOrderNewUser();
                    return;
                case 2:
                    Console.WriteLine("Same Address information - Enter 1 \n\n" +
                        "New address information - Enter 2\n\n");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            await NewOrderInterface.NewOrderExistingUser_KeepAddressAsync();
                            break;
                        case 2:
                            await NewOrderInterface.NewOrderExistingUser_NewAddressAsync();
                            break;
                    }
                    return;
                default:
                    break;
            }
        }
        public static async Task SOrderWatch()
        {
            int choice;
            Console.WriteLine("---------Watch Existing Order\\s---------\n\n" +
                   "Search Order By User Phone Number - Press 1 and then ENTER\n\n" +
                   "Search Order By Order ID- Press 2 and then ENTER\n\n" +
                   "Search Orders By Order Date- Press 3 and then ENTER\n\n" +
                   "Search Unfinished Orders- Press 4 and then ENTER\n\n" +
                   "Search All Orders- Press 5 and then ENTER\n\n" +
                   "Search All Deleted Orders - Press 6 and then ENTER\n\n" +
                   "Return to menu - Press 7 and then ENTER\n\n");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await OrderManagmentInterface.GetOrderByPhoneNumber();
                    await ChangeStatus();
                    return;
                case 2:
                    await OrderManagmentInterface.GetOrderByOrderID();
                    await ChangeStatus();
                    return;
                case 3:
                    await OrderManagmentInterface.GetOrdersByOrderDate();
                    await ChangeStatus();
                    return;
                case 4:
                    await OrderManagmentInterface.GetOrdersByUnfinished();
                    await ChangeStatus();
                    return;
                case 5:
                    await OrderManagmentInterface.GetOrdersALL();
                    await ChangeStatus();
                    return;
                case 6:
                    await OrderManagmentInterface.GetOrdersCanceld();
                    return;
                default:
                    Console.WriteLine("Input not valid! try again");
                    return;
            }
        }
        public static async Task ChangeStatus()
        {
            int choice;
            Console.WriteLine("?\n" +
                "Cancel order = Enter 1\n" +
                "Mark  order as Finished = Enter 2\n" +
                "Return = Enter 3");
            choice = int.Parse(Console.ReadLine());
            if (choice != 2 && choice != 1 && choice != 3)
            {
                Console.WriteLine("Wrong choice..");
                return;
            }
            else if (choice == 2 || choice == 1 || choice == 3)
            {
                switch (choice)
                {
                    case 1:
                        await OrderManagmentInterface.CancelOrder();
                        return;
                    case 2:
                        await OrderManagmentInterface.MarkOrderFinished();
                        return;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
