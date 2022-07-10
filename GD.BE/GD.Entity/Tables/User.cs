using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.User")]
    public partial class User
    {
        public User()
        {
            this.RefreshTokens = new List<RefreshToken>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string PasswordHash { get; set; }
        public DateTime CreateDate { get; set; }
        public int? status { get; set; }
        public int? MilitaryInformationFId { get; set; }
        public Guid? UniqueId { get; set; }
        [MaxLength(225)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string PasswordSalt { get; set; }
        public bool? Active { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public MilitaryInformation MilitaryInformation { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
