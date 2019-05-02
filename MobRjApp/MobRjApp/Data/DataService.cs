using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yansoft.Rest;

namespace MobRjApp.Data
{
    public class DataService
    {
        private RestHttpClient _rest = new RestHttpClient();

        public static DataService Instance { get; private set; } = new DataService();
        private DataService() { }

        public async Task<List<State>> GetStatesAsync(string filter = "")
        {
            filter = filter ?? "";

            var result = await _rest.GetAsync<JObject>("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            var states =
                result["records"].ToObject<List<State>>()
                .Where(s => s.Fields.Estado.Contains(filter) || s.Fields.Capital.Contains(filter)).ToList();

            foreach (var s in states)
            {
                s.Fields.Id = s.Id;
            }
            return states;
        }
    }
}
