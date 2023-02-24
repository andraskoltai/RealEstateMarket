using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace RealEstateMarket.Api.Pages.RealEstate
{
    public class ListAllModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<Domain.Entities.RealEstate> RealEstates { get; set; }

        public ListAllModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7056/api/RealEstate");
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
                //todo: error page
            }

            RealEstates = await httpResponseMessage.Content.ReadFromJsonAsync<List<Domain.Entities.RealEstate>>();
            return Page();
        }
    }
}
