using OrderApp.Domain;
using System.Collections.Generic;

namespace OrderApp.Data
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        void AddEntity(object entity);
        bool SaveAll();
    }
}