using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridSystem
{
    private int width;
    private int lenght;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    public GridSystem(int width, int lenght, float cellSize)
    {
        this.width = width;
        this.lenght = lenght;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, lenght];

        for (int z = 0; z < width; z++)
        {
            for (int x = 0; x < lenght; x++)
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
                gridPosition.x < lenght;
    }

    public int GetGridWidth() => width;
    public int GetGridLenght() => lenght;
}
