using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GarageManager : MonoBehaviour
{

    public static GarageManager instance;
    
    #region Variables

    [Header("Panel")] 
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode key;
    private bool weIn;
    
    
    [Header("Car Rotate Panel")] 
    [SerializeField] private GameObject rotatePanel;
    [SerializeField] private float speedRotate;
    [SerializeField] private bool handRota;
    [SerializeField] private int maxSpeedRotate;
    [SerializeField] private int minSpeedRotate;

    [Header("Info Panel")] 
    [SerializeField] private TMP_Text infoText;
    
    // shaere info
    public bool panelState {  get; private set; }
    public GameObject panelGet { get; private set; }
    
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        panelGet = panel;
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
    public void DeActivePanel() => DeActivePanelAction();

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
            print(speedRotate);
            speedRotate++;
        }

    }

    private void DownSpeedRotateAction()
    {
        if (speedRotate > minSpeedRotate)
        {
            print(speedRotate);
            speedRotate--;
        }
    }

    private void DeActivePanelAction()
    {
        panel.SetActive(false);
    }
    
    #endregion

    #region Find System

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weIn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weIn = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

    #endregion
    
}
