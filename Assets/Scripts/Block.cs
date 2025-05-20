using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Represents a block object that can be grabbed and moved within a grid system using XR interactions.
/// </summary>
public class Block : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private GridPosition gridPosition;

    private GridPosition newGridPosition;
    private XRInteractionManager interactionManager;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddBlockAtGridPosition(gridPosition, this);
        interactionManager = GameObject.Find("XR Interaction Manager")?.GetComponent<XRInteractionManager>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }


    private void OnRelease(SelectExitEventArgs args)
    {

        Debug.Log("Release");
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (!LevelGrid.Instance.IsValidGridPosition(newGridPosition))
        {
            Debug.Log("Outside Array");
            return;
        }
            MoveGridPosition(newGridPosition);
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public void SetGridPosition(GridPosition newGridPosition)
    {
        gridPosition = newGridPosition;
    }

    public void MoveGridPosition(GridPosition to)
    {
        LevelGrid.Instance.BlockedMovedOnGridPosition(this, this.gridPosition, to);
        this.gridPosition = to;
        this.transform.position = LevelGrid.Instance.GetWorldPosition(to);
        Debug.Log(this.transform.position);

    }
}
