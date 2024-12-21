using System;

public class CustomList<T>
{
    private T[] _items;
    private int _count;
    private const int _initialCapacity = 4;

    public CustomList()
    {
        _items = new T[_initialCapacity];
        _count = 0;
    }

    public int Count => _count;

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }
        return _items[index];
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[--_count] = default; // Clear the last item
    }

    public void Clear()
    {
        _items = new T[_initialCapacity];
        _count = 0;
    }

    private void Resize()
    {
        int newCapacity = _items.Length * 2;
        T[] newItems = new T[newCapacity];
        Array.Copy(_items, newItems, _count);
        _items = newItems;
    }

    public T this[int index]
    {
        get => Get(index);
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
            _items[index] = value;
        }
    }
}
