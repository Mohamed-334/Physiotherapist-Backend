namespace BaseArchitecture.Domain.Meta
{
    public static class Router
    {
        //public const string Domain = "https://localhost:5001";
        public const string Root = "/api/";
        public static class AuthenticationRouting
        {
            public const string SignUp = Root + "SignUp";
        }
    }
}
