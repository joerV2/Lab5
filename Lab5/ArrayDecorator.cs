﻿//Декоратор
using System;

public class ArrayDecorator<T> where T : IComparable
{
    protected T[] _array;
    protected int _operatoinCount;

    
    public int CompareItems(T a, T b)
    {
        _operatoinCount++;

        return a.CompareTo(b);
    }

    public int Length
    {
        get { return _array.Length; }
    }

    public int OperatoinCount
    {
        get { return _operatoinCount; }
    }

    //Индексатор
    public T this[int index]
    {
        get
        {// чтение
            _operatoinCount++;
            return _array[index];
        }
        set
        { //запись
            _operatoinCount++;
            _array[index] = value;
        }
    }

    public ArrayDecorator(T[] array)
    {
        _array = array;
        _operatoinCount = 0;
    }

    public T[] GetSource()
    {
        return _array;
    }

    public void WrapFor(ArrayDecorator<T> another)
    { 
        _array = another.GetSource();
        _operatoinCount += another.OperatoinCount;
    }
}
