using System.Collections.Generic;

namespace NeoDefenderEngine
{
    public static class DictionaryExtension
    {
        public static T2 Get<T1, T2>(this Dictionary<T1, T2> dict, T1 val) => dict.ContainsKey(val) ? dict[val] : default;
    }
}