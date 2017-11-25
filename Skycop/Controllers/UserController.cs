using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skycop.BAL.BusinessLogic;
using Skycop.Common.Constants;
using Skycop.Common.Exceptions;
using Skycop.Model.Models;
using System;
using System.Threading.Tasks;

namespace Skycop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        UserBAL _balUser = new UserBAL();

        #region stubs

        [HttpGet("getUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var data = _balUser.GetUsers();
                return SuccessResponse(data);
            }
            catch (DataNotFoundException ex)
            {
                return ErrorResponse(ErrorConstants.DATA_NOT_FOUND);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        [HttpGet("GetPolledDevices")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPolledDevices()
        {
            try
            {
                var data = _balUser.GetDevices();
                return SuccessResponse(data);
            }
            catch (DataNotFoundException ex)
            {
                return ErrorResponse(ErrorConstants.DATA_NOT_FOUND);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        [HttpGet("getroles")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var data = _balUser.GetRoles();
                return SuccessResponse(data);
            }
            catch (DataNotFoundException ex)
            {
                return ErrorResponse(ErrorConstants.DATA_NOT_FOUND);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
        }

        [HttpPost("adduser")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser([FromBody]User model)
        {
            try
            {
                return SuccessResponse(SuccessConstants.SAVE_SUCCESSFULLY);
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