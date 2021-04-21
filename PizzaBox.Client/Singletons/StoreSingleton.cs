using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    private const string _path = @"store.xml";
    private static StoreSingleton _instance;

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    public List<AStore> Stores
    { get; }
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

      var fr = new FileRepository();
      try
      {
        Stores = _context.Stores.ToList();
      }
      catch
      {
        Stores = new List<AStore> { new ChicagoStore(), new NewYorkStore() };
        fr.WriteToFile(Stores, _path);
      }

    }

  }

}