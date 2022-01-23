using CakesData.DataAccess;
using CakesData.Model;
using CakesData.Utilities;
using System;
using System.Threading.Tasks;

namespace UserInterface.DataMangaer
{
    public static class UserManagmentInterface
    {
        public static User CreateUserInOrder()
        {
            Console.WriteLine("First Name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Email Address:");
            string emailaddress = Console.ReadLine();

            Console.WriteLine("Phone Number:");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Street Name:");
            string streetname = Console.ReadLine();
            Console.WriteLine("House Number:");
            string housenumber = Console.ReadLine();
            Console.WriteLine("Zipcode:");
            string zipcode = Console.ReadLine();
            Console.WriteLine("City");
            string city = Console.ReadLine();
            return UserAccsess.AddNewUser(firstname, lastName, emailaddress, phonenumber, streetname, housenumber, zipcode, city);
        }
        public static async Task CreateNewUser()
        {
            Console.WriteLine("First Name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Email Address:");
            string emailaddress = Console.ReadLine();

            Console.WriteLine("Phone Number:");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Street Name:");
            string streetname = Console.ReadLine();
            Console.WriteLine("House Number:");
            string housenumber = Console.ReadLine();
            Console.WriteLine("Zipcode:");
            string zipcode = Console.ReadLine();
            Console.WriteLine("City");
            string city = Console.ReadLine();
            await UserAccsess.AddNewUserAsync(firstname, lastName, emailaddress, phonenumber, streetname, housenumber, zipcode, city);
        }
        public static async Task<User> Getuser()
        {
            try
            {
                bool work = true;
                User usertoview;
                do
                {
                    Console.WriteLine("User Phone Number:");
                    string _phonenumber = Console.ReadLine();
                    usertoview = await UserAccsess.GetUserAsync(_phonenumber);
                    if (usertoview == null)
                    {
                        Console.WriteLine("No user found with this phone number ");
                    }
                    else
                    {
                        work = false;
                    }
                } while (work);
                return usertoview;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static Address EditAddress()
        {
            Console.WriteLine("Street Name:");
            string streetname = Console.ReadLine();
            Console.WriteLine("House Number:");
            string housenumber = Console.ReadLine();
            Console.WriteLine("Zipcode:");
            string zipcode = Console.ReadLine();
            Console.WriteLine("City");
            string city = Console.ReadLine();

            return new Address { Street_name = streetname, House_number = housenumber, Zipcode = zipcode, City = city };
        }
        public static async Task UserEditor()
        {
            using (var context = new DBContext())
            {
                User usertoedit = await Getuser();
                bool editing = true;
                do
                {
                    Console.WriteLine("Choose data to change.. type choice number - then press enter:");
                    Console.WriteLine("" +
                        "1. First name\n" +
                        "2.Last name\n" +
                        "3.Email address\n" +
                        "4.Phone number\n" +
                        "5.Address\n" +
                        "6.Stop editing");
                    int choice = int.Parse(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("First Name:");
                            string firstname = Console.ReadLine();
                            usertoedit.FirstName = firstname;
                            break;
                        case 2:

                            Console.WriteLine("Last Name:");
                            string lastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Email Address:");
                            string emailaddress = Console.ReadLine();

                            break;
                        case 4:
                            Console.WriteLine("Phone Number:");
                            string phonenumber = Console.ReadLine();

                            break;
                        case 5:
                            usertoedit.Address = EditAddress();
                            break;
                        case 6:
                            context.Update(usertoedit);
                            await context.SaveChangesAsync();
                            editing = false;
                            break;
                        default:
                            continue;
                    }

                } while (editing); 
            }

        }
    }
}
