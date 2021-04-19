using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {
    protected override void AddCrust()
    {
      Crust = new Crust { Name = "Thin", Price = 1 };
    }

    protected override void AddName()
    {
      Name = "Veggie Pizza";
    }

    protected override void AddSize()
    {
      Size = new Size { Name = "Large", Price = 2 };
    }

    protected override void AddTopping()
    {
      Toppings = new List<Topping>
      {
        new Topping { Name = "Pepper" , Price = 2 },
        new Topping { Name = "Onion", Price = 2 }
      };
    }
  }
}