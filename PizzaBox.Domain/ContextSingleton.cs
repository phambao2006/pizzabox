namespace PizzaBox.Domain
{
  public class ContextSingleton
  {
    private static ContextSingleton _instance;

    public PizzaBoxContext context { get; }

    public static ContextSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ContextSingleton();
        }

        return _instance;
      }

    }
    private ContextSingleton()
    {

      context = new PizzaBoxContext();

    }

  }

}