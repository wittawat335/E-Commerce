namespace E_CommerceAPI.Common
{
    public static class Constants
    {     
        public struct AppSettings
        {
            //Connection DB
            public const string ConnectionStringSql = "ConnectionStrings:DB";
            //JWT
            public const string JWT_Secret = "JWT:Secret";
            public const string JWT_ExpireTime = "JWT:ExpireTime";
            public const string JWT_TokenDescriptor_Issuer = "JWT:TokenDescriptor:Issuer";
            public const string JWT_TokenDescriptor_Audience = "JWT:TokenDescriptor:Audience";
            //DateFormat
            public const string DateFormat = "DateFormat";

        }

        public struct StatusMessage
        {
            public const string Success = "OK";
            public const string Faile = "No data";
        }
        public struct Status
        {
            public const bool True = true;
            public const bool False = false;
        }
    }
}
