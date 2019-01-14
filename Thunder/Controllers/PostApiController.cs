using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thunder.Models;
using Microsoft.AspNet.Identity;

namespace Thunder.Controllers
{
    [Authorize]
    [RoutePrefix("api/wall")]
    public class PostApiController : ApiController
    {
        [Route("post/send")]
        [HttpPost]
        public HttpResponseMessage PostMessage([FromBody]Post p)
        {
            var authorUserId = User.Identity.GetUserId();

            HttpResponseMessage result;
            if (ModelState.IsValid)
            {
                using (var ctx = new PostDbContext())
                {
                    ctx.Posts.Add(p);
                    ctx.SaveChanges();
                }
                result = Request.CreateResponse(HttpStatusCode.OK, "Meddelande skickat");
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Någonting gick fel, försök igen!");
            }
            return result;
        }
    }
}
