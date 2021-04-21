namespace PizzaBox.Domain.Abstracts
{
  public abstract class AComponent : AModel
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}