using System;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    #region Variables

    [Header("Sun Setting")]
    [SerializeField] private GameObject sun;
    [SerializeField] private float speedRotateX;
    [SerializeField] private float speedRotateY;

    #endregion

    #region Unity Methods

    private void Update()
    {
        SunRotate();
    }

    #endregion

    #region Actions

    private void SunRotate()
    {
        sun.gameObject.transform.Rotate(speedRotateX * Time.deltaTime,speedRotateY * Time.deltaTime,0);
    }

    #endregion
}
