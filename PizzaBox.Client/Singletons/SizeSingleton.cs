using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class SizeSingleton
  {
    private static SizeSingleton _instance;

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

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

      Sizes = _context.Sizes.ToList();

    }

  }

}