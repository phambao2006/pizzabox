using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class MeatPizza : APizza
  {
    PizzaBoxContext _context = new PizzaBoxContext();
    protected override void AddCrust()
    {
    }

    protected override void AddSize()
    {
    }

    protected override void AddTopping()
    {
      Toppings = new List<Topping>();
      Toppings.AddRange(new List<Topping>
          {
             _context.Toppings.FirstOrDefault(t => t.Name == "Mushroom"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Pineapple"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Bell Pepper")
          });
    }

    protected override void AddName()
    {
    }
  }
}