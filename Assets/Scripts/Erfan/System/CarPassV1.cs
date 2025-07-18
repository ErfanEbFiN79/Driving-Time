using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarPassV1: MonoBehaviour
{
    #region README!

    /*
     * System control free and car pass rewards
     * it has 300 level and change each session
     * player can buy just once for all time and the name is VIP Pass or just for one session
     */

    #endregion

    #region Variables

    [Header("Base Setting")]
    //[SerializeField] private Slider progressSlider;
    [SerializeField] private TMP_Text progressText;
    private const string nameSaveLevel = "KDFSDJFHSJVBSVBJAKSBVDSBVJKDAV645V4Z6V5S";
    private int _currentLevel { get; set; }
    private CarPassTa carPass;
    
    [Header("Show Mission")]
    [SerializeField] private TMP_Text[] missionTexts;

    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        carPass = GetComponent<CarPassTa>();
        missionTexts[0].text = carPass.SendRandomLevel(CarPassTa.Level.Y1C1).description;
        missionTexts[1].text = carPass.SendRandomLevel(CarPassTa.Level.Y1C1).description;
        missionTexts[2].text = carPass.SendRandomLevel(CarPassTa.Level.Y1C1).description;
    }

    private void Start()
    {
        SetChanges(LoadData());
        carPass = GetComponent<CarPassTa>();
    }

    #endregion

    #region Helpers

    private int LoadData()
    {
        return PlayerPrefs.GetInt(nameSaveLevel);
    }

    private void SaveData(int level)
    {
        PlayerPrefs.SetInt(nameSaveLevel, PlayerPrefs.GetInt(nameSaveLevel) + level);
    }

    #endregion

    #region Get and send

    public void AddLevel(int level)
    { 
        SaveData(level);
        SetChanges(LoadData());
    }
    
    #endregion

    #region Manage

    private void SetChanges(int level)
    {
        //progressSlider.value = level;
        progressText.text = level.ToString();
    }

    #endregion
}
