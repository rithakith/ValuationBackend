namespace ValuationBackend.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(T data, string message = "Success", bool isSuccess = true)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>(data, message, true);
        }

        public static ApiResponse<T> Failure(string message)
        {
            return new ApiResponse<T>
            {
                Message = message,
                IsSuccess = false,
                Data = default(T)
            };
        }
    }
}