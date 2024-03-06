using KzTrail.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KzTrail.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {

            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();

            try
            {
                // Get all regions from web api
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7296/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();
                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

            }
            catch (Exception ex)
            {
                //Log the exception
                throw ex;
            }
            return View(response);
        }
    }
}
