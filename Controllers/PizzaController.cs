using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using Get = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using Post = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Put = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using Delete = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

namespace ContosoPizza.Controllers;

[Route("[controller]")]
public class PizzaController : Controller
{

    private readonly PizzaService _pizzaService;
    public PizzaController(PizzaService pizzaService){
        _pizzaService = pizzaService;
    }

    [Get]
    public List<Pizza> GetAll() {
        return _pizzaService.GetAll();
    }

    [Get("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _pizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [Post]
    public IActionResult Create([FromBody]Pizza pizza)
    {            
        _pizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.id }, pizza);
    }

    [Put("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.id)
            return BadRequest();
            
        var existingPizza = _pizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        _pizzaService.Update(pizza);           
    
        return NoContent();
    }

    [Delete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        _pizzaService.Delete(id);
    
        return NoContent();
    }
}