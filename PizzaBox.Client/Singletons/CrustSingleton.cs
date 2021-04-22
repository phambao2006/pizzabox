using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class CrustSingleton
  {
    private static CrustSingleton _instance;

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    public List<Crust> Crusts { get; }
    public static CrustSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CrustSingleton();
        }

        return _instance;
      }

    }
    private CrustSingleton()
    {

      Crusts = _context.Crusts.ToList();

    }

  }

}