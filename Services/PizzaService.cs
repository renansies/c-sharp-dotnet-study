using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services;

public class PizzaService
{

    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context) 
    {
        this._context = context;
    }
    public List<Pizza> GetAll() 
    {
        return _context.Pizzas.ToList();
    } 

    public Pizza? Get(int id) => _context.Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        Console.WriteLine($"{pizza.Name}\n{pizza.IsGlutenFree}");
        _context.Add<Pizza>(pizza);
        var id = _context.SaveChanges();
        Console.WriteLine(id);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        _context.Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var checkPizza = Get(pizza.Id);
        if(checkPizza == null)
            return;
        _context.Pizzas.Update(pizza);
    }
}