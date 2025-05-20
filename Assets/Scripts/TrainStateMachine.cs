public class TrainStateMachine
{
    private ITrainState currentState;
    private Train train;

    public void SetTrain(Train train)
    {
        this.train = train;
    }

    public void Initialize(ITrainState startingState, Train train)
    {
        currentState = startingState;
        currentState.Enter(train);
    }

    public void ChangeState(ITrainState newState)
    {
        currentState?.Exit(train);
        currentState = newState;
        currentState.Enter(train);
    }

    public void Update()
    {
        currentState?.Update(train);
    }

    public ITrainState CurrentState()
    {
        return currentState;
    }
}
