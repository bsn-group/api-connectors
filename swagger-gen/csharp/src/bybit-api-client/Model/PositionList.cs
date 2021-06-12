using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace IO.Swagger.Model
{
    partial class Position
    {
        private IEnumerable<PositionInfo> FromJArray(JArray ja)
        {
            var items = ja.ToObject <IEnumerable<JObject>>();
            return 
                items.Select(i => 
                {
                    if (i.TryGetValue("data", out var jtoken) && jtoken != null)
                    {
                        return jtoken.ToObject<PositionInfo>();
                    }
                    return i.ToObject<PositionInfo>();
                })
                .Where(p => p != null && p.Size > 0);
        }

        public IEnumerable<PositionInfo> GetResult() =>
            Result switch
            {
                JArray jarr => FromJArray(jarr),
                JObject jobj => new[] { jobj.ToObject<PositionInfo>() },
                _ => Enumerable.Empty<PositionInfo>(),
            };
    }
}
