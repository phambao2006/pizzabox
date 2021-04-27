using System.Collections.Generic;
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
      Assert.NotNull(pizza.Name);
      Assert.NotNull(pizza.Toppings);
    }
    [Theory]
    [MemberData(nameof(Custommervalues))]
    public void Test_CustomPizza(Customer customer)
    {
      Assert.NotNull(customer.Name);
      Assert.Equal(customer.Name, customer.ToString());
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
