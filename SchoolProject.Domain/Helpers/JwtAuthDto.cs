namespace SchoolProject.Domain.Helpers
{
    public class JwtAuthDto
    {
        public string AccessToken { get; set; }
        public RefrechToken refrechToken { get; set; }
    }

    public class RefrechToken
    {
        public string Username { get; set; }
        public string tokenString { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
