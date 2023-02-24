using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateMarket.Api.DTOs;
using System.Numerics;
using System.Reflection.Emit;

namespace RealEstateMarket.Api.Pages.RealEstate
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public Domain.Entities.RealEstate RealEstate { get; set; }

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGet(Guid id)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7056/api/RealEstate/" + RealEstate.Id)
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
