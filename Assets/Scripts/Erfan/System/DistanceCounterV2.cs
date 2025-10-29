using System;
using TMPro;
using UnityEngine;

public class DistanceCounterV2 : MonoBehaviour
{
    #region Variables
    
    private CarControlV1 carControl;
    private StringSystemManager stringSystem;
    private float bestRecordOfLevel;
    
    private float distance;
    
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private int codeOfLevel;

    #endregion

    #region Unity Methods

    private void Start()
    {
        carControl = FindAnyObjectByType<CarControlV1>();
        stringSystem = FindAnyObjectByType<StringSystemManager>();
        bestRecordOfLevel = PlayerPrefs.GetFloat(stringSystem.DistanceLoadSaveString[codeOfLevel]);
        print(bestRecordOfLevel);
    }

    private void Update()
    {
        if (carControl.stateOfCar != CarControlV1.StateOfCar.Die)
        {
            distance += Time.deltaTime;
            ShowUi();
        }
        else
        {
            if (distance > bestRecordOfLevel)
            {
                PlayerPrefs.SetFloat(stringSystem.DistanceLoadSaveString[codeOfLevel], distance);
            }
          
        }
    }

    #endregion

    #region My Methods

    private void ShowUi()
    {
        distanceText.text = distance.ToString("F1");
    }

    #endregion
    
}
