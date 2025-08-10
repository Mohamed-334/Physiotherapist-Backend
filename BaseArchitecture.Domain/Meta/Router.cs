namespace BaseArchitecture.Domain.Meta
{
    public static class Router
    {
        //public const string Domain = "https://localhost:5001";
        public const string Root = "/api/";
        public static class AuthenticationRouting
        {
            public const string SignUp = Root + "Authentication/SignUp";
            public const string SignIn = Root + "Authentication/SignIn";
            public const string ChangePassword = Root + "Authentication/ChangePassword";
        }
        public static class UserRouting
        {
            public const string GetById = Root + "User/GetById/{id}";
            public const string GetList = Root + "User/GetList";
            public const string GetUserRoles = Root + "User/GetUserRoles/{id}";
            public const string GetPaginatedList = Root + "User/GetPaginatedList";
            public const string Update = Root + "User/Update";
            public const string HardDelete = Root + "User/HardDelete/{id}";
            public const string SoftDeleteAndActivate = Root + "User/SoftDeleteAndActivate/{id}";
        }
        public static class RoleRouting
        {
            public const string GetById = Root + "Role/GetById/{id}";
            public const string GetList = Root + "Role/GetList";
            public const string GetPaginatedList = Root + "Role/GetPaginatedList";
            public const string Create = Root + "Role/Create";
            public const string Update = Root + "Role/Update";
            public const string Delete = Root + "Role/Delete/{id}";
            public const string SoftDeleteAndActivate = Root + "Role/SoftDeleteAndActivate/{id}";
        }
    }
}
