using Microsoft.EntityFrameworkCore;
using Api_Oficina.Models;

namespace Api_Oficina.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Cadastropecas>? Cadastropecas { get; set; }
        public DbSet<Cadastrovendedor>? Cadastrovendedor { get; set; }
        public DbSet<Cliente>? Cliente { get; set; }
        public DbSet<Pedido>? Pedido { get; set; }
        public DbSet<Premium>? Premium { get; set; }
        public DbSet<Pedidopeca>? Pedidopeca { get; set; }
    }
}