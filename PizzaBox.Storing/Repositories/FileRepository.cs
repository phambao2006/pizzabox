using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {
    public void WriteToFile<T>(T items, string path)
    {
      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(T));
      xml.Serialize(writer, items);
    }

    public T ReadFromFile<T>(string path) where T : class
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(T));
      return xml.Deserialize(reader) as T;
    }
  }
}