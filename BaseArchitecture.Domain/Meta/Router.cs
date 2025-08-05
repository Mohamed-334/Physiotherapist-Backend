namespace BaseArchitecture.Domain.Meta
{
    public static class Router
    {
        //public const string Domain = "https://localhost:5001";
        public const string Root = "/api/";
        public static class AuthenticationRouting
        {
            public const string SignUp = Root + "SignUp";
            public const string ChangePassword = Root + "ChangePassword";
        }
        public static class UserRouting
        {
            public const string GetUserById = Root + "GetUserById/{id}";
            public const string GetUsersList = Root + "GetUsersList";
            public const string GetUsersPaginatedList = Root + "GetUsersPaginatedList";
            public const string UpdateUser = Root + "UpdateUser";
            public const string HardDeleteUser = Root + "HardDeleteUser/{id}";
            public const string SoftDeleteAndActivateUser = Root + "SoftDeleteAndActivateUser/{id}";
        }
    }
}
