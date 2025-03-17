using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SaidaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/lista";
            List<SaidaDTO> categorias = new List<SaidaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                categorias = JsonSerializer.Deserialize<List<SaidaDTO>>(json);
                ViewBag.Categorias = categorias;


            }
            catch (Exception)
            {
                return View();

            }
            return View();
        }
    }
}
