using Business.STR.Product;
using DAL;
using Entities.ViewModels.STR.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRProductController : ControllerBase
    {
        private StrProductService _StrProductService;
        private AppDbContext _context;
        private IWebHostEnvironment _environment;
        public STRProductController(StrProductService AddService, IWebHostEnvironment environment, AppDbContext context)
        {

            _StrProductService = AddService;
            //_context = new AppDbContext(options);
            _environment = environment;
            _context = context;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StrProductVM add)
        {
            string _response = await _StrProductService.Add(add);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] StrProductVM update)
        {
            string _response = await _StrProductService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _StrProductService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _StrProductService.GetAll();
            return Ok(AllSTR_Add);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _StrProductService.GetById(id);
            return Ok(add);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var add = _StrProductService.GetByName(Name);
            return Ok(add);
        }

        [HttpGet("AutoCode")]
        public IActionResult AutoCode()
        {
            var _response = _StrProductService.AutoCode();
            return new JsonResult(_response);
        }
        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(StrProductVM sTR_product)
        //{
        //    var file = Request.Form.Files[0];
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No file uploaded.");

        //    // Save the uploaded file to a physical location
        //    string uploadsFolder = Path.Combine("uploads");
        //    // Generate a unique filename
        //    string uniqueFileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" +
        //                            Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    var product = new StrProduct()
        //    {
        //        Name = sTR_product.Name,
        //        Attachment = file.FileName,
        //        ItemId = sTR_product.ItemId,
        //        VendorId = sTR_product.VendorId,
        //        ModelId = sTR_product.ModelId,
        //        CreatedByID = sTR_product.TransactionUserId,
        //        CreationDate = DateTime.Now,
        //    };

        //    _context.StrProduct.Add(product);
        //    await _context.SaveChangesAsync();
        //    return new JsonResult("File uploaded successfully.");
        //}
        //[HttpGet("UploadFile")]
        //public IActionResult UploadFile(IFormFile file)
        //{
        //    var _response = _StrProductService.UploadFile(file);
        //    return new JsonResult(_response);
        //}

        //[HttpPost("UploadFile")]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> UploadFile([FromForm] StrProductVM sTR_product)
        //{
        //    var _response = await _StrProductService.UploadFile(sTR_product);
        //    return Ok(_response);
        //}

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var add = _StrProductService.GetById(id);
            if (add != null)
            {
                string filename = add.Attachment.Trim();
                if (!string.IsNullOrEmpty(filename) && !string.IsNullOrWhiteSpace(filename))
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\STRProduct", filename);

                    var provider = new FileExtensionContentTypeProvider();
                    if (!provider.TryGetContentType(filepath, out var contenttype))
                    {
                        contenttype = "application/octet-stream";
                    }

                    var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
                    return File(bytes, contenttype, Path.GetFileName(filepath));
                }
                else
                {
                    return new JsonResult("Product File Doesn't Exist");
                }


            }
            else
            {
                return new JsonResult("Product Doesn't Exist");
            }


        }


    }
}
