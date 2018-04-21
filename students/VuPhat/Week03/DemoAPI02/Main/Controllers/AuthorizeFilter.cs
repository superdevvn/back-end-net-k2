using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Main.Controllers
{
    public class AuthorizeFilter : ActionFilterAttribute
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