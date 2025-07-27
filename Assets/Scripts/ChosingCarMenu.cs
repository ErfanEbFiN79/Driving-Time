using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ChosingCarMenu : MonoBehaviour
{
    
    [SerializeField] Transform carPlatform,carPoint;
    [SerializeField]float platformrotationSpeed = 10f;
    [SerializeField] UnlockablesData_01[] unlockablesarray;
    [SerializeField] List<UnlockablesData_01> carlist, skyboxlist;
    [SerializeField] TMP_Text carText;
    [SerializeField] SessionDataSObase sessionData;
    [SerializeField] int carListIndex = 0;
    [SerializeField] GameObject carPlaceHolder;
    [SerializeField] ulong playerRecord;

    private void Awake()
    {
        carlist = new List<UnlockablesData_01>();
        skyboxlist = new List<UnlockablesData_01>();

    }

    void Start()
    {
        if (carPlatform != null && carPoint != null)
        {
            carPoint.transform.SetParent(carPlatform);
            
        }
        if (unlockablesarray.Length > 0)
        {
            foreach (UnlockablesData_01 item in unlockablesarray)
            {
                switch (item.type)
                {
                    case UnlockableType.car:
                        {
                            carlist.Add(item);
                            break;
                        }
                    case UnlockableType.level:
                        {
                            break;
                        }
                        
                    case UnlockableType.skybox:
                        {
                            skyboxlist.Add(item);
                            break;
                        }
                }
            }
        }
        // loading player record data
        // needs string manager in the scene
        string temp = PlayerPrefs.GetString(StringSystemManager.currentInstance.DistanceLoadSaveString, "0");

        if (ulong.TryParse(temp, out playerRecord)) Debug.Log("load player record successuly<<<<<<<<<"+playerRecord);
        else
        {
            Debug.Log("loading player record encounter error");
        }
    }
    

    public void ChoseTheCar()
    {
        if((ulong)carlist[carListIndex].minimumLevelToUnlock > playerRecord)
        {
            Debug.Log(" you can not chose this car \n low level problem");
        }
        else
        {
            sessionData.codeCar = carlist[carListIndex].unlockableObjectCode;
        }
    }

    private void FixedUpdate()
    {
        if (carPlatform != null)
        {
            carPlatform.Rotate(0, platformrotationSpeed, 0);
        }

    }



}
