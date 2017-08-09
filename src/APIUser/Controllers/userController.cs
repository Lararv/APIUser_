using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIUser.Models;

namespace APIUser.Controllers
{
    [Route("api/[controller]")]
    public class userController : Controller
    {
        public IuserRepository _userRepository { get; set; }

        public userController(IuserRepository userRepository)
        {
            _userRepository = userRepository;
        }        

        [HttpGet]
        public IEnumerable<user> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _userRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        #region snippet_Create
        [HttpPost]
        public IActionResult Create([FromBody] user item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _userRepository.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody]user item)
       
        {
            if (item == null || item.Id != id)
            {
               return BadRequest();
            }

            var todo = _userRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Birthdate = item.Birthdate;
            todo.Name = item.Name;

            _userRepository.Update(todo);
            // return new NoContentResult();
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _userRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _userRepository.Remove(id);
            return new NoContentResult();
        }
        #endregion
    }

}
