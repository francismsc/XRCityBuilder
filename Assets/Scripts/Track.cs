using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private List<TrackNode> allNodes = new List<TrackNode>();

    public List<TrackNode> AllNodes => allNodes;

    public TrackNode GetStartingNode()
    {
        if (allNodes != null)
        {
            if (allNodes.Count > 0)
            {
                return allNodes[0];
            }
        }

        return null;
    }
}