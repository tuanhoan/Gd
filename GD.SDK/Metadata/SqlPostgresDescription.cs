using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Metadata
{
    public class SqlPostgresDescription : IDbDescription
    {
        public ValueConverter DataVersionConVerter => new ValueConverter<Int64, byte[]>
            (
                v=>BitConverter.GetBytes(v),
                v=>BitConverter.ToInt64(v,0)
            );

        public string DbType => "RowVersion";

        public string SqlDefault => string.Empty;
    }
}
