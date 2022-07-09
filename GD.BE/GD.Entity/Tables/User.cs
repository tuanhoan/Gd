using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("User")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? status { get; set; }
        public int? information { get; set; }
        public Guid? UniqueId { get; set; }
        public bool Active { get; set; }
        public MilitaryInformation MilitaryInformation { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
