using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class CrustSingleton
  {
    private static CrustSingleton _instance;

    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;

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

      Crusts = contextSingleton.context.Crusts.ToList();

    }

  }

}