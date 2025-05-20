using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Track track;

    [SerializeField] private bool isMovingForward = true; // Track current direction

    public TrainStateMachine stateMachine;

    private TrackNode currentNode;
    private TrackNode nextNode;

    private void Awake()
    {
        stateMachine = new TrainStateMachine();
        stateMachine.SetTrain(this);
    }

    private void Start()
    {
        currentNode = track.GetStartingNode();
        nextNode = currentNode?.GetNextNode(isMovingForward);

        stateMachine.Initialize(new MovingState(), this);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void MoveAlongTrack()
    {
        if (currentNode == null || nextNode == null) return;

        Vector3 target = nextNode.GetNodeTransformPosition();

        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Rotate smoothly toward the direction of movement
        Vector3 direction = (target - transform.position).normalized;
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion lookRotation;
            if (!isMovingForward)
                lookRotation = Quaternion.LookRotation(-direction); // Use backside
            else
                lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if reached the node
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentNode = nextNode;
            nextNode = currentNode.GetNextNode(isMovingForward);

            if (nextNode == null)
            {
                Debug.Log("Dead end reached.");
                stateMachine.ChangeState(new StoppedState());
            }
        }
    }


    public void ReverseDirection()
    {
        isMovingForward = !isMovingForward;
        nextNode = currentNode.GetNextNode(isMovingForward);

        Debug.Log("Train reversed direction.");
    }

    public bool IsAtEndOfTrack()
    {
        return nextNode == null;
    }

    /// <summary>
    /// Starts the train moving forward.
    /// </summary>
    public void StartForward()
    {
            isMovingForward = true;
            nextNode = currentNode.GetNextNode(isMovingForward);
            stateMachine.ChangeState(new MovingState());
            Debug.Log("Train started moving in reverse.");
    }

    /// <summary>
    /// Starts the train moving in reverse.
    /// </summary>
    public void StartReverse()
    {
            isMovingForward = false;
            nextNode = currentNode.GetNextNode(isMovingForward);
            stateMachine.ChangeState(new MovingState());
            Debug.Log("Train started moving in reverse.");
    }
}