using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  public abstract class APizza : AModel
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    public List<Topping> Toppings { get; set; }

    public APizza()
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