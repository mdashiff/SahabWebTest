using SSS.DataAccess;
using SSS.TestWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSS.TestWeb.RestAPI
{
    public class CustomerController : ApiController
    {
        dbAccess db;
        public JsonResponse Login(LoginViewModel loginViewModel)
        {
            JsonResponse jsonResponse = new JsonResponse();
            jsonResponse.IsSuccess = false;
            try
            {
                using (this.db = new dbAccess())
                {
                    jsonResponse.data = this.db.Login(loginViewModel.Email,loginViewModel.Password);
                    if (jsonResponse.data != null && jsonResponse.data.Count > 0)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "Logged In successfully";
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
    }
}
