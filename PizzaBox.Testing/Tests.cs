using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class Test
  {
    public static IEnumerable<object[]> Storevalues = new List<object[]>()
    {
      new object[] { new ChicagoStore() },
      new object[] { new NewYorkStore() }
    };

    public static IEnumerable<object[]> Pizzavalues = new List<object[]>()
    {
      new object[] { new MeatPizza() },
      new object[] { new VeggiePizza() }
    };
    public static IEnumerable<object[]> Custommervalues = new List<object[]>()
    {
      new object[] { new Customer{Name = "Bao"} },
      new object[] { new Customer{Name = "John"} }
    };

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      Assert.True(sut.Name.Equals("NewYorkStore"));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(Storevalues))]

    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }

    [Theory]
    [MemberData(nameof(Pizzavalues))]
    public void Test_Pizza(APizza pizza)
    {
      Assert.NotNull(pizza.Toppings);
    }
    [Theory]
    [MemberData(nameof(Custommervalues))]
    public void Test_CustomPizza(Customer customer)
    {
      Assert.Equal(customer.Name, customer.ToString());
    }
    [Fact]
    public void Test_StoreSingleton()
    {
      var sut1 = StoreSingleton.Instance;
      var sut2 = StoreSingleton.Instance;

      sut1.Stores.Add(new ChicagoStore());

      Assert.Equal(sut1, sut2);

    }
    [Fact]
    public void Test_PizzaSingleton()
    {
      var sut1 = PizzaSingleton.Instance;
      var sut2 = PizzaSingleton.Instance;

      sut1.Pizzas.Add(new MeatPizza());

      Assert.Equal(sut1, sut2);

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="storeName"></param>
    /// <param name="x"></param>
    [Theory]
    [InlineData("ChicagoStore")]
    [InlineData("NewYorkStore")]
    public void Test_StoreNameSimple(string storeName)
    {
      Assert.NotNull(storeName);
    }
  }
}
