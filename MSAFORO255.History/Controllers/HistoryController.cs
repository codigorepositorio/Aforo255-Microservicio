using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSAFORO255.Deposit.Model;
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


        [HttpGet("{accounId}")]
        public async Task<IActionResult> GetHistory(int accounId)
        {
            var result = await _historyService.GetAll();

            var data = result.Where(x => x.AccountId.Equals(accounId)).ToList();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHistory(HistoryTransaction request)
        {
            await _historyService.Add(request);
            return  Ok();
        }

    }
}
