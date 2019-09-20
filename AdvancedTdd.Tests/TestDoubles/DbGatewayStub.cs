using System;
using AdvancedTDD.TestDoubles;

namespace AdvancedTdd.Tests.TestDoubles
{
    class DbGatewayStub : IDbGateway
    {
        private WorkingStatistics ws;
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return ws;
        }

        public void SetWorkingStatistic(WorkingStatistics ws)
        {
            this.ws = ws;
        }

    }
}
