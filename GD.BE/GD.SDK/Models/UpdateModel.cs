using System;
using System.Collections.Generic;
using System.Text;

namespace GD.SDK.Models
{
    public class UpdateModel<TEntity> : CreateModel<TEntity> 
        where TEntity: class
    {
        public TEntity OldEntity { get; set; }
    }
}
