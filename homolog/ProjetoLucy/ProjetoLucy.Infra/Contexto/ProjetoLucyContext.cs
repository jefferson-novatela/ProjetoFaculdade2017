using ProjetoLucy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Infra.Contexto
{
    public class ProjetoLucyContext : DbContext       
    {
        public ProjetoLucyContext()
             : base("ProjetoLucy")
        {
            
        }

        public DbSet<ItensPedido> ItensPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            //modelBuilder.Properties<string>()
            //   .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new ClasseConfig());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(45));

            base.OnModelCreating(modelBuilder);
        }
    }
}
