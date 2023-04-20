using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Back_PPE_SLAM
{
    public class Authentification : ActionFilterAttribute
    {
        //variable qui stock le token 
        private string ApiToken = "123456789";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool valideToken = false;

            IEnumerable<string> requestHeader;

            var checkApiExist = actionContext.Request.Headers.TryGetValues("token", out requestHeader);

            //token recupere dans le header on va verifier s'il correspond aux attentes
            if(checkApiExist)
            {
                if (requestHeader.FirstOrDefault().Equals(ApiToken))
                    valideToken = true;
            }

            // on refuse l'accès dans les autres cas
            if (!valideToken)
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
}