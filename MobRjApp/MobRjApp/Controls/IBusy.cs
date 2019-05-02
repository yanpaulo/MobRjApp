using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobRjApp.Controls
{
    /// <summary>
    /// Should be implemented by an object that can eventually be in a busy state.
    /// </summary>
    public interface IBusy
    {
        bool IsBusy { get; set; }
    }

    public static class BusyExtensions
    {
        public static BusyState BusyState(this IBusy target) 
            => new BusyState(target);
    }
}
