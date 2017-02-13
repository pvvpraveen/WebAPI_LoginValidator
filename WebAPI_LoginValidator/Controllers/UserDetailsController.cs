using System.Web.Http;
using WebAPI_LoginValidator.Models;

namespace WebAPI_LoginValidator.Controllers
{
    public class UserDetailsController : ApiController
    {
        public IHttpActionResult Post(UserDetails userDetails)
        {
            var actionResult = ModelState.IsValid ? (IHttpActionResult) Ok() : BadRequest(ModelState);
            return actionResult;
        }
    }
}
