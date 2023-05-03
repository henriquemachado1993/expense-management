using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagement.Shared.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<Key, Value> MergeInPlace<Key, Value>(this Dictionary<Key, Value> left, Dictionary<Key, Value> right)
        {
            if (left == null)            
                return new Dictionary<Key, Value>();
            else if (right == null)            
                return left;            

            foreach (var kvp in right)
            {
                if (!left.ContainsKey(kvp.Key))
                {
                    left.Add(kvp.Key, kvp.Value);
                }
            }

            return left;
        }
    }
}
