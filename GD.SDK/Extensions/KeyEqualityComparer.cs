using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 
namespace GD.Extensions
{
    public class KeyEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> comparer;
        private readonly Func<T, object> keyExtractor;
 
        public KeyEqualityComparer(Func<T, object> keyExtractor) : this(keyExtractor, null) { }
        public KeyEqualityComparer(Func<T, T, bool> comparer) : this(null, comparer) { }
 
        public KeyEqualityComparer(Func<T, object> keyExtractor, Func<T, T, bool> comparer)
        {
            this.keyExtractor = keyExtractor;
            this.comparer = comparer;
        }
 
        public bool Equals(T x, T y)
        {
            if (comparer != null)
                return comparer(x, y);
            else
                return keyExtractor(x).Equals(keyExtractor(y));
        }
 
        public int GetHashCode(T obj)
        {
            if (keyExtractor == null)
                return obj.ToString().ToLower().GetHashCode();
            else
                return keyExtractor(obj).GetHashCode();
        }
    }
}