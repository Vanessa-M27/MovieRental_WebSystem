using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental_WebSystem.Models;
using Newtonsoft.Json;

namespace MovieRental_WebSystem.Controllers
{
    public class HPController : Controller
    {
        // GET: HPController

        private readonly HttpClient client = new HttpClient();

        // GET: HP
        public async Task<IActionResult> Index()
        {
            string url = "https://hp-api.onrender.com/api/characters"; // Endpoint for all characters
            var response = await client.GetStringAsync(url);
            var characters = JsonConvert.DeserializeObject<List<HarryPotterCharacter>>(response);

            return View(characters);
        }

        // GET: HP/Details/5
        public async Task<IActionResult> Details(string id)
        {
            // Use the correct base URL for the HP-API
            string url = $"https://hp-api.onrender.com/api/characters/{id}";

            try
            {
                var response = await client.GetStringAsync(url);
                var character = JsonConvert.DeserializeObject<HarryPotterCharacter>(response);

                if (character == null)
                {
                    return NotFound();
                }

                return View(character);
            }
            catch (HttpRequestException e)
            {
              
                return NotFound();
            }
        }




        // GET: HPController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HPController/Create
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

        // GET: HPController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HPController/Edit/5
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

        // GET: HPController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HPController/Delete/5
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
