using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using VentaEntradas.Domain.Entities;
using VentaEntradas.Domain.Contracts;

namespace VentaEntradas.Infraestructure
{
    public class VentaEntradasDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Evento> Eventos { get; set; }
        public string DbPath { get; set; }

        public VentaEntradasDbContext(DbContextOptions<VentaEntradasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public void ExecuteStoredProcedure(string procedureName, object param = null)
        {
            using (var connection = new SqlConnection(Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                connection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
