using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasicPersistenceExercises
{
    public class TarefaRepository
    {
        //Salvar ou atualizar
        public static void SaveOrUpDate(Tarefa tarefa)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (tarefa.Id == 0)
                    {
                        dbContext.Tarefas.Add(tarefa);
                    }
                    else
                    {
                        dbContext.Entry(tarefa).State = EntityState.Modified;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar por id
        public static Tarefa? FindById(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (id > 0)
                    {
                        return dbContext.Tarefas.Find(id);
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //salvar tudo
        public static List<Tarefa> FindAll()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // deletar
        public static void Delete(Tarefa tarefa)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    dbContext.Tarefas.Attach(tarefa);
                    dbContext.Tarefas.Remove(tarefa);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //atrasadas
        public static List<Tarefa> FindLate()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.Where(t => t.Prazo < DateTime.Today).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Não completas
        public static List<Tarefa> FindNotCompleted()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.Where(t => t.Concluida == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Alta prioridade e não completada
        public static List<Tarefa> FindHighPriorityNotCompleted()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.Where(t => t.Prioridade == Prioridade.ALTA && t.Concluida == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Sem responsavel
        public static List<Tarefa> FindAllWithoutResponsible()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.Where(t => t.Responsavel == null).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //prazo vence em 7 dias
        public static List<Tarefa> FindAllDueNextSevenDays()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Tarefas.Where(t => t.Prazo == DateTime.Now.AddDays(7)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
