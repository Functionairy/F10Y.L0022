using System;

using F10Y.T0003;


namespace F10Y.L0022
{
    [ValuesMarker]
    public partial interface INuGetSources
    {
        /// <summary>
        /// <para><value>https://api.nuget.org/v3/index.json</value></para>
        /// </summary>
        public string NuGet_org_CoreV3 => "https://api.nuget.org/v3/index.json";

        /// <summary>
        /// <para><inheritdoc cref="NuGet_org_CoreV3" path="descendant::value"/></para>
        /// Quality-of-life overload for <see cref="NuGet_org_CoreV3"/>.
        /// </summary>
        public string NuGet_org => NuGet_org_CoreV3;
    }
}
