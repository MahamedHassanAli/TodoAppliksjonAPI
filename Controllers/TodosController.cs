
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApplikasjonAPI;
using TodoAppliksjonAPI.Services;

namespace TodoWebApplikasjonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todosService;

        public TodosController(ITodosService todosService)
        {
            _todosService = todosService;
        }
     
       
        // GET: api/todos
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            var todos = _todosService.GetTodos();
            return Ok(todos);
        }

        // GET api/todos/{id}
        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            var todo = _todosService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();  // Legg til return for NotFound
            }
            return Ok(todo);
        }

        // POST: api/todos
        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo newTodo)
        {
            
            _todosService.AddTodo(newTodo);
            return CreatedAtAction(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
        }

        // PUT: api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, Todo updatedTodo)
        {
            var existingTodo = _todosService.GetTodoById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            _todosService.UpdateTodo(id, updatedTodo);

            return NoContent();
        }

        // DELETE: api/todos/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var todo = _todosService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todosService.DeleteTodo(id);
            return NoContent();
        }
    }
}

