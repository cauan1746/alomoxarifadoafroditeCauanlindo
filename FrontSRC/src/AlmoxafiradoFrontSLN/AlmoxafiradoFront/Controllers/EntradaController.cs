using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class EntradaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/lista";
            List<EntradaDTO> categorias = new List<EntradaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                categorias = JsonSerializer.Deserialize<List<EntradaDTO>>(json);
                ViewBag.Categorias = categorias;


            }
            catch (Exception)
            {
                return View();

            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }

}
