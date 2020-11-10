namespace Data
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        IRepository<Products> Products { get; }
        IRepository<Order> Order { get; }
        IRepository<OrderDetails> OrderDetails { get; }

        void Commit();
    }
}
