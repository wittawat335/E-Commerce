namespace E_CommerceAPI.Common
{
    public static class Constants
    {
        public struct DateFormat
        {
            public const string DateFormatddd = "Constants:DateFormat";
        }
        public struct AppSettings
        {
            public const string JWT_Secret = "JWT:Secret";
            public const string JWT_TokenDescriptor_Issuer = "JWT:TokenDescriptor:Issuer";
            public const string JWT_TokenDescriptor_Audience = "JWT:TokenDescriptor:Audience";
        }
    }
}
