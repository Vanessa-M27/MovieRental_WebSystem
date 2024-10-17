using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental_WebSystem.Models;
using Newtonsoft.Json;
using System.Text;

namespace MovieRental_WebSystem.Controllers
{
    public class CListController : Controller
    {
        // GET: CListController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7099/OwnerAPI/Customers";

            List<Customer> cus = new List<Customer>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                cus = JsonConvert.DeserializeObject<List<Customer>>(result);
            }

            return View(cus);
        }


        // GET: CListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            string apiUrl = "https://localhost:7099/OwnerAPI/AddCustomer";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }


        // GET: CListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CListController/Edit/5
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

        // GET: CListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CListController/Delete/5
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
