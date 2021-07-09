using Abstraction.Common;
using System.Collections.Generic;
using System.Linq;

namespace Service.Location.Handlers
{
    public class ClientLocationModelGenerator : IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>>
    {
        public IDictionary<string, string> Generate(IDictionary<string, string[]> model)
        {
            return new Dictionary<string, string>()
            {
                ["country"] = model.FirstOrDefault(x => x.Value.Contains("country")).Key,
                ["locality"] = model.FirstOrDefault(x => x.Value.Contains("locality")).Key,
                ["administrative_area_level_5"] = model.FirstOrDefault(x => x.Value.Contains("administrative_area_level_5")).Key,
                ["administrative_area_level_4"] = model.FirstOrDefault(x => x.Value.Contains("administrative_area_level_4")).Key,
                ["administrative_area_level_3"] = model.FirstOrDefault(x => x.Value.Contains("administrative_area_level_3")).Key,
                ["administrative_area_level_2"] = model.FirstOrDefault(x => x.Value.Contains("administrative_area_level_2")).Key,
                ["administrative_area_level_1"] = model.FirstOrDefault(x => x.Value.Contains("administrative_area_level_1")).Key,
            };
        }
    }
}
