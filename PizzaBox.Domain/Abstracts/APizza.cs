using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza
    {
        public int Id {get; protected set;}
        public Order Order{get;protected set;}
        public HashSet<Topping> Toppings {get; protected set;}

    }
}