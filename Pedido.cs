using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace BasicPersistenceExercises
{
    public class Pedido
    {
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

        [Required]
        private DateOnly _data;
        [Required]
        public DateOnly Data
        {
            get => _data;
            set
            {
                if (_data > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Data do pedido não pode ser futura");
                }
                _data = value;
            }
        }

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

        public Estado Estado { get; set; }
    }
}
