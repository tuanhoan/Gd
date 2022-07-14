using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("Question")]
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
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        [MaxLength(200)]
        public string SubjectName { get; set; }
        public int? QuestionLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string content { get; set; }

        public List<ExamQuestion> ExamQuestions { get; set; }
        public List<QuestionChoice> QuestionChoices { get; set; }
    }
}
