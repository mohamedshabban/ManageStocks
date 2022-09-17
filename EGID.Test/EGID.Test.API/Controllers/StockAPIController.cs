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
    [Route("api/stock")]
    [ApiController]
    public class StockAPIController : ControllerBase
    {
        private readonly IStockService _StockService;
        private readonly IMapper _mapper;
        public StockAPIController(IStockService StockService, IMapper mapper)
        {
            this._StockService = StockService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        [Produces("application/json")]
        public async Task<ActionResult> GetStocks()
        {
            try
            {
                var Stocks = await _StockService.GetAllStocks();

                if (Stocks == null)
                    return NotFound();
                var StocksResources = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockResource>>(Stocks);

                return Ok(StocksResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
