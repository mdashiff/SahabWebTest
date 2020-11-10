using System.Collections;
using System.Collections.Generic;

namespace Data
{
    public interface ICustomerRepository
    {
        IEnumerable GetCustomers();
        IEnumerable<Customer> GetWithRawSql(string query,params object[] parameters);
        Customer GetCustomerByID(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
