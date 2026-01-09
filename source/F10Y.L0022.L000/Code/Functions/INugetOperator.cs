using System;

using F10Y.T0002;


namespace F10Y.L0022.L000
{
    [FunctionsMarker]
    public partial interface INugetOperator
    {
        string Get_PackageIdentity(
            string packageName,
            string version)
        {
            var output = $"{packageName}{Instances.Characters.Slash}{version}";
            return output;
        }
    }
}
