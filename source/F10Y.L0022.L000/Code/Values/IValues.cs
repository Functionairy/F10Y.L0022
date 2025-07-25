using System;

using F10Y.T0003;


namespace F10Y.L0022.L000
{
    [ValuesMarker]
    public partial interface IValues
    {
        /// <summary>
        /// <para><value>false</value></para>
        /// The default behavior is to <em>not</em> include prerelease.
        /// </summary>
        public const bool IncludePreRelase_Default_Constant = false;

        /// <inheritdoc cref="IncludePreRelase_Default_Constant"/>
        public bool IncludePreRelase_Default => IValues.IncludePreRelase_Default_Constant;

        /// <summary>
        /// <para><value>false</value></para>
        /// The default behavior is to <em>not</em> include prerelease.
        /// </summary>
        public const bool IncludeUnlisted_Default_Constant = false;

        /// <inheritdoc cref="IncludeUnlisted_Default_Constant"/>
        public bool IncludeUnlisted_Default => IValues.IncludeUnlisted_Default_Constant;
    }
}
