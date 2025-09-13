
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPersistenceExercises
{
    public class Evento
    {
        //id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public UInt64 Id { get; set; }

        //descricao
        [Required]
        [MaxLength(250)]
        public String? Descricao { get; set; }

        //inicio
        [Required]
        public DateTime _inicio;
        [Required]
        public DateTime Inicio
        {
            get => _inicio;
            set
            {
                if (_inicio > DateTime.Now)
                {
                    throw new Exception("Data de Inicio não pode ser futura");
                }
                _inicio = value;
            }
        }

        //fim
        private DateTime _fim;
        public DateTime Fim
        {
            get => _fim;
            set
            {
                if (_fim <= _inicio)
                {
                    throw new Exception("Data de Fim não pode ser igual menor que a data de inicio");
                }
                _fim = value;
            }
        }

        //capacidade
        private UInt32 _capacidade;
        public UInt32 Capacidade
        {
            get => _capacidade;
            set
            {
                if (value < 0)
                {
                    throw new Exception("A capacidade não pode ser menor que zero");
                }
                _capacidade = value;
            }
        }

        //tipo
        public Tipo Tipo { get; set; } = Tipo.REUNIAO;
    }
}