using System.Collections.Generic;
using UnityEngine;

public class TrackNode : MonoBehaviour
{
    [Tooltip("Nodes connected going forward from this node.")]
    public List<TrackNode> forwardConnectedNodes = new List<TrackNode>();

    [Tooltip("Nodes connected going reverse from this node.")]
    public List<TrackNode> reverseConnectedNodes = new List<TrackNode>();


    private int currentForwardIndex = 0;
    private int currentReverseIndex = 0;

    /// <summary>
    /// Gets the next node depending on direction.
    /// </summary>
    public TrackNode GetNextNode(bool isMovingForward)
    {
        if (isMovingForward)
        {
            if (forwardConnectedNodes.Count == 0) return null;
            return forwardConnectedNodes[currentForwardIndex];
        }
        else
        {
            if (reverseConnectedNodes.Count == 0) return null;
            return reverseConnectedNodes[currentReverseIndex];
        }
    }

    /// <summary>
    /// Cycles the next node in the current direction.
    /// </summary>
    public void SwitchNextNode(bool isMovingForward)
    {
        if (isMovingForward)
        {
            if (forwardConnectedNodes.Count == 0) return;
            currentForwardIndex = (currentForwardIndex + 1) % forwardConnectedNodes.Count;
        }
        else
        {
            if (reverseConnectedNodes.Count == 0) return;
            currentReverseIndex = (currentReverseIndex + 1) % reverseConnectedNodes.Count;
        }
    }

    /// <summary>
    /// Returns the world position of this node.
    /// </summary>
    public Vector3 GetNodeTransformPosition()
    {
        return transform.position;
    }

    // Draw gizmos in the Scene view for visualization
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the node position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.3f);

        // Draw lines to forward connected nodes in blue
        Gizmos.color = Color.blue;
        foreach (var node in forwardConnectedNodes)
        {
            if (node != null)
                Gizmos.DrawLine(transform.position, node.transform.position);
        }

        // Draw lines to reverse connected nodes in red
        Gizmos.color = Color.red;
        foreach (var node in reverseConnectedNodes)
        {
            if (node != null)
                Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}