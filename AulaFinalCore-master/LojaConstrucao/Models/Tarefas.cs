

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
   
    public class Tarefas
    {
        public int TarefasId { get; set; }

        [Display(Name = "nome da tarefa")]
        public string NomeTarefa { get; set; } = string.Empty;

        public string Status { get; set; } = "Por Fazer!";
        public DateTime dataInicio { get; set; } = DateTime.Now;

        public DateTime dataConclusão { get; set; }

        public string? descricao { get; set; }




    }
}
