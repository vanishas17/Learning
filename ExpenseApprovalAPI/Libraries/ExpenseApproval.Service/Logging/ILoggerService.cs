using ExpenseApproval.DataAccess.Entities;
using System;

namespace ExpenseApproval.Service.Logging
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
