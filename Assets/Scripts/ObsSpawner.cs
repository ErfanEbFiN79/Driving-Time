using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    [SerializeField] string spawnpointTag = "Obs";
    [SerializeField] string spanPointTagMoving = "movingObs";
    [SerializeField] Transform[] SpanPointsArrayOnSection;
    [SerializeField] bool attackedToSection = false;




    private void Start()
    {
        if(TryGetComponent<FollowPlayer>(out FollowPlayer folloplayerCode))
        {
            attackedToSection = true;
        }
        else
        {
            attackedToSection = false;
        }
    }


    private void OnEnable()
    {
        if (attackedToSection &&  SpanPointsArrayOnSection.Length>=1)
        {
            foreach (Transform spanPoint in SpanPointsArrayOnSection)
            {
                GameObject temp = ObjectPooler.currentInstance.GiveMeAnObstacle(ObstacleType.stationary);
                temp.transform.position = spanPoint.position;
                temp.transform.rotation = Quaternion.identity;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(spawnpointTag)&& attackedToSection)
        {
            if (Random.Range(0f, 1f) > 0.5f)
            {
                return;
            }
            GameObject temp= ObjectPooler.currentInstance.GiveMeAnObstacle(ObstacleType.stationary);
            temp.transform.position = other.transform.position;
            temp.transform.rotation = other.transform.rotation;
            temp.SetActive(true);
        }
    }
}