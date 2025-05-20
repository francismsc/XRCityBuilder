using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;

    private GridSystem gridSystem;
    private GridDebugSystem gridDebugSystem;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new GridSystem(15, 15, 2f);
        gridDebugSystem = new GridDebugSystem(gridSystem);
        gridDebugSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddBlockAtGridPosition(GridPosition gridPosition, Block block)
    {
        if (!IsValidGridPosition(gridPosition)) return;

        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddBlock(block);
    }

    public List<Block> GetBlockListAtGridPosition(GridPosition gridPosition)
    {
        if (!IsValidGridPosition(gridPosition)) return null;
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetBlockList();
    }


    public void RemoveBlockAtGridPosition(GridPosition gridPosition, Block block)
    {
        if (!IsValidGridPosition(gridPosition)) return;
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveBlock(block);
    }

    public void SpawnBlockAtStartGridPosition(GameObject blockPrefab, GridPosition gridPosition)
    {

        Vector3 spawn = gridSystem.GetWorldPosition(gridPosition);
        Instantiate(blockPrefab, spawn, Quaternion.identity);

    }

    public void BlockedMovedOnGridPosition(Block block, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveBlockAtGridPosition(fromGridPosition, block);
        AddBlockAtGridPosition(toGridPosition, block);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public bool HasBlockOnGridPosition(GridPosition gridPosition)
    {
        if (!IsValidGridPosition(gridPosition)) return false;
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);

        return gridObject.HasAnyBlock();
    }

    public int GetGridWidth() => gridSystem.GetGridWidth();

    public int GetGridLenght() => gridSystem.GetGridLenght();

    public void ClearGridPosition(GridPosition gridPosition)
    {
        if (!IsValidGridPosition(gridPosition)) return;
        gridSystem.GetGridObject(gridPosition).GetBlockList().Clear();
    }

    public void MoveBlockOnGrid(GridPosition from, GridPosition to)
    {
        Block block = gridSystem.GetGridObject(from).GetBlockList()[0];
        block.MoveGridPosition(to);

    }

    public void DebugLogWholeGrid()
    {
        for (int x = 0; x < gridSystem.GetGridLenght(); x++)
        {
            for (int z = 0; z < gridSystem.GetGridWidth(); z++)
            {
                if (LevelGrid.Instance.HasBlockOnGridPosition(new GridPosition(z, x)) == true)
                {
                    Debug.Log(z + " " + x + ": Block");
                }
            }
        }


    }
}