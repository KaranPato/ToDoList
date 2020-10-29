using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object result { get; set; }
        public Object Error { get; set; }

    }
}
