using Microsoft.EntityFrameworkCore;
using System;

namespace TTI.Practicas.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
           : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PruebasTablas> PruebaTabla { get; set; }
        public DbSet<PruebasTablasRelacionadas> PruebaTablaRel { get; set; }
    }
}
