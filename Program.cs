using System;

namespace BasicPersistenceExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Repository repository = new Repository();

            Paciente p1 = new Paciente();
            p1.Nome = null;
            p1.Nascimento = DateTime.Now;
            p1.Genero = Genero.NAO_DECLARADO;
            p1.Condicao = false;
            p1.UltimaConsulta = DateTime.Now;
            
            Pedido pd1 = new Pedido();
            pd1.Valor = 0;
            pd1.Data = DateTime.Now;
            pd1.Quantidade = 0;
            pd1.Estado = Estado.PENDENTE;

            Evento e1 = new Evento();
            e1.Descricao = null;
            e1.Inicio = DateTime.Now;
            e1.Fim = DateTime.Now;
            e1.Tipo = Tipo.REUNIAO;

            Tarefa t1 = new Tarefa();
            t1.Titulo = null;
            t1.Responsavel = "Alana";
            t1.Prioridade = Prioridade.MEDIA;
            t1.Concluida = false;



        }
    }
}   