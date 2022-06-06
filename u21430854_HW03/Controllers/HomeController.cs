using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21430854_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase userFile, string fileType)
        {
            //if the user actually selected a file
            if (userFile != null && userFile.ContentLength > 0)
            {
                var name = Path.GetFileName(userFile.FileName); //get file name

                //determine where to store file
                var filePath = "";

                switch (fileType)
                {
                    case "document":
                        filePath = Path.Combine(Server.MapPath("~/Media/Documents"), name);
                        break;

                    case "image":
                        filePath = Path.Combine(Server.MapPath("~/Media/Images"), name);
                        break;

                    case "video":
                        filePath = Path.Combine(Server.MapPath("~/Media/Videos"), name);
                        break;

                    default:
                        filePath = Path.Combine(Server.MapPath("~/Media/Documents"), name);
                        break;
                }

                userFile.SaveAs(filePath); //save file

                ViewBag.Notification = userFile.FileName + " has been uploaded.";
            }

            //back to default view
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}