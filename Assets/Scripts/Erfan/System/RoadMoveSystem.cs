using System;
using UnityEngine;

public class RoadMoveSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float speedRoad { get; private set; }

    [SerializeField] private float distanceDeleteObject;
    
    [SerializeField] private float distanceOfPlayer;
    [SerializeField] private Transform player;
    [SerializeField] private RoadsSystemV1 roadsSystem;
    
    private void Start()
    {
        roadsSystem = GameObject.FindFirstObjectByType<RoadsSystemV1>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Update()
    {
        
        distanceOfPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceDeleteObject > distanceOfPlayer)
        {
            roadsSystem.CreateRoad();
            Destroy(this.gameObject);
        }
        
        speedRoad = FindFirstObjectByType<GameDifficultyManagerV1>().SpeedOfGame;
        transform.Translate(0,speedRoad * Time.deltaTime,0);
    }
}
