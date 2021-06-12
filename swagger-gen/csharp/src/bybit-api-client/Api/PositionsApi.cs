using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

using PositionList = IO.Swagger.Model.Position;

namespace IO.Swagger.Api
{
    partial class PositionsApi
    {
        public async Task<PositionList> GetActivePositionsAsync(string symbolFilter = null)
        {
            var response = await PositionsMyPositionAsync(symbolFilter) as JObject;
            return response.ToObject<PositionList>();
        }
    }
}
