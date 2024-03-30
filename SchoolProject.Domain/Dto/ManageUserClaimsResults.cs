namespace SchoolProject.Domain.Dto
{

    public class ManageUserClaimsResults
    {
        public int UserId { get; set; }
        public List<UserClaims> userClaims { get; set; }
    }

    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
