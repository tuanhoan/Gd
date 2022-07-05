using System;
using System.Collections.Generic;
using System.Text;

namespace GD.SDK.Models
{
    public class ModelResult<T> where T: class
    {
        public ModelResult(T result, int Status, string Message)
        {
            this.Result = result;
            this.Status = Status;
            this.Message = Message;
        }
        public T Result { get; }
        public int Status { get; }
        public string Message { get; }
    }
}
