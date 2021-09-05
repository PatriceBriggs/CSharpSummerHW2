using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2Service.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public object Data { get; set; } // Data - the input values

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get;  } // message - what went wrong

        public ApiResponse(int code, object data = null, string message = null)
        {
            StatusCode = code;
            Data = data;
            Message = message ?? GetDefaultMessageForStatusCode(code);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Ok";
                case 201:
                    return "Created OK";
                case 400:
                    return "Email and password are both required.";
                case 404:
                    return "User not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
