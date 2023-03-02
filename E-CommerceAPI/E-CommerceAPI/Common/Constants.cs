namespace E_CommerceAPI.Common
{
    public static class Constants
    {     
        public struct AppSettings
        {
            //JWT
            public const string JWT_Secret = "JWT:Secret";
            public const string JWT_ExpireTime = "JWT:ExpireTime";
            public const string JWT_TokenDescriptor_Issuer = "JWT:TokenDescriptor:Issuer";
            public const string JWT_TokenDescriptor_Audience = "JWT:TokenDescriptor:Audience";
            //DateFormat
            public const string DateFormat = "DateFormat";

        }
    }
}
