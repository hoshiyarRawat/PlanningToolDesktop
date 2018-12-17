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

        public int? ParentTaskID { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(10)]
        public string Description { get; set; }

        public int? Duration { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? PercentComplete { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
