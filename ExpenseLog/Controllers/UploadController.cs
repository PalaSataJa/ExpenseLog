using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseLog.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        [HttpPost("csv")]
        public async Task<IActionResult> UploadCsv(IFormFile formFile)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            
            

            return Ok(new { result="success" });
        }
    }
}
