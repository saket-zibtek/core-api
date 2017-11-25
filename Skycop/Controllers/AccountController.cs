using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skycop.Common.Constants;
using Skycop.Common.Exceptions;
using Skycop.Model.Models;
using System;
using System.Threading.Tasks;

namespace Skycop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        #region stubs

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]Login model)
        {
            try
            {
                return SuccessResponse(SuccessConstants.LOGIN_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        [HttpPost("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody]Login model)
        {
            try
            {
                return SuccessResponse(SuccessConstants.LOGIN_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        [HttpPost("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody]Login model)
        {
            try
            {
                return SuccessResponse(SuccessConstants.PASSWORD_UPDATED_SUCCESSFULLY);
            }
            catch (DataIsNotSavedException ex)
            {
                return ErrorResponse(ErrorConstants.DATA_NOT_SAVED);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        #endregion
    }
}