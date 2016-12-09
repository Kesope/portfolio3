using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/comments")]
    public class CommentsController : BaseController
    {
        public CommentsController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.CommentsRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetComments(page, pagesize)
                .Select(c => ModelFactory.cMap(c, Url));
            var total = DataService.GetNumberOfComments();

            var result = new
            {
                total = total,
                prev = GetPrevCommentUrl(Url, page, pagesize),
                next = GetNextCommentUrl(Url, page, pagesize, total),
                data = data
            };

            return Ok(result);
        }

        


        // GET api/values/5
        [HttpGet("{id}", Name = Config.CommentRoute)]
        public IActionResult Get(int id)
        {
            var comment = DataService.GetComment(id);
            if (comment == null) return NotFound();
            return Ok(ModelFactory.cMap(comment, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CommentModel model)
        {
            var comment = ModelFactory.cMap(model);
            DataService.AddComment(comment);
            return Ok(ModelFactory.cMap(comment, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentModel model)
        {
            var comment = ModelFactory.cMap(model);
            comment.id = id;
            if (!DataService.UpdateComment(comment))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteComment(id))
            {
                return NotFound();
            }

            return Ok();
        }


        
    }
}
