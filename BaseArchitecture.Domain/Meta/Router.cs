namespace BaseArchitecture.Domain.Meta
{
    public static class Router
    {
        //public const string Domain = "https://localhost:5001";
        public const string Root = "/api/";
        public static class AuthenticationRouting
        {
            public const string Prefix = Root + "Authentication/";
            public const string SignUp = Prefix + "SignUp";
            public const string SignIn = Prefix + "SignIn";
            public const string VerifyRegistrationOtp = Prefix + "VerifyRegistrationOtp";
            public const string VerifyResetPasswordOtp = Prefix + "VerifyResetPasswordOtp";
            public const string ChangePassword = Prefix + "ChangePassword";
            public const string ResetPasswordRequest = Prefix + "ResetPasswordRequest";
            public const string ResetPassword = Prefix + "ResetPassword";
        }
        public static class UserRouting
        {
            public const string Prefix = Root + "User/";
            public const string GetById = Prefix + "GetById/{id}";
            public const string GetList = Prefix + "GetList";
            public const string GetUserRoles = Prefix + "GetUserRoles/{id}";
            public const string GetPaginatedList = Prefix + "GetPaginatedList";
            public const string Update = Prefix + "Update";
            public const string HardDelete = Prefix + "HardDelete/{id}";
            public const string SoftDeleteAndActivate = Prefix + "SoftDeleteAndActivate/{id}";
        }
        public static class RoleRouting
        {
            public const string Prefix = Root + "Role/";
            public const string GetById = Prefix + "GetById/{id}";
            public const string GetList = Prefix + "GetList";
            public const string GetPaginatedList = Prefix + "GetPaginatedList";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete/{id}";
            public const string SoftDeleteAndActivate = Prefix + "SoftDeleteAndActivate/{id}";
        }
        public static class EmailRouting
        {
            public const string Prefix = Root + "Email/";
            public const string SendEmail = Prefix + "SendEmail";
        }
        public static class CourseRouting
        {
            public const string Prefix = Root + "Course/";
            public const string GetById = Prefix + "GetById/{id}";
            public const string GetList = Prefix + "GetList";
            public const string GetPaginatedList = Prefix + "GetPaginatedList";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete/{id}";
            public const string SoftDeleteAndActivate = Prefix + "SoftDeleteAndActivate/{id}";
        }
        public static class SessionRouting
        {
            public const string Prefix = Root + "Session/";
            public const string GetById = Prefix + "GetById/{id}";
            public const string GetList = Prefix + "GetList";
            public const string GetPaginatedList = Prefix + "GetPaginatedList";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete/{id}";
            public const string SoftDeleteAndActivate = Prefix + "SoftDeleteAndActivate/{id}";
        }
        public static class UserCourseRouting
        {
            public const string Prefix = Root + "UserCourse/";
            public const string GetById = Prefix + "GetById/{id}";
            public const string GetList = Prefix + "GetList";
            public const string GetPaginatedList = Prefix + "GetPaginatedList";
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "Delete/{id}";
            public const string SoftDeleteAndActivate = Prefix + "SoftDeleteAndActivate/{id}";
        }
        public static class BookingRouting
        {
            public const string Prefix = Root + "Booking/";
            public const string BookSession = Prefix + "BookSession";
        }
    }
}
