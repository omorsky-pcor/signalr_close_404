using SignalRHubsSample.Hubs;

new WebHostBuilder()
    .UseContentRoot(Environment.CurrentDirectory)
    .UseKestrel()
    .ConfigureServices(services =>
    {
        services
                .AddSignalR(o =>
                {
                    o.EnableDetailedErrors = true;
                });
        services.AddRazorPages();
    })
    .Configure(app =>
    {
        app.Use(async (context, next) =>
        {
            await Task.Delay(500);  //This causes the issue
            await next();
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<ChatHub>("/hub/Chat");
            endpoints.MapRazorPages();
        });
    })
    .Build()
    .Run();

