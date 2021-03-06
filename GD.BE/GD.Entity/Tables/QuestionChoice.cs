using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("QuestionChoice")]
    public partial class QuestionChoice
    {
        public QuestionChoice()
        {
            this.StudentTests = new List<StudentTest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? QuestionFId { get; set; }
        public string content { get; set; }
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        public bool? is_answer { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public Question Question { get; set; }
        public List<StudentTest> StudentTests { get; set; }
    }
}
