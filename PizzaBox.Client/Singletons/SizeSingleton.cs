using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class SizeSingleton
  {
    private static SizeSingleton _instance;

    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;

    public List<Size> Sizes { get; }
    public static SizeSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new SizeSingleton();
        }

        return _instance;
      }

    }
    private SizeSingleton()
    {

      Sizes = contextSingleton.context.Sizes.ToList();

    }

  }

}