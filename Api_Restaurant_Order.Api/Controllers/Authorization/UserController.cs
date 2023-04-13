using Api_Restaurant_Order.Application.DTOs.Authorization;
using Api_Restaurant_Order.Application.Services.Interface.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Restaurant_Order.Api.Controllers.Authorization
{
    [Route("Auth/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        #region Documentation
        /// POST api/User
        /// <summary>
        ///  Register a user in the User entity
        /// </summary>
        /// <response code="200">
        ///  Return will be a successfully created user 
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterAsync([FromForm] UserDTO userDTO)
        {
            try
            {
                var result = await _userService.Register(userDTO);
                if (result.IsSuccess)
                    return Ok(result.Data);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }

        #region Documentation
        /// POST api/User/signin
        /// <summary>
        ///  Generates a token with the permissions for the user to be authenticated and authorized
        /// </summary>
        /// <remarks name="basicAutenticate">User name and password [name:pass] in base64</remarks>
        /// <response code="200">
        /// Retorno será token de acesso e refreshToken 
        /// </response>
        /// <response code="400">Return will be access token and refreshToken
        /// </response>  
        #endregion
        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult> SigninAsync([FromForm] UserSigninDTO userDTO)
        {
            try
            {

                var result = await _userService.Signin(userDTO);
                if (result.IsSuccess)
                    return Ok(result.Data);

                return BadRequest(result);

            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }

        }

        #region Documentation
        /// POST api/User/refreshtoken
        /// <summary>
        ///   Generates a new token with the permissions for the user to be authenticated and authorized
        /// </summary>
        /// <response code="200">
        ///  Return will be a new access token and refreshToken
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<ActionResult> RefreshTokenAsync([FromForm] RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                var result = await _userService.RefreshToken(refreshTokenDTO);
                if (result.IsSuccess)
                    return Ok(result.Data);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }

        }


        #region Documentation
        /// Get api/User/getpermission
        /// <summary>
        ///   Search all registered permissions
        /// </summary>
        /// <response code="200">
        ///  Return will be a list with existing permissions
        /// </response>
        /// <response code="400">Return with description of what is missing from the request
        /// </response>  
        #endregion
        [HttpGet]
        [Route("getpermission")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var result = await _userService.PermissionAsync();
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex.GetaAllMessages());
                return result;
            }
        }
    }
}
