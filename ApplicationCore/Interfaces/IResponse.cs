using ApplicationCore.Enum;

namespace ApplicationCore.Interfaces
{
    public interface IResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
