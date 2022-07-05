using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("MilitaryInformation")]
    public partial class MilitaryInformation
    {
        public MilitaryInformation()
        {
            this.Users = new List<User>();
            this.Classes = new List<Class>();
            this.Exams = new List<Exam>();
            this.Students = new List<Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MilitaryLevel { get; set; }
        [MaxLength(50)]
        public string MilitaryPosition { get; set; }
        [MaxLength(50)]
        public string WorkUnit { get; set; }
        [MaxLength(50)]
        public string Image { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public Guid? UniqueId { get; set; }

        public List<User> Users { get; set; }
        public List<Class> Classes { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Student> Students { get; set; }
    }
}
