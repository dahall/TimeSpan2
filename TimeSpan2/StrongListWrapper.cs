using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
	public class StrongListWrapper<T> : IList<T>, ICollection<T>, IEnumerable<T> //, IList, ICollection, IEnumerable
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
			private IEnumerator iEnum;

			internal StrongListWrapperEnumerator(IEnumerator ienum)
			{
				iEnum = ienum;
			}

			public T Current
			{
				get { return (T)iEnum.Current; }
			}

			public void Dispose()
			{
				Reset();
				iEnum = null;
			}

			object IEnumerator.Current
			{
				get { return this.Current; }
			}

			public bool MoveNext()
			{
				return iEnum.MoveNext();
			}

			public void Reset()
			{
				iEnum.Reset();
			}
		}

		/*
		int Add(object value)
		{
			return Add(value);
		}

		bool Contains(object value)
		{
			return Contains(value);
		}

		int IndexOf(object value)
		{
			return IndexOf(value);
		}

		void Insert(int index, object value)
		{
			Insert(index, value);
		}

		bool IsFixedSize
		{
			get { return list.IsFixedSize; }
		}

		void Remove(object value)
		{
			Remove(value);
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (T)value;
			}
		}

		void CopyTo(Array array, int index)
		{
			CopyTo(array, index);
		}

		bool IsSynchronized
		{
			get { return list.IsSynchronized; }
		}

		object SyncRoot
		{
			get { return list.SyncRoot; }
		}
		*/ 
	}
}
