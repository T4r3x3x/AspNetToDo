using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Representation.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public ProjectController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [Route("/data")]
        [HttpGet]
        public IActionResult ActionResult()
        {
            return Json(new { massage = "Hello world!" });
        }
    }
}