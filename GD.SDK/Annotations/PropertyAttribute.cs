using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Annotations
{
    public class PropertyAttribute: Attribute
    {
        public bool Required { get; set; }
        public string Length { get; set; }
        public bool Identity { get; set; }
        public bool AutoGen { get; set; }
        public bool Primary { get; set; }
        public bool RowVerion { get; set; }
        public string DBType { get; set; }
        public bool ConcurrencyToken { get; set; }
        public bool View { get; set; }
        public string SearchType { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
    }
}
