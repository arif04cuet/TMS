namespace Module.Core.ViewModels
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response(object data, int status = 200, string message = null)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}
