using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RectanglesApp.Models;

namespace RectanglesApp.Data
{
    public class RectanglesContext : DbContext
    {
        public RectanglesContext (DbContextOptions<RectanglesContext> options)
            : base(options)
        {
        }

        public DbSet<RectanglesApp.Models.Rectangle> Rectangle { get; set; } = default!;
    }
}
