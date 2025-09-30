using System;
using UnityEngine;

public class RoadMoveSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float speedRoad { get; private set; }
    
    public void Update()
    {
        speedRoad = moveSpeed;
        transform.Translate(0,speedRoad * Time.deltaTime,0);
    }
}
