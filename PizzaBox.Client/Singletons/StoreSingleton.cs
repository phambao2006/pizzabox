using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    private const string _path = @"store.xml";
    private static StoreSingleton _instance;

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

      var fr = new FileRepository();
      try
      {
        Stores = fr.ReadFromFile<List<AStore>>(_path);
      }
      catch
      {
        Stores = new List<AStore> { new ChicagoStore(), new NewYorkStore() };
        fr.WriteToFile(Stores, _path);
      }

    }

  }

}