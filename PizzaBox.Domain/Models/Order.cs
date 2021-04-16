using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public AStore Store { get; set; }
        public List<APizza> Pizzas { get; set; }
        public Customer Customer { get; set; }

    }
}