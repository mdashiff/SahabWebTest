

using Newtonsoft.Json;
using SSS.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace SSS.DataAccess
{
   class UnitOfWork 
    {
        private readonly DALEntities dal;
        private CustomerRepository<Customer> _customerRepository;
        private OrderDetailRepository<OrderDetail> _OrderDetailRepository;
        private OrderRepository<Order> _OrderRepository;
        private ProductRepository<Product> _ProductRepository;
        public UnitOfWork()
        {
            this.dal = new DALEntities();
        }
        public CustomerRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository<Customer>(dal);
                }
                return _customerRepository;
            }
        }
        public OrderDetailRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (_OrderDetailRepository == null)
                {
                    _OrderDetailRepository = new OrderDetailRepository<OrderDetail>(dal);
                }
                return _OrderDetailRepository;
            }
        }
        public OrderRepository<Order> OrderRepository
        {
            get
            {
                if (_OrderRepository == null)
                {
                    _OrderRepository = new OrderRepository<Order>(dal);
                }
                return _OrderRepository;
            }
        }
        public ProductRepository<Product> ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                {
                    _ProductRepository = new ProductRepository<Product>(dal);
                }
                return _ProductRepository;
            }
        }




        public void Commit()
        {
            this.dal.SaveChanges();
        }
        public Models.customer GetCustomerInfo(int customerId)
        {
            string dataOut = null;
            Models.customer data = new Models.customer();
           ObjectParameter output = new ObjectParameter("jsonOutput", typeof(string));
            this.dal.FetchDetailsByCustomerId(customerId,output);
            dataOut = output.Value.ToString();
            List<Models.customer> datas = JsonConvert.DeserializeObject<List<Models.customer>>(dataOut);
            if (datas != null && datas.Count != null && datas.Count > 0)
            {
                data = datas[0];
            }
            return data;
        }

        public void Dispose()
        {
           if(this.dal != null) this.dal.Dispose();
            GC.SuppressFinalize(this);
        }
      
    }
}
