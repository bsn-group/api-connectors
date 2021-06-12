using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;

namespace IO.Swagger.Api
{
    partial class LinearPositionsApi
    {
        public async Task<Model.LinearPositionList> GetActivePositionsAsync(string symbolFilter = null)
        {
            var response = await this.LinearPositionsMyPositionAsync(symbolFilter) as JObject;
            return response.ToObject<Model.LinearPositionList>();
        }
    }
}
