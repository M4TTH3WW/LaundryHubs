using LaundryHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaundryHub.Controllers
{
    public class MeowController : Controller
    {
        // GET: CatController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://api.thecatapi.com/v1/images/search?limit=10";

            List<Meow> catImages = new List<Meow>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    catImages = JsonConvert.DeserializeObject<List<Meow>>(result);
                }
            }

            return View(catImages);
        }
        // GET: CatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatController/Edit/5
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

        // GET: CatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatController/Delete/5
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
