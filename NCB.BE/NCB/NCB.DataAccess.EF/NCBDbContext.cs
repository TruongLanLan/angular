using Microsoft.EntityFrameworkCore;
using NCB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF
{
    public class NCBDbContext : DbContext
    {
        public NCBDbContext(DbContextOptions<NCBDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Log_Login> LogLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(a =>
            {
                a.HasKey(x => x.USER_ID);
            });

            modelBuilder.Entity<Log_Login>(logLogin =>
            {
                logLogin.HasKey(x => x.SEQ);
                logLogin.HasOne(x => x.User).WithMany(x => x.LogLogins).HasForeignKey(x => x.USER_ID);
            });

        }
    }
}
