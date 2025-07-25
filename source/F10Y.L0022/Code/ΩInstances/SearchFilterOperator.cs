using System;


namespace F10Y.L0022
{
    public class SearchFilterOperator : ISearchFilterOperator
    {
        #region Infrastructure

        public static ISearchFilterOperator Instance { get; } = new SearchFilterOperator();


        private SearchFilterOperator()
        {
        }

        #endregion
    }
}
