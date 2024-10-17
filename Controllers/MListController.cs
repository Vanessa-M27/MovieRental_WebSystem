using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental_WebSystem.Models;
using Newtonsoft.Json;
using System.Text;

namespace MovieRental_WebSystem.Controllers
{
    public class MListController : Controller
    {
        // GET: MListController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7099/OwnerAPI/Movies";

            List<Movie> mov = new List<Movie>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                mov = JsonConvert.DeserializeObject<List<Movie>>(result);
            }

            return View(mov);
        }

        // GET: MListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {
            string apiUrl = "https://localhost:7099/OwnerAPI/AddMovie";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);
        }

        // GET: AccountController/Edit/5
        public ActionResult Rent (int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        // POST: MListController/Rent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rent(int code, string customerEmail)
        {
            if (code == 0)
            {



                string apiUrl = "https://localhost:7099/OwnerAPI/RentMovie";
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(code), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            else
            {

            }



            return View(code);
        }

        // GET: MListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MListController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string title)
        {
            string apiUrl = $"https://localhost:7099/OwnerAPI/RemoveMovie?title={title}";

                using (HttpClient client = new HttpClient())
                {
                    // Send the DELETE request to the API, passing the title in the query string
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = $"Movie '{title}' deleted successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = $"Failed to delete the movie '{title}'.";
                    }
                }
            return RedirectToAction(nameof(Index));
        }





    }
}
