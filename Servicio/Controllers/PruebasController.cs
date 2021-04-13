using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTI.Practicas.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase 
    { 
    
        private readonly ToDoListContext _context;

        public PruebasController(ToDoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PruebasTablas>>> GetTodoItems()
        {
            return await _context.PruebaTabla.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PruebasTablas>> GetTodoItem(int id)
        {
            var todoItem = await _context.PruebaTabla.FindAsync(id);
            
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


        [HttpPost]
        public async Task<ActionResult<PruebasTablas>> PostTodoItem(PruebasTablas todoItem)
        {
            _context.PruebaTabla.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, PruebasTablas todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;


            // Creo otro TodoListContext
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PruebasTablas>> DeleteTodoItem(int id)
        {
            var todoItem = await _context.PruebaTabla.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.PruebaTabla.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }


        private bool TodoItemExists(int id)
        {
            return _context.PruebaTabla.Any(e => e.Id == id);
        }


    }
}
