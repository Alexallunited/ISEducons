using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ISEducons.HelpProzor
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JSHelper
    {
        PocetniProzor prozor;
        public JSHelper(PocetniProzor w)
        {
            prozor = w;
        }

    }
}
