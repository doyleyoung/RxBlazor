using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class InjectableAttribute : Attribute {
  private Type InterfaceType { get; set; }
  private string ServiceType { get; set; }

  public InjectableAttribute(Type iType, string serviceType = "singleton") {
    InterfaceType = iType;
    ServiceType = serviceType;
  }

  public static void RegisterInjectables(IServiceCollection services) {
    var injectableTypes =
      from a in AppDomain.CurrentDomain.GetAssemblies()
      from t in a.GetTypes()
      let attributes = t.GetCustomAttributes(typeof(InjectableAttribute), true)
      where attributes != null && attributes.Length > 0
      select new {Type = t, Attributes = attributes.Cast<InjectableAttribute>()};

    foreach (var injectableType in injectableTypes) {
      var t = injectableType.Attributes.ElementAt(0);
      switch (t.ServiceType) {
        case "transient":
          services.AddTransient(t.InterfaceType, injectableType.Type);
          break;
        case "scoped": {
          services.AddScoped(t.InterfaceType, injectableType.Type);
          break;
        }
        default:
          services.AddSingleton(t.InterfaceType, injectableType.Type);
          break;
      }
    }
  }
}