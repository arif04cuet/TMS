namespace Module.Core.Shared
{
    public class Result : IResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Result(object data, int status = 200, string message = default)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}
