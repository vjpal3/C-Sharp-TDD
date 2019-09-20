using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTDD.TestDoubles
{
    public class Customer
    {
        private readonly ILogger logger;
        private readonly IDbGateway gateway;

        // Dependency injection via constructor
        public Customer(ILogger logger, IDbGateway gateway)
        {
            this.logger = logger;
            this.gateway = gateway;
        }

        public decimal CalculateWage(int id)
        {
            WorkingStatistics ws = gateway.GetWorkingStatistics(id);

            decimal wage;
            if (ws.PayHourly)
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthSalary;
            }
            logger.Info($"Customer ID={id}, Wage:{wage}");

            return wage;
        }
    }

    internal class Logger : ILogger
    {
        public void Info(string s)
        {
            File.WriteAllText(@"C:\tmp:\log.txt", s);
        }
    }

    public class DbGateway : IDbGateway
    {
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            //a real gateway can experience any possible problems
            //like "no connection" throwing an exception
            throw new NoConnection();
        }
    }

    public class NoConnection : Exception
    {
    }
}
