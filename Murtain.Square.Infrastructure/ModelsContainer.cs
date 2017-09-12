using Murtain.EntityFramework;
using Murtain.Square.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Infrastructure
{
    public class ModelsContainer : EntityFrameworkDbContext
    {
        public ModelsContainer()
             : base("DefaultConnection")
        {

        }
        public ModelsContainer(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            DbInterception.Add(new EntityFrameworkDbCommandInterceptor());
        }

        public virtual DbSet<Focus> Focus { get; set; }
        public virtual DbSet<Sentence> Sentence { get; set; }
    }
}
