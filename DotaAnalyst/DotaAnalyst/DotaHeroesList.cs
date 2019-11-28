using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DotaAnalyst
{
    public class DotaHeroesList : IDictionary<string, DotaHero>
    {
        private SortedDictionary<string, DotaHero> dictionary_;
        public DotaHeroesList()
        {
           dictionary_ = new SortedDictionary<string, DotaHero>();
        }
        public ICollection<string> Keys => ((IDictionary<string, DotaHero>)dictionary_).Keys;

        public ICollection<DotaHero> Values => ((IDictionary<string, DotaHero>)dictionary_).Values;

        public int Count => ((IDictionary<string, DotaHero>)dictionary_).Count;

        public bool IsReadOnly => ((IDictionary<string, DotaHero>)dictionary_).IsReadOnly;

        public DotaHero this[string key] { get => ((IDictionary<string, DotaHero>)dictionary_)[key]; set => ((IDictionary<string, DotaHero>)dictionary_)[key] = value; }

        public void Add(string key, DotaHero value)
        {
            ((IDictionary<string, DotaHero>)dictionary_).Add(key, value);
        }
        
        public bool TryGetValue(string key, out DotaHero value)
        {
            return ((IDictionary<string, DotaHero>)dictionary_).TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, DotaHero> item)
        {
            ((IDictionary<string, DotaHero>)dictionary_).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<string, DotaHero>)dictionary_).Clear();
        }

        public bool Contains(KeyValuePair<string, DotaHero> item)
        {
            return ((IDictionary<string, DotaHero>)dictionary_).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, DotaHero>[] array, int arrayIndex)
        {
            ((IDictionary<string, DotaHero>)dictionary_).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, DotaHero> item)
        {
            return ((IDictionary<string, DotaHero>)dictionary_).Remove(item);
        }

        public IEnumerator<KeyValuePair<string, DotaHero>> GetEnumerator()
        {
            return ((IDictionary<string, DotaHero>)dictionary_).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<string, DotaHero>)dictionary_).GetEnumerator();
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, DotaHero>)dictionary_).ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, DotaHero>)dictionary_).Remove(key);
        }

    }
}
