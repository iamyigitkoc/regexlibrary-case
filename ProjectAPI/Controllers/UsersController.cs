using Microsoft.AspNetCore.Mvc;
using ProjectAPI.DTO;
using ProjectAPI.Request;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/v1.0/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> register( [FromBody] CreateUserRequest createUserRequest ) {

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            try {
                UserDTO userDTO = _userService.Create(createUserRequest);
                return CreatedAtRoute("GetUser", new { id = userDTO.Id }, userDTO);
            } catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUser(int id) { 
            UserDTO? userDto = _userService.GetUserAsDTO(id);
            if (userDto != null) {
                return Ok(userDto);
            }
            return NotFound("User not found");
        }

    }
}
