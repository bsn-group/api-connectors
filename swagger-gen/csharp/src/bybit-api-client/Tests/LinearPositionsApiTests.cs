using System.Linq;
using NUnit.Framework;
using IO.Swagger.Api;
using System.Threading.Tasks;
using System;

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
            Console.Out.WriteLine("Log statement to debug "+ response.GetResult().Count());
            Assert.AreEqual(1, response.GetResult().Count());
        }

        [Test]
        public async Task GetActivePositionsWithFilterTest()
        {
            var response = await api.GetActivePositionsAsync("XRPUSDT");
            Console.WriteLine("Log statement to debug " + response.RetMsg);
            Assert.AreEqual(0, response.RetCode, message: response.RetMsg);
            Assert.AreEqual(1, response.GetResult().Count());
        }
    }

}
