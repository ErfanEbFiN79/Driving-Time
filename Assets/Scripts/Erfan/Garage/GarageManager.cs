using TMPro;
using UnityEngine;
public class GarageManager : MonoBehaviour
{

    public static GarageManager instance;
    
    #region Variables

    [Header("Panel")] 
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode key;
    [SerializeField] private string nameGarage;
    private bool weIn;
    
    
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
        panelGet = panel;
        LoadData();
        print(_carSelector);
        ManageCarSelector();
    }

    void Update()
    {
        RotatePanelAction();
        ManagePanelSystem();
        panelState = panel.activeInHierarchy;
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
        }

    }

    private void DownSpeedRotateAction()
    {
        if (speedRotate > minSpeedRotate)
        {
            speedRotate--;
            textSpeed.text = speedRotate.ToString();
        }
    }

    private void DeActivePanelAction()
    {
        panel.SetActive(false);
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
    }
    
    private void BackChangeCarAction()
    {
        _carSelector--;
        if (_carSelector < 0)
        {
            _carSelector = 0;
        }
        ManageCarSelector();

    }

    #region Find System

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadData();
            weIn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveData();
            weIn = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveData();
            weIn = true;
        }
    }
    
    #endregion

    #region Manager

    private void ManagePanelSystem()
    {
        if (weIn)
        {
            panel.SetActive(true);
            if (Input.GetKeyDown(key))
            {
                panel.SetActive(true);
            }
        }
        else
        {
            panel.SetActive(false);
            infoText.gameObject.SetActive(false);
        }
        
    }

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
