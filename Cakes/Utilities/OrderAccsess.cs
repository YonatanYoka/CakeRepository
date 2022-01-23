using CakesData.DataAccess;
using CakesData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CakesData.Utilities
{

    public static class OrderAccsess
    {

        public static async Task NewOrder(string deliverydate, User user, Cake cake, double? addon)
        {
            using (var context = new DBContext())
            {
                try
                {
                    Order neworder = new Order
                    {
                        OrderDate = DateTime.Now,
                        DelivryDate = DateTime.Parse(deliverydate),
                        OrderUserID = user.UserID,
                        Address = user.Address.ToString(),
                        Cake = cake,
                        OrderPrice = cake.CakePrice + addon == null ? 0 : addon.Value
                    };
                    await context.AddAsync(neworder);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }


        }
        public static async Task NewOrder(string deliverydate, User user, Cake cake, double? addon, string address)
        {
            using (var context = new DBContext())
            {
                try
                {
                    await context.AddAsync(new Order
                    {
                        OrderDate = DateTime.Now,
                        DelivryDate = DateTime.Parse(deliverydate),
                        OrderID = user.UserID,
                        Address = address,
                        Cake = cake,
                        OrderPrice = cake.CakePrice + addon == null ? 0 : addon.Value

                    });
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }
        public static async Task<Order> GetOrderByIDAsync(int id)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(o => o.OrderID == id).Include(o => o.Cake).Include(u => u.User).FirstAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetOrdersByIDAsync(int id)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(o => o.OrderID == id).Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetAllOrderAsync()
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetAllNotFinished()
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(o => o.OrderPreparedDate == null).Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetOrderByUserPhoneNumberAsync(string phonenumber)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(u => u.User.PhoneNumber == phonenumber).Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetOrderByConditionAsync(Expression<Func<Order, bool>> predicate)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(predicate).Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        public static async Task<List<Order>> GetOrdersByDateAsync(DateTime ordertime)
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(o => o.OrderDate.Date == ordertime).Include(o => o.Cake).Include(u => u.User).ToListAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task<List<Order>> GetCanceldOrdersAsync()
        {
            using (var context = new DBContext())
            {
                try
                {
                    return await context.Orders.Where(o => o.DelivryDate == DateTime.MinValue).Include(o => o.Cake).Include(u => u.User).ToListAsync();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static async Task CancelOrder(int id)
        {
            using (var context = new DBContext())
            {
                try
                {
                    Order ordertodelete = await OrderAccsess.GetOrderByIDAsync(id);
                    ordertodelete.DelivryDate = DateTime.MinValue;
                    Console.WriteLine("Order Cancled");
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        public static async Task ChangeOrderAddressAsync(Order order, string address)
        {
            using (var context = new DBContext())
            {
                try
                {
                    order.Address = address;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public static async Task ChangeOrderToPreparedAsync(int id)
        {
            using (var context = new DBContext())
            {
                try
                {
                    Order order = await GetOrderByIDAsync(id);
                    order.OrderPreparedDate = DateTime.Now;
                    Console.WriteLine("Order Marked as Prepared");
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
