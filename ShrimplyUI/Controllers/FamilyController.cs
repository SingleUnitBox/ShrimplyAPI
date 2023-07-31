using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.Models.Domain;
using ShrimplyUI.Models;
using ShrimplyUI.Models.Dto;
using System.Text;
using System.Text.Json;

namespace ShrimplyUI.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FamilyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<FamilyDto> response = new List<FamilyDto>();
            //get all families from api
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponse = await client.GetAsync("https://localhost:7272/api/family");

                httpResponse.EnsureSuccessStatusCode();

                response.AddRange(await httpResponse.Content.ReadFromJsonAsync<IEnumerable<FamilyDto>>());
            }
            catch (Exception ex)
            {
                //log ex
            }

            return View(response);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddFamilyViewModel addFamilyViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7272/api/family"),
                Content = new StringContent(JsonSerializer.Serialize(addFamilyViewModel), Encoding.UTF8, "application/json"),
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<FamilyDto>();

            if (response != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
