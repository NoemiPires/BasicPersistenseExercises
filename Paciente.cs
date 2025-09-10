using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPersistenceExercises
{
    public class Paciente
    {
        [Required]
        [MaxLength(45)]
        public String? Nome {  get; set; }

        [Required]
        private DateOnly _nascimento;
        [Required]
        public DateOnly Nascimento 
        {
            get => _nascimento;
            set
            {
                if (_nascimento > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Data de Nascimento não pode ser futura");
                }
                _nascimento = value;
            } 
        }
        public Genero Genero { get; set; }
        public Boolean Condicao {  get; set; }
        public DateOnly UltimaConsulta {  get; set; }
    }
}
