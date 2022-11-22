using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using As.Core.Model;
using System.Reflection;

namespace WebApplication1.Controllers
{
    public class DataController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Create");
                var Gettask = client.GetAsync(client.BaseAddress);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StudentLocation>>();
                    readTask.Wait();
                    ViewBag.Location = readTask.Result;
                }
            }
            //EmployeeDetailsContext context = new EmployeeDetailsContext();
            //List<Locations> locations = context.Locations.ToList();
            //ViewBag.location = new SelectList(locations, "Location_Id", "Location");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Details app1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Create");
                var Posttask = client.PostAsJsonAsync(client.BaseAddress, app1);
                Posttask.Wait();
                var result = Posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        public IActionResult Read()
        {
            List<Details> app = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Read");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Details>>();
                    readTask.Wait();
                    app = (List<Details>?)readTask.Result;
                }
                return View(app);
            }
        }
        public IActionResult Search(string search)
        {
            List<Details> app = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Search?search=");
                var responseTask = client.GetAsync(client.BaseAddress + search);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Details>>();
                    readTask.Wait();
                    app = (List<Details>?)readTask.Result;
                }
                return View("Read", app);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Create();
            Details app1 = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Edit?id=");
                var responseTask = client.GetAsync(client.BaseAddress + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Details>();
                    readTask.Wait();

                    app1 = readTask.Result;
                }
            }
            return View("Create", app1);
        }
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Delete?id=");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        public IActionResult Detail(int id)
        {
            Details app1 = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7290/api/DataApi/Detail?id=");
                var responseTask = client.GetAsync(client.BaseAddress + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Details>();
                    readTask.Wait();
                    app1 = readTask.Result;
                }
            }
            return PartialView(app1);
        }
    }
}
