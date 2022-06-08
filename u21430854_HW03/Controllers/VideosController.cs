using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21430854_HW03.Models;

namespace u21430854_HW03.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            string[] videoPaths = Directory.GetFiles(Server.MapPath("~/Media/Videos")); //get video path

            List<FileModel> videos = new List<FileModel>(); //for videos

            foreach (string vidPath in videoPaths)
            {
                videos.Add(new FileModel { FileName = Path.GetFileName(vidPath) }); //add video to list
            }

            return View(videos);
        }

        //download video
        public FileResult DownloadFile(string name)
        {
            //read file into byte array; again, use byte array because of octet-stream
            byte[] byteArray = System.IO.File.ReadAllBytes(Server.MapPath("~/Media/Videos/") + name);

            return File(byteArray, "application/octet-stream", name);
        }

        public ActionResult DeleteFile(string name)
        {
            string videoPath = Server.MapPath("~/Media/Videos/") + name;

            System.IO.File.Delete(videoPath); //delete

            return RedirectToAction("Index"); //show default view again
        }
    }
}