using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateMarket.Api.DTOs;
using System.Text.Json;

namespace RealEstateMarket.Api.Pages.RealEstate
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public RealEstateDTO RealEstate{ get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //todo: mapper, error message for validation errors
            RealEstateDTO realEstateDTO = new RealEstateDTO()
            {
                City = RealEstate.City,
                Description = RealEstate.Description,
                Email = RealEstate.Email,
                HouseNumber = RealEstate.HouseNumber,
                Phone = RealEstate.Phone,
                Price = RealEstate.Price,
                Region = RealEstate.Region,
                StreetName = RealEstate.StreetName,
                ZipCode = RealEstate.ZipCode,
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7056/api/RealEstate")
            {
                Content = JsonContent.Create(realEstateDTO),

            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
               return RedirectToPage("/Index");
            }
            //todo: error page
            return Page();
        }
    }
}
