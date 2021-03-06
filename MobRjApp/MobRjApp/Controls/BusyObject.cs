﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobRjApp.Controls
{
    /// <summary>
    /// Sub-class of ObservableObject with IBusy capabilities.
    /// </summary>
    public class BusyObject : ObservableObject, IBusy
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }


        public BusyState BusyState() => BusyExtensions.BusyState(this);
    }
}
