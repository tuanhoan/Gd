using GD.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Models
{
    public interface IEntity
    {
        [Property(Required = false, Length = "50")]
        public string CreatedBy { get; set; }
        [Property(Required = false)]
        public DateTime? CreatedTime { get; set; }
        [Property(Required = false, Length = "50")]
        public string LastUpdatedBy { get; set; }
        [Property(Required = false)]
        public DateTime? LastUpdatedTime { get; set; }
        [Property(Required = true)]
        public bool Deleted { get; set; }
        // [Property(Required = true)]
        // public Int64 RowVersion { get; set; }
    }
}
