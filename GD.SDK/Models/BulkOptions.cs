using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Models
{
    public class BulkOptions
    {
        public bool SetOutputIdentity { get; set; } = false;
        public int BatchSize { get; set; } = 2000;
        public bool EnableStreaming { get; set; } = false;
        public bool UseTempDB { get; set; } = true;
        public bool TrackingEntities { get; set; } = false;
        public int BulkCopyOptions { get; set; } = 0;
        public List<string> KeyProperties { get; set; }
        public List<string> SkipUpdateProperties { get; set; }
    }
}
