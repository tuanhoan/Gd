using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Entity.Tables
{
    [Table("luongSA.RefreshToken")]
    public partial class RefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(1000)]
        public string TokenHash { get; set; }
        [MaxLength(1000)]
        public string TokenSalt { get; set; }
        public DateTime TS { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
