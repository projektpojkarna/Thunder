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
using Image = Thunder.Models.User.Image;

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

        //Tar in en image model och ger bilden ett unikt namn i databasen och sparar filsökvägen.
        [HttpPost]
        public ActionResult Add(Thunder.Models.User.Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            imageModel.UserID = User.Identity.GetUserId();


            ImageDbContext ctx = new ImageDbContext();
            var existingImage = ctx.Images.FirstOrDefault(u => u.UserID == imageModel.UserID);
            if(existingImage != null)
            {
                ctx.Images.Remove(existingImage);
            }
            ctx.Images.Add(imageModel);
            ctx.SaveChanges();
            
           

            ModelState.Clear();

            return RedirectToAction("EditProfile", "User");
        }

        [HttpGet]
        public ActionResult ViewImage(Image imageModel)
        {
            return View(imageModel);
        }
        
    }
}