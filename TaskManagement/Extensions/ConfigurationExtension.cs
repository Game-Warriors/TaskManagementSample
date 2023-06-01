namespace TaskManagement.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetJwtSecretKey(this ConfigurationManager configuration)
        {
            return configuration["JwtSetting:SecretKey"] ?? default!;
        }

        public static string GetJwtIssuer(this ConfigurationManager configuration)
        {
            return configuration["JwtSetting:Issuer"] ?? default!;
        }

        public static string GetJwtAudience(this ConfigurationManager configuration)
        {
            return configuration["JwtSetting:Audience"] ?? default!;
        }

        public static string GetJwtSecretKey(this IConfiguration configuration)
        {
            return configuration["JwtSetting:SecretKey"] ?? default!;
        }

        public static string GetJwtIssuer(this IConfiguration configuration)
        {
            return configuration["JwtSetting:Issuer"] ?? default!;
        }

        public static string GetJwtAudience(this IConfiguration configuration)
        {
            return configuration["JwtSetting:Audience"] ?? default!;
        }
    }
}
