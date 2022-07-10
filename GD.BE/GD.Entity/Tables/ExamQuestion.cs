using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.ExamQuestion")]
    public partial class ExamQuestion
    {
        [Key]
        [Column(Order = 1)]
        public int ExamFId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int QuestionFId { get; set; }
        public int? QuestionSequence { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}
