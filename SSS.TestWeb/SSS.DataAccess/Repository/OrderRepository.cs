using SSS.DataAccess.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SSS.DataAccess
{
    class OrderRepository<T> where T  :Order
    {
        private DALEntities context;
        private DbSet<T> dbSet;
        public OrderRepository(DALEntities _context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<T>();
        }
        public void DeleteOrder(int orderId)
        {
            Order order = this.context.Orders.Find(orderId);
            this.context.Orders.Remove(order);
        }

        public IEnumerable GetOrder()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable GetOrder(int skip, int page, int takeCount = 1)
        {
            return this.dbSet.Skip(skip).Take(page * takeCount).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return this.dbSet.Where(x => x.Id == orderId)?.FirstOrDefault();
        }

        public IEnumerable<Order> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters);
        }

        public void InsertOrder(Order order)
        {
            this.context.Entry(order).State = EntityState.Modified;
            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            this.context.Entry(order).State = EntityState.Modified;
            this.Save();
        }
    }
}
