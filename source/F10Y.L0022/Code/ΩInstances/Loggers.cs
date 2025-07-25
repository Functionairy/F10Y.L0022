using System;


namespace F10Y.L0022
{
    public class Loggers : ILoggers
    {
        #region Infrastructure

        public static ILoggers Instance { get; } = new Loggers();


        private Loggers()
        {
        }

        #endregion
    }
}
