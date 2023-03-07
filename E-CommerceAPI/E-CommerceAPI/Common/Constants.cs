namespace E_CommerceAPI.Common
{
    public static class Constants
    {     
        public struct AppSettings
        {
            //Connection DB
            public const string ConnectionStringSql = "AppSetting:ConnectionStrings:DB";
            //JWT
            public const string JWT_Secret = "AppSetting:JWT:Secret";
            public const string JWT_ExpireTime = "AppSetting:JWT:ExpireTime";
            public const string JWT_TokenDescriptor_Issuer = "AppSetting:JWT:TokenDescriptor:Issuer";
            public const string JWT_TokenDescriptor_Audience = "AppSetting:JWT:TokenDescriptor:Audience";
            //DateFormat
            public const string DateFormat = "AppSetting:DateFormat";
            //Port Url
            public const string Client_URL = "AppSetting:Client_URL";
        }

        public struct StatusMessage
        {
            public const string Success = "OK";
            public const string No_Data = "No Data";
            public const string Could_Not_Create = "Could not create";
            public const string No_Delete = "No Deleted";
        }
        public struct Status
        {
            public const bool True = true;
            public const bool False = false;
        }
    }
}
