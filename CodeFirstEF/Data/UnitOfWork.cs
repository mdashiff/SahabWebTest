using System;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private DbContext _dbContext;
        private Repository<Customer> _customers;
        private Repository<Products> _products;
        private Repository<Order> _order;
        private Repository<OrderDetails> _orderDetail;

        public UnitOfWork()
        {
            this._dbContext = new DbContext();
        }

        public IRepository<Customer> Customers
        {
            get
            {
                return _customers ??
                    (_customers = new Repository<Customer>(_dbContext));
            }
        }

        public IRepository<Products> Products
        {
            get
            {
                return _products ??
                    (_products = new Repository<Products>(_dbContext));
            }
        }

        public IRepository<Order> Order
        {
            get
            {
                return _order ??
                    (_order = new Repository<Order>(_dbContext));
            }
        }

        public IRepository<OrderDetails> OrderDetails
        {
            get
            {
                return _orderDetail ??
                    (_orderDetail = new Repository<OrderDetails>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }
    }
}
