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
    public class Pedido
    {
        //id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public UInt64 Id { get; set; }

        //valor
        private Decimal _valor;
        public Decimal Valor
        {
            get => _valor;
            set
            {
                if (_valor <= 0)
                {
                    throw new ArgumentException("O valor não pode ser menor igual a zero");
                }
                _valor = value;
            }
        }

        //data
        [Required]
        private DateTime _data;
        [Required]
        public DateTime Data
        {
            get => _data;
            set
            {
                if (_data > DateTime.Now)
                {
                    throw new Exception("Data do pedido não pode ser futura");
                }
                _data = value;
            }
        }

        //quantidade
        private Decimal _quantidade;
        public Decimal Quantidade
        {
            get => _quantidade;
            set
            {
                if (_quantidade <= 0)
                {
                    throw new ArgumentException("A quantidade não ode ser negativa ou nula");
                }
                _quantidade = value;
            }
        }

        //estado
        public Estado Estado { get; set; } = Estado.PENDENTE;
    }
}