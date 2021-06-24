using YTCSearcherApi.Models;
using YTCSearcherApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace YTCSearcherApi.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IDbOperationsService _dataOpService;

        public StatisticController(IDbOperationsService dataOpService)
        {
            _dataOpService = dataOpService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] RequestDataModel data)
        {
            try
            {
                if (data == null)
                    throw new NullReferenceException("Null RequestData from POST request.");

                await _dataOpService.Create(data);
                return Ok();
            }
            catch (NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
