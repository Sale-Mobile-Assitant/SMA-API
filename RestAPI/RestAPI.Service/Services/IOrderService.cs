using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        Order GetOrder(string id);

        int Add(Order _order);

        int Put(Order _order);

        int Delete(string id);
    }
}