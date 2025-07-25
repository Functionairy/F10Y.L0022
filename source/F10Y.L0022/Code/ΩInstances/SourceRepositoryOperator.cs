using System;


namespace F10Y.L0022
{
    public class SourceRepositoryOperator : ISourceRepositoryOperator
    {
        #region Infrastructure

        public static ISourceRepositoryOperator Instance { get; } = new SourceRepositoryOperator();


        private SourceRepositoryOperator()
        {
        }

        #endregion
    }
}
