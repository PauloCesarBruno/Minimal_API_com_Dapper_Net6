using System.Data.SqlClient;
using static ApiTarefaDapper.Data.TarefaContext;

namespace ApiTarefaDapper.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionsting = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<Getconnection>(sp =>
            async () =>
            {
                var connection = new SqlConnection(connectionsting);
                await connection.OpenAsync();
                return connection;
            });
            return builder;
        }
    }
}
