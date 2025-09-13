using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPersistenceExercises
{
    public class Paciente
    {
        // id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public UInt64 Id { get; set; }

        //nome
        [Required]
        [MaxLength(45)]
        public String? Nome { get; set; }

        //nascimento
        [Required]
        private DateTime _nascimento;
        [Required]
        public DateTime Nascimento
        {
            get
            {
                return _nascimento;
            }
            set
            {
                if (_nascimento > DateTime.Today)
                {
                    throw new Exception("Data de Nascimento não pode ser futura");
                }
                _nascimento = value;


                for (DateTime d = _nascimento; d <= DateTime.Today; d = d.AddYears(1))
                {
                    _idade++;
                }
            }
        }

        //idade
        private Byte _idade { get; set; }
        public Byte Idade { get => _idade; }

        //genero
        public Genero Genero { get; set; } = Genero.NAO_DECLARADO;

        //Condição Cronica
        public Boolean Condicao { get; set; }

        //ultima Consulta
        public DateTime UltimaConsulta { get; set; }

        public override String ToString()
        {
            return Id
                + ", " + Nome + ", " + Nascimento + ", " + 
                Idade + ", " + Genero + ", " + Condicao +
                 ", " + UltimaConsulta;
        }

    }
}