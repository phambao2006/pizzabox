using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    private static readonly StoreSingleton _instance;

    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new StoreSingleton();
        }

        return _instance;
      }

    }
    private StoreSingleton()
    {
      Stores = new List<AStore>
                {
                new ChicagoStore(),
                new NewYorkStore()
                };
    }
    public void WriteToFile()
    {
      var path = @"store.xml";
      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<AStore>));
      xml.Serialize(writer, Stores);
    }

  }

}