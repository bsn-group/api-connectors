using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Api
{
    partial class LinearPositionsApi
    {
        public async Task<Model.LinearPositionListResultBase> GetActivePositionsAsync(string symbolFilter = null)
        {
            var response = await this.LinearPositionsMyPositionAsync(symbolFilter) as JObject;
            return response.ToObject<Model.LinearPositionListResultBase>();
        }
    }
}
