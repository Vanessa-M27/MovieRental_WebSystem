using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental_WebSystem.Models;
using Newtonsoft.Json;

namespace MovieRental_WebSystem.Controllers
{
    public class HPController : Controller
    {
        

        // GET: HP
        public async Task<IActionResult> Index()
        {
            string url = "https://hp-api.onrender.com/api/characters";

			HttpClient client = new HttpClient();

			var response = await client.GetStringAsync(url);
            var characters = JsonConvert.DeserializeObject<List<HarryPotterCharacter>>(response);

            return View(characters);
        }

        // GET: HP/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound(); 
            }

            string url = $"https://hp-api.onrender.com/api/character/{id}";

            HttpClient client = new HttpClient();

            
                var response = await client.GetStringAsync(url);

                var characters = JsonConvert.DeserializeObject<List<HarryPotterCharacter>>(response);

                var character = characters.FirstOrDefault();
              
                return View(character);
         
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
