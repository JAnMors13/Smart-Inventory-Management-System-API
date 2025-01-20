using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserProfiileController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserProfiileController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string username)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetUserAsync(username);
            var userDto = _mapper.Map<UserProfileDto>(user);

            return Ok(userDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Adduser([FromBody] CreateUserProfileRequestDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            

            var userModel = _mapper.Map<UserProfile>(createDto);
            await _userRepo.AddUserAsync(userModel);

            return CreatedAtAction(nameof(GetUser), new { id = userModel.Username }, _mapper.Map<UserProfileDto>(userModel));
        }
    }
}
