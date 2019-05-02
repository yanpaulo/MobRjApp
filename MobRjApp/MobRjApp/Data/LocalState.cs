using MobRjApp.Extensions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobRjApp.Data
{
    /// <summary>
    /// Flattened counterpart for the State class, for local database operations.
    /// </summary>
    public class LocalState
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }

        public string Sigla { get; set; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }

        /// <summary>
        /// Creates and returns a new instance of LocalState with values obtained from the "state" object and descendants.
        /// </summary>
        /// <param name="state">Instance of State from which values should be copied.</param>
        /// <returns></returns>
        public static LocalState FromState(State state)
        {
            var local = new LocalState();
            state.CopyTo(local);
            state.Fields.CopyTo(local);
            return local;
        }
    }
}
