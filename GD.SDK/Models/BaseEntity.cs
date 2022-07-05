using GD.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Models
{
    public class BaseEntity : IEntity, ICloneable
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
        // [Property(Required = true, RowVerion =true)]
        // public Int64 RowVersion { get; set; }
        public BaseEntity()
        {
            CreatedTime = DateTime.Now;
            LastUpdatedTime = DateTime.Now;
        }
        public virtual object Clone()
        {
            return new BaseEntity
            {
                CreatedBy = this.CreatedBy,
                CreatedTime = this.CreatedTime,
                LastUpdatedBy = this.LastUpdatedBy,
                LastUpdatedTime = this.LastUpdatedTime,
                Deleted = this.Deleted,
                // RowVersion = this.RowVersion
            };
        }
    }
}
