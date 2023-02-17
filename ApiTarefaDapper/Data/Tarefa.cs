using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefaDapper.Data;

// Usando O "record" ao invés de uma Classe
[Table("Tarefas")]
public record Tarefa(int Id, string Atividade, string Status);
