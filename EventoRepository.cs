using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BasicPersistenceExercises
{
    public class EventoRepository
    {
        //salvar ou atualizar
        public static void SaveOrUpdate(Evento evento)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (evento.Id == 0)
                    {
                        dbContext.Eventos.Add(evento);
                    }
                    else
                    {
                        dbContext.Entry(evento).State = EntityState.Modified;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // salvar por id
        public static Evento? FindById(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (id > 0)
                    {
                        return dbContext.Eventos.Find(id);
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
        public static List<Evento> findAll()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Eventos.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //deletar
        public static void Delete(Evento evento)
        {
            try
            {
                using (Repository dbContex = new Repository())
                {
                    dbContex.Eventos.Attach(evento);
                    dbContex.Eventos.Remove(evento);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //possiveis datas de inicio
        public static List<Evento> FindStartDateBetween(DateTime start, DateTime end)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Eventos.Where(e => e.Inicio > start && e.Inicio < end).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Capacidade Acima
        public static List<Evento> FindCapacityAbove(UInt32 capacity)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Eventos.Where(e => e.Capacidade > capacity).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar por tipo
        public static List<Evento> FindByType(Tipo type)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Eventos.Where(e => e.Tipo == type).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}