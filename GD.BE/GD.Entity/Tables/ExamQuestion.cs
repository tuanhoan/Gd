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
        public int Exam { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Question { get; set; }
        public int? QuestionSequence { get; set; }

        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}
