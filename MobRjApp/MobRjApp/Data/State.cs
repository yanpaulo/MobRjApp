using System;

namespace MobRjApp.Data
{
    /// <summary>
    /// Domain class
    /// </summary>
    public class State
    {
        public string Id { get; set; }
        public Fields Fields { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}