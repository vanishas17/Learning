using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Contracts
{
    public interface ILoggerService
    {
        public void Log(LogType logType,
            string method,
            string request,
            string response,
            Exception ex,
            string logMessage);
    }
}
