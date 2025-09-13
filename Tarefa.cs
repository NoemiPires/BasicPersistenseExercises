using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPersistenceExercises
{
    public class Tarefa
    {
        //id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public UInt64 Id { get; set; }

        //titulo
        [Required]
        [MaxLength(150)]
        public String? Titulo { get; set; }

        //responsavel
        [MaxLength(25)]
        public String? Responsavel { get; set; }

        //nivel de prioridade
        public Prioridade Prioridade { get; set; } = Prioridade.MEDIA;

        //prazo
        public DateTime Prazo { get; set; }

        //se foi ou não concluida
        public Boolean Concluida { get; set; } = false;
    }
}