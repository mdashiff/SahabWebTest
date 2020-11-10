using System.Collections;
using System.Collections.Generic;

namespace Data
{
    public interface IOrderRepository
    {
        IEnumerable GetOrder();
        IEnumerable<Order> GetWithRawSql(string query, params object[] parameters);
        Order GetOrderById(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
        void Save();
    }
}
