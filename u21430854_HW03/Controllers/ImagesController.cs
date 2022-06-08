using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21430854_HW03.Models;

namespace u21430854_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            string[] imgPaths = Directory.GetFiles(Server.MapPath("~/Media/Images")); //get file paths

            List<FileModel> images = new List<FileModel>(); //list for image files

            foreach (string imagePath in imgPaths)
            {
                images.Add(new FileModel { FileName = Path.GetFileName(imagePath) });
            }

            return View(images);
        }

        public FileResult DownloadFile(string name)
        {
            //read file into array; use byte array because of octet-stream
            byte[] byteArray = System.IO.File.ReadAllBytes(Server.MapPath("~/Media/Images/") + name);

            //send file to be downloaded
            return File(byteArray, "application/octet-stream", name);
        }

        public ActionResult DeleteFile(string name)
        {
            string imgPath = Server.MapPath("~/Media/Images/") + name; //file path

            System.IO.File.Delete(imgPath); //delete file

            return RedirectToAction("Index"); //redirect to default view so that images are reloaded
        }
    }
}