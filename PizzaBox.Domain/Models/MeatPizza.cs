using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class MeatPizza : APizza
  {
    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;
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
            new Topping {Name = "Chicken", Price = 2},
            new Topping {Name = "Beef", Price = 2},
            new Topping {Name = "Pork", Price = 2}
          });
    }

    protected override void AddName()
    {
      Name = "Meat Lover";
    }
  }
}