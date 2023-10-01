using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasKing.TasKingData;
using TasKing.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasKing.Controllers
{
    [Route("api/[controller]")]
    public class TasKingController : ControllerBase
    {
        private ITasKingData _todoData;
        public TasKingController(ITasKingData toDoData)
        {
            _todoData = toDoData;
        }

        // GET: api/values
        [HttpGet]
        [Route("api/[controller]")]
        ///<Summary>
        ///This method gets all the to do items
        ///</Summary>
        public IActionResult Get()
        {
            return Ok(_todoData.GetTodoList());
        }

        // GET api/values/5
        /// <summary>
        /// Get a TodoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetTodoItem/{id}")]
        public IActionResult GetTodoItem(Guid id)
        {
            var vTodoItem = _todoData.GetTodoItem(id);
            if (vTodoItem != null)
            {
                return Ok(vTodoItem);
            }
            return NotFound("Could not find a todo item with {id} id");
        }

        // POST api/values
        // For adding
        [HttpPost]
        [Route("api/AddTodoItem")]
        public IActionResult AddTodoItem(VTodoItem vTodoItem)
        {
            var newItem = _todoData.AddTodoItem(vTodoItem);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/"
                + newItem.Id, newItem);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] string Descr, Status Status)
        {
            var updateItem = new VTodoItem{ Id = id, Descr = Descr, Status = Status};
            var updatedItem = _todoData.UpdateTodoItem(updateItem);
            if (updatedItem != null)
            {
                return Ok(updatedItem);
            }
            return NotFound("Could not find a todo item with {id} id");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoData.DeleteTodoItem(id);
            return Ok();
        }
    }
}
