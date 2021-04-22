using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {
    protected override void AddCrust()
    {
    }

    protected override void AddName()
    {
      Name = "Custom Pizza";
    }

    protected override void AddSize()
    {
    }

    protected override void AddTopping()
    {

    }
  }
}