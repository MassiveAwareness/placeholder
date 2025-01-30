using System.Text.Json;

namespace backend.Entities.ResponseObjects
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public ErrorResponse() {  }

        public ErrorResponse(int StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.ErrorMessage = Message;
        }
    }
}
