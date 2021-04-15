using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Client
{
    public class Program
    {
      private static void Main()  
      {
       var stores = new List<AStore>{new ChicagoStore() , new NewYorkStore()};
       for(var x = 0 ; x < stores.Count;x++)
       {
         System.Console.WriteLine($"{x} {stores[x]}");
       }
      string input = System.Console.ReadLine();
      int entry = int.Parse(input);

      System.Console.WriteLine(stores[entry]);
      }
    }
}