using System.Linq;
using NUnit.Framework;
using IO.Swagger.Api;
using System.Threading.Tasks;

namespace Bybit.Api.Client.Test
{
    [TestFixture]
    public class LinearPositionsApiTests
    {
        private LinearPositionsApi api;

        [SetUp]
        public void Init()
        {
            api = new LinearPositionsApi();
            TestHelper.SetupForTestnet(api.Configuration);
        }
        
        [Test]
        public async Task GetActivePositionsTest()
        {
            var response = await api.GetActivePositionsAsync();
            Assert.AreEqual(0, response.RetCode);
            Assert.AreEqual(1, response.GetResult().Count());
        }

        [Test]
        public async Task GetActivePositionsWithFilterTest()
        {
            var response = await api.GetActivePositionsAsync("BTCUSD");
            Assert.AreEqual(0, response.RetCode);
            Assert.AreEqual(1, response.GetResult().Count());
        }
    }

}
