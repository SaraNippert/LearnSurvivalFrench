﻿using System;

namespace Learn_French_App.Exceptions
{
    public class DaoException : Exception
    {
        public DaoException() : base() { }
        public DaoException(string message) : base(message) { }
        public DaoException(string message, Exception inner) : base(message, inner) { }
    }
}
