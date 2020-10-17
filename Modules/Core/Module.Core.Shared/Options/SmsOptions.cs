namespace Module.Core.Shared.Options
{
    public class SmsOptions
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string SenderId { get; set; }
    }
}
