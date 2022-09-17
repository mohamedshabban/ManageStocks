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
    [Route("api/client")]
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        private readonly IClientService _ClientService;
        private readonly IMapper _mapper;
        public PersonAPIController(IClientService ClientService, IMapper mapper)
        {
            this._ClientService = ClientService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        [Produces("application/json")]
        public async Task<ActionResult> GetClients()
        {
            try
            {
                var Clients = await _ClientService.GetAllClients();

                if (Clients == null)
                    return NotFound();
                var ClientsResources = _mapper.Map<IEnumerable<Person>, IEnumerable<ClientResource>>(Clients);

                return Ok(ClientsResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
