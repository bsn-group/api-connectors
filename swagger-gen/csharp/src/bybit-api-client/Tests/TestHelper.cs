using IO.Swagger.Client;

namespace Bybit.Api.Client.Test
{
    public static class TestHelper
    {
        public static void SetupForTestnet(Configuration config)
        {
            config.BasePath = "https://api-testnet.bybit.com";
            config.AddApiKey("api_key", "eaZwPEvO2hqmrEuwFa");
            config.AddApiKey("api_secret", "Xqpo1ZtrtTJMwiQ5br7pfpG4tCwKfTakqqr2");
        }
    }
}
