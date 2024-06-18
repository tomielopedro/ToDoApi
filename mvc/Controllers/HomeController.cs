using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Models;

namespace Mvc.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("/home")]
        public IActionResult Get([FromServices] AppDbContext context)
           => Ok(context.Todos.ToList());



        [HttpGet("/home/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null) return NotFound();

            return Ok(todos);
        }


        [HttpPost("/home")]
        public IActionResult Post([FromBody] TodoModel todo,
        [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return Created($"/home/{todo.Id}", todo);
        }

        [HttpPut("/home/{id:int}")]
        public IActionResult Put(

            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null) return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;
            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }


        [HttpDelete("/home/{id:int}")]
        public IActionResult Delete(

            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null) return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }
}