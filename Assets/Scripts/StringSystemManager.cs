using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSystemManager : MonoBehaviour
{
    public static StringSystemManager currentInstance;
    #region constant strings
    [Space]
    [Header("strings constance")]
    public  string[] DistanceLoadSaveString;
    #endregion



    private void Awake()
    {
        if(currentInstance==null)
        {
            currentInstance = this;
        }
        else
        {
            if (currentInstance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
