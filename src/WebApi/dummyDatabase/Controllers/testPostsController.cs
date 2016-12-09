using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapKnockout.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapKnockout.Controllers
{
    [Route("api/testposts")]
    public class testPostsController : Controller
    {
        private readonly testIDataService _dataService;

        public testPostsController(testIDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataService.GetDummyPosts());
        }
    }
}
