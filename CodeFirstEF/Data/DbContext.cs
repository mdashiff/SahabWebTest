using System.Data.Entity;

namespace Data
{
    internal partial class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=ConnStringDb1")
        {
             Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
             this.Configuration.LazyLoadingEnabled = false;

        }
        public  DbSet<Customer> Customer
        { 
            get;
            set;
        }
        public  DbSet<OrderDetails> OrderDetails
        {
            get;
            set;
        }
        public DbSet<Products> Products
        {
            get;
            set;
        }
        public DbSet<Order> Order
        {
            get;
            set;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

