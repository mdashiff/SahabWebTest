using SSS.DataAccess;
using SSS.TestWeb.Models;
using System;
using System.Web.Http;
using CustomerInfo = SSS.DataAccess.Models.customer;

namespace SSS.TestWeb.RestAPI
{
    [Authorize]
    public class CustomerInfoController : ApiController
    {
        private dbAccess db;
        [HttpGet]
        public JsonResponse GetCustomerInfo(int customerId)
        {
            JsonResponse response = new JsonResponse();
            response.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    CustomerInfo customerInfo = this.db.GetCustomerInfo(customerId);
                    if (customerInfo != null)
                    {
                        response.IsSuccess = true;
                        response.data = customerInfo;
                        response.Message = "Successfully Retrieved";
                    }
                    else response.Message = "No records found for the user";
                }

            }
            catch (Exception e)
            {
                response.Message = "Server Error";
            }
            return response;
        }
    }
}

