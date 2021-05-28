using ExpenseApproval.API.Contracts;
using ExpenseApproval.API.DbContexts;
using ExpenseApproval.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ExpenseDataContext _context;

        public LoggerService(ExpenseDataContext context)
        {
            _context = context;
        }
        public void Log(
            LogType logType,
            string method,
            string request,
            string response,
            Exception ex,
            string logMessage
        )
        {
            Logger logger = new Logger();
            logger.Id = new Guid();
            logger.LogMessage = logMessage;
            logger.MethodName = method;
            logger.Request = request;
            logger.Response = response;
            logger.StackTrace = ex.StackTrace;
            logger.CreatedDate = DateTime.Now;
            _context.Logger.Add(logger);
        }
    }
}
