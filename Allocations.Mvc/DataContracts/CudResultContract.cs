namespace Allocations.Mvc.DataContracts
{
    public class CudResultContract
    {
        public bool Success => string.IsNullOrEmpty(Message);
        public string Message { get; set; }
    }
}
