using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            //arange
            var sut = new ChicagoStore();

            //act
            var actual = sut.Name;

            //assert
            Assert.True(actual == "ChicagoStore");

        }
                [Fact]
        public void Test_NewYorkStore()
        {
            //arange
            var sut = new NewYorkStore();

            //act
            var actual = sut.Name;

            //assert
            Assert.True(actual == "NewYorkStore");

        }

    }
}