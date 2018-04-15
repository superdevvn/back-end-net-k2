using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Services;

namespace SampleApi.Controllers
{
    public class AuthorizeFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var userService = new UserService();
                userService.GetCurrrentUser();
                base.OnActionExecuting(actionContext);
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }
    }
}