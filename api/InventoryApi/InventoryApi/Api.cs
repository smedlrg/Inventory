using DataAccess.Services;

namespace InventoryApi;

/// <summary>
/// Api endpoints for invetory app
/// </summary>
public static class Api
{
    //These should be moved to appsettings file to allow changes without needing to recompile
    private const int DURATION = 5;
    private const string END_MESSAGE = "Sale Over! Too Bad!";

    /// <summary>
    /// Configures endpoints
    /// </summary>
    /// <param name="app">Web Application for endpoint binding</param>
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Items", GetItems);
        app.MapGet("/Timer", GetTimer);
        app.MapPost("/Timer", TimerFinished);
    }

    /// <summary>
    /// Returns List of Items from Inventory Service
    /// </summary>
    /// <param name="service">DI Invetory service for getting items</param>
    /// <returns>Task<IResult> of Items</returns>
    private static async Task<IResult> GetItems(IInventoryService service)
    {
        try
        {
            return Results.Ok(await service.GetItems());
        }
        catch(Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Returns Date in x minutes in future - defined by DURATION const
    /// </summary>
    /// <returns>Current DateTime + Duration</returns>
    private static IResult GetTimer()
    {
        try
        {
            return Results.Ok(DateTime.Now.AddMinutes(DURATION));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint to signify timer has ended
    /// </summary>
    /// <returns>Message to display</returns>
    private static IResult TimerFinished()
    {
        return Results.Ok(END_MESSAGE);
    }
}
