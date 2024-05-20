SignalR close call returning 404

Caused by a delay in 
```csharp
    app.Use(async (context, next) =>
        {
            await Task.Delay(500);
            await next();
        });
```
