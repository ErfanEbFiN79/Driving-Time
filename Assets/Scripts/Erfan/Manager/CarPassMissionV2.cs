using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarPassMissionV2 : MonoBehaviour
{
    /*
     * Get Active mission and give them to system 
     */
    #region Variables

    [Header("References")]
    [SerializeField] private Mission2[] missions;
    private List<Mission2> _missionsActiveList;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        MarkMissionsAreDone();
        GetActiveMissions();
    }

    #endregion

    #region Our Methods

    private void MarkMissionsAreDone()
    {
        foreach (Mission2 mission2 in missions)
        {
            mission2.active = false;
        }
        
        foreach (Mission2 mission in missions)
        {
            if (PlayerPrefs.GetInt(mission.codeNeedCheck) == 1)
            {
                mission.isDone = true;
            }
        }
    }

    private void GetActiveMissions()
    {
        foreach (Mission2 mission in missions)
        {
            if (!mission.isDone)
            {
                _missionsActiveList.Add(mission);
            }
        }
    }

    public Mission2 SendMission()
    {
        return _missionsActiveList[Random.Range(0, _missionsActiveList.Count)];
    }

    #endregion
}
