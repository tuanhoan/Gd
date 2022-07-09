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
        public int ExamId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int QuestionId { get; set; }
        public int? QuestionSequence { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public Exam Exams { get; set; }
        public Question Questions { get; set; }
    }
}
