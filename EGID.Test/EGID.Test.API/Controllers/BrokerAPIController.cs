using AutoMapper;
using EGID.Test.API.Data.Dtos;
using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Controllers
{
    [Route("api/broker")]
    [ApiController]
    public class BrokerAPIController : ControllerBase
    {
        private readonly IBrokerService _BrokerService;
        private readonly IMapper _mapper;
        public BrokerAPIController(IBrokerService BrokerService, IMapper mapper)
        {
            _mapper = mapper;
            _BrokerService = BrokerService;
        }
        [HttpGet("list")]
        [Produces("application/json")]
        public async Task<ActionResult> GetBrokers()
        {
            try
            {
                var Brokers = await _BrokerService.GetAllBrokers();

                if (Brokers == null)
                    return NotFound();
                var BrokersResources = _mapper.Map<IEnumerable<Broker>, IEnumerable<BrokerResource>>(Brokers);

                return Ok(BrokersResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
