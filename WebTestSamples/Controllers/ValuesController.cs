using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Linq;
using WebTestSamples.ViewModel;

namespace WebTestSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly ConcurrentDictionary<int, FixedSizedQueue<decimal>> MainQueue = new ConcurrentDictionary<int, FixedSizedQueue<decimal>>();
        private static readonly int QueueSize = 10;

        [HttpPost]
        public void AddExchange([FromForm]ExchangeInfoModel exchangeInfo)
        {
            if (ModelState.IsValid)
            {
                if (MainQueue.TryGetValue(exchangeInfo.id, out var queue))
                {
                    queue.Enqueue(exchangeInfo.Amount);
                }
                else
                {
                    MainQueue[exchangeInfo.id] = new FixedSizedQueue<decimal>(QueueSize, exchangeInfo.Amount);
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<int> GetFibonacci(int n)
        {
            return Ok(Enumerable.Range(1, n)
                       .Skip(2)
                       .Aggregate(new { Current = 1, Prev = 1 }, (x, index) => new { Current = x.Prev + x.Current, Prev = x.Current })
                       .Current);
        }
    }
}
