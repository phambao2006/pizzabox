using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {
    public void WriteToFile(List<AStore> Stores, string path)
    {
      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<AStore>));
      xml.Serialize(writer, Stores);
    }

    public List<AStore> ReadFromFile(string path)
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<AStore>));
      return xml.Deserialize(reader) as List<AStore>;
    }
  }
}