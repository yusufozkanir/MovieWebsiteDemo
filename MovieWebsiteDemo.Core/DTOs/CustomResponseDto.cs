using System.Text.Json.Serialization;

namespace MovieWebsiteDemo.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public ErrorDto Error { get; private set; }

        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        //public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        //{
        //    return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        //}

        //public static CustomResponseDto<T> Fail(int statusCode, string error)
        //{
        //    return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        //}

        public static CustomResponseDto<T> Fail(int statusCode, ErrorDto errorDto)
        {
            return new CustomResponseDto<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
            };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string errorMessage,bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage,isShow);

            return new CustomResponseDto<T> { Error = errorDto, StatusCode = statusCode };
        }
    }
}
