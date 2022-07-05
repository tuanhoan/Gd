using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.StudentTest")]
    public partial class StudentTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? Test { get; set; }
        public int? Choice { get; set; }

        public Test Tests { get; set; }
        public QuestionChoice QuestionChoices { get; set; }
    }
}
