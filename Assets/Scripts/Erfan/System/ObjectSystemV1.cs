using UnityEngine;

public class ObjectSystemV1 : MonoBehaviour
{
    private enum State
    {
        X,
        Y,
        Z
    }
    
    [SerializeField] private State _state;
    private RoadMoveSystem roadMoveSystem;
    private float speed;
    
    private void Start()
    {
        gameObject.tag = "Obstacle";
        roadMoveSystem = FindFirstObjectByType<RoadMoveSystem>();
    }

    private void Update()
    {
        speed = roadMoveSystem.speedRoad;
        switch (_state)
        {
            case State.X:
                transform.Translate(speed * Time.deltaTime,0,0); break;
            
            case State.Y:
                transform.Translate(0,speed * Time.deltaTime,0); break;
            
            case State.Z:
                transform.Translate(0,0,speed * Time.deltaTime); break;
        }

    }
}
