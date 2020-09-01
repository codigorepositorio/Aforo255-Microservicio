using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MSAFORO255.History.DTO;
using MSAFORO255.History.Model;
using MSAFORO255.History.Service;

namespace MSAFORO255.History.Controllers
{

    [Route("api/History")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IHistoryService _historyService;

        public HistoryController(IDistributedCache distributedCache, IHistoryService historyService)
        {
            _distributedCache = distributedCache;
            _historyService = historyService;
        }

        [HttpGet("{accounId}")]
        public async Task<IActionResult> GetHistory(int accounId)
        {
            string _key = $"key-account-{accounId}";

            var _cache = _distributedCache.GetString(_key);
            List<HistoryResponse> model = null;
            if (_cache == null)
            {
                var result = await _historyService.GetAll();
                model = result.Where(x => x.AccountId.Equals(accounId)).ToList();

                var options = new DistributedCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                _distributedCache.SetString(_key, Newtonsoft.Json.JsonConvert.SerializeObject(model), options);
            }
            else
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HistoryResponse>>(_cache);
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHistory(HistoryTransaction request)
        {
            await _historyService.Add(request);
            return Ok();
        }

    }
}
