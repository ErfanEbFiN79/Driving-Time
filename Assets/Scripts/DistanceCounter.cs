using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    float lastPositionOnZ, currentPositionOnZ;
    [SerializeField] ulong  longestRunCurrent;
    [SerializeField] ulong  longestRunRecord;
    [SerializeField] float intervalsBetweenCheck = 10f;
    [SerializeField] private int codeOfLevel;

    // Start is called before the first frame update
    void Start()
    {
        longestRunCurrent = 0;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentPositionOnZ = _playerTransform.position.z;
        lastPositionOnZ = _playerTransform.position.z;
        InvokeRepeating(nameof(CheckDistance), 1f, intervalsBetweenCheck);
        if (StringSystemManager.currentInstance != null)
        {
            string bestRunstring = PlayerPrefs.GetString(StringSystemManager.currentInstance.DistanceLoadSaveString[codeOfLevel], "0");
            if (ulong.TryParse(bestRunstring, out longestRunRecord))
            {
                Debug.Log("load succesfully"+ "best Run was : "+longestRunRecord);
            }
            else
            {
                Debug.Log("loading best run fialed");
            }
        }
        else
        {
            Debug.Log("no string system manager is found in the scene");
        }
       
    }

    

    public void CheckDistance()
    {
        currentPositionOnZ = _playerTransform.position.z;
        if(currentPositionOnZ > lastPositionOnZ)
        {
            longestRunCurrent += (ulong)(currentPositionOnZ - lastPositionOnZ);
            //Debug.Log($"curren Z={currentPositionOnZ}  last Z ={lastPositionOnZ}  current longestRun{longestRunCurrent}  longest run ever{longestRunRecord}");
            lastPositionOnZ = currentPositionOnZ;
        }
        else
        {
            lastPositionOnZ = currentPositionOnZ;
        }
        SaveLongestdistanceSoFar();
    }



    public void SaveLongestdistanceSoFar()
    {
        if(longestRunCurrent> longestRunRecord)
        {
            longestRunRecord = longestRunCurrent;
        }
        if (StringSystemManager.currentInstance != null)
        {
            PlayerPrefs.SetString(StringSystemManager.currentInstance.DistanceLoadSaveString[codeOfLevel], longestRunRecord.ToString());
            PlayerPrefs.Save();

        }
    }

    public void OnPlayerDeathEventRaiesd()
    {
        StopCheckingDistance();
        SaveLongestdistanceSoFar();
    }

    public void OnPauseTheGameEventRaised()
    {
        StopCheckingDistance();
    }
    public void StopCheckingDistance()
    {
        CancelInvoke(nameof(CheckDistance));
    }

    public void ResumeCheckingdistance()
    {
        CancelInvoke(nameof(CheckDistance));
        InvokeRepeating(nameof(CheckDistance), 0, intervalsBetweenCheck);
    }
    public void ResumeCheckingDistanceAfterDeath()
    {
        longestRunCurrent = 0;
        lastPositionOnZ = _playerTransform.position.z;
        currentPositionOnZ = _playerTransform.position.z;
        //InvokeRepeating(nameof(CheckDistance), 0, intervalsBetweenCheck);
        ResumeCheckingdistance();
    }
}
