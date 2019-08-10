namespace System.Collections.Generic
{
    public class OrderedSet<T> : ICollection<T>
    {
        private readonly IDictionary<T, LinkedListNode<T>> mDictionary;
        private readonly LinkedList<T> mLinkedList;

        public OrderedSet()
            : this(EqualityComparer<T>.Default)
        {
        }

        public OrderedSet(IEqualityComparer<T> comparer)
        {
            mDictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
            mLinkedList = new LinkedList<T>();
        }

        public OrderedSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            foreach (T item in collection)
            {
                Add(item);
            }
            mDictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
            mLinkedList = new LinkedList<T>();
        }

        public Int32 Count
        {
            get { return mDictionary.Count; }
        }

        public virtual Boolean IsReadOnly
        {
            get { return mDictionary.IsReadOnly; }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            mLinkedList.Clear();
            mDictionary.Clear();
        }

        public Boolean Remove(T item)
        {
            Boolean found = mDictionary.TryGetValue(item, out LinkedListNode<T> node);
            if (!found) return false;
            mDictionary.Remove(item);
            mLinkedList.Remove(node);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return mLinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Boolean Contains(T item)
        {
            return mDictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, Int32 arrayIndex)
        {
            mLinkedList.CopyTo(array, arrayIndex);
        }

        public Boolean Add(T item)
        {
            if (mDictionary.ContainsKey(item)) return false;
            LinkedListNode<T> node = mLinkedList.AddLast(item);
            mDictionary.Add(item, node);
            return true;
        }
    }
}
