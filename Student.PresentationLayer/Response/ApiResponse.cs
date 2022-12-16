using System;
using System.Collections.Generic;
using System.Text;

namespace Student.PresentationLayer.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }
    }
}
