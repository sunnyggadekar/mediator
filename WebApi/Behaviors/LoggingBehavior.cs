namespace WebApi.Behaviors
{
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Threading;


    /// <summary>
    /// This will save hundreds of lines of code we write for logging in every action method
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async System.Threading.Tasks.Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            //Pre logic 
            logger.LogInformation("{Request} is starting.", requestName);
            var timer = Stopwatch.StartNew();
            
            var response = await next();
            timer.Stop();


            logger.LogInformation("{Request} has finished in {Time}ms.", requestName, timer.ElapsedMilliseconds);
            //Post logic

            return response;
        }
    }
}
