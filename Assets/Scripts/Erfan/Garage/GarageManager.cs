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
    public bool panelState {  get; private set; }
    public GameObject panelGet { get; private set; }

    [Header("Cars")]
    [SerializeField] private GameObject[] cars;
    [SerializeField] private TMP_Text textCar;
    private int _carSelector;
    // shaere info
    

    
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadData();
        print(_carSelector);
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
        if (_carSelector > cars.Length )
        {
            _carSelector = cars.Length;
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
    #endregion
    
}
