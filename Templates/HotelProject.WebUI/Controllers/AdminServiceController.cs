using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly HttpClient _client;

        public AdminServiceController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync("http://localhost:5093/api/service");   //yazılı olan url'e client nesnesi ile get isteği atıyoruz. Geriye durum kodu dönüyor(responsemessage).
            if (responseMessage.IsSuccessStatusCode) //eğer durum kodu başarılı olursa(200-299) jsondatayı alıcaz.
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //yukarıdan gelen değerleri jsondata formatında okuduk.Gelen değerleri deserialize ediyoruz.jsondan->stringe.
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }

            return View();
            //var values = await _client.GetFromJsonAsync<List<ResultServiceDto>>("service");
            //return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var service = JsonConvert.SerializeObject(createServiceDto);

            var stringContent = new StringContent(service, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync("http://localhost:5093/api/service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var responseMessage = await _client.DeleteAsync("http://localhost:5093/api/service/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var responseMessage = await _client.GetAsync("http://localhost:5093/api/service/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var service = JsonConvert.SerializeObject(updateServiceDto);

            var stringContent = new StringContent(service, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PutAsync("http://localhost:5093/api/service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
