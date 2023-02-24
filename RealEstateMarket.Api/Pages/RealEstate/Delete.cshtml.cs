using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace RealEstateMarket.Api.Pages.RealEstate
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7056/api/RealEstate/" + id);
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
                //todo: error page
            }

            return Page();
        }
    }
}
