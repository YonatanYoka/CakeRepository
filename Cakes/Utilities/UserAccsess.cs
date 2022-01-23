using CakesData.DataAccess;
using CakesData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CakesData.Utilities
{
    public static class UserAccsess
    {
        public static async Task AddNewUserAsync
            (string firstname, string Lastname, string emailaddress, string phonenumber,string streetname,string housenumber, string zipcode, string city)
        {
            using (var context = new DBContext())
            {
                try
                {
                    User newuser = new User()
                    {
                        FirstName = firstname,
                        LastName = Lastname,
                        EmailAddress = emailaddress,
                        PhoneNumber = phonenumber,
                        Address = new Address
                        {
                        Street_name = streetname,
                        House_number = housenumber,
                        Zipcode = zipcode,
                        City = city
                        }
                        
                    };
                    await context.AddAsync(newuser);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static User AddNewUser(string firstname, string Lastname, string emailaddress, string phonenumber, string streetname, string housenumber, string zipcode, string city)
        {
            using (var context = new DBContext())
            {
                try
                {
                    User newuser = new User()
                    {
                        FirstName = firstname,
                        LastName = Lastname,
                        EmailAddress = emailaddress,
                        PhoneNumber = phonenumber,
                        Address = new Address
                        {
                            Street_name = streetname,
                            House_number = housenumber,
                            Zipcode = zipcode,
                            City = city
                        }
                    };
                    context.Add(newuser);
                    context.SaveChanges();

                    return newuser;
                }
                catch (Exception)
                {
                    throw;
                } 
            }
        }

        public static async Task<User> GetUserAsync(string phonenumber)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await 
                        context.Users.Where(p => p.PhoneNumber == phonenumber).Include(o => o.Address).Include(o => o.Orders).ThenInclude(x=>x.Cake).FirstOrDefaultAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public static async Task EditUser(User usertoedit)
        {
            using (var context = new DBContext())
            {
                try
                {
                    context.Users.Update(usertoedit);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }

            }   
        }
    }
}
