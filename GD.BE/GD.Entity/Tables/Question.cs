using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.Question")]
    public partial class Question
    {
        public Question()
        {
            this.ExamQuestions = new List<ExamQuestion>();
            this.QuestionChoices = new List<QuestionChoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Content { get; set; }
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        [MaxLength(200)]
        public string SubjectName { get; set; }
        public int? QuestionLevel { get; set; }

        public List<ExamQuestion> ExamQuestions { get; set; }
        public List<QuestionChoice> QuestionChoices { get; set; }
    }
}
