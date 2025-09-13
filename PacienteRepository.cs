using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BasicPersistenceExercises
{
    public class PacienteRepository
    {
        // Salvar ou Atualizar
        public static void SaveOrUpdate(Paciente paciente)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (paciente.Id == 0)
                    {
                        dbContext.Pacientes.Add(paciente);
                    }
                    else
                    {
                        dbContext.Entry(paciente).State = EntityState.Modified;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Salvar por Id
        public static Paciente? SaveById(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (id > 0)
                    {
                        return dbContext.Pacientes.Find(id);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Salvar todos
        public static List<Paciente> FindAll()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Deletar
        public static void Delete(Paciente paciente)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    dbContext.Pacientes.Attach(paciente);
                    dbContext.Pacientes.Remove(paciente);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar todas as mulheres
        public static List<Paciente> FindAllWoman()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.Where(p => p.Genero == Genero.FEMININO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar todos os homens
        public static List<Paciente> FindAllMen()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.Where(p => p.Genero == Genero.MASCULINO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar todos que não declararam genero
        public static List<Paciente> FindAllUndeclaredGenre()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.Where(p => p.Genero == Genero.NAO_DECLARADO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar maiores de 18 anos ou mais
        public static List<Paciente> FindAll18YearsOrMore(Byte idade)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.Where(p => p.Idade >= 18).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar pessoa com doenças cronicas
        public static List<Paciente> FindAllChronicConditions()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pacientes.Where(p => p.Condicao == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}