using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UploadFile.wwwroot
{
    public class UploadFileController : Controller
    {
        
            [HttpPost]
            [Route("UploadFile")]
            public IActionResult UploadFile(int? contractId, string path)
            {
                if (contractId == null)
                    return Content("Sözleşme Numarası bulunamadı");


                var file = Request.Form.Files[0];

                if (file == null || file.Length == 0)
                    return Content("Dosya bulunamadı");

                var fileName = ContentDispositionHeaderValue
                           .Parse(file.ContentDisposition)
                           .FileName
                           .Trim('"');
                using (FileStream fs = System.IO.File.Create(path + fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                string filePath = Path.ChangeExtension(fileName.ToString(), null);
                string pathRev = path.Replace(":", "");
                DateTime createdOn = DateTime.Now;

                Connection.Npgsql();

                return View();
            }

            [HttpPost]
            [Route("DeleteFile")]
            public IActionResult DeleteFile(int? contractId, string path)
            {
                if (contractId == null)
                    return Content("Sözleşme Numarası bulunamadı");


                var file = Request.Form.Files[0];

                if (file == null || file.Length == 0)
                    return Content("Dosya bulunamadı");

                var fileName = ContentDispositionHeaderValue
                           .Parse(file.ContentDisposition)
                           .FileName
                           .Trim('"');

                System.IO.File.Delete(path + fileName);

                string filePath = Path.ChangeExtension(fileName.ToString(), null);
                string pathRev = path.Replace(":", "");
                DateTime createdOn = DateTime.Now;

                Connection.Firebase();

                return View();
            }
        
    }
}
