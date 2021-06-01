using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseApproval.DataAccess.Entities
{
    public class Logger
    {
        [Key]
        public Guid Id { get; set; }

        public LogType LogType { get; set; }

        public string LogMessage { get; set; }

        public string MethodName { get; set; }
        public string StackTrace { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Request { get; set; }

        public string Response { get; set; }
    }

    public enum LogType
    {
        Error,
        Info
    }
}
