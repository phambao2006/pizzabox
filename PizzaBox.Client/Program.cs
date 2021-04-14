using System.Collections.Generic;

namespace PizzaBox.Client
{
    public class Program
    {
      private static void Main()  
      {
       var stores = new List<Store>{new Store("Store001") , new Store("Store002")};
       for(var x = 0 ; x < stores.Count;x+=1)
       {
         System.Console.WriteLine($"{x} {stores[x]}");
       }
      string input = System.Console.ReadLine();
      int entry = int.Parse(input);

      System.Console.WriteLine(stores[entry]);
      }
    }
}