using System.Text.Json.Serialization;

namespace Transport.Shared.Middleware
{
    public class Middleware<T>
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int Code { get; set; } = 200;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ApiError>? Errors { get; set; }


        public static Middleware<T> Success(T data, string message = "Success") => new()
        {
            Status = true,
            Message = message,
            Code = 200,
            Data = data,
        };

        public static Middleware<T> Fail(int statusCode , T data, string message, List<ApiError> errors) => new()
        {
            Status = false,
            Message = message,
            Code = statusCode,
            Data = default,
            Errors = errors
        };

        public class ApiError
        {
            public string Type { get; set; } = string.Empty;

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? Field { get; set; }

            public string Details { get; set; } = string.Empty;

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? HelpUrl { get; set; }

        }

    }
}
