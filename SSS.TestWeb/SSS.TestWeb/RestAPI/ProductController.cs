using SSS.DataAccess;
using SSS.DataAccess.DAL;
using SSS.TestWeb.Models;
using SSS.TestWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace SSS.TestWeb.RestAPI
{
    [Authorize]
    public class ProductController : ApiController
    {
        private dbAccess db;
        [HttpGet]
        [AllowAnonymous]
        public JsonResponse ListAllProduct()
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    jsonResponse.data =(List<Product>) this.db.GetAllProduct();
                    if (jsonResponse.data != null && jsonResponse.data.Count > 0)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "Successfully Retreived";
                    }
                    else jsonResponse.Message = "No data found";
                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResponse ListAllProduct(string search)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    jsonResponse.data = (List<Product>)this.db.GetProductBySearch(search);
                    if (jsonResponse.data != null && jsonResponse.data.Count > 0)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "Successfully Retreived";
                    }
                    else jsonResponse.Message = "No data found";
                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("api/Products/ListByPagination")]
        public JsonResponse ListByPagination(ProductPaginationViewModel paginationViewModel)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            int takeCount = int.Parse(ConfigurationManager.AppSettings["DefaultPagination"]);
            try
            {
                using (this.db = new dbAccess())
                {
                    jsonResponse.data = (List<Product>)this.db.GetProductByPagination(paginationViewModel.skip,paginationViewModel.page, takeCount);
                    if (jsonResponse.data != null && jsonResponse.data.Count > 0)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "Successfully Retreived";
                    }
                    else jsonResponse.Message = "No data found";
                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
        [HttpGet]
        [Route("api/Product/GetProductById")]

        public JsonResponse GetProductById(int id)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    jsonResponse.data = this.db.GetProductById(id);
                    if (jsonResponse.data != null)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "Successfully Retreived";
                    }
                    else jsonResponse.Message = "No data found";

                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
        [HttpPut]
        public JsonResponse DeleteProductById(int id)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    this.db.DeleteProduct(id);

                    jsonResponse.IsSuccess = true;
                    jsonResponse.Message = "Successfully Deleted";

                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
        [HttpPost]
        public JsonResponse CreateProduct(Product product)
        {
            product.ProductStatusId = 1;
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    this.db.CreateProduct(product);
                    jsonResponse.Message = "Successfully Inserted";
                    jsonResponse.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
        [HttpPut]
        [Route("api/Product/UpdateProduct")]

        public JsonResponse UpdateProduct(Product product)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    this.db.UpdateProduct(product);
                    jsonResponse.Message = "Successfully Updated";
                    jsonResponse.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                jsonResponse.Message = e.Message;

            }
            return jsonResponse;
        }
    }
}
