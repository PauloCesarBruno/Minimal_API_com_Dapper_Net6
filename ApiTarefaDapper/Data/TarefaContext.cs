using System.Data;

namespace ApiTarefaDapper.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> Getconnection();
    }
}
