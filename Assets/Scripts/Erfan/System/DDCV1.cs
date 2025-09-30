using System;
using UnityEngine;

public class DDCV1 : MonoBehaviour
{
    // DDC: Detect, Destroy, Create

    #region Variables

    [SerializeField] private RoadsSystemV1 roadsSystem;
    [SerializeField] private string tagWork;

    #endregion

    #region Unity Functions

    private void Start()
    {
        roadsSystem = GameObject.FindFirstObjectByType<RoadsSystemV1>();
    }

    #endregion

    #region Detect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagWork))
        {
            roadsSystem.CreateRoad();
            Destroy(other.gameObject);
        }
    }

    #endregion
}
