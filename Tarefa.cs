using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPersistenceExercises
{
    public class Tarefa
    {
        [Required]
        [MaxLength(150)]
        public String? Titulo {  get; set; }

        [MaxLength(25)]
        public String? Responsavel {  get; set; }

        public Prioridade Prioridade { get; set; }

        public DateOnly Prazo { get; set; }
        public Boolean Concluida {  get; set; }
    }
}
