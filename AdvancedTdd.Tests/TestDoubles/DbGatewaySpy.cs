using System;
using AdvancedTDD.TestDoubles;

namespace AdvancedTdd.Tests.TestDoubles
{
    class DbGatewaySpy : IDbGateway
    {
        public int Id { get; private set; }
        private WorkingStatistics ws;
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return ws;
        }

        public void SetWorkingStatistics(WorkingStatistics ws)
        {
            this.ws = ws;
        }
    }
}
