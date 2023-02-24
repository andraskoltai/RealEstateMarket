using Microsoft.AspNetCore.Mvc;
using RealEstateMarket.Api.DTOs;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;

namespace RealEstateMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly ILogger<RealEstateController> _logger;

        public RealEstateController(IRealEstateRepository realEstateRepository, ILogger<RealEstateController> logger)
        {
            this._realEstateRepository = realEstateRepository;
            this._logger = logger;
        }


        // GET: api/<RealEstateController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Requesting every real estate.");
            return Ok(await _realEstateRepository.GetAllAsync());
        }

        // GET api/<RealEstateController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var realEstate = await _realEstateRepository.GetByIdAsync(id);
            if(realEstate == null)
            {
                return NotFound();
            }

            return Ok(realEstate); 
        }


        // POST api/<RealEstateController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RealEstateDTO realEstate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid real estate format." });
            }

            // todo: automapper
            var createdRealEstate = new RealEstate
            {
                City = realEstate.City,
                Description = realEstate.Description,
                Email = realEstate.Email,
                HouseNumber = realEstate.HouseNumber,
                Id = new Guid(),
                Phone = realEstate.Phone,
                Price = realEstate.Price,
                Region = realEstate.Region,
                StreetName = realEstate.StreetName,
                ZipCode = realEstate.ZipCode,
            };

            await _realEstateRepository.InsertAsync(createdRealEstate);
            return Ok(new { message = "Real estate created." });
        }

        // PUT api/<RealEstateController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] RealEstateDTO realEstate)
        {
            var updatedRealEstate = await _realEstateRepository.GetByIdAsync(id);
            updatedRealEstate.City = realEstate.City;
            updatedRealEstate.Description = realEstate.Description;
            updatedRealEstate.Email = realEstate.Email;
            updatedRealEstate.HouseNumber = realEstate.HouseNumber;
            updatedRealEstate.Phone = realEstate.Phone;
            updatedRealEstate.Price = realEstate.Price;
            updatedRealEstate.Region = realEstate.Region;
            updatedRealEstate.StreetName = realEstate.StreetName;
            updatedRealEstate.ZipCode = realEstate.ZipCode;
            await _realEstateRepository.UpdateAsync(updatedRealEstate);

            return Ok(new { message = "Real estate updated." });
        }

        // DELETE api/<RealEstateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _realEstateRepository.DeleteAsync(id);
            return Ok(new { message = "Real estate deleted." });
        }
    }
}
