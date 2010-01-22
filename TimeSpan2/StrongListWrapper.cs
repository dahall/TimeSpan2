namespace System.Collections.Generic
{
	public class StrongListWrapper<T> : IList<T>
	{
		private IList list;

		public StrongListWrapper(IList baseList)
		{
			list = baseList;
		}

		public IList Core { get { return list; } }

		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			list.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public T this[int index]
		{
			get
			{
				return (T)list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		public void AddRange(T[] items)
		{
			for (int i = 0; i < items.Length; i++)
				list.Add(items[i]);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return list.Count; }
		}

		public bool IsReadOnly
		{
			get { return list.IsReadOnly; }
		}

		public bool Remove(T item)
		{
			return Remove(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new StrongListWrapperEnumerator<T>(list.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public class StrongListWrapperEnumerator<T> : IEnumerator<T>
		{
			private IEnumerator _iEnum;

			internal StrongListWrapperEnumerator(IEnumerator ienum)
			{
				_iEnum = ienum;
			}

			public T Current
			{
				get { return (T)_iEnum.Current; }
			}

			public void Dispose()
			{
				Reset();
				_iEnum = null;
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public bool MoveNext()
			{
				return _iEnum.MoveNext();
			}

			public void Reset()
			{
				_iEnum.Reset();
			}
		}
	}
}
