using ConsumeApiWithIHttpClientFactory.Dtos.Setting;
using ConsumeApiWithIHttpClientFactory.Services;
using Microsoft.Extensions.Options;

namespace ConsumeApiWithIHttpClientFactory.Helpers
{
    public static class IocExtention
    {
        public static void AddHttpClientFactory(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var siteSetting = sp.GetService<IOptions<SiteSetting>>().Value;
            services.AddHttpClient("school", c =>
            {
                c.BaseAddress = new Uri(siteSetting.ServiceUrl);
                c.Timeout= TimeSpan.FromSeconds(100);
            });
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentServices, StudentServices>();
        }
    }
}
