﻿using FileUpload.Model;
using FileUpload.Services.FileUpload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{

    public class FileUploadController : Controller
    {
        private readonly IFileUploadSystem fileUploadSystem;
        public FileUploadController(IFileUploadSystem fileUploadSystem)
        {
            this.fileUploadSystem = fileUploadSystem;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(FileUploadDetails model)
        {
            var result = await fileUploadSystem.UploadFile(model);
            return Json(new { Code = result.Code, Message = result.Message });
        }
    }
}
