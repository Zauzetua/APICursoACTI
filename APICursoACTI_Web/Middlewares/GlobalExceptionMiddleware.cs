namespace APICursoACTI_Web.Middlewares
{
    /// <summary>
    /// Middleware para manejo global de excepciones.
    /// Con esto, no es necesario manejar try-catch en cada servicio.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //Intentamos realizar la siguiente operacion en la cadena de middlewares
                await _next(context);
            }
            catch (Exception ex)
            {
                //Si llegara a fallar algo (Servicio, repo, controller, etc), se captura la excepcion aqui.
                _logger.LogError(ex, ex.Message);

                // Preparamos una respuesta de error estandarizada
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new
                {
                    success = false,
                    message = "Error interno del servidor.",
                    detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
