namespace TodoAppliksjonAPI.Middleware
{
    public class LoggingMiddleware
    {
        // Vriable som holder referansen til neste middleware i serien 
        private readonly RequestDelegate _next;


        // Konstruktør som intialiserer LoggingMiddleware
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Metode som blir kalt for hver http-request
        public async Task InvokeAsync(HttpContext context)
        {
            // Logger Detalje for den innkommende requesten
            Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Path}");
            // Sender requesten videre til neste middleware
            await _next(context);

            // Logger detaljene for respons etter middleware (Controller er ferdig 
            Console.WriteLine($"[{DateTime.Now}]Response: {context.Response.StatusCode}");
         
            
        } 
        
    }        
    
}
