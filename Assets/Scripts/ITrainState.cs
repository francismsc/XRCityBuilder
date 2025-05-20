using UnityEngine;

public interface ITrainState
{
    void Enter(Train train);

    void Update(Train train);

    void Exit(Train train);

}
