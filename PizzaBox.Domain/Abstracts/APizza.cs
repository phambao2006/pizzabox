using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizza
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    public List<Topping> Toppings { get; protected set; }

    protected APizza()
    {
      Factory();
    }

    protected virtual void Factory()
    {
      AddName();
      AddCrust();
      AddSize();
      AddTopping();
    }

    protected abstract void AddName();
    protected abstract void AddTopping();

    protected abstract void AddSize();

    protected abstract void AddCrust();

    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item.Name}{separator}");
      }

      return $"{Name} - Crust:{Crust.Name} - Size:{Size.Name} - Topping:{stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }

  }

}