using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/tags")]
    public class TagsController :BaseController
    {
        public TagsController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/values
        [HttpGet(Name = Config.TagsRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetTags(page, pagesize)
                .Select(t => ModelFactory.tMap(t, Url));


            var total = DataService.GetNumberOfTags();

            var result = new
            {
                total = total,
                prev = GetPrevPostUrl(Url, page, pagesize),
                next = GetNextPostUrl(Url, page, pagesize, total),
                data = data
            };


            return Ok(result);

        }




        // GET api/values/5
        [HttpGet("{id}", Name = Config.TagRoute)]
        public IActionResult Get(int id)
        {
            var tags = DataService.GetTags(id);
            if (tags == null) return NotFound();
            return Ok(ModelFactory.tMap(tags, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Tags([FromBody] TagsModel model)
        {
            var tags = ModelFactory.tMap(model);
            DataService.AddTags(tags);
            return Ok(ModelFactory.tMap(tags, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TagsModel model)
        {
            var tags = ModelFactory.tMap(model);
            tags.id = id;
            if (!DataService.UpdateTags(tags))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteTags(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }

}
