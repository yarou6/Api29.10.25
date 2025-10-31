using Api29._10._25.CQRS.DTO;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.ComponentModel.DataAnnotations;

namespace Api29._10._25.Behaviors
{
    public class ClientInfoBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> HandleAsync(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken ct)
        {
            var requestName = typeof(TRequest).Name;
            Console.WriteLine($"[START] обработка команды {requestName}");

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                // 1
                if (request is CommandInfo info)
                    info.AddInfo = new AddInfo { Date = DateTime.Now, IP = "", UserAgent = "" };
                ////2 
                //var prop = typeof(TRequest).GetProperty("AddInfo");
                //if (prop != null)
                //    prop.SetValue(request, new AddInfo { Date = DateTime.Now, IP = "", UserAgent = "" });

                var response = await next(); // Выполняем команду
                Console.WriteLine($"[SUCCESS]");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"[TIME] {requestName} время работы: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine($"[END] дообрабатывали команду {requestName}");
                Console.WriteLine();
            }
        }
    }
}
