using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Represents a 2D grid system for managing grid positions and their corresponding GridObjects.
/// </summary>
public class GridSystem
{
    private int width;
    private int length;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    public GridSystem(int width, int length, float cellSize)
    {
        this.width = width;
        this.length = length;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, length];

        for (int z = 0; z < width; z++)
        {
            for (int x = 0; x < length; x++)
            {
                GridPosition gridPosition = new GridPosition(z, x);
                gridObjectArray[z, x] = new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.z / cellSize),
            Mathf.RoundToInt(worldPosition.x / cellSize)
            );
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        if (!IsValidGridPosition(gridPosition)) return null;
        return gridObjectArray[gridPosition.z, gridPosition.x];
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.z >= 0 &&
                gridPosition.x >= 0 &&
                gridPosition.z < width &&
                gridPosition.x < length;
    }

    public int GetGridWidth() => width;
    public int GetGridLenght() => length;
}
