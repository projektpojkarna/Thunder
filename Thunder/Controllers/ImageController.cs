using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Thunder.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Thunder.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public void Add(Thunder.Models.User.Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            imageModel.UserID = User.Identity.GetUserId();


            ImageDbContext ctx = new ImageDbContext();
                
                ctx.Images.Add(imageModel);
                ctx.SaveChanges();
            
           

            ModelState.Clear();
            

        }

        /*[HttpGet]
        public ActionResult ViewImage(int Id)
        {
            Image imageModel = new Image();

            ImageDbContext ctx = new ImageDbContext();

            imageModel = ctx.Images.Where(x => x.ImageID == Id).FirstOrDefault();

            return View(imageModel);
        }
        */
    }
}