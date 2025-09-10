using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace BasicPersistenceExercises
{
    public class Evento
    {
        [Required]
        [MaxLength(250)]
        public String? Descricao { get; set; }

        [Required]
        public DateOnly _inicio;
        [Required]
        public DateOnly Inicio
        {
            get => _inicio;
            set
            {
                if (_inicio > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Data de Inicio não pode ser futura");
                }
                _inicio = value;
            }
        }

        private DateOnly _fim;
        public DateOnly Fim
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

        public Tipo Tipo { get;set; }
    }
}
