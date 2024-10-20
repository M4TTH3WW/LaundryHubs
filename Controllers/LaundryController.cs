using LaundryHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaundryHub.Controllers
{
    public class LaundryController : Controller
    {
        // GET: LaundryController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7274/api/user";

            List<Laundry> users = new List<Laundry>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<Laundry>>(result);
            }

            return View(users);
        }

        // GET: LaundryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaundryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaundryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Laundry users)
        {
            string apiUrl = "https://localhost:7274/api/user";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(users);
        }


        // GET: LaundryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaundryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LaundryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaundryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
