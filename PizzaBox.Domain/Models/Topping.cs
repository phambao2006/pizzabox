using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
    public class Topping
    {
        public string Name{get; set;}
        public double Price{get;set;}
        public Topping(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}