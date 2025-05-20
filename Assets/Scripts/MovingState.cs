using UnityEngine;

public class MovingState : ITrainState
{
    public void Enter(Train train)
    {
        Debug.Log("Train started moving.");
    }

    public void Update(Train train)
    {
        train.MoveAlongTrack();
    }

    public void Exit(Train train)
    {
        Debug.Log("Train stopped moving.");
    }
}