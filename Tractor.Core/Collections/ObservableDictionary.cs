using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Tractor.Core.Collections
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyPropertyChanging, INotifyCollectionChanged
    {
        private readonly Dictionary<TKey, TValue> _Store;

        public event PropertyChangingEventHandler PropertyChanging;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;
        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

        public TValue this[TKey key]
        {
            get => _Store[key];
            set
            {
                bool replace = _Store.TryGetValue(key, out TValue _value);
                if (!replace || !Equals(_value, value))
                {
                    PropertyChanging?.Invoke(this, null);
                    _Store[key] = value;
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(replace ? NotifyCollectionChangedAction.Replace : NotifyCollectionChangedAction.Add, key));
                }
            }
        }
        public Dictionary<TKey, TValue>.KeyCollection Keys => _Store.Keys;
        public Dictionary<TKey, TValue>.ValueCollection Values => _Store.Values;
        public int Count => _Store.Count;
        public bool IsReadOnly => ((IDictionary<TKey, TValue>)_Store).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            //Проверяем, что не произойдёт ArgumentException после вызова метода Add
            if (!_Store.ContainsKey(key))
            {
                PropertyChanging?.Invoke(this, null);
            }
            _Store.Add(key, value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, key));
        }

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            PropertyChanging?.Invoke(this, null);
            _Store.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)_Store).Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return _Store.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)_Store).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)_Store).GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            PropertyChanging?.Invoke(this, null);
            bool result = _Store.Remove(key);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, key));
            return result;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _Store.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)_Store).GetEnumerator();
        }
    }
}
