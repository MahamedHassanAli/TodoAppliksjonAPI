
using System.Collections.Generic;
using System.Linq;
using TodoApplikasjonAPI;
using TodoAppliksjonAPI.Services;

namespace TodoApplikasjonAPI.Services
{
    public class TodosService : ITodosService
    {
        private static List<Todo> todos = new List<Todo>
        {
            new Todo { Id = 1, Title = "Buy groceries", Description = "Get milk, bread, and eggs from the store", IsCompleted = false },
            new Todo { Id = 2, Title = "Finish project report", Description = "Complete the final section and review formatting", IsCompleted = true }
        };

        public IEnumerable<Todo> GetTodos() => todos;

        public Todo GetTodoById(int id) => todos.FirstOrDefault(t => t.Id == id);  // Returner null hvis ikke funnet, håndter null i controlleren

        public void AddTodo(Todo todo)
        {
            todo.Id = todos.Max(t => t.Id) + 1;  // Genererer ny Id basert på maks id fra todos
            todos.Add(todo);
        }

        public void UpdateTodo(int id, Todo updatedTodo)
        {
            var todo = GetTodoById(id);
            if (todo == null) return;  // Hvis todo ikke finnes, gjør ingenting

            todo.Title = updatedTodo.Title;
            todo.Description = updatedTodo.Description;
            todo.IsCompleted = updatedTodo.IsCompleted;
        }

        public void DeleteTodo(int id)
        {
            var todo = GetTodoById(id);
            if (todo != null) todos.Remove(todo);
        }
    }
}

