using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.Class")]
    public partial class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? TeacherInfo { get; set; }
        [MaxLength(50)]
        public string ClassName { get; set; }
        [MaxLength(20)]
        public string SchoolYear { get; set; }
        public Guid? UniqueId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public MilitaryInformation MilitaryInformation { get; set; }
    }
}
