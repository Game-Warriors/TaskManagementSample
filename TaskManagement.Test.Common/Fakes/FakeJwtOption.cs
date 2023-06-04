using Microsoft.Extensions.Options;
using TaskManagement.Infrastructure.Options;

namespace TaskManagement.Test.Common.Fakes
{
    public class FakeJwtOption : IOptions<JwtOptions>
    {
        public JwtOptions Value { get; }

        public FakeJwtOption()
        {
            Value = new JwtOptions()
            {
                Audience = "father",
                HourLifeTime = 168,
                Issuer = "mahdifada",
                SecretKey = "12345789fasf54gtwwtgwtwc54twrtc34-5tvtck45033t=c454tv7654uyythw45-"
            };
        }
    }
}
