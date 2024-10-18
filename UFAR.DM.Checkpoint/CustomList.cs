using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFAR.DM.Checkpoint {
    public class CustomList<T> {
        private T[] values;
        private int size = 5;
        private int lastIndex;

        public CustomList() { 
            values = new T[size];
            lastIndex = 0;
        }

        public void Add(T item) {
            if (values.Length == lastIndex)
            {
                ResizeArray(true);
            } 

            values[lastIndex] = item;
            lastIndex++;
        }

        public void Remove(T value) {
            if (value == null)
            {
                return;
            }
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null)
                {
                    return;
                }
                else if (values[i].Equals(value))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index) {
            if (index >= lastIndex)
            {
                throw new Exception("Index is out of range");
            }

            for (int i = index; i < values.Length - 1; i++) {
                values[i] = values[i + 1];
            }
            lastIndex--;
            values[lastIndex] = default;
            


            if (size - lastIndex == 5)
            {
                ResizeArray(false);
            }
        }

        private void ResizeArray(bool bigger) {
            if (bigger)
            {
                size += 5;
                Array.Resize(ref values, size);
            } else {
                size -= 5;
                Array.Resize(ref values, size);
            }
        }

        public int Count() {
            return values.Length;
        }

        public void Clear() {
            values = new T[0];
            size = 0;
            lastIndex = 0;
        }

        public bool Contains(T value) {
            foreach (var item in values)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
