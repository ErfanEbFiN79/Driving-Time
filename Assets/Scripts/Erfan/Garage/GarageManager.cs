using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GarageManager : MonoBehaviour
{

    public static GarageManager instance;
    
    #region Variables

    [Header("Base")]
    [SerializeField] private string nameGarage;
    
    [Header("Car Rotate Panel")] 
    [SerializeField] private GameObject rotatePanel;
    [SerializeField] private int speedRotate;
    [SerializeField] private bool handRota;
    [SerializeField] private int maxSpeedRotate;
    [SerializeField] private int minSpeedRotate;
    [SerializeField] private TMP_Text textSpeed;

    [Header("Info Panel")] 
    [SerializeField] private TMP_Text infoText;
    // new
    [SerializeField] private GameObject lockImage;
    
    public bool panelState {  get; private set; }
    public GameObject panelGet { get; private set; }

    [Header("Cars")]
    [SerializeField] private GameObject[] cars;
    [SerializeField] private TMP_Text textCar;
    private int _carSelector;
    // shaere info
    [Header("Save Data Info")]
    // Add by member 2
    [SerializeField] SessionDataSObase sessionData;
    [SerializeField] UnlockablesData_01[] unlockablesArray;
    [SerializeField] List<UnlockablesData_01> carlist, skyboxlist;
    [SerializeField] ulong playerRecord;
    [SerializeField] UnlockablesData_01[] unlockablesarray;

    [Header("VIP Manager")] 
    [SerializeField] private bool vip; //Need Change After
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        carlist = new List<UnlockablesData_01>();
        instance = this;
    }

    private void Start()
    {
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
        LoadData();
        ManageCarSelector();
        ManageUi();
    }

    void Update()
    {
        RotatePanelAction();
    }

    #endregion



    #region Buttons

    public void PlusSpeedRotate() => PlusSpeedRotateAction();
    public void DownSpeedRotate() => DownSpeedRotateAction();

    public void GoChangeCar() => GoChangeCarAction();
    public void BackChangeCar() => BackChangeCarAction();

    

    #endregion
    
    #region Actions

    private void RotatePanelAction()
    {
        if (!handRota)
        {
            rotatePanel.transform.Rotate(0,speedRotate*Time.deltaTime,0);
        }
    }

    private void PlusSpeedRotateAction()
    {
        if (speedRotate < maxSpeedRotate)
        {
            speedRotate++;
            textSpeed.text = speedRotate.ToString();
            SaveData();
            LoadData();
            ManageUi();
        }


    }

    private void DownSpeedRotateAction()
    {
        if (speedRotate > minSpeedRotate)
        {
            speedRotate--;
            textSpeed.text = speedRotate.ToString();
            SaveData();
            LoadData();
            ManageUi();
        }
    }
    


    
    #endregion

    private void GoChangeCarAction()
    {
        _carSelector++;
        if (_carSelector > 14 )
        {
            _carSelector = 14;
        }
        ManageCarSelector();
        SaveData();
        LoadData();
        ManageUi();
        
    }
    
    private void BackChangeCarAction()
    {
        _carSelector--;
        if (_carSelector < 0)
        {
            _carSelector = 0;
        }
        ManageCarSelector();
        SaveData();
        LoadData();
        ManageUi();

    }
    

    #region Manager


    private void ManageCarSelector()
    {
        textCar.text = _carSelector.ToString();

        for (int i = 0; i < cars.Length; i++)
        {
            if (i != _carSelector)
            {
                cars[i].SetActive(false);
            }
            else
            {
                cars[i].SetActive(true);
            }
        }
        
        ChoseTheCar();
    }

    private void ManageUi()
    {
        textCar.text = _carSelector.ToString();
        textSpeed.text = speedRotate.ToString();
    }

    #endregion

    #region Save and Load

    private void SaveData()
    {
        PlayerPrefs.SetInt(nameGarage + "LevelRotate", speedRotate);
        PlayerPrefs.SetInt(nameGarage + "CarCount", _carSelector);
    }

    private void LoadData()
    {

        speedRotate = PlayerPrefs.GetInt(nameGarage + "LevelRotate");
        _carSelector = PlayerPrefs.GetInt(nameGarage + "CarCount");
    }
    
    private void ChoseTheCar()
    {
        if (_carSelector > 14)
        {
            _carSelector = 14;
        }
        
        if (!carlist[_carSelector].needVip)
        {
            if((ulong)carlist[_carSelector].minimumLevelToUnlock > playerRecord)
            {
                lockImage.SetActive(true);
                Debug.Log(" you can not chose this car \n low level problem");
            }
            else
            {
                lockImage.SetActive(false);
                sessionData.codeCar = carlist[_carSelector].unlockableObjectCode;
            }
        }
        else
        {
            lockImage.SetActive(true);
            Debug.Log("You Need buy vip");
        }

    }
    #endregion
    
}
