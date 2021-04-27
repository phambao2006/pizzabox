using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public AStore Store { get; set; }
    public List<APizza> Pizzas { get; set; }
    public Customer Customer { get; set; }
    public long CustomerEntityID { get; set; }
    public long StoreEntityID { get; set; }

    public decimal Total()
    {
      decimal total = 0;
      foreach (var pizza in Pizzas)
      {
        total = total + pizza.PizzaPrice();
      }
      return total;
    }
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Pizzas)
      {
        stringBuilder.Append($"{item.ToString()}{separator}");
      }

      return $"Store:{Store.Name}-Customer:{Customer.Name}-Pizzas:{stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }

  }

}