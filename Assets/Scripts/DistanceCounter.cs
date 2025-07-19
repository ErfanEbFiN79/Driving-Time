using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    float lastPositionOnZ, currentPositionOnZ;
    [SerializeField] float longestRunCurrent;
    [SerializeField] float longestRunRecord;
    [SerializeField] float intervalsBetweenCheck = 10f;

    // Start is called before the first frame update
    void Start()
    {
        longestRunCurrent = 0f;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentPositionOnZ = _playerTransform.position.z;
        lastPositionOnZ = _playerTransform.position.z;
        InvokeRepeating(nameof(CheckDistance), 1f, intervalsBetweenCheck);
    }

    

    public void CheckDistance()
    {
        currentPositionOnZ = _playerTransform.position.z;
        if(currentPositionOnZ > lastPositionOnZ)
        {
            longestRunCurrent += (currentPositionOnZ - lastPositionOnZ);
            Debug.Log($"curren Z={currentPositionOnZ}  last Z ={lastPositionOnZ}  current longestRun{longestRunCurrent}  longest run ever{longestRunRecord}");
            lastPositionOnZ = currentPositionOnZ;
        }
        else
        {
            lastPositionOnZ = currentPositionOnZ;
        }
    }
    public void StopCheckingDistance()
    {
        CancelInvoke(nameof(CheckDistance));
    }
    public void ResumeCheckingDistance()
    {
        InvokeRepeating(nameof(CheckDistance), 0, intervalsBetweenCheck);
    }
}