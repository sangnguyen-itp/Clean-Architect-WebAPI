using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response()
        {

        }

        public Response(T data, string message = null, List<string> errors = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            Errors = errors;
        }
    }
}
