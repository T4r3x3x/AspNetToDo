using ApplicationCore.Enum;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Implementations
{
    public class BaseResponse<T> : IResponse<T>
    {
        public string Description { get; }

        public StatusCode StatusCode { get; }

        public T Data { get; }


        public BaseResponse(string description, StatusCode statusCode, T data)
        {
            Description = description;
            StatusCode = statusCode;
            Data = data;
        }
    }
}