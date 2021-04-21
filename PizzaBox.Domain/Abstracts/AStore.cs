using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public abstract class AStore : AModel
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}