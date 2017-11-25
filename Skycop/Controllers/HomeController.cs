using Microsoft.AspNetCore.Mvc;
using Skycop.Common.Constants;
using System.Threading.Tasks;

namespace Skycop.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : BaseController
    {
        public async Task<IActionResult> IsAlive(bool checkError = false)
        {
            if (checkError)
            {
                return ErrorResponse(ErrorConstants.API_INTERNAL_ERROR);
            }
            return SuccessResponse(SuccessConstants.IS_ALIVE);
        }
    }
}