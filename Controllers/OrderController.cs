using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        public OrderController(IOrderRepository orderRepo, IMapper mapper, IUserRepository userRepo)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = await _orderRepo.GetOrderAsync();
            var orderDto = _mapper.Map<IEnumerable<OrderDto>>(order);

            return Ok(orderDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null) return NotFound();

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost("{userId:int}")]
        public async Task<IActionResult> AddOrder([FromRoute] int userId, [FromBody] CreateOrderRequestDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _userRepo.UserExistsAsync(userId))
            {
                return BadRequest("Order does not exists");
            }

            var orderModel = _mapper.Map<Order>(createDto);
            orderModel.UserId = userId;
            await _orderRepo.AddOrderAsync(orderModel);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderModel.Id }, _mapper.Map<OrderDto>(orderModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!await _userRepo.UserExistsAsync(updateDto.UserId))
            {
                return BadRequest("Invalid UserId. The specified User does not exist.");
            }

            var order = await _orderRepo.UpdateOrderAsync(id, _mapper.Map<UpdateOrderRequestDto>(updateDto));
            if (order == null) return NotFound("Order Not Found");

            return Ok(_mapper.Map<OrderDto>(order));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = await _orderRepo.DeleteOrderAsync(id);
            if (order == null) return NotFound("Order not found");

            return Ok(order);
        }
    }
}
