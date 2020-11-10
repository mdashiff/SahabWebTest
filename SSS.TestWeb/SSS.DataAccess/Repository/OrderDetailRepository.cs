using SSS.DataAccess.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SSS.DataAccess
{
    class OrderDetailRepository<T> where T : OrderDetail
    {
        private DALEntities context;
        private DbSet<T> dbSet;
        public OrderDetailRepository(DALEntities _context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<T>();
        }
        public void DeleteOrderDetails(int orderDetailsId)
        {
            OrderDetail orderDetail = this.context.OrderDetails.Find(orderDetailsId);
            this.context.OrderDetails.Remove(orderDetail);
        }

        public IEnumerable GetOrderDetails()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable GetOrderDetails(int skip, int page,int takeCount = 1)
        {
            return this.dbSet.Skip(skip).Take(page * takeCount).ToList();
        }

        public OrderDetail GetOrderDetailsById(int orderNumber)
        {
            return this.dbSet.Where(x => x.OrderNumber.Equals(orderNumber))?.FirstOrDefault();
        }

        public IEnumerable<OrderDetail> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters);
        }

        public void InsertOrderDetails(OrderDetail orderdetails)
        {
            this.context.Entry(orderdetails).State = EntityState.Modified;
            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetail orderdetais)
        {
            this.context.Entry(orderdetais).State = EntityState.Modified;
            this.Save();
        }
    }
}
