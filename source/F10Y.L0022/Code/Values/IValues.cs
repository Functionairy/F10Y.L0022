using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0022
{
    [ValuesMarker]
    public partial interface IValues :
        L000.IValues
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L000.IValues _L000 => L000.Values.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
