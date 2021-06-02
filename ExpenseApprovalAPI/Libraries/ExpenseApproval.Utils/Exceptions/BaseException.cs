﻿using System;
using System.Globalization;

namespace ExpenseApproval.Utils.Exceptions
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
