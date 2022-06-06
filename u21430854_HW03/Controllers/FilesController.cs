using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21430854_HW03.Models;
using System.IO;

namespace u21430854_HW03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //get all the file paths
            string[] docPaths = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            List<FileModel> documents = new List<FileModel>();

            //add files to the docs list using their paths
            foreach (string documentPath in docPaths)
            {
                documents.Add(new FileModel { FileName = Path.GetFileName(documentPath) });
            }

            return View(documents);
        }

        public FileResult DownloadFile(string name)
        {
            //read file into byte array (byte array is used cos of octet-stream)
            byte[] byteArr = System.IO.File.ReadAllBytes(Server.MapPath("~/Media/Documents/") + name);

            //sending file for downloading
            return File(byteArr, "application/octet-stream", name);
        }

        public ActionResult DeleteFile(string name)
        {
            string filePath = Server.MapPath("~/Media/Documents/") + name; //get file path
            byte[] byteArr = System.IO.File.ReadAllBytes(filePath); //read file

            System.IO.File.Delete(filePath);

            return RedirectToAction("Index");

        }

        //delete all files in documents folder
        public ActionResult DeleteAll()
        {
            string[] allPaths = Directory.GetFiles(Server.MapPath("~/Media/Documents")); //get file path for all docs

            //loop through and delete
            foreach (string docPath in allPaths)
            {
                byte[] byteArray = System.IO.File.ReadAllBytes(docPath); //read file

                System.IO.File.Delete(docPath); //delete
            }

            return RedirectToAction("Index");
        }
    }
}