namespace TaskManagement.Infrastructure.Options
{
    public class JwtOptions
    {
        public const string JwtSettingName = "JwtSetting";
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string SecretKey { get; set; } = default!;// it is not suitable production way
        public double HourLifeTime { get; set; }
    }
}
