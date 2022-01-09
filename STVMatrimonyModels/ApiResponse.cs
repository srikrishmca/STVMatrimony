using System;

namespace STVMatrimonyModels
{
    public class ApiResponse<T>
    {
        public string Version { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public T Result { get; set; }
    }
}
