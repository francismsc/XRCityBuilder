using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPosition
{
    public int x;
    public int z;


    public GridPosition(int z, int x)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "z: " + z + "; y:" + x;
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.z == b.z && a.x == b.x;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.z + b.z, a.x + b.x);
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.z - b.z, a.x - b.x);
    }



}
