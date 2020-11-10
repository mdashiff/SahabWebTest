using System.Collections;
using System.Collections.Generic;

namespace Data
{
    public interface IOrderDetailsRepository
    {
        IEnumerable GetOrderDetails();
        IEnumerable<OrderDetails> GetWithRawSql(string query, params object[] parameters);
        OrderDetails GetOrderDetailsById(int orderNumber);
        void InsertOrderDetails(OrderDetails orderdetails);
        void DeleteOrderDetails(int orderDetailsId);
        void UpdateOrderDetails(OrderDetails orderdetais);
        void Save();
    }
}
