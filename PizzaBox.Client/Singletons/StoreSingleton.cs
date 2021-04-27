using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    private static StoreSingleton _instance;

    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;

    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }

    }
    private StoreSingleton()
    {

      Stores = contextSingleton.context.Stores.ToList();

    }

  }

}