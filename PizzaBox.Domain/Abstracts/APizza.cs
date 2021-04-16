using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza
    {
        public int Id {get; protected set;}
        public Crust Crust { get; set; }
        public Size Size { get; set; }

        public List<Topping> Toppings {get; protected set;}

    }
}