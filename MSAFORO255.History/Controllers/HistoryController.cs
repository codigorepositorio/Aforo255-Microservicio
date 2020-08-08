using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSAFORO255.History.Service;

namespace MSAFORO255.History.Controllers
{

    [Route("api/History")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpGet("{accounIdd}")]
        public async Task<IActionResult> GetHistory(int accounIdd)
        {
            var result = await _historyService.GetAll();

            var data = result.Where(x => x.IdTransaction == accounIdd).ToList();

            return View(data);
        }

    }
}
