using System;

using NuGet.Protocol.Core.Types;

using F10Y.T0002;


namespace F10Y.L0022
{
    [FunctionsMarker]
    public partial interface ISearchFilterOperator
    {
        public SearchFilter New(bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
        {
            var output = new SearchFilter(includePreRelease);
            return output;
        }
    }
}
