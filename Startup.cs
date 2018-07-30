using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RxBlazor {
  public class Startup {
    public void ConfigureServices(IServiceCollection services) {
      services.AddSingleton<ICounterService, CounterService>();
      services.AddSingleton<IMessageService, MessageService>();
    }

    public void Configure(IBlazorApplicationBuilder app) {
      app.AddComponent<App>("app");
    }
  }
}