using SSS.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSS.DataAccess
{
   // public delegate void Notify(string LogMessage);
    public class dbAccess : IDisposable
    {
     //   public event Notify OnLogMessages;
        private UnitOfWork UnitOfWork;
        private bool disposedValue;

        public dbAccess()
        {
            this.UnitOfWork = new UnitOfWork();

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.UnitOfWork.Dispose();
                }
                disposedValue = true;
            }
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return this.UnitOfWork.ProductRepository.GetProduct();
        }

        public bool CheckEmailIdAlreadyExist(string email)
        {
            string query = string.Format(Constants.CheckIfUserExistByEmailQuery, email);
            var data = this.UnitOfWork.CustomerRepository.GetWithRawSql(query);
            if (data != null && data.Count() > 0) return true;
            return false;
        }

        public void createCustomer(Customer customer)
        {
            this.UnitOfWork.CustomerRepository.InsertCustomer(customer);
        }

        public SSS.DataAccess.Models.customer GetCustomerInfo(int customerID)
        {
            return this.UnitOfWork.GetCustomerInfo(customerID);
        
        }

        public IEnumerable<Product> GetProductBySearch(string search)
        {
            string query = string.Format(Constants.GetProductByNameLikeQuery, search);
            var data = this.UnitOfWork.ProductRepository.GetWithRawSql(query);
            return data.ToList();
        }

        public IEnumerable<Customer> Login(string userName, string passWord)
        {
            string query = string.Format(Constants.CheckIfUserExistQuery, userName, passWord);
            var data = this.UnitOfWork.CustomerRepository.GetWithRawSql(query);
             return data;
        }

        public Product GetProductById(int id)
        {
            return this.UnitOfWork.ProductRepository.GetProductById(id);
        }

        ~dbAccess()
        {
            Dispose(disposing: false);
        }

        public void DeleteProduct(int productId)
        {
            this.UnitOfWork.ProductRepository.DeleteProduct(productId);
        }

        public void CreateProduct(Product product)
        {
            this.UnitOfWork.ProductRepository.InsertProduct(product);
        }

        public IEnumerable<Product> GetProductByPagination(int skip, int take, int takeCount)
        {
           return this.UnitOfWork.ProductRepository.GetProduct(skip, take, takeCount);
        }

        public void UpdateProduct(Product product)
        {
            this.UnitOfWork.ProductRepository.UpdateProduct(product);
        }
        //private void LogMessage(string MethodName,string className, string OnLogMessage)
        //{
        //    string LogMessage = $"{className}::{MethodName}::{OnLogMessage}";
        //    this.OnLogMessages?.Invoke(OnLogMessage);
        //}
    }
}
