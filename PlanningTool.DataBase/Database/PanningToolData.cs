namespace PlanningTool.DataBase.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PanningToolData : DbContext
    {
        //string connectionstrint ="@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=PlanningDataBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" ;
        public PanningToolData()
            : base("name=PanningToolData")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsFixedLength();
        }
    }
}
