using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class MeatPizza : APizza
  {
    protected override void AddCrust()
    {
      Crust = new Crust { Name = "Original", Price = 2 };
    }

    protected override void AddSize()
    {
      Size = new Size { Name = "Medium" };
    }

    protected override void AddTopping()
    {
      Toppings = new List<Topping>
      { new Topping { Name = "Pork" },
        new Topping { Name = "Chicken" }
      };
    }

    protected override void AddName()
    {
      Name = "Meat Pizza";
    }
  }
}