namespace PlanningTool.DataBase.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskID { get; set; }

        [StringLength(400)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? Duration { get; set; }

        public DateTime? StartDate { get; set; }

        public int? PercentComplete { get; set; }

        public int? Status { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Status Status1 { get; set; }
    }
}
