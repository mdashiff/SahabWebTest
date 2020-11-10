using SSS.DataAccess.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SSS.DataAccess
{
    class CustomerRepository<T> where T: Customer
    {
        private DALEntities context;
        private DbSet<T> dbSet;
        public CustomerRepository(DALEntities _context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<T>();
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = this.context.Customers.Find(customerId);
            context.Customers.Remove(customer);
        }

        public Customer GetCustomerByID(int customerId)
        {
            return this.dbSet.Where(x => x.Id == customerId)?.FirstOrDefault();
        }

        public IEnumerable GetCustomers()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<Customer> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters).Select(x=> new Customer { 
                Name = x.Name,
                BirthDate = x.BirthDate,
                Email = x.Email,
                Id = x.Id
            }).ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            this.context.Entry(customer).State = EntityState.Added;
            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            this.context.Entry(customer).State = EntityState.Modified;
            this.Save();
        }
    }
}
