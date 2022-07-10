using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            this.Tests = new List<Test>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? Class { get; set; }
        [MaxLength(10)]
        public string StudentCode { get; set; }
        [ForeignKey("MilitaryInformation")]
        public int? MilitaryInformationFId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public MilitaryInformation MilitaryInformation { get; set; }
        public List<Test> Tests { get; set; }
    }
}
