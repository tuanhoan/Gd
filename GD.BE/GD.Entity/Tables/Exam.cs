using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("Exam")]
    public partial class Exam
    {
        public Exam()
        {
            this.ExamQuestions = new List<ExamQuestion>();
            this.Tests = new List<Test>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("MilitaryInformation")]
        public int? MilitaryInformationFId { get; set; }
        [MaxLength(200)]
        public string SubjectName { get; set; }
        public int? Duration { get; set; }
        [MaxLength(30)]
        public string term { get; set; }
        public Guid? UniqueId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public MilitaryInformation MilitaryInformation { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }
        public List<Test> Tests { get; set; }
    }
}
