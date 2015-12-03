namespace rpc.Web
{
 using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
   
public partial class RPC_DBEntities : DbContext
{
public RPC_DBEntities()
: base("name=RPC_DBEntities")
{
       }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobAssign> JobAssigns { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<ManHour> ManHours { get; set; }
        public virtual DbSet<Work> Works { get; set; }
    }
}