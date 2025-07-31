using Microsoft.AspNetCore.Mvc;
using OpenSenseMapAssessment.Models.User;
using OpenSenseMapAssessment.Services.User;

namespace OpenSenseMapAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Registers a new user in OpenSenseMap.
        /// </summary>
        /// <param name="request">Contains name, email, and password.</param>
        /// <returns>Returns user info and token on success.</returns>
        /// <response code="200">User registered successfully</response>
        /// <response code="400">Validation or registration error</response>
        [HttpPost("register")]
        public async Task<IActionResult> UsersRegister([FromBody] UserRegisterRequest request)
        {
            try
            {
                var result = await _usersService.RegisterUserAsync(request);
                return Ok(result);
            }
            catch(ApplicationException  ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Authenticates a user and returns a token.
        /// </summary>
        /// <param name="request">Contains email and password.</param>
        /// <returns>Returns login info and token on success.</returns>
        /// <response code="200">Login successful</response>
        /// <response code="403">Invalid credentials</response>
        [HttpPost("sign-in")]
        public async Task<IActionResult> UsersLogin([FromBody] UserLoginRequest request)
        {
            try
            {
                var result = await _usersService.LoginUserAsync(request);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(403, new { code = "UnauthorizedError", message = ex.Message });
            }

        }

        /// <summary>
        /// Logs out the current authenticated user.
        /// </summary>
        /// <returns>Returns a logout confirmation message.</returns>
        /// <response code="200">Logout successful</response>
        /// <response code="403">Invalid JWT or session</response>
        [HttpPost("sign-out")]
        public async Task<IActionResult> UsersLogout()
        {
            try
            {
               bool result =  await _usersService.LogoutUserAsync();
                if (result)
                {
                    return Ok(new { message = "Successfully signed out", status = 200 });
                }
                else
                {
                    // This case may not happen given your service throws on failure,
                    // but just in case:
                    return StatusCode(500, new { message = "Logout failed for unknown reasons.", status = 500 });
                }                
            }
            catch (ApplicationException ex)
            {
                return StatusCode(403, new { message = "Invalid JWT. Please sign sign in", status = 403 });
            }
        }

    }
}
