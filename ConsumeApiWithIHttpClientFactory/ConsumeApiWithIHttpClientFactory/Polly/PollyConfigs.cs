using Polly;
using Polly.Extensions.Http;

namespace ConsumeApiWithIHttpClientFactory.Polly
{
    public class PollyConfigs
    {
        public static IAsyncPolicy<HttpResponseMessage> GetStudentsRetryer()
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(5)
                }, (_, waitingTime) =>
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Polly run retryer");
                        Console.ResetColor();
                    });
        }
        public static IAsyncPolicy<HttpResponseMessage> GetStudentsCircuitBreaker()
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
        }
    }
}
