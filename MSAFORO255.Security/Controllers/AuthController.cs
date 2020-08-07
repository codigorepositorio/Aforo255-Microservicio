using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSAFORO255.Security.Service;

namespace MSAFORO255.Security.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public AuthController(IAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accessService.GetAll());
        }
    }
}
