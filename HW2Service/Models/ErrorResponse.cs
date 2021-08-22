using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2Service.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; } // message - what went wrong

        public object Data { get; set; } // Data - the input values
    }
}
