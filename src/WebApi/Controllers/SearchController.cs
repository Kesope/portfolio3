using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/search")]
    public class SearchController : BaseController
    {
        public SearchController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.SearchResultRoute)]
        public IActionResult Get(String searchstring)
        {
            var data = DataService.EFShowSearchResult(searchstring)
                .Select(s => ModelFactory.SearchMap(s));

            var result = new
            {
                Url = Url.Link(Config.SearchResultRoute, new { searchstring }),
                Result = data
            };

            return Ok(result);

        }
    }
}

