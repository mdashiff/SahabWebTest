using System.Collections;
using System.Collections.Generic;

namespace Data
{
    public interface IProductRepository
    {
        IEnumerable GetProduct();
        IEnumerable<Products> GetWithRawSql(string query, params object[] parameters);
        Products GetProductById(int productID);
        void InsertProduct(Products products);
        void DeleteProduct(Products productID);
        void UpdateProduct(Products products);
        void Save();
    }
}
