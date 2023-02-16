using Microsoft.AspNetCore.Mvc;
using RealEstateMarket.Api.Context;
using RealEstateMarket.Api.Models;
using RealEstateMarket.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private IRealEstateRepository _realEstateRepository;

        public RealEstateController(IRealEstateRepository realEstateRepository)
        {
            this._realEstateRepository = realEstateRepository;
        }


        // GET: api/<RealEstateController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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

        // todo

        //// POST api/<RealEstateController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        //// PUT api/<RealEstateController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RealEstateController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
