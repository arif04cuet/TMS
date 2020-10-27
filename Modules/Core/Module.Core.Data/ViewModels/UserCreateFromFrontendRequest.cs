namespace Module.Core.Data
{
    public class UserCreateFromFrontendRequest
    {
        public string FullName { get; set; }
        public long Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? Media { get; set; }
    }

}
