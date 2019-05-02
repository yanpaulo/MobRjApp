using MobRjApp.Extensions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobRjApp.Data
{
    public class LocalState
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }

        public string Sigla { get; set; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }

        public static LocalState FromState(State state)
        {
            var local = new LocalState();
            state.CopyTo(local);
            state.Fields.CopyTo(local);
            return local;
        }
    }
}
