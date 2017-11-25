using Microsoft.AspNetCore.Mvc;
using Skycop.Common.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skycop.Controllers
{
    public class BaseController : ControllerBase
    {
        protected OkObjectResult SuccessResponse(object result)
        {
            var response = new SuccessResponse(result);
            return Ok(response);
        }

        protected OkObjectResult SuccessResponse(string successCode)
        {
            var response = new SuccessResponse(SuccessConstants.GetSuccessMessage(successCode));
            return Ok(response);
        }

        protected BadRequestObjectResult ErrorResponse(string errorCode)
        {
            var response = new FailureResponse(errorCode);
            return BadRequest(response);
        }
    }

    #region API Response
    public interface IResponse { }

    public class SuccessResponse : APIResponse, IResponse
    {
        public SuccessResponse(object result)
        {
            this.status = ResponseConstants.SUCCESS;
            this.data = result;
        }

        public object data { get; set; }
    }

    public class FailureResponse : APIResponse, IResponse
    {
        public FailureResponse(string code) : base(ResponseConstants.FAILURE, code, ErrorConstants.GetErrorMessage(code)) { }
        public FailureResponse(string code, string message) : base(ResponseConstants.FAILURE, code, message) { }
    }

    public class APIResponse
    {
        public APIResponse() { }
        public APIResponse(int status, string code, string message)
        {
            this.status = status;
            this.error = new APIError() { code = code, message = message };
        }

        public int status { get; set; }
        public APIError error { get; set; }
    }

    public class APIError
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class ResponseConstants
    {
        public static int FAILURE = 0;
        public static int SUCCESS = 1;
    }
    #endregion
}
