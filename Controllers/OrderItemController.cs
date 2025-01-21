using api.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.Models;
using Smart_Inventory_Management_System.Repositories;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly IMapper _mapper;
        public OrderItemController(IOrderItemRepository orderItemRepo, IMapper mapper)
        {
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{orderId:int}")]
        [Authorize]
        public async Task<IActionResult> GetOrderItems([FromRoute] int orderId)
        {
            var orderItems = await _orderItemRepo.GetOrderItems(orderId);

            if (orderItems == null || orderItems.Count == 0)
            {
                return NotFound("OrderItems not found");
            }

            var orderItemDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);

            return Ok(orderItemDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrderItemRequestDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (createDto.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }

            var OrderItemModel = _mapper.Map<OrderItem>(createDto);
            await _orderItemRepo.CreateAsync(OrderItemModel);
            return CreatedAtAction(nameof(GetOrderItems), new { orderId = OrderItemModel.OrderId, productId = OrderItemModel.ProductId }, _mapper.Map<OrderItemDto>(OrderItemModel));
        }

        [HttpDelete]
        [Route("{orderId:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            var deletedOrderItem = await _orderItemRepo.DeleteOrderItem(orderId);

            if (deletedOrderItem == null)
            {
                return NotFound("OrderItem not found");
            }

            return Ok(deletedOrderItem);
        }
    }
}
