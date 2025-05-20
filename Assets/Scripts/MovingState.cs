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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            train.SwitchBifurcation();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            train.ReverseDirection();
        }
    }

    public void Exit(Train train)
    {
        Debug.Log("Train stopped moving.");
    }
}