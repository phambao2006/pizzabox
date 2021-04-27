using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class VeggiePizza : APizza
  {
    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;
    protected override void AddCrust()
    {
    }

    protected override void AddName()
    {
      Name = "Veggie Pizza";
    }

    protected override void AddSize()
    {
    }

    protected override void AddTopping()
    {
      Toppings = new List<Topping>();
      Toppings.AddRange(new List<Topping>
          {
            new Topping {Name = "Mushroom" ,Price = 2},
            new Topping {Name = "Pinapple", Price = 2},
            new Topping {Name = "Bell Pepper", Price = 2}
          });
    }
  }
}