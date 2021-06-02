using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApproval.API
{
    public class BaseException :Exception
    {
        public BaseException() : base() { }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
