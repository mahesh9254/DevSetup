using Microsoft.AspNet.WebHooks;

namespace WebHook.Handler
{
    public class BitBucketAPIWebHookHandler : WebHookHandler
    {
        private readonly ILogger logger;

        public BitBucketAPIWebHookHandler(ILogger<BitBucketAPIWebHookHandler> logger)
        {
            this.logger = logger;
        }
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            logger.LogInformation("Hit");
            return Task.CompletedTask;

        }
    }
}
