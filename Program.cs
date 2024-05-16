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
        services.AddSession();
    })
    .Configure(app =>
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<ChatHub>("/hub/Chat");
            endpoints.MapRazorPages();
        });
    })
    .Build()
    .Run();

