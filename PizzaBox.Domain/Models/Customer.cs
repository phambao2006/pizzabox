using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public int Id{get; set;}
        public string Name{get;set;}
        public List<Order> Orders {get; set;}
        
    }
}