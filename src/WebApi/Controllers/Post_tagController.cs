using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/post_tag")]
    public class Post_tagController : BaseController
    {
        public Post_tagController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/values
        [HttpGet(Name = Config.Post_tagsRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetPost_tag(page, pagesize)
                .Select(pt => ModelFactory.ptMap(pt, Url));


            var total = DataService.GetNumberOfPost_tag();

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
        [HttpGet("{id}", Name = Config.Post_tagRoute)]
        public IActionResult Get(int id)
        {
            var post_tag = DataService.GetPost_tag(id);
            if (post_tag == null) return NotFound();
            return Ok(ModelFactory.ptMap(post_tag, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Post_tagModel model)
        {
            var pt = ModelFactory.ptMap(model);
            DataService.AddPost_tag(pt);
            return Ok(ModelFactory.ptMap(pt, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post_tagModel model)
        {
            var post_tag = ModelFactory.ptMap(model);
            post_tag.id = id;
            if (!DataService.UpdatePost_tag(post_tag))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeletePost_tag(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
