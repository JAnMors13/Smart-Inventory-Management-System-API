using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserProfileController(IUserRepository userRepo, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _mapper = mapper;
        }

        // Fetch all users (Only Admin & Manager can access)
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var users = await _userRepo.GetAllUsersAsync();
            if (users == null || !users.Any()) return NotFound(new { message = "No users found" });

            var userDtos = _mapper.Map<List<UserProfileDto>>(users);

            // Fetch user roles in parallel
            foreach (var userDto in userDtos)
            {
                var user = await _userManager.FindByIdAsync(userDto.Id);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Role = roles.FirstOrDefault() ?? "User";
            }

            return Ok(userDtos);
        }

        // Fetch a user by ID (Only Admin & Manager can access)
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfileById([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetUserProfileById(id);
            if (user == null) return NotFound(new { message = "User not found" });

            var userDto = _mapper.Map<UserProfileDto>(user);

            var roles = await _userManager.GetRolesAsync(user);
            userDto.Role = roles.FirstOrDefault() ?? "User";

            return Ok(userDto);
        }

        // Fetch the logged-in user profile
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                         User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "User ID not found in claims" });

            var user = await _userRepo.GetUserProfileById(userId);
            if (user == null) return NotFound(new { message = "User not found" });

            var userProfileDto = _mapper.Map<UserProfileDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userProfileDto.Role = roles.FirstOrDefault() ?? "User";

            return Ok(userProfileDto);
        }
    }
}
