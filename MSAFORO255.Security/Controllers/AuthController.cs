using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.AFORO255.Cross.Jwt.Src;
using MSAFORO255.Security.DTO;
using MSAFORO255.Security.Service;

namespace MSAFORO255.Security.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;

        private readonly JwtOptions _options;

        public AuthController(IAccessService accessService, IOptionsSnapshot<JwtOptions> options)
        {
            _accessService = accessService;
            _options = options.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accessService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            var acceso = _accessService.Validate(request.UserName, request.Password);
            if (!acceso)
            {
                return Unauthorized();
            }
            var token = JwtToken.Create(_options);

            Response.Headers.Add("access-control-expose-headers","Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_options));

            return Ok();

            //return Ok(new { token });
        }
    }
}
