using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IOrderDetailService
    {
        int Add(OrderDetail _order);

        int Delete(string id);

        OrderDetail GetOrder(string id);

        List<OrderDetail> GetOrders();

        int Put(OrderDetail _orderDetail);
    }
}