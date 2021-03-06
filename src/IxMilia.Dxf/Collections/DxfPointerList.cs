﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IxMilia.Dxf.Collections
{
    internal class DxfPointerList<TItem> : IList<TItem> where TItem : IDxfItem
    {
        private List<DxfPointer> _items = new List<DxfPointer>();

        internal IList<DxfPointer> Pointers => _items;

        public TItem this[int index]
        {
            get { return (TItem)_items[index].Item; }
            set { _items[index].Item = value; }
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public void Add(TItem item) => _items.Add(new DxfPointer(item));

        public void Clear() => _items.Clear();

        public bool Contains(TItem item) => GetItems().Contains(item);

        public void CopyTo(TItem[] array, int arrayIndex) => GetItems().ToList().CopyTo(array, arrayIndex);

        public IEnumerator<TItem> GetEnumerator() => GetItems().GetEnumerator();

        public int IndexOf(TItem item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (item.Equals(_items[i].Item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, TItem item) => _items.Insert(index, new DxfPointer(item));

        public bool Remove(TItem item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (item.Equals(_items[i].Item))
                {
                    _items.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index) => _items.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<TItem> GetItems() => _items.Select(i => (TItem)i.Item);
    }
}
