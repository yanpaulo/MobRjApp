using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yansoft.Rest;

namespace MobRjApp.Data
{
    public class DataService
    {
        private readonly RestHttpClient _rest = new RestHttpClient();
        private readonly SQLiteAsyncConnection _sql = 
            new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db"));

        public static DataService Instance { get; private set; } = new DataService();
        private DataService() { }

        public void Init()
        {
            Task.Run(async () => await _sql.CreateTableAsync<LocalState>()).Wait();
        }

        

        public async Task<List<LocalState>> FetchLocalStatesAsync(string filter = "")
        {
            var states = await GetStatesAsync(filter);
            var local = states.Select(s => LocalState.FromState(s));
            await _sql.DeleteAllAsync<LocalState>();
            await _sql.InsertAllAsync(local);

            return await GetLocalStatesAsync(filter);

        }

        public async Task<List<LocalState>> GetLocalStatesAsync(string filter = "")
        {
            filter = filter?.ToLower() ?? "";

            return await _sql.Table<LocalState>().Where(s => s.Estado.ToLower().Contains(filter) || s.Capital.ToLower().Contains(filter)).ToListAsync();
        }

        public async Task<List<State>> GetStatesAsync(string filter = "")
        {
            filter = filter?.ToLower() ?? "";

            var result = await _rest.GetAsync<JObject>("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            var states =
                result["records"].ToObject<List<State>>()
                .Where(s => s.Fields.Estado.ToLower().Contains(filter) || s.Fields.Capital.ToLower().Contains(filter))
                .ToList();
            
            return states;
        }
    }
}
