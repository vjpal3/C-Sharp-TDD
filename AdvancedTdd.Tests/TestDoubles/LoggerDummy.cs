using System;
using AdvancedTDD.TestDoubles;

namespace AdvancedTdd.Tests.TestDoubles
{
    class LoggerDummy : ILogger
    {
        public void Info(string s)
        {
            //Do Nothing
        }
    }
}
