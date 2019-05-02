using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobRjApp.Controls
{
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
