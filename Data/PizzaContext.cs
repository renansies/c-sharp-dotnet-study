using System;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
	public class PizzaContext: DbContext
    { 
        public PizzaContext (DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza>? Pizzas { get; set; }

    }
}

