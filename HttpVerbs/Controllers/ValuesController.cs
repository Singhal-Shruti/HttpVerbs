using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HttpVerbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Dictionary<int,User> Users = new Dictionary<int,User>{
            {1, new User(1, "a", "a@a.com")} ,
            {2, new User(2, "b", "b@b.com")}
        };

        // GET api/values
        [HttpGet]
        public ActionResult<Dictionary<int,User>> Get()
        {
            return Users;
        }

        // GET api/values/1
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Users[id];
        }

        // POST api/values
        // Request Body {"userId": 3, "userName": "c", "userEmail": "c@c.com"}
        [HttpPost]
        public StatusCodeResult Post(User value)
        {
            Users.Add(3, value);
            return new StatusCodeResult(200);
        }

        // PUT api/values/1
        // Request Body {"userId": 1, "userName": "aa", "userEmail": "aa@a.com"}
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, User value)
        {
            Users[id] = value;
            return new OkResult();
        }

        // DELETE api/values/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //PATCH api/values/1
        // Request Body [{"op" : "replace", "path" : "/userEmail", "value" : "c@c.com"}]
        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, JsonPatchDocument<User> value)
        {
            value.ApplyTo(Users[id]);
            return new StatusCodeResult(201);
        }
    }
}
