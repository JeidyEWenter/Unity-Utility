using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationList<T> : List<T>
{
    private int _currentIndex = 0;
    public int CurrentIndex
    {
        get
        {
            if (_currentIndex > Count - 1) { _currentIndex = Count - 1; }
            if (_currentIndex < 0) { _currentIndex = 0; }
            return _currentIndex;
        }
        set { _currentIndex = value; }
    }

    public T Next
    {
        get { _currentIndex++; return this[CurrentIndex]; }
    }

    public T Prev
    {
        get { _currentIndex--; return this[CurrentIndex]; }
    }

    public T Current
    {
        get { return this[CurrentIndex]; }
    }

    public T FindNext(Predicate<T> predicate)
    {
        try
        {
            _currentIndex = FindIndex(predicate);
        }
        catch (System.Exception e)
        {
            Debug.Log($"VehiclePack 에 해당 데이터가 없음 : {e}");
        }

        return Next;
    }

    public T FindPrev(Predicate<T> predicate)
    {
        try
        {
            _currentIndex = FindIndex(predicate);
        }
        catch (System.Exception e)
        {
            Debug.Log($"VehiclePack 에 해당 데이터가 없음 : {e}");
        }

        return Prev;
    }
}
