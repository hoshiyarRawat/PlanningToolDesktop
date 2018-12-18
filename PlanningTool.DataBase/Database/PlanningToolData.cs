namespace PlanningTool.DataBase.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlanningToolData : DbContext
    {
        public PlanningToolData()
            : base("name=PlanningToolData")
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

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Status1)
                .HasForeignKey(e => e.Status);
        }
    }
}
