using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BusinessLogic.CustomExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public int? StatusCode { get; set; }
    }
}
