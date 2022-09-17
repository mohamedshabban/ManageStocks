using AutoMapper;
using EGID.Test.API.Data.Dtos;
using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.Services;
using EGID.Test.API.Data.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        public OrderAPIController(IOrderService OrderService, IMapper mapper)
        {
            this._OrderService = OrderService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        [Produces("application/json")]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                var Orders = await _OrderService.GetAllOrders();

                if (Orders == null)
                    return NotFound();
                var OrdersResources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(Orders);

                return Ok(OrdersResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("")]
        public async Task<ActionResult<OrderResource>> CreateOrder([FromBody] SaveOrderResource saveOrderResource)
        {
            try
            {
                var validator = new SaveOrderResourceValidator();
                var validationResult = await validator.ValidateAsync(saveOrderResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok
                var OrderToCreate = _mapper.Map<SaveOrderResource, Order>(saveOrderResource);

                var newOrder = await _OrderService.CreateOrder(OrderToCreate);

                var Order = await _OrderService.GetOrderById(newOrder.ID);

                var OrderResource = _mapper.Map<Order, OrderResource>(Order);

                return Ok(OrderResource);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
