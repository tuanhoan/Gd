using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.Test")]
    public partial class Test
    {
        public Test()
        {
            this.StudentTests = new List<StudentTest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? ExamFId { get; set; }
        public int? StudentFId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? TestingTime { get; set; }
        public Guid? UniqueId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public List<StudentTest> StudentTests { get; set; }
    }
}
