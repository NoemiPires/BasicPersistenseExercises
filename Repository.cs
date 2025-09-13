using System;
using Microsoft.EntityFrameworkCore;

namespace BasicPersistenceExercises
{
    public class Repository : DbContext
    {
        private static readonly String _connectionParams = @"server=127.0.0.1;port=3307;uid=root;pwd=;database=basicpersistence";

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        public Repository() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(_connectionParams);
        }
    }
}