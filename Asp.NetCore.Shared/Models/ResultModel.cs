namespace Asp.NetCore.Shared.Models
{
    public class ResultModel
    {
        public string? Message { get; set; }
        public int? Code { get; set; }
        public object? Data { get; set; }
    }

    public class ResultModel<T>
    {
        public ResultModel()
        {

        }

        public ResultModel(T data)
        {
            Data = data;
        }

        public ResultModel(int code, T data)
        {
            Code = code;
            Data = data;
        }

        public ResultModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public ResultModel(int code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
        public string? Message { get; set; }
        public int? Code { get; set; }
        public T Data { get; set; }
    }
}
