using Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

  try
  {
      var builder = WebApplication.CreateBuilder(args);
      StartupHelper.ConfigureServices(builder);
  
      var app = builder.Build();
      StartupHelper.Configure(app);
  }
  catch(Exception ex)
  {
      Console.WriteLine($"ERrr:   {ex.Message}");
  }  

