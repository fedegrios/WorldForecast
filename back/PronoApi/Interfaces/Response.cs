namespace Interfaces
{
    public class Response<T>
    {
        public T Data { get; set; }
        public ResponseType Type { get; set; } = ResponseType.Unexpected;
        public string[] ErrMgs { get; set; } = Array.Empty<string>();

        public Response()
        {
        }

        public Response(T data, ResponseType type, string[] errMgs)
        {
            Data = data;
            Type = type;
            ErrMgs = errMgs;
        }
    }

    public enum ResponseType 
    { 
        Success,
        NotFound,
        ValidationErr,
        Unexpected
    }
}
