using ApiTarefaDapper.Data;
using Dapper.Contrib.Extensions;
using static ApiTarefaDapper.Data.TarefaContext;

namespace ApiTarefaDapper.EndPoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem vindo a API TarefasDapper {DateTime.Now}");

            app.MapGet("/tarefas", async (Getconnection connectionGatter) =>
            {
                using var conn = await connectionGatter();
                var tarefas = conn.GetAll<Tarefa>().ToList();

                if (tarefas is null)
                    return Results.NotFound("Tarefas não puderam ser encontradas!");

                return Results.Ok(tarefas);
            });

            app.MapGet("/tarefas/{id}", async (Getconnection connectionGatter, int id) =>
            {
                using var conn = await connectionGatter();
                /*var tarefa = conn.Get<Tarefa>(id);
                if (tarefa is null)
                return Results.NotFound("Tarefas não puderam ser encontradas!");
                return Results.Ok(tarefa); */

                // USAR CODIGO MAIS LIMPO:
                return conn.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa)
                    : Results.NotFound("Tarefa " + id + " não pode ser localizada!");
            });

            app.MapPost("/tarefas", async (Getconnection connectioGatter, Tarefa tarefa) =>
            {
               using var conn = await connectioGatter();
                var id = conn.Insert(tarefa);
                return Results.Created($"/tarefas/{id}", tarefa);
            });


            app.MapPut("/tarefas", async (Getconnection connectioGatter, Tarefa tarefa) =>
            {
                using var conn = await connectioGatter();
                var id = conn.Update(tarefa);
                return Results.Ok();
            });

            app.MapDelete("/tarefas/{id}", async (Getconnection connectionGatter, int id) =>
            {
                using var conn = await connectionGatter();
                var deleted = conn.Get<Tarefa>(id);

                if (deleted is null)
                    return Results.NotFound("A Tarefa " + id + " não pode ser localizada!");

                conn.Delete(deleted);
                return Results.Ok(deleted);
            });
        }
    }
}
