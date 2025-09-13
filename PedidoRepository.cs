using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasicPersistenceExercises
{
    public class PedidoRepository
    {
        public static void SaveOrUpdate(Pedido pedido)
        {
            //salvar ou atulaizar
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (pedido.Id == 0)
                    {
                        dbContext.Pedidos.Add(pedido);
                    }
                    else
                    {
                        dbContext.Entry(pedido).State = EntityState.Modified;
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //salvar por id
        public static Pedido? FindById(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (id > 0)
                    {
                        return dbContext.Pedidos.Find(id);
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar todos
        public static List<Pedido> FindAll()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //deletar
        public static void Delete(Pedido pedido)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    dbContext.Pedidos.Attach(pedido);
                    dbContext.Pedidos.Remove(pedido);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Salvar preço abaixo
        public static List<Pedido> FindPriceBelow(Decimal price)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Valor < price).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //salvar preço alto
        public static List<Pedido> FindPriceAbove(Decimal price)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Valor > price).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Salvar preço entre maior e menor
        public static List<Pedido> FindPriceBetween(Decimal minPrice, Decimal maxPrice)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    if (minPrice > maxPrice)
                    {
                        throw new Exception("Preço menor não pode ser maior que o maior preço");
                    }
                    return dbContext.Pedidos.Where(p => p.Valor > minPrice && p.Valor < maxPrice).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Todos os cancelados
        public static List<Pedido> FindAllCanceled()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Estado == Estado.CANCELADO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Todos não enviados
        public static List<Pedido> FindAllNotSent()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Estado != Estado.ENVIADO).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Pendentes acima
        public static List<Pedido> FindAllPendentsAbove(Decimal price)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Valor > price && p.Estado == Estado.PENDENTE).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Quantidade Acima
        public static List<Pedido> FindAllQuantityAbove(UInt32 quantity)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Quantidade > quantity).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Todos os pedidos feitos nos ultimos 30 dias
        public static List<Pedido> FindAllLastThirtyDays()
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Pedidos.Where(p => p.Data >= DateTime.Now.AddDays(-30)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}