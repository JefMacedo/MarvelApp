using MarvelApp.Api;
using MarvelApp.Core.Interfaces;
using MarvelApp.Infrastructure;
using MarvelApp.Infrastructure.Clients;
using MarvelApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args)
  .ConfigureAppConfiguration((context, config) =>
  {
      config.AddJsonFile("appsettings.json", optional: false);
  })
  .ConfigureServices((context, services) =>
  {
      services.Configure<MarvelApiOptions>(
          context.Configuration.GetSection("MarvelApi"));

      services.AddMemoryCache();
      services.AddSingleton<IHashService, Md5HashService>();

      services.AddHttpClient<MarvelApiClient>((provider, client) =>
      {
          var options = provider
              .GetRequiredService<Microsoft.Extensions.Options.IOptions<MarvelApiOptions>>()
              .Value;
          client.BaseAddress = new Uri(options.BaseUrl);
      });

      services.AddTransient<IMarvelApiClient>(provider =>
      {
          var innerClient = provider.GetRequiredService<MarvelApiClient>();
          var cache = provider.GetRequiredService<Microsoft.Extensions.Caching.Memory.IMemoryCache>();

          return new CachingMarvelApiClient(innerClient, cache);
      });

      services.AddHostedService<MarvelConsoleRunner>();
  })
  .Build()
  .Run();
