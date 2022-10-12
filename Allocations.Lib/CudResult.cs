using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Lib
{
    public class CudResult
    {
        public bool Success => string.IsNullOrEmpty(Message);
        public string Message { get; set; }

        public CudResult()
        {
            Message = null;
        }

        public CudResult(string message)
        {
            Message=message;
        }

        public CudResult(Exception ex)
        {
            StringBuilder messageBuilder = new StringBuilder();
            Exception e = ex;
            while(e != null)
            {
                messageBuilder.Append(e.Message);
                e = e.InnerException;
            }
            Message = messageBuilder.ToString();
        }
    }
}
