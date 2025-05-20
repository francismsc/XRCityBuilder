using UnityEngine;

public class StoppedState : ITrainState
{
    private float stopDuration = 1f;
    private float timer = 0f;

    public void Enter(Train train)
    {
        Debug.Log("Train is stopped.");
        timer = 0f;
    }

    public void Update(Train train)
    {
        timer += Time.deltaTime;
        if (timer >= stopDuration)
        {
            train.stateMachine.ChangeState(new MovingState());
        }
    }

    public void Exit(Train train)
    {
        Debug.Log("Train starting again.");
    }
}