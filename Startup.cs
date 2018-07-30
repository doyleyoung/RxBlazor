using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RxBlazor {
  public class Startup {
    public void ConfigureServices(IServiceCollection services) {
      InjectableAttribute.RegisterInjectables(services);
    }

    public void Configure(IBlazorApplicationBuilder app) {
      app.AddComponent<App>("app");
    }
  }
}