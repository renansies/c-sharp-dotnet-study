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
        return _context.Pizza.ToList();
    } 

    public Pizza? Get(int id) => _context.Pizza.FirstOrDefault(p => p.id == id);

    public void Add(Pizza pizza)
    {
        Console.WriteLine($"{pizza.name}\n{pizza.isGlutenFree}");
        _context.Add<Pizza>(pizza);
        var id = _context.SaveChanges();
        Console.WriteLine(id);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        _context.Pizza.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var checkPizza = Get(pizza.id);
        if(checkPizza == null)
            return;
        _context.Pizza.Update(pizza);
    }
}