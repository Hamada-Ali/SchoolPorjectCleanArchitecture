namespace SchoolProject.Domain.ApplicantionMetaData
{
    public static class Router // Custom Route
    {

        public const string Id = "/{id}";

        public const string root = "Api";
        public const string version = "v1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + Id;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string PaginatedList = Prefix + "/PaginatedList";

        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string GetById = Prefix + "/Id";
            public const string GetDepartmentStudentsCount = Prefix + "/GetDepartmentStudentsCount";
            public const string GetDepartmentStudentCountById = Prefix + "/GetDepartmentStudentCountById/{id}";

        }

        public static class IdentityUser
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";
            public const string Paginated = Prefix + "/PaginatedList";
            public const string GetById = Prefix + Id;
            public const string Update = Prefix + "/Update";
            public const string UpdatePassowrd = Prefix + "/UpdatePassowrd";
        }

        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/signin";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string ValidateToken = Prefix + "/ValidateToken";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPassword = Prefix + "/SendResetPassword";
            public const string CheckResetPasswordConfirmation = Prefix + "/CheckResetPasswordConfirmation";
            public const string ResetPassword = Prefix + "/ResetPassword";
        }

        public static class Authorization
        {
            public const string Prefix = Rule + "Authorization";
            public const string Role = Prefix + "/Role";
            public const string CreateRole = Role + "/CreateRole";
            public const string EditRole = Role + "/EditRole";
            public const string GetRolesList = Role + "/GetRolesList";
            public const string GetRoleById = Role + "/GetRoleById" + Id;
            public const string DeleteRole = Role + "/DeleteRole" + Id;
            public const string ManageUserRoles = Role + "/ManageUserRoles/{userId}";
            public const string ManageUserClaims = Role + "/ManageUserClaims/{userId}";
            public const string UpdateUserRoles = Role + "/UpdateUserRoles";
            public const string UpdateUserClaims = Role + "/UpdateUserClaims";

        }

        public static class InstructorRouting
        {
            public const string Prefix = Rule + "Instructor";
            public const string AddInstructor = Prefix + "/Create";
        }

        public static class EmailsRoute
        {
            public const string Prefix = Rule + "Email";
            public const string SendEmail = Prefix + "/Send";
        }

    }
}
