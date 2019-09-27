using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestAPI.Data;

namespace RestAPI.Service.Services
{
    public class OrderService : IOrderService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(Order _order)
        {
            DB.Orders.Add(_order);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.Orders.Where(p => p.MyOrderID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public Order GetOrder(string id)
        {
            return DB.Orders.Where(p => p.MyOrderID == id).FirstOrDefault();
        }

        public List<Order> GetOrders()
        {
            return DB.Orders.ToList();
        }

        public int Put(Order _order)
        {
            var exitingOrder = DB.Orders.Where(p => p.MyOrderID == _order.MyOrderID).FirstOrDefault();
            if (exitingOrder != null)
            {
                exitingOrder.CompID = _order.CompID;
                exitingOrder.OrdeID = _order.OrdeID;
                exitingOrder.CustID = _order.CustID;
                exitingOrder.EmplID = _order.EmplID;
                exitingOrder.OrderDate = _order.OrderDate;
                exitingOrder.NeedByDate = _order.NeedByDate;
                exitingOrder.RequestDate = _order.RequestDate;
                exitingOrder.OrderStatus = _order.OrderStatus;

                return DB.SaveChanges();
            }
            return -1;
        }
    }
}