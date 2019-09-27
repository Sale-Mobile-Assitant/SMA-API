using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public int Add(OrderDetail _order)
        {
            DB.OrderDetails.Add(_order);
            return DB.SaveChanges();
        }

        public int Delete(string id)
        {
            var result = DB.OrderDetails.Where(p => p.MyOrderID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }

        public OrderDetail GetOrder(string id)
        {
            return DB.OrderDetails.Where(p => p.MyOrderID == id).FirstOrDefault();
        }

        public List<OrderDetail> GetOrders()
        {
            return DB.OrderDetails.ToList();
        }

        public int Put(OrderDetail _orderDetail)
        {
            var exitingOrderDetail = DB.OrderDetails.Where(p => p.MyOrderID == _orderDetail.MyOrderID).FirstOrDefault();
            if (exitingOrderDetail != null)
            {
                exitingOrderDetail.CompID = _orderDetail.CompID;
                exitingOrderDetail.SiteID = _orderDetail.SiteID;
                exitingOrderDetail.MyOrderID = _orderDetail.MyOrderID;
                exitingOrderDetail.ProdID = _orderDetail.ProdID;
                exitingOrderDetail.SellingQuantity = _orderDetail.SellingQuantity;
                exitingOrderDetail.UnitPrice = _orderDetail.UnitPrice;

                return DB.SaveChanges();
            }
            return -1;
        }
    }
}