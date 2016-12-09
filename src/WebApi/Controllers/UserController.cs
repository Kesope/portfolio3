using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/values
        [HttpGet(Name = Config.UsersRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetUser(page, pagesize)
                .Select(u => ModelFactory.uMap(u, Url));


            var total = DataService.GetNumberOfUser();

            var result = new
            {
                total = total,
                prev = GetPrevUserUrl(Url, page, pagesize),
                next = GetNextUserUrl(Url, page, pagesize, total),
                data = data
            };


            return Ok(result);

        }




        // GET api/values/5
        [HttpGet("{id}", Name = Config.UserRoute)]
        public IActionResult Get(int id)
        {
            var user = DataService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(ModelFactory.uMap(user, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UserModel model)
        {
            var user = ModelFactory.uMap(model);
            DataService.AddUser(user);
            return Ok(ModelFactory.uMap(user, Url));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel model)
        {
            var user = ModelFactory.uMap(model);
            user.id = id;
            if (!DataService.UpdateUser(user))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteUser(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }

}
