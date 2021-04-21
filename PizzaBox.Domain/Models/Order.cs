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

  }
}