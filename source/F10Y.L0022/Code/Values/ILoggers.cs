using System;

using NuGet.Common;

using F10Y.T0003;


namespace F10Y.L0022
{
    [ValuesMarker]
    public partial interface ILoggers
    {
        /// <summary>
        /// The <see cref="NullLogger.Instance"/>.
        /// </summary>
        public ILogger Null => NullLogger.Instance;
    }
}
