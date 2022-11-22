using Microsoft.AspNetCore.Mvc;
using As.Core.IService;
using As.Core.Model;
using As.Entity;
using static As.Service.Service.StudentService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;

namespace Assesment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataApiController : Controller
    {
        private readonly IStudentService _studentService;
        public DataApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public IActionResult Create(Details app1)
        {
            _studentService.CreateDetails(app1);
            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult Read()
        {
            var value = _studentService.Readlist();
            return Ok(value);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _studentService.Update(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteDone(id);
            return RedirectToAction("Read");
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            var value = _studentService.Search(search);
            return Ok(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var value = _studentService.Dropdown();
            return Ok(value);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var value = _studentService.Details(id);
            return Ok(value);
        }
    }
}
