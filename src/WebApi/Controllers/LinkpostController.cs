using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/linkpost")]
    public class LinkpostController : BaseController
    {
        public LinkpostController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/values
        [HttpGet(Name = Config.LinkpostsRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetLinkpost(page, pagesize)
                .Select(lp => ModelFactory.lpMap(lp, Url));


            var total = DataService.GetNumberOfLinkpost();

            var result = new
            {
                total = total,
                prev = GetPrevLinkpostUrl(Url, page, pagesize),
                next = GetNextLinkpostUrl(Url, page, pagesize, total),
                data = data
            };


            return Ok(result);

        }




        // GET api/values/5
        [HttpGet("{id}", Name = Config.LinkpostRoute)]
        public IActionResult Get(int id)
        {
            var linkpost = DataService.GetLinkpost(id);
            if (linkpost == null) return NotFound();
            return Ok(ModelFactory.lpMap(linkpost, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] LinkpostModel model)
        {
            var linkpost = ModelFactory.lpMap(model);
            DataService.AddLinkpost(linkpost);
            return Ok(ModelFactory.lpMap(linkpost, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LinkpostModel model)
        {
            var linkpost = ModelFactory.lpMap(model);
            linkpost.postid = id;
            if (!DataService.UpdateLinkpost(linkpost))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteLinkpost(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
