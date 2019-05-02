using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobRjApp.Pages.Navigation
{

    public class RootPageMenuItem
    {
        public RootPageMenuItem()
        {
            TargetType = typeof(RootPageDetail);
        }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}