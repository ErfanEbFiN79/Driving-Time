using TMPro;
using UnityEngine;

public class CarPassV2 : MonoBehaviour
{
    #region Variables

    [Header("Base Setting")]
    [SerializeField] private TMP_Text[] missionText;
    [SerializeField] private Mission2[] missionsAreActive;
    [SerializeField] private CarPassMissionV2 getMission;

    private const string codeCheckWeekMission = "fbhsagfhfjhjfkshgfgkjkuksbvhbesfkbsfjvaegouv";
    private const string codeCheckDayMission = "fsajdyrosgfjrofdkfhfks5785fgssgckgfksgchjshc";
    
    private int currentOurLevel { get; set; }
    
    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        GetActiveMissions();
        LoadUi();
    } 

    #endregion
    
    #region Methods

    private void GetActiveMissions()
    {
        // Week missions
        missionsAreActive[0] = getMission.SendMission();
        missionsAreActive[1] = getMission.SendMission();
        missionsAreActive[2] = getMission.SendMission();
        
        // Day missions
        missionsAreActive[3] = getMission.SendMission();

        foreach (Mission2 mission in missionsAreActive)
        {
            mission.active = true;
        }
    }

    private void LoadUi()
    {
        for (int i = 0; i < missionText.Length; i++)
        {
            missionText[i].text = missionsAreActive[i].description;
        }
    }

    private void CheckDone()
    {
        foreach (Mission2 mission2 in missionsAreActive)
        {
            if (PlayerPrefs.GetInt(mission2.codeNeedCheck) == 1)
            {
                mission2.isDone = true;
                
            }
        }
    }
    
    #endregion
    
    


}
