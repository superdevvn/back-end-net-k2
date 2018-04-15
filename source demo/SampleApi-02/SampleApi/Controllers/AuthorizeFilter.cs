using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SampleApi.Controllers
{
    public class AuthorizeFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var token = actionContext.Request.Headers
                    .FirstOrDefault(header => header.Key == "Auth-SuperDev")
                    .Value.ToString();
                if(token == "ABC") base.OnActionExecuting(actionContext);
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
    }
}