using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AStore
    {
        public string Name {get; protected set;}
        public int Id {get; protected set;}
        public List<Order> Orders{get;set;}

        public override string ToString()
        {
            return Name;
        }
    }
}