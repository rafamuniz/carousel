using System;

namespace WebApplication3.Models
{
    public class ErrorViewModel
    {
        public String Message { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
