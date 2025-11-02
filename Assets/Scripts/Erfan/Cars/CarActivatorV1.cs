using System;
using UnityEngine;

public class CarActivatorV1 : MonoBehaviour
{
    #region Variables

    [Header("Settings")]
    [SerializeField] private SessionDataSObase getData;

    [Header("Cars")]
    [SerializeField] private GameObject[] cars;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        foreach (GameObject car in cars)
        {
            car.SetActive(false);
        }
        
        cars[getData.codeCar].SetActive(true);
    }

    #endregion
}
