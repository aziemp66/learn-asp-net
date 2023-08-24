var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(e =>
{
    e.Map(
        "/employee/{id:int}",
        // int
        //
        // Matches with any integer.
        //
        // Eg: {id:int} matches with 123456789, -123456789
        //
        //
        // bool
        //
        // Matches with true or false. Case-insensitive.
        //
        // Eg: {active:bool} matches with true, false, TRUE, FALSE
        //
        //
        // datetime
        //
        // Matches a valid DateTime value with formats "yyyy-MM-dd hh:mm:ss tt" and "MM/dd/yyyy hh:mm:ss tt".
        //
        // Eg: {id:datetime} matches with 2030-01-01%2011:59%20pm
        //
        // Note: '%20' is equal to space.
        //
        //
        // decimal
        //
        // Matches with a valid decimal value.
        //
        // Eg: {price:decimal} matches with 49.99, -1, 0.01
        //
        //
        // long
        //
        // Matches a valid long value.
        //
        // Eg: {id:long} matches with 123456789, -123456789
        //
        //
        // guid
        //
        // Matches with a valid Guid value (Globally Unique Identifier - A hexadecimal number that is universally unique).
        //
        // Eg: {id:guid} matches with 123E4567-E89B-12D3-A456-426652340000
        //
        //
        // minlength(value)
        //
        // Matches with a string that has at least specified number of characters.
        //
        // Eg: {username:minlength(4)} matches with John, Allen, William
        //
        //
        // maxlength(value)
        //
        // Matches with a string that has less than or equal to the specified number of characters.
        //
        // Eg: {username:maxlength(7)} matches with John, Allen, William
        //
        //
        // length(min,max)
        //
        // Matches with a string that has number of characters between given minimum and maximum length (both numbers including).
        //
        // Eg: {username:length(4, 7)} matches with John, Allen, William
        //
        //
        // length(value)
        //
        // Matches with a string that has exactly specified number of characters.
        //
        // Eg: {tin:length(9)} matches with 987654321
        //
        //
        // min(value)
        //
        // Matches with an integer value greater than or equal to the specified value.
        //
        // Eg: {age:min(18)} matches with 18, 19, 100
        //
        //
        // max(value)
        //
        // Matches with an integer value less than or equal to the specified value.
        //
        // Eg: {age:max(100)} matches with -1, 1, 18, 100
        //
        // range(min,max)
        //
        // Matches with an integer value between the specified minimum and maximum values (both numbers including).
        //
        // Eg: {age:range(18,100)} matches with 18, 19, 99, 100
        //
        //
        // alpha
        //
        // Matches with a string that contains only alphabets (A-Z) and (a-z).
        //
        // Eg: {username:alpha} matches with rick, william
        async ctx =>
        {
            int employeeId = Convert.ToInt32(ctx.Request.RouteValues["id"]);
            await ctx.Response.WriteAsync($"Employee ID is {employeeId}");
        }
    );

    e.Map(
        "/employee/email/{email:regex(^[a-zA-z0-9-.+]+@[a-zA-z0-9-.]+.[a-zA-z]{{2,}}$)}",
        async ctx =>
        {
            string email = ctx.Request.RouteValues["email"]?.ToString()!;
            await ctx.Response.WriteAsync($"Employee Email is {email}");
        }
    );
});

app.Run(
    async (ctx) =>
    {
        await ctx.Response.WriteAsync($"You're in the {ctx.Request.Path} Endpoint");
    }
);

app.Run();
