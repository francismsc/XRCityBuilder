using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private List<TrackNode> allNodes = new List<TrackNode>();

    public List<TrackNode> AllNodes => allNodes;

    public TrackNode GetStartingNode()
    {
        return allNodes != null && allNodes.Count > 0 ? allNodes[0] : null;
    }
}