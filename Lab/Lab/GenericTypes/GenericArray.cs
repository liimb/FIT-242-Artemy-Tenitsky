namespace Lab.GenericTypes;

public class GenericArray<T> where T : new()
{
    private T[] _array;
    private int _length;
    private int _countElements;
   
    public GenericArray(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        _array = new T[length];
        _length = length;
        _countElements = 0;
    }

    public void Add(T item)
    {
        if (_countElements >= _length)
        {
            ResizeArray();
        }
        
        _array[_countElements] = item;
        _countElements++;
    }

    private void ResizeArray()
    {
        int newLenth =  _array.Length * 2;
        T[] newArray = new T[newLenth];
        Array.Copy(_array, newArray, _countElements);
        _array = newArray;
    }
    
    public void Delete(int index)
    {
        if (index < 0 || index >= _countElements)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < _countElements - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _array[_countElements - 1] = default(T);
        _countElements--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _countElements)
        {
            throw new IndexOutOfRangeException();
        }

        return _array[index];
    }
}
