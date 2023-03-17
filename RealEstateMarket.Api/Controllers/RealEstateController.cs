using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateMarket.Api.DTOs;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Application.RealEstates.Commands.Create;
using RealEstateMarket.Application.RealEstates.Commands.Delete;
using RealEstateMarket.Application.RealEstates.Commands.Update;
using RealEstateMarket.Application.RealEstates.Queries.ListAllPaged;
using RealEstateMarket.Application.RealEstates.Queries.ListById;
using RealEstateMarket.Domain;
using RealEstateMarket.Domain.Entities;
using System.Numerics;
using System.Reflection.Emit;

namespace RealEstateMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RealEstateController> _logger;

        public RealEstateController(IMediator mediator, IRealEstateRepository realEstateRepository, ILogger<RealEstateController> logger)
        {
            _mediator = mediator;
            this._logger = logger;
        }


        // GET: api/<RealEstateController>
        [HttpGet]
        public async Task<IActionResult> GetAllPaged([FromQuery]ListAllPagedQuery listAllPagedQuery)
        {
            var listResult = await _mediator.Send(listAllPagedQuery);
            _logger.LogInformation("Requesting real estates from... to... .");
            return Ok(listResult);
        }

        // GET api/<RealEstateController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]ListByIdQuery listByIdQuery)
        {
            var realEstate = await _mediator.Send(listByIdQuery);
            if(realEstate == null)
            {
                return NotFound();
            }

            return Ok(realEstate); 
        }


        // POST api/<RealEstateController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCommand createCommand)
        {
            var createResult = await _mediator.Send(createCommand);

            return createResult.IsSuccesful ? 
                Ok(new { message = "Real estate created." }) : 
                BadRequest(new { Errors = createResult.Errors });
        }

        // PUT api/<RealEstateController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateCommand updateCommand)
        {
            var updateResult = await _mediator.Send(updateCommand);
            if (!updateResult.IsSuccesful)
            {
                return BadRequest(updateResult.Errors);
            }

            return Ok(new { message = "Real estate updated." });
        }

        // DELETE api/<RealEstateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteCommand deleteCommand)
        {
            await _mediator.Send(deleteCommand);
            return Ok(new { message = "Real estate deleted." });
        }
    }
}
