using SSS.DataAccess.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SSS.DataAccess
{
    class ProductRepository<T> where T : Product
    {
        private DALEntities context;
        private DbSet<T> dbSet;
        public ProductRepository(DALEntities _context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<T>();
        }

        public void DeleteProduct(int productID)
        {
            Product product = this.context.Products.Find(productID);
            product.ProductStatusId = 2;
            this.UpdateProduct(product);
        }

        public IEnumerable<Product> GetProduct()
        {
            return this.dbSet.Where(x=>x.ProductStatusId == 1).ToList();
        }

        public IEnumerable<Product> GetProduct(int skip, int page, int takeCount = 1)
        {
            return this.dbSet.Where(x => x.ProductStatusId == 1).OrderBy(x=>x.Id).Skip(skip).Take(page * takeCount).ToList();
        }

        public Product GetProductById(int productID)
        {
            return this.dbSet.Where(x => x.Id == productID)?.FirstOrDefault();
        }

        public IEnumerable<Product> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters);
        }

        public void InsertProduct(Product products)
        {
            this.context.Entry(products).State = EntityState.Added;
            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            this.context.Entry(product).State = EntityState.Modified;
            this.Save();
        }
    }
}
