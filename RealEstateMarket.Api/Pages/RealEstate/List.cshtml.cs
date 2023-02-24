using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RealEstateMarket.Api.Pages.RealEstate
{
    public class ListModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Domain.Entities.RealEstate RealEstate { get; set; }

        public ListModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7056/api/RealEstate/" + id);
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
                //todo: error page
            }

            RealEstate = await httpResponseMessage.Content.ReadFromJsonAsync<Domain.Entities.RealEstate>();
            return Page();
        }
    }
}
