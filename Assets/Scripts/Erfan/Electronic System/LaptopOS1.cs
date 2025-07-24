using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]

public class LaptopOS1 : MonoBehaviour
{
    #region Variables

    [Header("Color System")]
    [SerializeField] private Light[] colorOfDesk;
    [SerializeField] private string codeSaveColorDesk;
    [SerializeField] private Slider setIntensity;
    [SerializeField] private string codeSaveIntensity;
    
    [Header("Music System")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] musics;
    [SerializeField] private string codeSaveMusic;
    
    [Header("PowerSystem")]
    [SerializeField] private MeshRenderer meshRenderers;
    [SerializeField] private Material materialOn;
    [SerializeField] private Material materialOff;
    [SerializeField] private GameObject materialOnScreen;
    private Material[] materials;
    
    [Header("PowerSystem Tv")]
    [SerializeField] private MeshRenderer meshRenderersTv;
    [SerializeField] private Material materialOnTv;
    [SerializeField] private Material materialOffTv;
    private Material[] materialsTv;
    
    [Header("PowerSystem Tv2")]
    [SerializeField] private MeshRenderer meshRenderersTv2;
    [SerializeField] private Material materialOnTv2;
    [SerializeField] private Material materialOffTv2;
    private Material[] materialsTv2;
    
    #endregion

    #region Unity Functions

    private void Start()
    {
        LoadData();
        materials = meshRenderers.materials;
        materialsTv = meshRenderersTv.materials;
        TurnOffLaptop();
        TurnOffTv();
    }

    #endregion

    #region Buttons

    public void ChangeColor(int code)
    {
        foreach (var light1 in colorOfDesk)
        {
            switch (code)
            {
                case 0:
                    light1.color = Color.red;
                    break;
                case 1:
                    light1.color = Color.blue;
                    break;
                case 2:
                    light1.color = Color.green;
                    break;
                case 3:
                    light1.color = Color.magenta;
                    break;
            }
        }
        SaveData(codeSaveColorDesk, code, true);
    }
    
    public void ChangeIntensity()
    {
        foreach (var light1 in colorOfDesk)
        {
            light1.intensity = setIntensity.value;
        }
        
        SaveData(codeSaveIntensity,setIntensity.value);
    }

    public void TurnOnLaptop()
    {
        materials[8] = materialOn;
        meshRenderers.materials = materials;
        materialOnScreen.gameObject.SetActive(true);
    }
    
    

    public void TurnOffLaptop()
    {
        materials[8] = materialOff;
        meshRenderers.materials = materials;
        materialOnScreen.gameObject.SetActive(false);
    }
    
    public void TurnOnTv()
    {
        materialsTv[0] = materialOnTv;
        meshRenderersTv.materials = materialsTv;
    }
    
    public void TurnOffTv()
    {
        materialsTv[0] = materialOffTv;
        meshRenderersTv.materials = materialsTv;
    }
    
    
    #endregion

    #region Managers

    private void SaveData(string code, float value)
    {
        PlayerPrefs.SetFloat(code, value);
    }
    
    private void SaveData(string code, int value, bool intSet)
    {
        if (intSet)
        {
            PlayerPrefs.SetInt(code, value);
        }
        else
        {
            PlayerPrefs.SetFloat(code, value);
        }

    }

    private void LoadData()
    {
        ChangeColor( PlayerPrefs.GetInt(codeSaveColorDesk));
        foreach (var light1 in colorOfDesk)
        {
            light1.intensity = PlayerPrefs.GetFloat(codeSaveIntensity);
        }
    }

    #endregion
}
