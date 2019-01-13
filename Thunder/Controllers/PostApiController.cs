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
                result = Request.CreateResponse(HttpStatusCode.Created, p);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Någonting gick fel, försök igen!");
            }
            return result;
        }

        [Route("posts/get")]
        [HttpGet]
        public IHttpActionResult GetPosts(string userId)
        {
            var posts = new PostDbContext().Posts.Where(p => p.UserId == userId);
            var authors = new ProfileDbContext().Profiles
                .Where(a => posts.Select(p=> p.Author_UserId).ToList().Contains(a.UserId));

            var result =
            from post in posts
            join author in authors on post.Author_UserId equals author.UserId
            select new {
                Post = post,
                Author = string.Concat(author.FirstName, " ", author.LastName)
            };

            return Ok(new { results = result.ToList() });
        }
    }
}
