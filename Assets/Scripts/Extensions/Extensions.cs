using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    public static T removeAt<T>(this List<T> list, int index)
    {
        T temp = list[index];
        list.RemoveAt(index);
        return temp;
    }

}
