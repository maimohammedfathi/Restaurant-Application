using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;

namespace VersionOfProject.PL
{
    public  class OrderPL
    {
        WFContext con;
        public OrderPL()
        {
            con = new WFContext();
        }
        // for casher 
        public bool Submitorder (Order order , List<OrderItem> orderItems)
        {
            try
            {
                con.orders.Add(order);
                con.SaveChanges();

                var orderId = con.orders.OrderBy( o=> o.Id).LastOrDefault().Id;

                foreach (OrderItem item in orderItems)
                {
                    item.OrderId = orderId;
                }
                con.OrdersItems.AddRange(orderItems);
                con.SaveChanges();
                return true;

            }
            catch (Exception ex) 
            {
                throw new Exception($"Invalid Data {ex.Message}");
            }
            
        }

        // for Admin
        public List<Order> GetAllOrder ()
        {
            return con.orders.Include("Orders").ToList();
        }
        public List<Order> GetAllOrderByMonth(DateTime date )
        {
            return con.orders.Where(o =>o.OrderDate.Month == date.Month).Include("Orders").ToList();
        }

    }
}
