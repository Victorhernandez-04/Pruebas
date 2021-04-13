using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTI.Practicas.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        public CategoriesController(ToDoListContext context)
        {
            _context = context;
        }
        ToDoListContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Category>>> GetByName(string name_contains)
        {
            return await _context.Categories.Where(_=>_.Name.Contains(name_contains)).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
