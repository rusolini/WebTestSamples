using System.Collections.Generic;

namespace WebTestSamples
{
    public class FixedSizedQueue<T> : Queue<T>
    {
        public FixedSizedQueue(int size, T firstAddition)
        {
            Size = size;
            Enqueue(firstAddition);
        }

        public int Size { get; private set; }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            while (Count > Size)
            {
                TryDequeue(out T outObj);
            }
        }
    }
}
